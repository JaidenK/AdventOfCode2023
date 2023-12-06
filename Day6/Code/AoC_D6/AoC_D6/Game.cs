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

        public static (double x1, double x2) SolveQuadraticFormula(double a, double b, double c)
        {
            double x1 = (-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
            double x2 = (-b - Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
            return (x1, x2);
        }

        public int CountWinningStrategies()
        {
            // Technically this returns the wrong answer 
            // if the winning strategy occurs between two
            // integers
            var a = -1;
            var b = Time;
            var epsilon = 0.001; // hack to reject solutions exactly equal to the record
            var c = -(Record+epsilon);
            var sol = SolveQuadraticFormula(a, b, c);
            sol.x1 = Math.Ceiling(sol.x1);
            sol.x2 = Math.Floor(sol.x2);
            return (int)((sol.x2 - sol.x1) + 1);
        }
    }
}
