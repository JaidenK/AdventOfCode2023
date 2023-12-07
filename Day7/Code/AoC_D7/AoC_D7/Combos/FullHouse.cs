using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC_D7.Combos
{
    public class FullHouse : ICombo
    {
        public int Strength => 5;

        public bool ContainedIn(IReadOnlyCollection<ICard> cards)
        {
            var typeCounts = new ComboUtil().CountTypes(cards);
            typeCounts.DistributeJokers();
            return typeCounts.counts.Any(x => x == 3)
                && typeCounts.counts.Any(x => x == 2);
        }
    }
}
