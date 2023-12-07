using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D7.Combos
{
    internal class ComboUtil
    {
        public (List<Type> types,List<int> counts) CountTypes(IReadOnlyCollection<ICard> cards)
        {
            List<Type> types = new List<Type>();
            List<int> counts = new List<int>();

            foreach (ICard card in cards)
            {
                var i = types.IndexOf(card.GetType());
                if (i >= 0)
                {
                    counts[i]++;
                }
                else
                {
                    types.Add(card.GetType());
                    counts.Add(1);
                }
            }

            return (types, counts);
        }
    }
}
