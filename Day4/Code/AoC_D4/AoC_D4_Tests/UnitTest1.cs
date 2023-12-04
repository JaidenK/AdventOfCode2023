using AoC_D4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AoC_D4_Tests
{    
    [TestClass]
    public class UnitTest1
    {
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
        public void ExampleInput_End2End()
        {
            string input = "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53";
            Card card = new CardFactory().GetCard(input);

            Assert.IsNotNull(card);
            Assert.IsTrue(1 == card.ID);
            Assert.AreEqual(5, card.RequiredNumbers.Count);
            Assert.IsTrue(41 == card.RequiredNumbers[0]);
            Assert.IsTrue(48 == card.RequiredNumbers[1]);
            Assert.IsTrue(83 == card.RequiredNumbers[2]);
            Assert.IsTrue(86 == card.RequiredNumbers[3]);
            Assert.IsTrue(17 == card.RequiredNumbers[4]);

            Assert.AreEqual(8, card.MyNumbers.Count);
            Assert.IsTrue(83 == card.MyNumbers[0]);
            Assert.IsTrue(86 == card.MyNumbers[1]);
            Assert.IsTrue( 6 == card.MyNumbers[2]);
            Assert.IsTrue(31 == card.MyNumbers[3]);
            Assert.IsTrue(17 == card.MyNumbers[4]);
            Assert.IsTrue( 9 == card.MyNumbers[5]);
            Assert.IsTrue(48 == card.MyNumbers[6]);
            Assert.IsTrue(53 == card.MyNumbers[7]);

            var winningNumbers = card.GetWinningNumbers();
            Assert.AreEqual(4, winningNumbers.Count);
            Assert.IsTrue(48 == winningNumbers[0]);
            Assert.IsTrue(83 == winningNumbers[1]);
            Assert.IsTrue(86 == winningNumbers[2]);
            Assert.IsTrue(17 == winningNumbers[3]);

            Assert.IsTrue(8 == card.GetPointValue());
        }

        [TestMethod]
        public void ExampleInput_End2End2()
        {
            string[] input =
            {
                "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
                "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
                "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
                "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
                "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
                "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11",
            };
            
            var sum = CardUtil.Sum(new CardFactory().GetCards(input));
            Assert.IsTrue(13 == sum);
        }
        [TestMethod]
        public void ExampleInput_Part2_End2End2()
        {
            string[] input =
            {
                "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
                "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
                "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
                "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
                "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
                "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11",
            };

            var cards = new CardFactory().GetCards(input);
            var sum = CardUtil.CountScratch(cards);
            Assert.AreEqual(30, sum);
        }

        [TestMethod]
        public void ExampleInput_Test1()
        {
            string[] input =
            {
                "Card 201: 71 92 68 45 33 17 99 32 96 93 | 90 82 79 26 20 85 94 61 31 84 73 30  4 87 29 28 81 27 75 39 36 58 97 98 21",                
            };
            var card = new CardFactory().GetCards(input)[0];
            Assert.IsTrue(card.RequiredNumbers.Contains(71));
            Assert.IsTrue(card.RequiredNumbers.Contains(93));
            Assert.IsTrue(card.MyNumbers.Contains(90));
            Assert.IsTrue(card.MyNumbers.Contains(21));
        }

        [TestMethod]
        public void MyTestMethod()
        {
            var card = new CardFactory().GetCard("Card 1: 1 2 3 | 4 5 6");
            Assert.IsTrue(0 == card.GetPointValue() );
        }
    }
}
