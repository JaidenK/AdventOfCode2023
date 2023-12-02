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
