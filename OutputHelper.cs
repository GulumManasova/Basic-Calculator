using System;
using System.Collections.Generic;
using System.IO;

namespace StatsCalcApp
{
    static class OutputHelper
    {
        public static void PrintTable(Statistics stats)
        {
            double mean = stats.Mean();
            double median = stats.Median();
            List<double> mode = stats.Mode();
            double range = stats.Range();
            double sd = stats.StandardDeviation();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n=== Statistics Results ===");
            Console.ResetColor();

            Console.WriteLine(new string('=', 50));
            Console.WriteLine("| Metric             | Value           |");
            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"| Mean               | {mean,14:F2} |");
            Console.WriteLine($"| Median             | {median,14:F2} |");
            Console.WriteLine($"| Mode               | {string.Join(", ", mode),14} |");
            Console.WriteLine($"| Range              | {range,14:F2} |");
            Console.WriteLine($"| Standard Deviation | {sd,14:F2} |");
            Console.WriteLine(new string('=', 50));
        }

        public static void PrintHistogram(Statistics stats)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nHistogram:");
            Console.ResetColor();

            double max = stats.Numbers.Max();
            foreach (var n in stats.Numbers)
            {
                int stars = (int)(n / max * 50); // нормализуем до 50 символов
                Console.Write($"{n,5:F2}: ");
                Console.WriteLine(new string('*', stars));
            }
        }

        public static void SaveToFile(Statistics stats, string filename)
        {
            double mean = stats.Mean();
            double median = stats.Median();
            List<double> mode = stats.Mode();
            double range = stats.Range();
            double sd = stats.StandardDeviation();

            using (StreamWriter sw = new StreamWriter(filename))
            {
                sw.WriteLine("=== Basic Statistics Calculator ===");
                sw.WriteLine("Введённые числа: " + string.Join(", ", stats.Numbers));
                sw.WriteLine($"Mean: {mean:F2}");
                sw.WriteLine($"Median: {median:F2}");
                sw.WriteLine("Mode: " + string.Join(", ", mode));
                sw.WriteLine($"Range: {range:F2}");
                sw.WriteLine($"Standard Deviation: {sd:F2}");
            }
        }
    }
}
