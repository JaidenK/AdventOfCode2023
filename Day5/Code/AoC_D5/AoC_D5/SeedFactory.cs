using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC_D5
{
    public class SeedFactory : ISeedFactory
    {
        public List<ISeed> ParseSeeds(string input)
        {
            var seeds = new List<ISeed>();
            MatchCollection matches = Regex.Matches(input, @"\d+");
            foreach (Match match in matches)
            {
                seeds.Add(new Seed(long.Parse(match.Value)));
            }
            return seeds;
        }
    }
}
