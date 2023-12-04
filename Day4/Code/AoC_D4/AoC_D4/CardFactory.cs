using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC_D4
{
    public class CardFactory
    {
        public ICard GetCard(string input)
        {
            var card = new Card();
            Regex regex = new Regex(@"Card\s+(\d+):([^\|]+)\|(.*)");
            Regex regex_digit = new Regex(@"\d+");
            var match = regex.Match(input);
            card.ID = ulong.Parse(match.Groups[1].Value);
            var required_numbers_string = match.Groups[2].Value;
            var my_numbers_string = match.Groups[3].Value;
            var matches = regex_digit.Matches(required_numbers_string);
            foreach(Match m in matches)
            {
                card.RequiredNumbers.Add(ulong.Parse(m.Value));
            }
            matches = regex_digit.Matches(my_numbers_string);
            foreach (Match m in matches)
            {
                card.MyNumbers.Add(ulong.Parse(m.Value));
            }
            return card;
        }

        public ICard GetCard_Old(string input)
        {
            var card = new Card();
            Regex regex = new Regex(@"Card\s+(\d+):\s+(\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+\|\s+(\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+(\d+)");
            Match match = regex.Match(input);
            for(int i = 1; i < match.Groups.Count; i++)
            {
                var val = ulong.Parse(match.Groups[i].Value);
                if (i <= 1)
                {
                    card.ID = val;
                }
                else if (i <= 1 + 5)
                {
                    card.RequiredNumbers.Add(val);
                }
                else if (i <= 1 + 5 + 8)
                {
                    card.MyNumbers.Add(val);
                }
                else
                {
                    throw new Exception("????");
                }
            }
            return card;
        }

        public List<ICard> GetCards(string[] input)
        {
            var cards = new List<ICard>();
            foreach (var s in input)
            {
                cards.Add(GetCard(s));
            }
            return cards;
        }
    }
}
