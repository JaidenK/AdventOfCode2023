using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D5.MathUtil
{
    public interface ISpan
    {
        long Start { get; }
        long End { get; }
        long Length { get; }

        bool Contains(long point);
        (ISpan Overlap, List<ISpan> Extra) GetOverlap(ISpan target);
    }
}
