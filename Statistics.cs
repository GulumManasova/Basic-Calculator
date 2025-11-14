using System;
using System.Collections.Generic;
using System.Linq;

namespace StatsCalcApp
{
    class Statistics
    {
        public List<double> Numbers { get; private set; }

        public Statistics(List<double> numbers)
        {
            Numbers = numbers;
        }

        public double Mean() => Numbers.Sum() / Numbers.Count;

        public double Median()
        {
            var sorted = Numbers.OrderBy(n => n).ToList();
            int count = sorted.Count;
            return count % 2 == 1
                ? sorted[count / 2]
                : (sorted[count / 2 - 1] + sorted[count / 2]) / 2;
        }

        public List<double> Mode()
        {
            var counts = Numbers.GroupBy(n => n)
                                .ToDictionary(g => g.Key, g => g.Count());

            int maxCount = counts.Values.Max();
            return counts.Where(pair => pair.Value == maxCount)
                         .Select(pair => pair.Key)
                         .ToList();
        }

        public double Range() => Numbers.Max() - Numbers.Min();

        public double StandardDeviation()
        {
            double mean = Mean();
            double sumSquares = Numbers.Sum(n => Math.Pow(n - mean, 2));
            return Math.Sqrt(sumSquares / Numbers.Count);
        }
    }
}
