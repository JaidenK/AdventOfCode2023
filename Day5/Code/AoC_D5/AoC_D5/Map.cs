using AoC_D5.MathUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D5
{
    public class Map : IMap
    {
        public string Name { get; set; } = "";
        public List<IMapRange> Ranges { get; set; } = new List<IMapRange>();

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

        public List<ISpan> GetMappedValue(List<ISpan> seedSpans)
        {
            var unmappedSeedRanges = new List<ISpan>();
            var _unmappedSeedRanges = new List<ISpan>();
            foreach (var span in seedSpans)
            {
                unmappedSeedRanges.Add(new Span(span));
            }
            var mappedSeedRanges = new List<ISpan>();
            while(unmappedSeedRanges.Count > 0)
            {
                foreach (var seedRange in unmappedSeedRanges)
                {
                    bool didMappingOccur = false;
                    foreach (var range in Ranges)
                    {
                        var result = range.GetMappedValue(seedRange);
                        if(result.mapped is null)
                            continue;

                        didMappingOccur = true;
                        _unmappedSeedRanges.AddRange(result.unmappable);
                        mappedSeedRanges.Add(result.mapped);
                        if((result.unmappable.Sum(x => x.Length) +  result.mapped.Length) != seedRange.Length    )
                        {
                            throw new Exception("Bad math.");
                        }
                        break;
                        
                    }
                    if (!didMappingOccur)
                    {
                        mappedSeedRanges.Add(new Span(seedRange));
                    }
                }
                unmappedSeedRanges.Clear();
                foreach (var unmappedSeedRange in _unmappedSeedRanges)
                {
                    unmappedSeedRanges.Add(new Span(unmappedSeedRange));
                }
                _unmappedSeedRanges.Clear();
            }
            return mappedSeedRanges;
        }
    }
}
