using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AoC_D7_Tests
{
    [TestClass]
    public class ExampleInputTests
    {
        readonly string[] example_input =
        {
            "32T3K 765",
            "T55J5 684",
            "KK677 28",
            "KTJJT 220",
            "QQQJA 483"
        };

        [TestMethod]
        public void ExampleInput_E2E()
        {
            // Parse the input
            ISet set = SetFactory.ParseLines(example_input);
            // Sort by rank
            set.SortHands();
            // Calculate the winnings
            var winnings = set.ComputeWinnings();
            // Verify the output
            Assert.AreEqual(6440, winnings);

        }
    }
}
