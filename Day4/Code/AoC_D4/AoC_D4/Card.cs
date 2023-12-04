using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_D4
{
    public class Card : ICard
    {
        public ulong ID { get; set; }
        public List<ulong> RequiredNumbers { get; set; } = new List<ulong>();
        public List<ulong> MyNumbers { get; set; } = new List<ulong>();

        public bool Equals(ICard other)
        {
            if (ID != other.ID) return false;
            if (!RequiredNumbers.SequenceEqual(other.RequiredNumbers)) return false;
            if (!MyNumbers.SequenceEqual(other.MyNumbers)) return false;
            return true;
        }

        public ulong GetPointValue()
        {
            var winningNumbers = GetWinningNumbers();
            Console.WriteLine($"Card {ID} Winning Numbers: {String.Join(" ", winningNumbers)}");
            if (winningNumbers.Count == 0)
                return 0;
            return ((ulong)1) << (winningNumbers.Count - 1);
        }

        public List<ulong> GetWinningNumbers()
        {
            var WinningNumbers = new List<ulong>();
            foreach (var number in RequiredNumbers)
            {
                if (MyNumbers.Contains(number))
                    WinningNumbers.Add(number);
            }
            return WinningNumbers;
        }
    }
}
