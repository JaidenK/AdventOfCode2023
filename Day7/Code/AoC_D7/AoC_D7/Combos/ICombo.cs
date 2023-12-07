using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D7.Combos
{
    public interface ICombo
    {
        int Strength { get; }
        bool ContainedIn(IReadOnlyCollection<ICard> cards);
    }
}
