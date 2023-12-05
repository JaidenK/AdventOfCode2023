using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D5
{
    public class Seed : ISeed
    {
        public long Value { get; set; }

        public long Soil => mappedValues.Count > 0 ? mappedValues[0] : -1;

        public long Fertilizer => mappedValues.Count > 1 ? mappedValues[1] : -1;

        public long Water => mappedValues.Count > 2 ? mappedValues[2] : -1;

        public long Light => mappedValues.Count > 3 ? mappedValues[3] : -1;

        public long Temperature => mappedValues.Count > 4 ? mappedValues[4] : -1;

        public long Humidity => mappedValues.Count > 5 ? mappedValues[5] : -1;

        public long Location => mappedValues.Count > 6 ? mappedValues[6] : -1;

        List<long> mappedValues = new List<long>();

        public Seed(long value)
        {
            Value = value;
        }

        public void Map(List<IMap> maps)
        {
            if (maps is null) return;
            if (maps.Count == 0) return;

            mappedValues.Clear();
            mappedValues.Add(maps[0].GetMappedValue(Value));
            for (int i = 1; i < maps.Count; i++)
            {
                mappedValues.Add(maps[i].GetMappedValue(mappedValues[i-1]));
            }
        }
    }
}
