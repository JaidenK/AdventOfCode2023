using AoC_D5.MathUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D5
{
    public class MappedSpan : IMappedSpan
    {
        public ISpan Span { get; set; }
        public IMapRange MappedBy { get; set; }

        public MappedSpan(ISpan Span)
        {
            this.Span = Span;
        }
    }
}
