using AoC_D3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace AoC_D3_Tests
{
    [TestClass]
    public class UnitTest1
    {

        public void Test1_BuildNetwork()
        {
        }

        [TestMethod]
        public void ExampleInput_SkippedParsing()
        {
            #region building nodes
            // 467..114..
            // ...*......
            // ..35..633.
            // ......#...
            // 617*......
            // .....+.58.
            // ..592.....
            // ......755.
            // ...$.*....
            // .664.598..
            List<INode> nodes = new List<INode>();
            var n_467 = new Number(467); nodes.Add(n_467);
            var n_114 = new Number(114); nodes.Add(n_114);
            var s_1 = new Symbol('*'); nodes.Add(s_1);
            s_1.Neighbors.Add(n_467); n_467.Neighbors.Add(s_1);
            var n_35 = new Number(35); nodes.Add(n_35);
            n_35.Neighbors.Add(s_1); s_1.Neighbors.Add(n_35);
            var n_633 = new Number(633); nodes.Add(n_633);
            var s_2 = new Symbol('#'); nodes.Add(s_2);
            s_2.Neighbors.Add(n_633); n_633.Neighbors.Add(s_2);
            var n_617 = new Number(617); nodes.Add(n_617);
            var s_3 = new Symbol('*'); nodes.Add(s_3);
            s_3.Neighbors.Add(n_617); n_617.Neighbors.Add(s_3);
            var s_4 = new Symbol('+'); nodes.Add(s_4);
            var n_58 = new Number(58); nodes.Add(n_58);
            var n_592 = new Number(592); nodes.Add(n_592);
            n_592.Neighbors.Add(s_4); s_4.Neighbors.Add(n_592);
            var n_755 = new Number(755); nodes.Add(n_755);
            var s_5 = new Symbol('$'); nodes.Add(s_5);
            var s_6 = new Symbol('*'); nodes.Add(s_6);
            s_6.Neighbors.Add(n_755); n_755.Neighbors.Add(s_6);
            var n_664 = new Number(664); nodes.Add(n_664);
            n_664.Neighbors.Add(s_5); s_5.Neighbors.Add(n_664);
            var n_598 = new Number(598); nodes.Add(n_598);
            n_598.Neighbors.Add(s_6); s_6.Neighbors.Add(n_598);
            #endregion

            Assert.AreEqual(1, n_617.AdjacentSymbols().Count);
            Assert.AreEqual(1, n_633.AdjacentSymbols().Count);
            Assert.AreEqual(0, n_114.AdjacentSymbols().Count);

            Part1 part1 = new Part1();
            var sum = part1.GetAnswer(nodes);

            Assert.AreEqual(4361, sum);
        }

        [TestMethod]
        public void ExampleInput_End2End()
        {
            string[] input = new string[] {
                "467..114..",
                "...*......",
                "..35..633.",
                "......#...",
                "617*......",
                ".....+.58.",
                "..592.....",
                "......755.",
                "...$.*....",
                ".664.598..",
            };
            var factory = new NodeFactory();
            List<INode> nodes = factory.BuildFullGraph(input);

            Part1 part1 = new Part1();
            var sum = part1.GetAnswer(nodes);

            Assert.AreEqual(4361, sum);
        }

        [TestMethod]
        public void Test2_ParseLine()
        {
            string input = ".467..11..";
            var nodes = new NodeFactory().GetNodes(input);
            int nNumbers = nodes.Where(n => n is Number).Count();
            Assert.AreEqual(2, nNumbers);
            Assert.AreEqual(1, nodes[0].Col);
            Assert.AreEqual(3, nodes[0].Width);
            Assert.AreEqual(6, nodes[1].Col);
            Assert.AreEqual(2, nodes[1].Width);
        }

        [TestMethod]
        public void Test3_ParseLine()
        {
            string input = "+..|..";
            var nodes = new NodeFactory().GetNodes(input);
            int nSymbols = nodes.Where(n => n is Symbol).Count();
            Assert.AreEqual(2, nSymbols);
        }

        [TestMethod]
        public void Test4_ParseLine()
        {
            string input = "+..456..";
            var nodes = new NodeFactory().GetNodes(input);
            int nNumbers = nodes.Where(n => n is Symbol).Count();
            int nSymbols = nodes.Where(n => n is Symbol).Count();
            Assert.AreEqual(1, nNumbers);
            Assert.AreEqual(1, nSymbols);
        }

        [TestMethod]
        public void NeighborsTest_1()
        {
            string[] input = 
            {
                ".467..11+........",
                ".-..|......|.23.+",
                ".................",
                "..............+..",
            };

            //string input0 = ".467..11+........";
            //string input1 = ".-..|......|.23.+";
            //string input2 = ".................";
            //string input3 = "..............+..";
            var factory = new NodeFactory();
            //var nodes = new List<INode>();
            //nodes.AddRange(factory.GetNodes(input0, row: 0));
            //nodes.AddRange(factory.GetNodes(input1, row: 1));
            //nodes.AddRange(factory.GetNodes(input2, row: 2));
            //nodes.AddRange(factory.GetNodes(input3, row: 3));
            //factory.BuildGraph(nodes);

            List<INode> nodes = factory.BuildFullGraph(input);

            Assert.AreEqual(9, nodes.Count);

            var n_23 = nodes[6] as Number;
            Assert.AreEqual(23, n_23.Value);
            Assert.AreEqual(0, n_23.Neighbors.Count);

            var n_467 = nodes[0] as Number;
            Assert.AreEqual(467, n_467.Value);
            Assert.AreEqual(2, n_467.Neighbors.Count);
            Assert.AreEqual('-', (n_467.Neighbors[0] as Symbol).Value);
            Assert.AreEqual('|', (n_467.Neighbors[1] as Symbol).Value);
        }

        [TestMethod]
        public void Part2Example_End2End()
        {
            string[] input = new string[] {
                "467..114..",
                "...*......",
                "..35..633.",
                "......#...",
                "617*......",
                ".....+.58.",
                "..592.....",
                "......755.",
                "...$.*....",
                ".664.598..",
            };
            var factory = new NodeFactory();
            List<INode> nodes = factory.BuildFullGraph(input);

            Part1 part1 = new Part1();
            var sum = part1.GetAnswer(nodes);

            Assert.AreEqual(4361, sum);
        }
    }
}
