using AoC_D5.MathUtil;
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

        public (ISeedRange mapped, List<ISeedRange> unmappable) GetMappedValue(ISeedRange seedRange)
        {
            var knife = new Span(this);
            var target = new Span(seedRange);
            var chopped = knife.GetOverlap(target);
            
            return 
            (
                (chopped.Overlap is null) 
                    ? null
                    : new SeedRange
                        (
                            GetMappedValue(chopped.Overlap.Start),
                            chopped.Overlap.Length
                        )
                ,
                chopped.Extra.Select(s => (ISeedRange)(new SeedRange(s))).ToList()
            );
        }

        // https://stackoverflow.com/questions/41185122/finding-overlapping-region-between-two-ranges-of-integers
        int FindOverlapping(int start1, int end1, int start2, int end2)
        {
            return Math.Max(0, Math.Min(end1, end2) - Math.Max(start1, start2) + 1);
        }


    }
}
