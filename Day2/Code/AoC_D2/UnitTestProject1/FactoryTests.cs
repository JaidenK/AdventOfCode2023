using AoC_D2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class FactoryTests
    {
        [TestMethod]
        public void HandFactoryTest1()
        {
            string input = "3 blue, 4 red";
            var Factory = new HandFactory();
            var Handful = Factory.FromString(input);
            var Expected = new Handful { Blue = 3, Red = 4 };

            Assert.AreEqual(Expected.Red,   Handful.Red);
            Assert.AreEqual(Expected.Green, Handful.Green);
            Assert.AreEqual(Expected.Blue,  Handful.Blue);

        }
        [TestMethod]
        public void FactoryTest1()
        {
            string input = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";
            var Factory = new GameFactory();
            var Game = Factory.FromString(input);
            var ExpectedGame = new Game
            {
                ID = 1,
                Grabs = new List<Handful>
                {
                    new Handful { Blue = 3, Red = 4 },
                    new Handful { Red = 1, Green = 2, Blue = 6},
                    new Handful { Green = 2 }
                }
            };


            Assert.AreEqual(ExpectedGame.ID, Game.ID);
            Assert.AreEqual(ExpectedGame.Grabs[0].Red, Game.Grabs[0].Red);
            Assert.AreEqual(ExpectedGame.Grabs[0].Green, Game.Grabs[0].Green);
            Assert.AreEqual(ExpectedGame.Grabs[0].Blue, Game.Grabs[0].Blue);
            Assert.AreEqual(ExpectedGame.Grabs[1].Red,   Game.Grabs[1].Red);
            Assert.AreEqual(ExpectedGame.Grabs[1].Green, Game.Grabs[1].Green);
            Assert.AreEqual(ExpectedGame.Grabs[1].Blue,  Game.Grabs[1].Blue);
            Assert.AreEqual(ExpectedGame.Grabs[2].Red,   Game.Grabs[2].Red);
            Assert.AreEqual(ExpectedGame.Grabs[2].Green, Game.Grabs[2].Green);
            Assert.AreEqual(ExpectedGame.Grabs[2].Blue,  Game.Grabs[2].Blue);

        }
    }
}
