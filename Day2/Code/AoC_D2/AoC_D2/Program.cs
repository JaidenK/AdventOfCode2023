using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filename = "input.txt";
            Handful load = new Handful { Red = 12, Green = 13, Blue = 14 };

            var bag = new ElfBag();
            bag.LoadGames(File.ReadAllLines(filename));
            int sum = bag.GetPossibleGames(load).Sum(x => x.ID);

            Console.WriteLine($"Sum of possible games: {sum}");
            Console.WriteLine();
            Console.WriteLine("press any key to continue...");
            Console.ReadKey();
        }
    }
}
