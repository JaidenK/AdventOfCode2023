using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D2
{
    public class Handful
    {
        public int Red { get; set; } = 0;
        public int Green { get; set; } = 0;
        public int Blue { get; set; } = 0;

        public bool IsPossible(Handful load1)
        {
            bool isPossible = true;

            isPossible &= (Red <= load1.Red);
            isPossible &= (Green <= load1.Green);
            isPossible &= (Blue <= load1.Blue);

            return isPossible; 
        }
    }
}
