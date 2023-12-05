using AoC_D5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D5
{
    public interface ISeedRange
    {
        long Start { get; }
        long Length { get; }

        List<ISeedRange> Soil { get; }
        List<ISeedRange> Fertilizer { get; }
        List<ISeedRange> Water { get; }
        List<ISeedRange> Light { get; }
        List<ISeedRange> Temperature { get; }
        List<ISeedRange> Humidity { get; }
        List<ISeedRange> Location { get; }
        void Map(List<IMap> maps);
        List<ISeedRange> GetMappedValue(ISeedRange range);
    }

    public static class ListExtension
    {
        public static List<ISeed> AsSeeds(this List<ISeedRange> ranges)
        {
            var seeds = new List<ISeed>();
            foreach (var range in ranges)
            {
                seeds.Add(new Seed(range.Start));
                seeds.Add(new Seed(range.Length));
            }
            return seeds;
        }
        public static List<ISeedRange> AsSeedRanges(this List<ISeed> seeds)
        {
            var seedRanges = new List<ISeedRange>();
            for (int i = 0; i < seeds.Count; i += 2)
            {
                seedRanges.Add(new SeedRange(seeds[i].Value, seeds[i+1].Value));
            }
            return seedRanges;
        }
    }
}
