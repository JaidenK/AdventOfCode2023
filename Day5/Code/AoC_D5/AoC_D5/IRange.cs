using System.Collections.Generic;

namespace AoC_D5
{
    public interface IRange
    {
        long Source { get; }
        long Destination { get; }
        long Length { get; }

        long GetMappedValue(long value);
        List<List<ISeedRange>> GetMappedValue(ISeedRange value);
        bool SourceContains(long value);
        bool DestinationContains(long value);
    }
}