using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D7
{
    public class SetFactory
    {
        public static ISet ParseLines(string[] example_input, bool usingJokers = false)
        {
            var factory = new HandFactory(usingJokers: usingJokers);
            var hands = new List<IHand>();
            foreach (string line in example_input)
            {
                hands.Add(factory.BuildHand(line));
            }
            return new Set(hands);
        }
    }
}
