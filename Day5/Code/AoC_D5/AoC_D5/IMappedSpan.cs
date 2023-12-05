using AoC_D5.MathUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D5
{
    public interface IMappedSpan
    {
        ISpan Span { get; }
        IMapRange MappedBy { get; }
    }
}
