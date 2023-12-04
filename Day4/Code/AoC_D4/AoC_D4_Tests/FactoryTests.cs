using AoC_D4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AoC_D4_Tests
{
    [TestClass]
    public class FactoryTests
    {
        [TestMethod]
        public void CardFactory_Test1_Simple()
        {
            var card1 = new CardFactory().GetCard("Card 1: 1 2 3 | 2 3 4");
            var card2 = new Card
            {
                ID = 1,
                RequiredNumbers = new List<ulong> { 1, 2, 3 },
                MyNumbers = new List<ulong> { 2, 3, 4 }
            };
            Assert.IsTrue(card1.Equals(card2));
        }

        [TestMethod]
        public void CardFactory_Test2_Simple()
        {
            var card1 = new CardFactory().GetCard("Card 123: 456 789 123 | 159 483 267");
            var card2 = new Card
            {
                ID = 123,
                RequiredNumbers = new List<ulong> { 456, 789, 123 },
                MyNumbers = new List<ulong> { 159, 483, 267 }
            };
            Assert.IsTrue(card1.Equals(card2));
        }

        [TestMethod]
        public void CardFactory_Test3_Whitespace()
        {
            var card1 = new CardFactory().GetCard("Card 1:    1  2 3 | 2    3 4");
            var card2 = new Card
            {
                ID = 1,
                RequiredNumbers = new List<ulong> { 1, 2, 3 },
                MyNumbers = new List<ulong> { 2, 3, 4 }
            };
            Assert.IsTrue(card1.Equals(card2));
        }
    }
}
