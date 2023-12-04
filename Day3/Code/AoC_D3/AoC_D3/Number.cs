using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC_D3
{
    public class Number : INode
    {
        public Number(int v)
        {
            this.Value = v;
        }

        public Number(Match match)
        {
            Col = match.Index;
            Value = int.Parse(match.Value);
            Width = match.Value.Length;
        }

        public int Row { get; set; }

        public int Col { get; private set; }

        public int Width { get; private set; }

        public int Value { get; private set; }

        public List<INode> Neighbors { get; private set; } = new List<INode>();

        public List<INode> AdjacentNumbers()
        {
            return Neighbors.Where(n => n is Number).ToList();
        }

        public List<INode> AdjacentSymbols()
        {
            return Neighbors.Where(n => n is Symbol).ToList();
        }
    }
}
