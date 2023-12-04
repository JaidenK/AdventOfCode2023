using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D3
{
    public class Part2
    {
        public int GetAnswer(List<INode> Nodes)
        {
            List<Gear> valid_gears = Nodes.Where(n => n is Gear)
                                    .Cast<Gear>()
                                    .Where(n => n.HasValidNeighbors())
                                    .ToList();
            int sum = valid_gears.Sum(n => n.GetRatio());
            return sum;
        }
    }
}
