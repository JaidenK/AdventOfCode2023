﻿using AoC_D7.Cards;
using AoC_D7;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AoC_D7.Combos;

namespace AoC_D7_Tests
{
    [TestClass]
    public class HandTests
    {
        [TestMethod]
        public void CardValueTests()
        {
            Assert.AreEqual(2, new Two().Strength);
            Assert.AreEqual(3, new Three().Strength);
            Assert.AreEqual(4, new Four().Strength);
            Assert.AreEqual(5, new Five().Strength);
            Assert.AreEqual(6, new Six().Strength);
            Assert.AreEqual(7, new Seven().Strength);
            Assert.AreEqual(8, new Eight().Strength);
            Assert.AreEqual(9, new Nine().Strength);
            Assert.AreEqual(10, new Ten().Strength);
            Assert.AreEqual(11, new Jack().Strength);
            Assert.AreEqual(12, new Queen().Strength);
            Assert.AreEqual(13, new King().Strength);
            Assert.AreEqual(14, new Ace().Strength);
        }

        [TestMethod]
        public void HandFactoryTest()
        {
            var hand1 = new HandFactory().BuildHand("A2345 123");
            var hand2 = new HandFactory().BuildHand("6789T 456");
            var hand3 = new HandFactory().BuildHand("JQKA2 789");
            Assert.IsNotNull(hand1);
            Assert.AreEqual(123, hand1.Bid);
            Assert.AreEqual(5, hand1.Cards.Count);
            Assert.IsInstanceOfType(hand1.Cards[0], typeof(Ace));
            Assert.IsInstanceOfType(hand1.Cards[1], typeof(Two));
            Assert.IsInstanceOfType(hand1.Cards[2], typeof(Three));
            Assert.IsInstanceOfType(hand1.Cards[3], typeof(Four));
            Assert.IsInstanceOfType(hand1.Cards[4], typeof(Five));

            Assert.AreEqual(456, hand2.Bid);
            Assert.IsInstanceOfType(hand2.Cards[0], typeof(Six));
            Assert.IsInstanceOfType(hand2.Cards[1], typeof(Seven));
            Assert.IsInstanceOfType(hand2.Cards[2], typeof(Eight));
            Assert.IsInstanceOfType(hand2.Cards[3], typeof(Nine));
            Assert.IsInstanceOfType(hand2.Cards[4], typeof(Ten));

            Assert.AreEqual(789, hand3.Bid);
            Assert.IsInstanceOfType(hand3.Cards[0], typeof(Jack));
            Assert.IsInstanceOfType(hand3.Cards[1], typeof(Queen));
            Assert.IsInstanceOfType(hand3.Cards[2], typeof(King));
            Assert.IsInstanceOfType(hand3.Cards[3], typeof(Ace));
            Assert.IsInstanceOfType(hand3.Cards[4], typeof(Two));
        }

        [TestMethod]
        public void ComboTests()
        {
            // Example input
            Assert.IsInstanceOfType(new HandFactory().BuildHand("32T3K 765").Combo, typeof(OnePair));
            Assert.IsInstanceOfType(new HandFactory().BuildHand("KK677 765").Combo, typeof(TwoPair));
            Assert.IsInstanceOfType(new HandFactory().BuildHand("KTJJT 765").Combo, typeof(TwoPair));
            Assert.IsInstanceOfType(new HandFactory().BuildHand("T55J5 765").Combo, typeof(ThreeOfAKind));
            Assert.IsInstanceOfType(new HandFactory().BuildHand("QQQJA 765").Combo, typeof(ThreeOfAKind));
            // Custom input
            Assert.IsInstanceOfType(new HandFactory().BuildHand("AAAAA 111").Combo, typeof(FiveOfAKind));
            Assert.IsInstanceOfType(new HandFactory().BuildHand("55555 111").Combo, typeof(FiveOfAKind));
            Assert.IsInstanceOfType(new HandFactory().BuildHand("3333Q 111").Combo, typeof(FourOfAKind));
            Assert.IsInstanceOfType(new HandFactory().BuildHand("JJ3JJ 111").Combo, typeof(FourOfAKind));
            Assert.IsInstanceOfType(new HandFactory().BuildHand("QQ333 111").Combo, typeof(FullHouse));
            Assert.IsInstanceOfType(new HandFactory().BuildHand("94949 111").Combo, typeof(FullHouse));
            Assert.IsInstanceOfType(new HandFactory().BuildHand("Q3Q4Q 111").Combo, typeof(ThreeOfAKind));
            Assert.IsInstanceOfType(new HandFactory().BuildHand("TTT98 111").Combo, typeof(ThreeOfAKind));
            Assert.IsInstanceOfType(new HandFactory().BuildHand("23432 111").Combo, typeof(TwoPair));
            Assert.IsInstanceOfType(new HandFactory().BuildHand("QQ339 111").Combo, typeof(TwoPair));
            Assert.IsInstanceOfType(new HandFactory().BuildHand("A23A4 111").Combo, typeof(OnePair));
            Assert.IsInstanceOfType(new HandFactory().BuildHand("QQ345 111").Combo, typeof(OnePair));
            Assert.IsInstanceOfType(new HandFactory().BuildHand("23456 111").Combo, typeof(HighCard));
            Assert.IsInstanceOfType(new HandFactory().BuildHand("Q2345 111").Combo, typeof(HighCard));
            // Example input (jokers)
            Assert.IsInstanceOfType(new HandFactory(usingJokers: true).BuildHand("32T3K 765").Combo, typeof(OnePair));
            Assert.IsInstanceOfType(new HandFactory(usingJokers: true).BuildHand("KK677 765").Combo, typeof(TwoPair));
            Assert.IsInstanceOfType(new HandFactory(usingJokers: true).BuildHand("KTJJT 765").Combo, typeof(FourOfAKind));
            Assert.IsInstanceOfType(new HandFactory(usingJokers: true).BuildHand("T55J5 765").Combo, typeof(FourOfAKind));
            Assert.IsInstanceOfType(new HandFactory(usingJokers: true).BuildHand("QQQJA 765").Combo, typeof(FourOfAKind));
            // Joker edge cases
            Assert.IsInstanceOfType(new HandFactory(usingJokers: true).BuildHand("JJJ34 111").Combo, typeof(FourOfAKind));
            Assert.IsInstanceOfType(new HandFactory(usingJokers: true).BuildHand("JJ234 111").Combo, typeof(ThreeOfAKind));
            Assert.IsInstanceOfType(new HandFactory(usingJokers: true).BuildHand("J2244 111").Combo, typeof(FullHouse));
        }

        [TestMethod]
        public void ComparisonTest_1()
        {
            // Example input
            var hand1 = new HandFactory().BuildHand("32T3K 765");
            var hand2 = new HandFactory().BuildHand("KK677 765");
            var hand3 = new HandFactory().BuildHand("KTJJT 765");
            var hand4 = new HandFactory().BuildHand("T55J5 765");
            var hand5 = new HandFactory().BuildHand("QQQJA 765");

            Assert.IsTrue(hand2.CompareTo(hand1) > 0);
            Assert.IsTrue(hand2.CompareTo(hand3) > 0);
            Assert.IsTrue(hand4.CompareTo(hand2) > 0);
            Assert.IsTrue(hand5.CompareTo(hand4) > 0);
        }
    }
}
