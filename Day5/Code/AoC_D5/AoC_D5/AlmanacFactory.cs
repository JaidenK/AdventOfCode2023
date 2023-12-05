using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC_D5
{
    public class AlmanacFactory
    {
        public IAlmanac LoadAlamanac(string[] input, ISeedFactory seedFactory = null, bool useSeedRanges = false)
        {
            seedFactory = seedFactory ?? new SeedFactory();

            var seeds = new List<ISeed>();
            var maps = new List<IMapping>();

            for(long i = 0; i < input.Length; i++)
            {
                var line = input[i];
                if(line.Contains("seeds:"))
                {
                    seeds = seedFactory.ParseSeeds(line);
                    continue;
                }
                
                // Match the map name
                var match = Regex.Match(line, @"(\S+) map:");
                if(match.Success)
                {
                    var map_name = match.Groups[1].Value;
                    maps.Add(new Mapping { Name = map_name });
                    continue;
                }
                // Match a range
                match = Regex.Match(line, @"(\d+)\s+(\d+)\s+(\d+)");
                if(match.Success)
                {
                    var range = new Range
                    (
                        source:      long.Parse(match.Groups[2].Value),
                        destination: long.Parse(match.Groups[1].Value),
                        length:      long.Parse(match.Groups[3].Value)
                    );
                    maps.Last().Ranges.Add(range);
                }
            }

            if(useSeedRanges)
            {                
                return new RangeAlmanac(seeds.AsSeedRanges(), maps);
            }
            return new Almanac(seeds, maps);
        }
    }
}
