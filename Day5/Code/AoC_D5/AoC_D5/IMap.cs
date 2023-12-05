using System.Collections.Generic;

namespace AoC_D5
{
    public interface IMap
    {
        string Name { get; }
        List<IMapRange> Ranges { get; }

        long GetMappedValue(long value);
        List<ISeedRange> GetMappedValue(List<ISeedRange> seedRanges);
    }
}