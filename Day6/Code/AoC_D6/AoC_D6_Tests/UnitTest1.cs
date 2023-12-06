using AoC_D6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC_D6_Tests
{
    [TestClass]
    public class UnitTest1
    {
        private List<IGame> BuildInputGames()
        {
            return new List<IGame>
            {
                new Game(time: 45, record: 305),
                new Game(time: 97, record: 1062),
                new Game(time: 72, record: 1110),
                new Game(time: 95, record: 1695),
            };
        }
        private List<IGame> BuildInputGames2()
        {
            return new List<IGame>
            {
                new Game(time: 45977295, record: 305106211101695),
            };
        }

        [TestMethod]
        public void TestMethod1()
        {
            IGame game = new Game(time: 7, record: 9);

            List<IStrategy> winningStrats = game.GetWinningStrategies();
            
            Assert.AreEqual(4, winningStrats.Count);

            Assert.AreEqual(2, winningStrats[0].HoldTime);
            Assert.AreEqual(10, winningStrats[0].Distance);

            Assert.AreEqual(3, winningStrats[1].HoldTime);
            Assert.AreEqual(12, winningStrats[1].Distance);

            Assert.AreEqual(4, winningStrats[2].HoldTime);
            Assert.AreEqual(12, winningStrats[2].Distance);

            Assert.AreEqual(5, winningStrats[3].HoldTime);
            Assert.AreEqual(10, winningStrats[3].Distance);
        }

        [TestMethod]
        public void Part1()
        {
            var games = BuildInputGames();
            var winningStrats = games.Select(x => x.GetWinningStrategies()).ToList();
            var product = 1;
            winningStrats.ForEach(x => product *= x.Count);
            Console.WriteLine($"Product of strat count (Part 1:): {product}");
        }

        [TestMethod]
        public void Part2()
        {
            var games = BuildInputGames2();
            var winningStrats = games.Select(x => x.GetWinningStrategies()).ToList();
            var product = 1;
            winningStrats.ForEach(x => product *= x.Count);
            Console.WriteLine($"Product of strat count (Part 2:): {product}");
        }
    }
}
