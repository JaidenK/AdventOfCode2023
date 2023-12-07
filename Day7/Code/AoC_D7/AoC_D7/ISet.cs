using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D7
{
    public interface ISet
    {
        ReadOnlyCollection<IHand> Hands { get; }
        void SortHands();
        int ComputeWinnings();
    }
}
