using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D4
{
    public class CardUtil
    {
        public static int ScratchAndCount(List<ICard> cards)
        {
            int[] counts = new int[cards.Count];
            for (int i = 0; i < cards.Count; i++)
            {
                counts[i]++;
                var card = cards[i];
                var nWinningNos = card.GetWinningNumbers().Count;
                for (int j = 0; j < nWinningNos; j++)
                {
                    if((i + j + 1) < cards.Count)
                        counts[i + j + 1] += counts[i];
                }
            }
            return counts.Sum();
        }

        public static ulong SumPointValues(List<ICard> cards)
        {
            ulong sum = 0;
            foreach (var card in cards)
            {
                sum += card.PointValue;
            }
            return sum;
        }
    }
}
