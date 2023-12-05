using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D5
{
    public class Mapping : IMapping
    {
        public string Name { get; set; } = "";
        public List<IRange> Ranges { get; set; } = new List<IRange>();

        public long GetMappedValue(long value)
        {
            foreach (var range in Ranges)
            {
                if (range.SourceContains(value))
                {
                    return range.GetMappedValue(value);
                }
            }
            return value;
        }
    }
}
