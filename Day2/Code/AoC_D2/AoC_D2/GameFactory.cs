using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC_D2
{
    public class GameFactory
    {
        public Game FromString(string input)
        {
            HandFactory factory = new HandFactory();
            Regex rx_game = new Regex(@"Game (\d+)");
            Regex rx_grabs = new Regex(@"[:;]([^;]*)");

            int id = -1;

            var game_match = rx_game.Match(input);
            if (game_match.Success)
            {
                id = int.Parse(game_match.Groups[1].Value);
            }

            List<Handful> grabs = new List<Handful>();  
            foreach(Match match in rx_grabs.Matches(input))
            {
                grabs.Add(factory.FromString(match.Groups[1].Value));
            }

            return new Game
            {
                ID = id,
                Grabs = grabs
            };
        }
    }
}
