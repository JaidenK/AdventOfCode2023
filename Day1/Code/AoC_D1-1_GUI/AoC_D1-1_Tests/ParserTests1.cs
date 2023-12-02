using AoC_D1_1_GUI.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace AoC_D1_1_Tests
{
    [TestClass]
    public class ParserTests1
    {
        public static void BasicParserTest(IParser parser, string input, int expectedResult)
        {
            // Act
            IParserResult result = parser.ParseLine(input);
            int calVal = result.CalValue;

            // Verify
            Assert.AreEqual(expectedResult, calVal);
        }

        [TestMethod]
        public void Test1_Simple()
        {
            IParser parser = new Parser();
            BasicParserTest(parser, "1abc2", 12);
        }

        [TestMethod]
        public void Test2_2digitsInString()
        {
            IParser parser = new Parser();
            BasicParserTest(parser, "pqr3stu8vwx", 38);
        }

        [TestMethod]
        public void Test3_manyDigitsInString()
        {
            IParser parser = new Parser();
            BasicParserTest(parser, "a1b2c3d4e5f", 15);
        }

        [TestMethod]
        public void Test4_oneDigitInString()
        {
            IParser parser = new Parser();
            BasicParserTest(parser, "treb7uchet", 77);
        }

        [TestMethod]
        public void Test5_ParseManyLines()
        {
            // Arrange
            string[] input =
            {
                "1abc2",
                "pqr3stu8vwx",
                "a1b2c3d4e5f",
                "treb7uchet",
            };
            int expectedResult = 142;
            IParser parser = new Parser();

            // Act
            var result = parser.ParseLines(input);

            // Verify
            Assert.AreEqual(expectedResult, result.FullCalValue);

        }

        [TestMethod]
        public void AlphaTest1()
        {
            // These are all the same as the original tests
            IParser parser = new AlphaNumericParser();
            BasicParserTest(parser, "1abc2", 12);
            BasicParserTest(parser, "pqr3stu8vwx", 38);
            BasicParserTest(parser, "a1b2c3d4e5f", 15);
            BasicParserTest(parser, "treb7uchet", 77);
            // These are new
            BasicParserTest(parser,"two1nine",29);
            BasicParserTest(parser,"eightwothree",83);
            BasicParserTest(parser,"abcone2threexyz",13);
            BasicParserTest(parser,"xtwone3four",24);
            BasicParserTest(parser,"4nineeightseven2",42);
            BasicParserTest(parser,"zoneight234",14);
            BasicParserTest(parser,"7pqrstsixteen",76);
        }
    }
}
