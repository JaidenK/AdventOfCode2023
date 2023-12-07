using AoC_D7.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D7
{
    public class CardFactory
    {
        internal ICard BuildCard(char letter)
        {
            switch(char.ToUpper(letter))
            {
                case 'A': return new Ace();
                case '2': return new Two();
                case '3': return new Three();
                case '4': return new Four();
                case '5': return new Five();
                case '6': return new Six();
                case '7': return new Seven();
                case '8': return new Eight();
                case '9': return new Nine();
                case 'T': return new Ten();
                case 'J': return new Jack();
                case 'Q': return new Queen();
                case 'K': return new King();
            }
            throw new Exception($"Invalid card: {letter}");
        }
    }
}
