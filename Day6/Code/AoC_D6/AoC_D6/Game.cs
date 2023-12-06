using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D6
{
    public class Game : IGame
    {
        public long Time { get; set; }
        public long Record { get; set; }

        public Game(long time, long record)
        {
            Time = time;
            Record = record;
        }

        public List<IStrategy> GetAllStrategies()
        {
            var strategies = new List<IStrategy>();
            for (long i = 0; i <= Time; i++)
            {
                strategies.Add(new Strategy(i, this));
            }
            return strategies;
        }
        public List<IStrategy> GetWinningStrategies(long threshold = -1)
        {
            if (threshold == -1) 
                threshold = Record;
            var strats = GetAllStrategies();

            return strats.Where(x => x.Distance > threshold).ToList();
        }
    }
}
