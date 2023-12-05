using System.Collections.Generic;

namespace AoC_D5
{
    public interface ISeedFactory
    {
        List<ISeed> ParseSeeds(string input);
    }
}