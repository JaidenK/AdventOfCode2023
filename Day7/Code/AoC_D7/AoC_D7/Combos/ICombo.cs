using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D7.Combos
{
    public interface ICombo
    {
        int Strength { get; }
        bool ContainedIn(IReadOnlyCollection<ICombo> combo);
    }

    public class FiveOfAKind : ICombo
    { public int Strength => 7; }

    public class FourOfAKind : ICombo
    { public int Strength => 6; }

    public class FullHouse : ICombo
    { public int Strength => 5; }
    public class ThreeOfAKind : ICombo
    { public int Strength => 4; }

    public class TwoPair : ICombo
    { public int Strength => 3; }

    public class OnePair : ICombo
    { public int Strength => 2; }

    public class HighCard : ICombo
    { public int Strength => 1; }
}
