using AoC_D2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void GetMinimumHandful()
        {
            GameFactory gameFactory = new GameFactory();

            string input = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";

            var Game = gameFactory.FromString(input);
            var minSet = Game.GetMinimumHand();

            var ExpectedGame = gameFactory.FromString("Game 1: 4 red, 2 green, 6 blue");

            Assert.AreEqual(ExpectedGame.ID, Game.ID);
            Assert.AreEqual(ExpectedGame.Grabs[0].Red, minSet.Red);
            Assert.AreEqual(ExpectedGame.Grabs[0].Green, minSet.Green);
            Assert.AreEqual(ExpectedGame.Grabs[0].Blue, minSet.Blue);
            Assert.AreEqual(48, minSet.Power);
        }

        [TestMethod]
        public void GetMinimumHandful2()
        {
            GameFactory gameFactory = new GameFactory();

            string input = "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red";

            var Game = gameFactory.FromString(input);
            var minSet = Game.GetMinimumHand();

            var ExpectedGame = gameFactory.FromString("Game 3: 20 red, 13 green, 6 blue");

            Assert.AreEqual(ExpectedGame.ID, Game.ID);
            Assert.AreEqual(ExpectedGame.Grabs[0].Red, minSet.Red);
            Assert.AreEqual(ExpectedGame.Grabs[0].Green, minSet.Green);
            Assert.AreEqual(ExpectedGame.Grabs[0].Blue, minSet.Blue);
            Assert.AreEqual(1560, minSet.Power);
        }
    }
}
