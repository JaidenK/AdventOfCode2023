using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D5
{
    public class Almanac : IAlmanac
    {
        public List<ISeed> Seeds { get; set; }
        public List<IMapping> Maps { get; set; }

        public Almanac(List<ISeed> seeds, List<IMapping> maps)
        {
            Seeds = seeds;
            Maps = maps;
        }

        public List<long> GetLocations()
        {
            return Seeds.Select(s => s.Location).ToList();
        }

        public void MapSeeds()
        {
            foreach (var seed in Seeds)
            {
                seed.Map(Maps);
            }
        }
    }
}
