using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D7.Combos
{
    internal class ComboFactory
    {
        public ICombo CalculateCombo(IReadOnlyCollection<ICard> cards)
        {
            var possibleCombos = new List<ICombo>
            {
                new FiveOfAKind(),
                new FourOfAKind(),
                new FullHouse(),
                new ThreeOfAKind(),
                new TwoPair(),
                new OnePair(),
                new HighCard(),
            };

            foreach (var combo in possibleCombos)
            {
                if(combo.ContainedIn(cards))
                    return combo;
            }

            throw new Exception("No combo found in cards.");
        }
    }
}
