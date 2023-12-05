using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D5
{
    public interface IAlmanac
    {
        List<ISeed> Seeds { get; }
        //List<ISeedRange> SeedRanges { get; }
        List<IMapping> Maps { get; }

        void MapSeeds();
        List<long> GetLocations();
    }
}
