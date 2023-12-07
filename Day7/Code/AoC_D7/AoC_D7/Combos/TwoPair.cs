using System.Collections.Generic;
using System.Linq;

namespace AoC_D7.Combos
{
    public class TwoPair : ICombo
    { 
        public int Strength => 3;

        public bool ContainedIn(IReadOnlyCollection<ICard> cards)
        {
            var typeCounts = new ComboUtil().CountTypes(cards);

            return typeCounts.counts.Where(x => x >= 2).Count() >= 2;
        }
    }
}
