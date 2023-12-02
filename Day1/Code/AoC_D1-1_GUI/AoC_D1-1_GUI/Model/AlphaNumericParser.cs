using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC_D1_1_GUI.Model
{
    public class AlphaNumericParser : IParser
    {
        readonly Regex rx = new Regex(@"(one|two|three|four|five|six|seven|eight|nine|zero|\d)");

        public IParserResult ParseLine(string input)
        {
            input = input.Trim();
            if (input != input.ToLower())
            {
                var foo = 0;
            }
            input = input.ToLower();


            string firstDigit_s = null;
            string lastDigit_s = null;

            Match match = rx.Match(input);
            while (match.Success)
            {
                if(firstDigit_s is null)
                {
                    firstDigit_s = match.Value;
                }
                lastDigit_s = match.Value;
                match = rx.Match(input, match.Index + 1);
            }

            if (firstDigit_s is null)
            {
                return new ParserResult(0); // This is where we would put an error status if we had one
            }

            int firstDigit = stringToDigitValue(firstDigit_s);
            int lastDigit = stringToDigitValue(lastDigit_s);

            int calibration_value = 10 * firstDigit + lastDigit;

            Console.WriteLine($"{input} -> {calibration_value}");

            return new ParserResult(calibration_value);
        }

        private int stringToDigitValue(string firstDigit_s)
        {
            // Please don't write a switch statement like this
            switch (firstDigit_s)
            {
                case "0": return 0;
                case "1": return 1;
                case "2": return 2;
                case "3": return 3;
                case "4": return 4;
                case "5": return 5;
                case "6": return 6;
                case "7": return 7;
                case "8": return 8;
                case "9": return 9;
                case "zero": return 0;
                case "one": return 1;
                case "two": return 2;
                case "three": return 3;
                case "four": return 4;
                case "five": return 5;
                case "six": return 6;
                case "seven": return 7;
                case "eight": return 8;
                case "nine": return 9;
            };
            return 0;
        }

        public IFullParserResult ParseLines(string[] input)
        {
            List<IParserResult> Results = new List<IParserResult>();
            foreach (var s in input)
            {
                Results.Add(ParseLine(s));
            }
            return new FullParserResult(Results);
        }

    }
}
