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
            var range = new Range
                        (
                            source: 10,
                            destination: 20,
                            length: 10
                        );
            var result = range.GetMappedValue(seed_range);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result[0].Count);
            Assert.AreEqual(10, result[0][0].Length);
            Assert.AreEqual(2, result[1].Count);
            Assert.AreEqual(5, result[1][0].Length);
            Assert.AreEqual(11, result[1][1].Length);
        }
        [TestMethod]
        public void Splitting_Test3()
        {
            var seed_range = new SeedRange(5, 5);
            var range = new Range
                        (
                            source: 100,
                            destination: 20,
                            length: 10
                        );
            var result = range.GetMappedValue(seed_range);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result[0].Count);
            Assert.AreEqual(1, result[1].Count);
            Assert.AreEqual(5, result[1][0].Length);
        }
        [TestMethod]
        public void Splitting_Test5()
        {
            var seed_range = new SeedRange(10, 10);
            var range = new Range
                        (
                            source: 5,
                            destination: 15,
                            length: 40
                        );
            var result = range.GetMappedValue(seed_range);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result[0].Count);
            Assert.AreEqual(10, result[0][0].Length);
            Assert.AreEqual(0, result[1].Count);
        }
        [TestMethod]
        public void Splitting_Test4()
        {
            var seed_range = new SeedRange(5, 15);
            var range = new Range
                        (
                            source: 10,
                            destination: 20,
                            length: 10
                        );
            var result = range.GetMappedValue(seed_range);

            Assert.AreEqual(20, result[0][0].Start);
            Assert.AreEqual(10, result[0][0].Length);
            Assert.AreEqual(5, result[1][0].Start);
            Assert.AreEqual(5, result[1][0].Length);
        }

        [TestMethod]
        public void Splitting_Test1()
        {
            var seed_range = new SeedRange(5, 15);
            var maps = new List<IMapping>()
            {
                new Mapping()
                {
                    Ranges = new List<IRange>()
                    {
                        new Range
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
