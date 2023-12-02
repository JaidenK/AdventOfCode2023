using AoC_D2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class HandfulTests
    {
        [TestMethod]
        public void Test1_IsPossible()
        {
            Handful draw = new Handful
            {
                Red = 5,
                Green = 5,
                Blue = 5
            };
            Handful load1 = new Handful
            {
                Red = 6,
                Green = 5,
                Blue = 5
            };
            Handful load2 = new Handful
            {
                Red = 5,
                Green = 5,
                Blue = 5
            };
            Handful load3 = new Handful
            {
                Red = 4,
                Green = 5,
                Blue = 5
            };
            Assert.IsTrue(draw.IsPossible(load1));
            Assert.IsTrue(draw.IsPossible(load2));
            Assert.IsFalse(draw.IsPossible(load3));
        }
    }
}
