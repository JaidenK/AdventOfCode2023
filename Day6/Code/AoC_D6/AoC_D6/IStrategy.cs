using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D6
{
    public interface IStrategy
    {
        long HoldTime { get; }
        long Distance { get; }
        long Speed { get; }
    }
}
