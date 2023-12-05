using AoC_D5.MathUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D5
{
    public class SeedRange : ISeedRange
    {
        public SeedRange(long start, long length)
        {
            Start = start;
            Length = length;
        }

        public SeedRange(ISeedRange range) : this(range.Start, range.Length)
        {
        }
        public SeedRange(ISpan span) : this(span.Start, span.Length)
        {
        }

        public long Start { get; set; }

        public long Length { get; set; }
        public List<ISeedRange> Soil => GetAllAtDepth(0);
        public List<ISeedRange> Fertilizer => GetAllAtDepth(1);
        public List<ISeedRange> Water => GetAllAtDepth(2);
        public List<ISeedRange> Light => GetAllAtDepth(3);
        public List<ISeedRange> Temperature => GetAllAtDepth(4);
        public List<ISeedRange> Humidity => GetAllAtDepth(5);
        public List<ISeedRange> Location => GetAllAtDepth(6);

        List<List<ISeedRange>> mappedValues = new List<List<ISeedRange>>();
        private List<ISeedRange> GetAllAtDepth(int v)
        {
            if (v >= mappedValues.Count)
                return null;
            return mappedValues[v];
        }

        public void Map(List<IMapping> maps)
        {
            if (maps is null) return;
            if (maps.Count == 0) return;

            mappedValues.Add(maps[0].GetMappedValue(new List<ISeedRange>() { new SeedRange(this)}));
            for (int i = 1; i < maps.Count; i++)
            {
                mappedValues.Add(maps[i].GetMappedValue(mappedValues[i-1]));
            }
        }

        public List<ISeedRange> GetMappedValue(ISeedRange range)
        {
            throw new NotImplementedException();
        }
    }
}
