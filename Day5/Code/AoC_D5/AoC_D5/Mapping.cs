using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D5
{
    public class Mapping : IMapping
    {
        public string Name { get; set; } = "";
        public List<IRange> Ranges { get; set; } = new List<IRange>();

        public long GetMappedValue(long value)
        {
            foreach (var range in Ranges)
            {
                if (range.SourceContains(value))
                {
                    return range.GetMappedValue(value);
                }
            }
            return value;
        }

        public List<ISeedRange> GetMappedValue(List<ISeedRange> valuesToMap)
        {
            var unmappedSeedRanges = new List<ISeedRange>();
            var _unmappedSeedRanges = new List<ISeedRange>();
            foreach (var seedRange in valuesToMap)
            {
                unmappedSeedRanges.Add(new SeedRange(seedRange));
            }
            var mappedSeedRanges = new List<ISeedRange>();
            while(unmappedSeedRanges.Count > 0)
            {
                foreach (var seedRange in unmappedSeedRanges)
                {
                    bool didMappingOccur = false;
                    foreach (var range in Ranges)
                    {
                        var mappedUnmapped = range.GetMappedValue(seedRange);
                        var mapped = mappedUnmapped[0];
                        var unmapped = mappedUnmapped[1];
                        if(unmapped.Count == 1)
                        {
                            if (unmapped[0].Length == seedRange.Length)
                                continue;
                        }
                        _unmappedSeedRanges.AddRange(unmapped);
                        mappedSeedRanges.AddRange(mapped);
                        didMappingOccur = true;
                        if((unmapped.Sum(x => x.Length) +  mapped.Sum(x => x.Length)) != seedRange.Length    )
                        {
                            throw new Exception("Bad math.");
                        }
                        break;
                        
                    }
                    if (!didMappingOccur)
                    {
                        mappedSeedRanges.Add(new SeedRange(seedRange));
                    }
                }
                unmappedSeedRanges.Clear();
                foreach (var unmappedSeedRange in _unmappedSeedRanges)
                {
                    unmappedSeedRanges.Add(new SeedRange(unmappedSeedRange));
                }
                _unmappedSeedRanges.Clear();
            }
            return mappedSeedRanges;
        }
    }
}
