using AoC_D7.Combos;
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
        readonly int bid;
        public int Bid => bid;

        readonly ReadOnlyCollection<ICard> cards;
        public ReadOnlyCollection<ICard> Cards => cards;

        readonly ICombo combo;
        public ICombo Combo => combo;

        public Hand(int bid, List<ICard> cards)
        {
            this.bid = bid;
            this.cards = cards.AsReadOnly();

            combo = new ComboFactory().CalculateCombo(cards);
        }

    }
}
