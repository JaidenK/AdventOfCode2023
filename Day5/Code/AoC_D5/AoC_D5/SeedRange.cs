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
            Value = new Span
            {
                Start = start,
                Length = length
            };
        }

        public SeedRange(ISeedRange range) : this(range.Value.Start, range.Value.Length)
        {
        }
        public SeedRange(ISpan span) : this(span.Start, span.Length)
        {
        }

        public ISpan Value { get; set; }

        public List<IMappedSpan> Soil => GetAllAtDepth(0);
        public List<IMappedSpan> Fertilizer => GetAllAtDepth(1);
        public List<IMappedSpan> Water => GetAllAtDepth(2);
        public List<IMappedSpan> Light => GetAllAtDepth(3);
        public List<IMappedSpan> Temperature => GetAllAtDepth(4);
        public List<IMappedSpan> Humidity => GetAllAtDepth(5);
        public List<IMappedSpan> Location => GetAllAtDepth(6);

        List<List<IMappedSpan>> mappedValues = new List<List<IMappedSpan>>();
        private List<IMappedSpan> GetAllAtDepth(int v)
        {
            if (v >= mappedValues.Count)
                return null;
            return mappedValues[v];
        }

        public void Map(List<IMap> maps)
        {
            if (maps is null) return;
            if (maps.Count == 0) return;

            mappedValues.Add(maps[0].GetMappedValue(new List<ISpan>() { new Span(Value) }));
            for (int i = 1; i < maps.Count; i++)
            {
                mappedValues.Add(maps[i].GetMappedValue(mappedValues[i - 1].Select(ms => ms.Span).ToList()));
            }
        }

        public override string ToString()
        {
            var s = $"Seed: {Value}";
            foreach (var mappedSpanList in mappedValues)
            {
                s += Environment.NewLine;
                s += "    ";
                foreach (var mappedSpan in mappedSpanList)
                {
                    s += " ";
                    s += mappedSpan.ToString();
                }
            }
            return s;
        }
    }
}
