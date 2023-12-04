using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC_D3
{
    public class Symbol : INode
    {
        public Symbol(char v)
        {
            this.Value = v;
        }

        public Symbol(Match match)
        {
            Col = match.Index;            
            Value = match.Value[0];
            Width = match.Value.Length;
        }

        public int Row { get; set; }

        public int Col { get; private set; }

        public int Width { get; private set; }

        public char Value { get; private set; }

        public List<INode> Neighbors { get; private set; } = new List<INode>();

        public List<INode> AdjacentNumbers()
        {
            throw new NotImplementedException();
        }

        public List<INode> AdjacentSymbols()
        {
            throw new NotImplementedException();
        }
    }
}
