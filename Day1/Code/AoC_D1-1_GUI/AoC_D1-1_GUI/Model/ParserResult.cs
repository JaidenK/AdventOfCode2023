using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D1_1_GUI.Model
{
    internal class ParserResult : IParserResult
    {
        public int CalValue { get; private set; } = 0;

        public ParserResult(int calibration_value)
        {
            CalValue = calibration_value;
        }

    }
}
