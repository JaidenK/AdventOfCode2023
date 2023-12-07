using System.Collections.Generic;

namespace AoC_D7.Combos
{
    public class HighCard : ICombo
    { 
        public int Strength => 1;

        public bool ContainedIn(IReadOnlyCollection<ICard> cards)
        {
            return true;
        }
    }
}
