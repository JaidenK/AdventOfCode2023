using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D6
{
    public class Strategy : IStrategy
    {
        public long HoldTime { get; set; }
        public long Distance => Speed * (game.Time - HoldTime);
        public long Speed => HoldTime * 1;
        readonly IGame game;

        public Strategy(long holdTime, IGame game)
        {
            HoldTime = holdTime;
            this.game = game;
        }
    }
}
