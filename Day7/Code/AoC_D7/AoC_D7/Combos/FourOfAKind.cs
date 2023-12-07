using System.Collections.Generic;
using System.Linq;

namespace AoC_D7.Combos
{
    public class FourOfAKind : ICombo
    {
        public int Strength => 6;
        public bool ContainedIn(IReadOnlyCollection<ICard> cards)
        {
            var typeCounts = new ComboUtil().CountTypes(cards);

            return typeCounts.counts.Any(x => x >= 4);
        }
    }
}
