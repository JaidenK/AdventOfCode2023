﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            var cards = new CardFactory().GetCards(input);
            var sum = CardUtil.SumPointValues(cards);
            var sum2 = CardUtil.ScratchAndCount(cards);
            Console.WriteLine($"Total value (Part1): {sum}");
            Console.WriteLine($"Total count (Part2): {sum2}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
