using AoC_D7.Cards;
using AoC_D7;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
        public void TestMethod1()
        {
            // 32T3K 765
            //IHand hand = new Hand(bid: 765, cards: new ICard[] { new Three(), new Two(), new Ten(), new Three(), new King() });
        }
    }
}
