using AoC_D5.MathUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D5
{
    public class RangeAlmanac : IAlmanac
    {
        public List<ISeed> Seeds { get { return SeedRanges.AsSeeds(); } }

        public List<IMap> Maps { get; set; }
        List<ISeedRange> SeedRanges { get; set; }
        public RangeAlmanac(List<ISeedRange> seedRanges, List<IMap> maps)
        {
            this.SeedRanges = seedRanges;
            Maps = maps;
        }

        public List<long> GetLocations()
        {
            var locationSeedRanges = new List<ISpan>();
            foreach (var seedRange in SeedRanges)
            {
                locationSeedRanges.AddRange(seedRange.Location);
            }
            return locationSeedRanges.Select(s => s.Start).ToList();
            //return locationSeedRanges.AsSeeds().Select(s => s.Location).ToList();
        }

        public void MapSeeds()
        {
            foreach (var seedRange in SeedRanges)
            {
                seedRange.Map(Maps);
            }
        }
    }
}
