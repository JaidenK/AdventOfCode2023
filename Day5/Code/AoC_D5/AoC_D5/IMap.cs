using AoC_D5.MathUtil;
using System.Collections.Generic;

namespace AoC_D5
{
    public interface IMap
    {
        string Name { get; }
        List<IMapRange> Ranges { get; }

        long GetMappedValue(long value);
        List<ISpan> GetMappedValue(List<ISpan> seedSpans);
    }
}