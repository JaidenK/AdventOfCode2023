using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D7.Cards
{
    public abstract class CardBase : ICard
    {
        public abstract int Strength { get; }
    }
}
