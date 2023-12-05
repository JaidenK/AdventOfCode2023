using System.Collections.Generic;

namespace AoC_D5
{
    public interface IMapRange
    {
        long Source { get; }
        long Destination { get; }
        long Length { get; }

        long GetMappedValue(long value);
        (ISeedRange mapped, List<ISeedRange> unmappable) GetMappedValue(ISeedRange value);
        bool SourceContains(long value);
        bool DestinationContains(long value);
    }
}