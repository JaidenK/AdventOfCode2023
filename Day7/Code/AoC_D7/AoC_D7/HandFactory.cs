using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC_D7
{
    public class HandFactory
    {
        public IHand BuildHand(string input)
        {
            var match = Regex.Match(input, @"(\S+) (\d+)");
            if (!match.Success)
                throw new Exception($"Failed to build Hand from: {input}");
            
            var cards = ParseCards(match.Groups[1].Value);
            var bid = int.Parse(match.Groups[2].Value);

            return new Hand(bid, cards);
        }

        private List<ICard> ParseCards(string cards_string)
        {
            var cardFactory = new CardFactory();
            var cards = new List<ICard>();
            foreach (var letter in cards_string)
            {
                cards.Add(cardFactory.BuildCard(letter));
            }
            return cards;
        }
    }
}
