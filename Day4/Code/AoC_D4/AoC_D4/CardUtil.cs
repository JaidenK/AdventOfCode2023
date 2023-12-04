using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D4
{
    public class CardUtil
    {
        public static ulong Sum(List<Card> cards)
        {
            ulong sum = 0;
            foreach (var card in cards)
            {
                sum += card.GetPointValue();
            }
            return sum;
        }
    }
}
