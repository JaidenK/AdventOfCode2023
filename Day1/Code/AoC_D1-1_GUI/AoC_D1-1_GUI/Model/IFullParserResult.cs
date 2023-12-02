using System.Collections.Generic;

namespace AoC_D1_1_GUI.Model
{
    public interface IFullParserResult
    {
        int FullCalValue { get; }
        List<IParserResult> Results { get; }
    }
}