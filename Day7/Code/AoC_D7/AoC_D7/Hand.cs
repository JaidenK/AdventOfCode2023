using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D7
{
    public class Hand : IHand
    {
        private int bid;
        private ICard[] cards;

        public Hand(int bid, ICard[] cards)
        {
            this.bid = bid;
            this.cards = cards;
        }

        public ReadOnlyCollection<ICard> Cards => throw new NotImplementedException();
    }
}
