using System.Collections.Generic;

namespace AoC_D5
{
    public interface IMapping
    {
        string Name { get; }
        List<IRange> Ranges { get; }

        long GetMappedValue(long value);
    }
}