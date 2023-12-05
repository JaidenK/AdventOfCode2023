using AoC_D5;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC_D5_Tests
{
    [TestClass]
    public class ExampleInputTests
    {
        private readonly string[] full_example_input =
        {
            "seeds: 79 14 55 13",
            "",
            "seed-to-soil map:",
            "50 98 2",
            "52 50 48",
            "",
            "soil-to-fertilizer map:",
            "0 15 37",
            "37 52 2",
            "39 0 15",
            "",
            "fertilizer-to-water map:",
            "49 53 8",
            "0 11 42",
            "42 0 7",
            "57 7 4",
            "",
            "water-to-light map:",
            "88 18 7",
            "18 25 70",
            "",
            "light-to-temperature map:",
            "45 77 23",
            "81 45 19",
            "68 64 13",
            "",
            "temperature-to-humidity map:",
            "0 69 1",
            "1 0 69",
            "",
            "humidity-to-location map:",
            "60 56 37",
            "56 93 4",
        };

        [TestMethod]
        public void ExampleInput_End2End()
        {
            IAlmanac almanac = new AlmanacFactory().LoadAlamanac(full_example_input);
            almanac.MapSeeds();
            var lowest = almanac.GetLocations().Min();
            Assert.AreEqual(35, lowest);
        }

        [TestMethod]
        public void ExampleInput_Part2_End2End()
        {
            var factory = new SeedFactory_SimpleRanges();
            IAlmanac almanac = new AlmanacFactory().LoadAlamanac(full_example_input, factory);
            almanac.MapSeeds();
            var lowest = almanac.GetLocations().Min();
            Assert.AreEqual(46, lowest);
        }

        [TestMethod]
        public void ExampleInput_Part2_End2End_2()
        {
            RangeAlmanac almanac = (RangeAlmanac)(new AlmanacFactory().LoadAlamanac(full_example_input, useSeedRanges:true));
            almanac.MapSeeds();
            var lowest = almanac.GetLocations().Min();
            Assert.AreEqual(46, lowest);
            Console.WriteLine(almanac.SeedRanges[0].ToString());
        }
    }
}
