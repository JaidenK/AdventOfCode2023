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

        public int CompareTo(IHand other)
        {
            var comboComparison =  combo.Strength - other.Combo.Strength;
            if (comboComparison != 0)
                return comboComparison;            
            for(int i = 0; i < cards.Count; i++)
            {
                if (cards[i].Strength != other.Cards[i].Strength)
                    return cards[i].Strength - other.Cards[i].Strength;
            }
            return 0;
        }
    }
}
