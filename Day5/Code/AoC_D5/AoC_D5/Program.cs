using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            IAlmanac almanac = new AlmanacFactory().LoadAlamanac(input);
            almanac.MapSeeds();
            var lowest = almanac.GetLocations().Min();

            Console.WriteLine($"Lowest location for all seeds (Part 1): {lowest}");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
