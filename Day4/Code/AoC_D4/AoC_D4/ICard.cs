using System;
using System.Collections.Generic;

namespace AoC_D4
{
    public interface ICard : IEquatable<ICard>
    {
        string OriginalInputString { get; }
        ulong ID { get; }
        List<ulong> MyNumbers { get; }
        List<ulong> RequiredNumbers { get; }

        ulong GetPointValue();
        List<ulong> GetWinningNumbers();
    }
}