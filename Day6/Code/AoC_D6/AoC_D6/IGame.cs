using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D6
{
    public interface IGame
    {
        long Time { get; }
        long Record { get; }

        int CountWinningStrategies();
        List<IStrategy> GetWinningStrategies(long threshold = -1);
    }
}
