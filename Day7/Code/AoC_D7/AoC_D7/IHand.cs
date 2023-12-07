using AoC_D7.Combos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D7
{
    public interface IHand
    {
        ReadOnlyCollection<ICard> Cards { get; }
        int Bid { get; }
        ICombo Combo { get; }
    }
}
