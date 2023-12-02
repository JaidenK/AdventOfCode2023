using AoC_D1_1_GUI.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AoC_D1_1_Tests
{
    [TestClass]
    public class ParserTests1
    {
        [TestMethod]
        public void Test1_Simple()
        {
            // Arrange 
            string input = "1abc2";
            int expectedResult = 12;
            IParser parser = new Parser();

            // Act
            IParserResult result = parser.Parse(input);
            int calVal = result.CalValue;

            // Verify
            Assert.AreEqual(expectedResult, calVal);
        }

        [TestMethod]
        public void Test2_2digitsInString()
        {
            // Arrange 
            string input = "pqr3stu8vwx";
            int expectedResult = 38;
            IParser parser = new Parser();

            // Act
            IParserResult result = parser.Parse(input);
            int calVal = result.CalValue;

            // Verify
            Assert.AreEqual(expectedResult, calVal);
        }

        [TestMethod]
        public void Test3_manyDigitsInString()
        {
            // Arrange 
            string input = "a1b2c3d4e5f";
            int expectedResult = 15;
            IParser parser = new Parser();

            // Act
            IParserResult result = parser.Parse(input);
            int calVal = result.CalValue;

            // Verify
            Assert.AreEqual(expectedResult, calVal);
        }

        [TestMethod]
        public void Test4_oneDigitInString()
        {
            // Arrange 
            string input = "treb7uchet";
            int expectedResult = 77;
            IParser parser = new Parser();

            // Act
            IParserResult result = parser.Parse(input);
            int calVal = result.CalValue;

            // Verify
            Assert.AreEqual(expectedResult, calVal);
        }
    }
}
