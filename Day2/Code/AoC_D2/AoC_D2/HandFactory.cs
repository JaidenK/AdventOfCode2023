using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC_D2
{
    public class HandFactory
    {
        public Handful FromString(string input)
        {
            Regex rx_red = new Regex(@"(\d+) red");
            Regex rx_green = new Regex(@"(\d+) green");
            Regex rx_blue = new Regex(@"(\d+) blue");

            int r = 0;
            int g = 0;
            int b = 0;

            var match = rx_red.Match(input);
            if (match.Success)
            {
                r = int.Parse(match.Groups[1].Value);
            }
            match = rx_green.Match(input);
            if (match.Success)
            {
                g = int.Parse(match.Groups[1].Value);
            }
            match = rx_blue.Match(input);
            if (match.Success)
            {
                b = int.Parse(match.Groups[1].Value);
            }

            return new Handful
            {
                Red = r,    
                Green = g,
                Blue = b,
            };
        }
    }
}
