using System;
using System.Collections.Generic;

namespace StatsCalcApp
{
    class Program
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=== Welcome to Basic Statistics Calculator ===");
            Console.ResetColor();

            bool running = true;

            while (running)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nMenu:");
                Console.ResetColor();
                Console.WriteLine("1. Ввести числа и рассчитать статистику");
                Console.WriteLine("2. Выйти");
                Console.Write("Выберите пункт меню: ");

                string choice = Console.ReadLine() ?? "";
                switch (choice)
                {
                    case "1":
                        List<double> numbers = InputHelper.GetNumbersFromUser();
                        Statistics stats = new Statistics(numbers);
                        OutputHelper.PrintTable(stats);
                        OutputHelper.PrintHistogram(stats);
                        OutputHelper.SaveToFile(stats, "statistics_results.txt");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("\nРезультаты сохранены в файл 'statistics_results.txt'");
                        Console.ResetColor();
                        break;
                    case "2":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор, попробуйте снова.");
                        break;
                }
            }

            Console.WriteLine("\nСпасибо за использование Statistics Calculator!");
        }
    }
}

