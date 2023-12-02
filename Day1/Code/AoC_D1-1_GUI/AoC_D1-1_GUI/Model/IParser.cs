using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D1_1_GUI.Model
{
    public interface IParser
    {
        IParserResult ParseLine(string input);

        IFullParserResult ParseLines(string[] input);
    }
}
