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

        public List<IMappedSpan> GetMappedValue(List<ISpan> seedSpans)
        {
            var unmappedSeedSpans = new List<ISpan>();
            var _unmappedSeedRanges = new List<IMappedSpan>();
            var mappedSeedRanges = new List<IMappedSpan>();
            foreach (var span in seedSpans)
            {
                unmappedSeedSpans.Add(new Span(span));
            }
            while(unmappedSeedSpans.Count > 0)
            {
                foreach (var seedSpan in unmappedSeedSpans)
                {
                    bool didMappingOccur = false;
                    foreach (var range in Ranges)
                    {
                        var result = range.GetMappedValue(seedSpan);
                        if(result.mapped is null)
                            continue;

                        didMappingOccur = true;
                        _unmappedSeedRanges.AddRange(result.unmappable);
                        mappedSeedRanges.Add(result.mapped);
                        if((result.unmappable.Sum(x => x.Span.Length) +  result.mapped.Span.Length) != seedSpan.Length    )
                        {
                            throw new Exception("Bad math.");
                        }
                        break;
                        
                    }
                    if (!didMappingOccur)
                    {
                        mappedSeedRanges.Add(new MappedSpan(seedSpan));
                    }
                }
                unmappedSeedSpans.Clear();
                foreach (var unmappedSeedRange in _unmappedSeedRanges)
                {
                    unmappedSeedSpans.Add(new Span(unmappedSeedRange.Span));
                }
                _unmappedSeedRanges.Clear();
            }
            return mappedSeedRanges;
        }
    }
}
