using System;
using System.Collections.Generic;

namespace StatsCalcApp
{
    class Program
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Статистический калькулятор запущен");
            Console.ResetColor();

            bool working = true;

            while (working)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Ввести числа и посмотреть расчёты");
                Console.WriteLine("2. Завершить работу");
                Console.Write("Ваш выбор: ");

                string option = Console.ReadLine() ?? "";

                if (option == "1")
                {
                    // ввод
                    List<double> list = InputHelper.GetNumbersFromUser();

                    // расчёты
                    Statistics s = new Statistics(list);

                    // вывод результатов
                    OutputHelper.PrintTable(s);
                    OutputHelper.PrintHistogram(s);

                    // сохранение в файл
                    OutputHelper.SaveToFile(s, "statistics_results.txt");

                    Console.WriteLine("\nДанные записаны в файл statistics_results.txt");
                }
                else if (option == "2")
                {
                    working = false;
                }
                else
                {
                    Console.WriteLine("Такой команды нет, попробуйте снова.");
                }
            }

            Console.WriteLine("\nПрограмма закрыта. Спасибо, что использовали её.");
        }
    }
}
