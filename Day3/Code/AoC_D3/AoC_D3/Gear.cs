using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC_D3
{
    public class Gear : Symbol
    {
        public Gear(char v) : base(v)
        {
        }

        public Gear(Match match) : base(match)
        {
        }

        public bool HasValidNeighbors()
        {
            return (Neighbors.Where(n => n is Number).Count()) == 2;
        }

        public int GetRatio()
        {
            int product = 1;
            foreach (var node in Neighbors)
            {
                if (node is Number)
                {
                    product *= (node as Number).Value;
                }
            }
            return product;
        }
    }
}
