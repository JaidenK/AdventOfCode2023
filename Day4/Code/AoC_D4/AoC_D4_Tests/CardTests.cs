using AoC_D4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AoC_D4_Tests
{
    [TestClass]
    public class CardTests
    {

        [TestMethod]
        public void Card_PointValue_Test1()
        {
            var card = new CardFactory().GetCard("Card 1: 1 2 3 | 4 5 6");
            Assert.IsTrue(0 == card.GetPointValue());
        }

        [TestMethod]
        public void Card_GetWinningNumbers()
        {
            Card card = new Card
            {
                RequiredNumbers = new List<ulong> { 1, 2, 3, 7, 8 },
                MyNumbers = new List<ulong> { 2, 3, 4, 5, 8 },
            };
            var winningNumbers = card.GetWinningNumbers();
            Assert.IsTrue(3 == winningNumbers.Count);
            Assert.IsTrue(2 == winningNumbers[0]);
            Assert.IsTrue(3 == winningNumbers[1]);
            Assert.IsTrue(8 == winningNumbers[2]);
            Assert.IsTrue(4 == card.GetPointValue());
        }

        [TestMethod]
        public void Card_GetWinningNumbers_Factory()
        {
            var card = new CardFactory().GetCard("Card 1: 1 2 3 7 8 | 2 3 4 5 8");
            var winningNumbers = card.GetWinningNumbers();
            Assert.IsTrue(3 == winningNumbers.Count);
            Assert.IsTrue(2 == winningNumbers[0]);
            Assert.IsTrue(3 == winningNumbers[1]);
            Assert.IsTrue(8 == winningNumbers[2]);
            Assert.IsTrue(4 == card.GetPointValue());
        }

        [TestMethod]
        public void Card_Equality_Test1_Equal()
        {
            var card1 = new Card
            {
                ID = 1,
                RequiredNumbers = new List<ulong> { 1, 2, 3 },
                MyNumbers = new List<ulong> { 2, 3, 4 }
            };
            var card2 = new Card
            {
                ID = 1,
                RequiredNumbers = new List<ulong> { 1, 2, 3 },
                MyNumbers = new List<ulong> { 2, 3, 4 }
            };
            Assert.IsTrue(card1.Equals(card2));
        }

        [TestMethod]
        public void Card_Equality_Test2_ID()
        {
            var card1 = new Card
            {
                ID = 1,
                RequiredNumbers = new List<ulong> { 1, 2, 3 },
                MyNumbers = new List<ulong> { 2, 3, 4 }
            };
            var card2 = new Card
            {
                ID = 2,
                RequiredNumbers = new List<ulong> { 1, 2, 3 },
                MyNumbers = new List<ulong> { 2, 3, 4 }
            };
            Assert.IsFalse(card1.Equals(card2));
        }

        [TestMethod]
        public void Card_Equality_Test3_NumberOrder()
        {
            var card1 = new Card
            {
                ID = 1,
                RequiredNumbers = new List<ulong> { 1, 2, 3 },
                MyNumbers = new List<ulong> { 2, 3, 4 }
            };
            var card2 = new Card
            {
                ID = 2,
                RequiredNumbers = new List<ulong> { 1, 3, 2 }, // Order swapped
                MyNumbers = new List<ulong> { 2, 3, 4 }
            };
            Assert.IsFalse(card1.Equals(card2));
        }

        [TestMethod]
        public void Card_Equality_Test4_NumberLength()
        {
            var card1 = new Card
            {
                ID = 1,
                RequiredNumbers = new List<ulong> { 1, 2, 3 },
                MyNumbers = new List<ulong> { 2, 3, 4 }
            };
            var card2 = new Card
            {
                ID = 1,
                RequiredNumbers = new List<ulong> { 1, 2, 3, 4, 5, 6 },
                MyNumbers = new List<ulong> { 2, 3, 4 }
            };
            Assert.IsFalse(card1.Equals(card2));
        }
    }
}
