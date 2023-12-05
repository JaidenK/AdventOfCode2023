using System.Collections.Generic;

namespace AoC_D5
{
    public interface ISeed
    {
        long Value { get; }

        long Soil { get; }
        long Fertilizer { get; }
        long Water { get; }
        long Light { get; }
        long Temperature { get; }
        long Humidity { get; }
        long Location { get; }

        void Map(List<IMap> maps);
    }
}