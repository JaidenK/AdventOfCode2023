using AoC_D5.MathUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D5.MathUtil
{
    public class Span : ISpan
    {
        public long Start { get; set; }

        public long End
        {
            get => Start + Length - 1;
            set
            {
                Length = (value - Start) + 1;
            }
        }

        public long Length { get; set; }

        public Span()
        {
        }

        public Span(ISpan spanToClone)
        {
            Start = spanToClone.Start;
            End = spanToClone.End;
        }

        public Span(IMapRange range)
        {
            Start = range.Source;
            Length = range.Length;
        }

        public Span(ISeedRange seedRange)
        {
            Start = seedRange.Value.Start;
            Length = seedRange.Value.Length;
        }

        public bool Contains(long point)
        {

            return (point >= Start) && (point <= (End));
        }

        public (ISpan Overlap, List<ISpan> Extra) GetOverlap(ISpan target)
        {
            ISpan Overlap = null;
            List<ISpan> Extra = new List<ISpan>();

            bool hasOverlap = Contains(target.Start)
                           || Contains(target.End)
                           || target.Contains(Start)
                           || target.Contains(End);

            if (hasOverlap)
            {
                var lowerExtraLength = Start - target.Start;
                if (lowerExtraLength > 0)
                    Extra.Add(new Span { Start = target.Start, Length = lowerExtraLength });
                var upperExtraLength = target.End - End;
                if (upperExtraLength > 0)
                    Extra.Add(new Span { Start = End + 1, Length = upperExtraLength });

                Overlap = new Span
                {
                    Start = Contains(target.Start) ? target.Start : Start,
                    End = Contains(target.End) ? target.End : End
                };
            }
            else
            {
                Extra.Add(new Span(target));
            }

            return (Overlap, Extra);
        }
    }
}
