using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC_D3
{
    public class NodeFactory
    {
        public List<INode> GetNodes(string input, int row = 0)
        {
            Regex rx_symbols = new Regex(@"[^\d^.^\s]");
            Regex rx_number = new Regex(@"\d+");
            var nodes = new List<INode>();
            var matches = rx_symbols.Matches(input);
            foreach (Match match in matches)
            {
                nodes.Add(new Symbol(match));
            }
            matches = rx_number.Matches(input);
            foreach (Match match in matches)
            {
                nodes.Add(new Number(match));
            }
            foreach(var node in nodes)
            {
                node.Row = row;
            }
            return nodes.OrderBy(n => n.Col).ToList();
        }

        /// <summary>
        /// Takes a list of nodes and builds the Neighbor
        /// lists based on Row, Col, and Width info.
        /// </summary>
        /// <param name="nodes"></param>
        public void BuildGraph(List<INode> nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                var node = nodes[i];
                for (int j = 0; j < nodes.Count; j++)
                {
                    var node2 = nodes[j];
                    if (node == node2)
                        continue;
                    if (Math.Abs(node2.Row - node.Row) > 1)
                        continue;
                    if (node.Col > (node2.Col + node2.Width))
                        continue;
                    if (node2.Col > (node.Col + node.Width))
                        continue;
                    node.Neighbors.Add(node2);
                    //node2.Neighbors.Add(node);
                }
            }
        }

        public List<INode> BuildFullGraph(string[] input)
        {
            var nodes = new List<INode>();            
            for(int i = 0; i < input.Length; i++)
            {
                nodes.AddRange(GetNodes(input[i], row: i));
            }
            BuildGraph(nodes);
            return nodes; 
        }
    }
}
