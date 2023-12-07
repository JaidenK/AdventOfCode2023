using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D7
{
    public class Set : ISet
    {
        private List<IHand> hands;
        public ReadOnlyCollection<IHand> Hands => hands.AsReadOnly();

        public Set(List<IHand> hands)
        {
            this.hands = hands;
        }

        public int ComputeWinnings()
        {
            SortHands();

            int sum = 0;
            for (int i = 0; i < hands.Count; i++)
            {
                sum += hands[i].Bid * (i + 1);
                //Console.WriteLine($"Sum: {sum} (+{hands[i].Bid}*{i+1})");
            }
            return sum;
        }

        public void SortHands()
        {
            hands.Sort();
        }
    }
}
