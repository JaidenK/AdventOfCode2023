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
            throw new NotImplementedException();
        }

        public void SortHands()
        {
            throw new NotImplementedException();
        }
    }
}
