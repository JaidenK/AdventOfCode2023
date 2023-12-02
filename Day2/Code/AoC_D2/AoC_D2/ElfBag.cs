using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D2
{
    public class ElfBag
    {
        public List<Game> Games { get; private set; } = new List<Game>();
        public List<Game> GetPossibleGames(Handful load)
        {
            List<Game> possibleGames = new List<Game>();
            foreach (Game game in Games)
            {
                if(game.IsPossible(load))
                {
                    possibleGames.Add(game);
                }
            }
            return possibleGames;
        }

        public void LoadGames(string[] input)
        {
            GameFactory factory = new GameFactory();
            
            Games.Clear();

            foreach(var s in input)
            {
                Games.Add(factory.FromString(s));
            }
        }
    }
}
