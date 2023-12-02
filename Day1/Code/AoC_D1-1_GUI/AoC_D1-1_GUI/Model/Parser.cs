using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D1_1_GUI.Model
{
    public class Parser : IParser
    {
        public IParserResult ParseLine(string input)
        {
            int firstDigit = -1;
            int lastDigit = -1;

            foreach (char c in input)
            {
                if (Char.IsDigit(c))
                {
                    int digit = int.Parse(c.ToString());
                    if (firstDigit < 0)
                    {
                        firstDigit = digit;
                    }
                    lastDigit = digit;
                }
            }

            int calibration_value = 10 * firstDigit + lastDigit;

            Console.WriteLine($"{input} -> {calibration_value}");

            return new ParserResult(calibration_value);
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
