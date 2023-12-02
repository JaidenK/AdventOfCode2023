using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D1_1_GUI.Model
{
    public class FullParserResult : IFullParserResult
    {
        public List<IParserResult> Results { get; private set; }

        public int FullCalValue { get; private set; }

        public FullParserResult(List<IParserResult> Results)
        {
            this.Results = Results;
            FullCalValue = 0;
            foreach (var result in Results)
            {
                FullCalValue += result.CalValue;
            }
        }
    }
}
