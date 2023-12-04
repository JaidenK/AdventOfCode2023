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
            int sum = Nodes.Where(n => n is Number)
                           .Where(n => n.AdjacentSymbols().Count > 0)
                           .Sum(n => (n as Number).Value);
            return sum;
        }
    }
}
