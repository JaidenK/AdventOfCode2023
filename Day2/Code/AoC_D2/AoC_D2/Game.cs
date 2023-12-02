using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D2
{
    public class Game
    {
        public int ID { get; set; }
        public List<Handful> Grabs { get; set; }

        public Handful GetMinimumHand()
        {
            int minRed = 0;
            int minGreen = 0;                
            int minBlue = 0;

            foreach (Handful handful in Grabs)
            {
                minRed = Math.Max(minRed, handful.Red);
                minGreen = Math.Max (minGreen, handful.Green);
                minBlue = Math.Max(minBlue, handful.Blue);
            }

            return new Handful
            {
                Red = minRed,
                Green = minGreen,
                Blue = minBlue
            };
        }

        public bool IsPossible(Handful load)
        {
            bool isPossible = true;

            foreach (Handful handful in Grabs)
            {
                isPossible &= handful.IsPossible(load);     
            }

            return isPossible;
        }
    }
}
