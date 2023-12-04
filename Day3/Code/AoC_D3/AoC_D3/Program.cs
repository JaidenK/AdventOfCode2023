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
            Console.WriteLine($"Sum of part numbers (Part 1): {sum}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
