using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Stopwatch sw = Stopwatch.StartNew();

            var input = File.ReadAllLines("input.txt");
            var t1 = sw.Elapsed;

            var set = SetFactory.ParseLines(input);
            var t2 = sw.Elapsed;
            var winnings = set.ComputeWinnings();
            var t3 = sw.Elapsed;
            Console.WriteLine($"Winnings (Part 1): {winnings}");

            set = SetFactory.ParseLines(input, usingJokers: true);
            var t4 = sw.Elapsed;
            winnings = set.ComputeWinnings();
            Console.WriteLine($"Winnings (Part 2): {winnings}");
            var t5 = sw.Elapsed;

            Console.WriteLine($"Opening file:\t\t{t1}");
            Console.WriteLine($"Part 1 parsing:\t\t{t2-t1}");
            Console.WriteLine($"Part 1 computing:\t{t3-t2}");
            Console.WriteLine($"Part 2 parsing:\t\t{t4-t3}");
            Console.WriteLine($"Part 2 computing:\t{t5-t4}");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
