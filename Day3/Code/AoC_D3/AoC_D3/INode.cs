using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D3
{
    public interface INode
    {
        int Row { get; set; }
        int Col { get; }
        int Width { get; }

        List<INode> Neighbors { get; }
        List<INode> AdjacentNumbers();
        List<INode> AdjacentSymbols();
    }
}
