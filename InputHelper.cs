using System;
using System.Collections.Generic;

namespace StatsCalcApp
{
    static class InputHelper
    {
        public static List<double> GetNumbersFromUser()
        {
            while (true)
            {
                Console.Write("\nВведите числа через пробел: ");
                string input = Console.ReadLine() ?? "";
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                List<double> numbers = new List<double>();
                foreach (var t in tokens)
                {
                    if (double.TryParse(t, out double num))
                        numbers.Add(num);
                    else
                        Console.WriteLine($"Не удалось преобразовать '{t}' в число.");
                }

                if (numbers.Count > 0)
                    return numbers;
                else
                    Console.WriteLine("Попробуйте снова. Введите хотя бы одно число.");
            }
        }
    }
}
