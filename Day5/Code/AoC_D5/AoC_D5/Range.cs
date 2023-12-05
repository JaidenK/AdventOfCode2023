using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D5
{
    public class Range : IRange
    {
        public long Source {  get; set; }

        public long Destination { get; set; }

        public long Length { get; set; }

        public Range(long source, long destination, long length)
        {
            Source = source;
            Destination = destination;
            Length = length;
        }

        public long GetMappedValue(long value)
        {
            return value + (Destination - Source);
        }

        public bool SourceContains(long value)
        {
            return (value >= Source) && (value < (Source + Length));
        }

        public bool DestinationContains(long value)
        {
            return (value >= Destination) && (value < (Destination + Length));
        }
    }
}
