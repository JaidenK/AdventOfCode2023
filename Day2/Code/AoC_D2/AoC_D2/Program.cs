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
            int sum_possible = bag.GetPossibleGames(load).Sum(x => x.ID);
            int sum_powers = bag.Games.Sum(x => x.GetMinimumHand().Power);

            Console.WriteLine($"Sum of possible games: {sum_possible}");
            Console.WriteLine($"Sum of smallest powers: {sum_powers}");
            Console.WriteLine();
            Console.WriteLine("press any key to continue...");
            Console.ReadKey();
        }
    }
}
