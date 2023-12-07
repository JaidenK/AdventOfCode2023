using AoC_D7.Cards;
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

    public static class CardListExtensions
    {
        public static int RemoveJokers(this (List<Type> types, List<int> counts) tuple)
        {
            var i = tuple.types.IndexOf(typeof(Joker));
            if (i >= 0)
            {
                var count = tuple.counts[i];
                tuple.types.RemoveAt(i);
                tuple.counts.RemoveAt(i);
                return count;
            }
            return 0;
        }
        public static void DistributeJokers(this (List<Type> types, List<int> counts) tuple)
        {
            var nJokers = tuple.RemoveJokers();
            // Find the max, add the jokers
            for (var i = 0; i < nJokers; i++)
            {
                var iMax = tuple.counts.IndexOf(tuple.counts.Max());
                tuple.counts[iMax]++;
            }
        }
    }
}
