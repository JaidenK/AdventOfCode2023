using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            var factory = new NodeFactory();
            List<INode> nodes = factory.BuildFullGraph(lines);
            Part1 part1 = new Part1();
            var sum = part1.GetAnswer(nodes);
            Part2 part2 = new Part2();
            var ratio_sum = part2.GetAnswer(nodes);
            Console.WriteLine($"Sum of part numbers (Part 1): {sum}");
            Console.WriteLine($"Sum of gear ratios (Part 2): {ratio_sum}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
