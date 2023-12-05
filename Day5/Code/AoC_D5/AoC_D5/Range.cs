using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D5
{
    public class Range : IRange
    {
        public long Source { get; set; }

        public long Destination { get; set; }

        public long Length { get; set; }

        public Range(long source, long destination, long length)
        {
            Source = source;
            Destination = destination;
            Length = length;
        }

        public long GetMappedValue(long value)
        {
            return value + (Destination - Source);
        }

        public bool SourceContains(long value)
        {
            return (value >= Source) && (value < (Source + Length));
        }

        public bool DestinationContains(long value)
        {
            return (value >= Destination) && (value < (Destination + Length));
        }

        public List<List<ISeedRange>> GetMappedValue(ISeedRange seedRange)
        {
            bool isInMapRange = true;
            var rangeEndVal = Source + (Length - 1);
            var seedRangeEndVal = seedRange.Start + (seedRange.Length - 1);



            var mappableSeedRanges = new List<ISeedRange>(); // Intersection
            var unmappableSeedRanges = new List<ISeedRange>(); // Exclusion
            var mappedSeedRanges = new List<ISeedRange>();

            var seedRangeToBuild = new SeedRange(0, 0);
            List<ISeedRange> listToAddTo = null;

            #region "state machine"
            int state = 0;
            // State 0: Looking for start
            // State 1: looking for overlap sta
            // State 2: looking for overlap end
            // State 3: looking for range end
            // State 4: Done
            if (Source == seedRange.Start)
            {
                isInMapRange = true;
                state = 2;
                seedRangeToBuild.Start = Source;
                listToAddTo = mappableSeedRanges;
            }
            else
            {
                seedRangeToBuild.Start = Math.Min(Source, seedRange.Start);
                isInMapRange = Source < seedRange.Start;
                if(!isInMapRange)
                {
                    listToAddTo = unmappableSeedRanges;
                }
                else
                {
                    listToAddTo = null;
                }
                state = 1;
            }

            // In one of the regions, looking for overlap start
            if (state == 1)
            {
                if (isInMapRange)
                {
                    var endVal = Math.Min(rangeEndVal, seedRange.Start);
                    seedRangeToBuild.Length = (endVal - seedRangeToBuild.Start);
                    if(endVal == rangeEndVal)
                    {
                        // Found gap between them
                        unmappableSeedRanges.Add(new SeedRange(seedRange));
                        listToAddTo = null;
                        state = 4;
                        isInMapRange = false;
                    }
                }
                else
                {
                    isInMapRange = true;
                    var endVal = Math.Min(seedRangeEndVal, Source);
                    seedRangeToBuild.Length = (endVal - seedRangeToBuild.Start);
                    if (endVal == seedRangeEndVal)
                    {
                        // Found gap between them
                        unmappableSeedRanges.Add(new SeedRange(seedRange));
                        listToAddTo = null;
                        state = 4;
                        isInMapRange = false;
                    }
                }
                if(state != 4)
                {
                    listToAddTo?.Add(seedRangeToBuild);
                    seedRangeToBuild = new SeedRange(seedRangeToBuild.Start + seedRangeToBuild.Length, 0);
                    state = 2;
                }
            }

            // In both of the regions, looking for overlap end
            if (state == 2)
            {
                if (rangeEndVal == seedRangeEndVal)
                {
                    isInMapRange = false;
                    state = 4;
                    seedRangeToBuild.Length = (seedRangeEndVal - seedRangeToBuild.Start) + 1;
                    mappableSeedRanges.Add(seedRangeToBuild);
                    // no more seedranges to build
                }
                else
                {
                    var endVal = Math.Min(seedRangeEndVal, rangeEndVal);
                    seedRangeToBuild.Length = (endVal - seedRangeToBuild.Start) + 1;
                    mappableSeedRanges.Add(seedRangeToBuild);
                    seedRangeToBuild = new SeedRange(endVal + 1, 0);
                    isInMapRange = seedRangeEndVal < rangeEndVal;
                    state = 3;
                }
            }

            // looking for range end
            if (state == 3)
            {
                if (isInMapRange)
                {
                    seedRangeToBuild.Length = (rangeEndVal - seedRangeToBuild.Start) + 1;
                    listToAddTo = null;
                }
                else
                {
                    seedRangeToBuild.Length = (seedRangeEndVal - seedRangeToBuild.Start) + 1;
                    unmappableSeedRanges.Add(seedRangeToBuild);
                }
                // No more ranges to build
                state = 4;
            }
            #endregion

            foreach(var mappableSeedRange in mappableSeedRanges)
            {
                mappedSeedRanges.Add(new SeedRange(GetMappedValue(mappableSeedRange.Start),mappableSeedRange.Length));
            }

            return new List<List<ISeedRange>> { mappedSeedRanges, unmappableSeedRanges };
        }

        // https://stackoverflow.com/questions/41185122/finding-overlapping-region-between-two-ranges-of-integers
        int FindOverlapping(int start1, int end1, int start2, int end2)
        {
            return Math.Max(0, Math.Min(end1, end2) - Math.Max(start1, start2) + 1);
        }


    }
}
