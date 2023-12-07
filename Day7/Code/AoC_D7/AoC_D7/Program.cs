using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            
            var set = SetFactory.ParseLines(input);
            var winnings = set.ComputeWinnings();
            Console.WriteLine($"Winnings (Part 1): {winnings}");
            
            set = SetFactory.ParseLines(input, usingJokers: true);
            winnings = set.ComputeWinnings();
            Console.WriteLine($"Winnings (Part 2): {winnings}");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
