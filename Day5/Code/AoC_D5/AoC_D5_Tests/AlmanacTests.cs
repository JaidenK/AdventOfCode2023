using AoC_D5;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AoC_D5_Tests
{
    [TestClass]
    public class AlmanacTests
    {
        [TestMethod]
        public void Almanac_Test1()
        {
            // Arrange
            var s1 = new Seed(5);
            var s2 = new Seed(9);
            var s3 = new Seed(55);
            var s4 = new Seed(49);
            var seeds = new List<ISeed> { s1, s2, s3, s4 };
            var maps = new List<IMap>
            {
                new Map
                {
                    Ranges = new List<IMapRange>
                    {
                        new MapRange(1,3,50)
                    }
                },
                new Map
                {
                    Ranges = new List<IMapRange>
                    {
                        new MapRange(10,25,5),
                        new MapRange(50,60,10)
                    }
                }

            };
            var almanac = new Almanac(seeds,maps);

            // Act
            almanac.MapSeeds();

            // Verify
            // Seed 1
            Assert.AreEqual(5, s1.Value);
            Assert.AreEqual(7, s1.Soil);
            Assert.AreEqual(7, s1.Fertilizer);
            Assert.AreEqual(-1, s1.Water);
            Assert.AreEqual(-1, s1.Light);
            Assert.AreEqual(-1, s1.Temperature);
            Assert.AreEqual(-1, s1.Humidity);
            Assert.AreEqual(-1, s1.Location);
            // Seed 2
            Assert.AreEqual(9,  s2.Value);
            Assert.AreEqual(11, s2.Soil);
            Assert.AreEqual(26, s2.Fertilizer);
            Assert.AreEqual(-1, s2.Water);
            Assert.AreEqual(-1, s2.Light);
            Assert.AreEqual(-1, s2.Temperature);
            Assert.AreEqual(-1, s2.Humidity);
            Assert.AreEqual(-1, s2.Location);
            // Seed 3
            Assert.AreEqual(55, s3.Value);
            Assert.AreEqual(55, s3.Soil);
            Assert.AreEqual(65, s3.Fertilizer);
            Assert.AreEqual(-1, s3.Water);
            Assert.AreEqual(-1, s3.Light);
            Assert.AreEqual(-1, s3.Temperature);
            Assert.AreEqual(-1, s3.Humidity);
            Assert.AreEqual(-1, s3.Location);
            // Seed 4
            Assert.AreEqual(49, s4.Value);
            Assert.AreEqual(51, s4.Soil);
            Assert.AreEqual(61, s4.Fertilizer);
            Assert.AreEqual(-1, s4.Water);
            Assert.AreEqual(-1, s4.Light);
            Assert.AreEqual(-1, s4.Temperature);
            Assert.AreEqual(-1, s4.Humidity);
            Assert.AreEqual(-1, s4.Location);
        }

        [TestMethod]
        public void Range_Test1_Contains()
        {
            var r1 = new MapRange(10, 15, 10);

            Assert.IsFalse(r1.SourceContains(9));
            Assert.IsTrue(r1.SourceContains(10));
            Assert.IsTrue(r1.SourceContains(19));
            Assert.IsFalse(r1.SourceContains(20));
            Assert.IsFalse(r1.DestinationContains(14));
            Assert.IsTrue (r1.DestinationContains(15));
            Assert.IsTrue (r1.DestinationContains(24));
            Assert.IsFalse(r1.DestinationContains(25));
        }

        [TestMethod]
        public void Range_Test2_Mapping_InRange()
        {
            var r1 = new MapRange(10, 15, 10);

            Assert.AreEqual(15, r1.GetMappedValue(10));
            Assert.AreEqual(20, r1.GetMappedValue(15));
            Assert.AreEqual(29, r1.GetMappedValue(24));
        }

        [TestMethod]
        public void Range_Test3_Mapping_OutOfRange()
        {
            var r1 = new MapRange(10, 15, 10);

            Assert.AreEqual(5, r1.GetMappedValue(0));
            Assert.AreEqual(70, r1.GetMappedValue(65));
        }
    }
}
