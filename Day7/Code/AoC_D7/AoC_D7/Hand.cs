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
        public int Bid => bid;

        private List<ICard> cards;
        public ReadOnlyCollection<ICard> Cards => cards.AsReadOnly();

        public Hand(int bid, List<ICard> cards)
        {
            this.bid = bid;
            this.cards = cards;
        }

    }
}
