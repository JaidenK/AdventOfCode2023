using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC_D5
{
    public class SeedFactory_SimpleRanges : ISeedFactory
    {
        public List<ISeed> ParseSeeds(string input)
        {
            var seeds = new List<ISeed>();
            MatchCollection matches = Regex.Matches(input, @"(\d+)\s+(\d+)");
            foreach (Match match in matches)
            {
                var start = long.Parse(match.Groups[1].Value);
                var length = long.Parse(match.Groups[2].Value);
                for(int i = 0; i < length; i++)
                {
                    seeds.Add(new Seed(start + i));
                }
            }
            return seeds;
        }
    }
}
