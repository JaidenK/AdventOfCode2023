using AoC_D7.Cards;
using System.Collections.Generic;
using System.Linq;

namespace AoC_D7.Combos
{
    public class FiveOfAKind : ICombo
    {
        public int Strength => 7;
        public bool ContainedIn(IReadOnlyCollection<ICard> cards)
        {
            var typeCounts = new ComboUtil().CountTypes(cards);
            var nJokers = typeCounts.RemoveJokers();
            return nJokers == 5 || typeCounts.counts.Any(x => x >= 5 - nJokers);
        }
    }
}
