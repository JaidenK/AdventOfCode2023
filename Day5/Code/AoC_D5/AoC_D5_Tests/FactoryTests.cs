using AoC_D5;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AoC_D5_Tests
{
    [TestClass]
    public class FactoryTests
    {
        [TestMethod]
        public void Factory_Test1_1Map()
        {
            string[] input =
            {
                "seeds: 79 14 55 13",
                "",
                "seed-to-soil map:",
                "50 98 2",
                "52 50 48",
            };
            
            var almanac = new AlmanacFactory().LoadAlamanac(input);

            Assert.AreEqual(1, almanac.Maps.Count);
            Assert.AreEqual("seed-to-soil", almanac.Maps[0].Name);

            Assert.AreEqual(2, almanac.Maps[0].Ranges.Count);

            Assert.AreEqual(98, almanac.Maps[0].Ranges[0].Source);
            Assert.AreEqual(50, almanac.Maps[0].Ranges[0].Destination);
            Assert.AreEqual(2, almanac.Maps[0].Ranges[0].Length);

            Assert.AreEqual(50, almanac.Maps[0].Ranges[1].Source);
            Assert.AreEqual(52, almanac.Maps[0].Ranges[1].Destination);
            Assert.AreEqual(48, almanac.Maps[0].Ranges[1].Length);
        }

        [TestMethod]
        public void Factory_LargeValueRange()
        {
            string[] input =
            {
                "seeds: 79 14 55 13",
                "",
                "seed-to-soil map:",
                "3583419145 395807984 258551722",
            };

            var almanac = new AlmanacFactory().LoadAlamanac(input);

            Assert.AreEqual(1, almanac.Maps.Count);
            Assert.AreEqual("seed-to-soil", almanac.Maps[0].Name);

            Assert.AreEqual(395807984, almanac.Maps[0].Ranges[0].Source);
            Assert.AreEqual(3583419145, almanac.Maps[0].Ranges[0].Destination);
            Assert.AreEqual(258551722, almanac.Maps[0].Ranges[0].Length);

        }

        [TestMethod]
        public void Factory_SeedsOnly()
        {
            string[] input =
            {
                "seeds: 79 14 55 13",
            };

            var almanac = new AlmanacFactory().LoadAlamanac(input);

            Assert.IsNotNull(almanac);

            Assert.AreEqual(0, almanac.Maps.Count);

            Assert.AreEqual(4, almanac.Seeds.Count);
            Assert.AreEqual(79, almanac.Seeds[0].Value);
            Assert.AreEqual(14, almanac.Seeds[1].Value);
            Assert.AreEqual(55, almanac.Seeds[2].Value);
            Assert.AreEqual(13, almanac.Seeds[3].Value);
        }
    }
}
