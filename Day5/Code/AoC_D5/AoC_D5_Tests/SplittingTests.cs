using AoC_D5;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AoC_D5_Tests
{
    [TestClass]
    public class SplittingTests
    {
        [TestMethod]
        public void Splitting_Test2()
        {
            var seed_range = new SeedRange(5, 26);
            var range = new MapRange
                        (
                            source: 10,
                            destination: 20,
                            length: 10
                        );
            var result = range.GetMappedValue(seed_range);
            Assert.IsNotNull(result.mapped);
            Assert.AreEqual(10, result.mapped.Length);
            Assert.AreEqual(2, result.unmappable.Count);
            Assert.AreEqual(5, result.unmappable[0].Length);
            Assert.AreEqual(11, result.unmappable[1].Length);
        }
        [TestMethod]
        public void Splitting_Test3()
        {
            var seed_range = new SeedRange(5, 5);
            var range = new MapRange
                        (
                            source: 100,
                            destination: 20,
                            length: 10
                        );
            var result = range.GetMappedValue(seed_range);
            Assert.IsNotNull(result);
            Assert.IsNull(result.mapped);
            Assert.AreEqual(1, result.unmappable.Count);
            Assert.AreEqual(5, result.unmappable[0].Length);
        }
        [TestMethod]
        public void Splitting_Test5()
        {
            var seed_range = new SeedRange(10, 10);
            var range = new MapRange
                        (
                            source: 5,
                            destination: 15,
                            length: 40
                        );
            var result = range.GetMappedValue(seed_range);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.mapped);
            Assert.AreEqual(10, result.mapped.Length);
            Assert.AreEqual(0, result.unmappable.Count);
        }
        [TestMethod]
        public void Splitting_Test4()
        {
            var seed_range = new SeedRange(5, 15);
            var range = new MapRange
                        (
                            source: 10,
                            destination: 20,
                            length: 10
                        );
            var result = range.GetMappedValue(seed_range);

            Assert.AreEqual(20, result.mapped.Start);
            Assert.AreEqual(10, result.mapped.Length);
            Assert.AreEqual(5, result.unmappable[0].Start);
            Assert.AreEqual(5, result.unmappable[0].Length);
        }

        [TestMethod]
        public void Splitting_Test1()
        {
            var seed_range = new SeedRange(5, 15);
            var maps = new List<IMap>()
            {
                new Map()
                {
                    Ranges = new List<IMapRange>()
                    {
                        new MapRange
                        (
                            source: 10,
                            destination: 20,
                            length: 10
                        )
                    }
                }
            };
            seed_range.Map(maps);
            Assert.AreEqual(2, seed_range.Soil.Count);
            // Order not guaranteed. Bad test.
            Assert.AreEqual(5, seed_range.Soil[1].Start);
            Assert.AreEqual(5, seed_range.Soil[1].Length);
            Assert.AreEqual(20, seed_range.Soil[0].Start);
            Assert.AreEqual(10, seed_range.Soil[0].Length);
        }
    }
}
