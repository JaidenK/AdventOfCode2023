using AoC_D7;
using AoC_D7.Cards;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading;

namespace AoC_D7_Tests
{
    [TestClass]
    public class ExampleInputTests
    {
        public readonly string[] example_input =
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

        [TestMethod]
        public void ExampleInput_NoParsing()
        {
            // Parse the input
            ISet set = new Set
            (
                new List<IHand>
                {
                    new Hand(bid: 765, cards: new List<ICard> { new Three(), new Two(),   new Ten(),   new Three(), new King() }),
                    new Hand(bid: 684, cards: new List<ICard> { new Ten(),   new Five(),  new Five(),  new Jack(),  new Five() }),
                    new Hand(bid: 28,  cards: new List<ICard> { new King(), new King(), new Six(), new Seven(), new Seven() }),
                    new Hand(bid: 220, cards: new List<ICard> { new King(), new Ten(), new Jack(), new Jack(), new Ten() }),
                    new Hand(bid: 483, cards: new List<ICard> { new Queen(), new Queen(), new Queen(), new Jack(), new Ace() }),
                }
            );
            // Sort by rank
            set.SortHands();
            // Calculate the winnings
            var winnings = set.ComputeWinnings();
            // Verify the output
            Assert.AreEqual(6440, winnings);
        }

        [TestMethod]
        public void ExamplePart2_E2E()
        {
            // Parse the input
            ISet set = SetFactory.ParseLines(example_input, usingJokers: true);
            // Sort by rank
            set.SortHands();
            // Calculate the winnings
            var winnings = set.ComputeWinnings();
            // Verify the output
            Assert.AreEqual(5905, winnings);
        }
    }
}
