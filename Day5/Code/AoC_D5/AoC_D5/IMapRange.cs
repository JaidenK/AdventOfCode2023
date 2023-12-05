using AoC_D5.MathUtil;
using System.Collections.Generic;

namespace AoC_D5
{
    public interface IMapRange
    {
        long Source { get; }
        long Destination { get; }
        long Length { get; }

        long GetMappedValue(long value);
        (ISpan mapped, List<ISpan> unmappable) GetMappedValue(ISpan value);
        bool SourceContains(long value);
        bool DestinationContains(long value);
    }
}