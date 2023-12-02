using AoC_D2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class ExampleInputTest
    {
        Handful load = new Handful
        {
            Red = 12,
            Green = 13,
            Blue = 14
        };

        Game game1 = new Game
        {
            ID = 1,
            Grabs = new List<Handful>
                {
                    new Handful { Blue = 3, Red = 4 },
                    new Handful { Red = 1, Green = 2, Blue = 6},
                    new Handful { Green = 2 }
                }
        };

        Game game2 = new Game
        {
            ID = 2,
            Grabs = new List<Handful>
                {
                    new Handful { Blue = 1, Green = 2 },
                    new Handful { Green = 3, Blue = 4, Red = 1},
                    new Handful { Green = 1, Blue = 1 }
                }
        };

        Game game3 = new Game
        {
            ID = 3,
            Grabs = new List<Handful>
                {
                    new Handful { Green = 8, Blue = 6, Red = 20 },
                    new Handful { Blue = 5, Red = 4, Green = 13},
                    new Handful { Green = 5, Red = 1}
                }
        };

        [TestMethod]
        public void Game1()
        {
            Assert.IsTrue(game1.IsPossible(load));
        }
        [TestMethod]
        public void Game2()
        {
            Assert.IsTrue(game2.IsPossible(load));
        }
        [TestMethod]
        public void Game3()
        {
            Assert.IsFalse(game3.IsPossible(load));
        }
        //[TestMethod]
        //public void Game4()
        //{
        //    //Assert.IsTrue(game4.IsPossible(load));
        //}
        //[TestMethod]
        //public void Game5()
        //{
        //    //Assert.IsTrue(game5.IsPossible(load));
        //}

        [TestMethod]
        public void ElfBagTest_SumPossible()
        {
            string[] input =
            {
                "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
                "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
                "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
                "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
                "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green",
            };

            ElfBag bag = new ElfBag();
            bag.LoadGames(input);
            List<Game> possibleGames = bag.GetPossibleGames(load);
            int sum = possibleGames.Sum(x => x.ID);

            Assert.AreEqual(8, sum);
        }

        [TestMethod]
        public void ElfBagTest_PowerMinimum()
        {
            string[] input =
            {
                "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
                "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
                "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
                "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
                "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green",
            };

            ElfBag bag = new ElfBag();
            bag.LoadGames(input);
            List<Game> possibleGames = bag.GetPossibleGames(load);
            int sum = bag.Games.Sum(x => x.GetMinimumHand().Power);

            Assert.AreEqual(2286, sum);
        }
    }
}
