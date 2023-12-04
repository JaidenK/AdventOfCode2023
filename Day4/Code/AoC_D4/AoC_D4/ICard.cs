using System;
using System.Collections.Generic;

namespace AoC_D4
{
    public interface ICard : IEquatable<ICard>
    {
        ulong ID { get; set; }
        List<ulong> MyNumbers { get; set; }
        List<ulong> RequiredNumbers { get; set; }

        ulong GetPointValue();
        List<ulong> GetWinningNumbers();
    }
}