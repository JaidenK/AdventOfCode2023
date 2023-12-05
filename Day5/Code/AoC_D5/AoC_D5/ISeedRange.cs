using AoC_D5;
using AoC_D5.MathUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D5
{
    public interface ISeedRange
    {
        ISpan Value { get; }
        List<ISpan> Soil { get; }
        List<ISpan> Fertilizer { get; }
        List<ISpan> Water { get; }
        List<ISpan> Light { get; }
        List<ISpan> Temperature { get; }
        List<ISpan> Humidity { get; }
        List<ISpan> Location { get; }

        void Map(List<IMap> maps);
    }

    public static class ListExtension
    {
        public static List<ISeed> AsSeeds(this List<ISeedRange> seedRanges)
        {
            var seeds = new List<ISeed>();
            foreach (var seedRange in seedRanges)
            {
                seeds.Add(new Seed(seedRange.Value.Start));
                seeds.Add(new Seed(seedRange.Value.Length));
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
