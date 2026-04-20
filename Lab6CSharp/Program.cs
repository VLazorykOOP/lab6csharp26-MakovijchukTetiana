using System;
using Lab6.Task1;
using Lab6.Task2;
using Lab6.Task3;
using Lab6.Task4;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("  ЛАБОРАТОРНА РОБОТА №6 (МЕНЮ)");
                Console.WriteLine("1 - Завдання 1: Інтерфейси та Type Pattern (Документи)");
                Console.WriteLine("2 - Завдання 2: IComparable та Пошук (ПЗ)");
                Console.WriteLine("3 - Завдання 3: Обробка винятків (Exceptions)");
                Console.WriteLine("4 - Завдання 4: Перебір об'єктів (foreach/IEnumerator)");
                Console.WriteLine("0 - Вихід");
                Console.Write("Ваш вибір: ");

                switch (Console.ReadLine())
                {
                    case "1": Task1Runner.Run(); break;
                    case "2": Task2Runner.Run(); break;
                    case "3": Task3Runner.Run(); break;
                    case "4": Task4Runner.Run(); break;
                    case "0": exit = true; break;
                    default: Console.WriteLine("Помилка вибору!"); break;
                }
            }
        }
    }
}