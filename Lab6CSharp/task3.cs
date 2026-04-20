using System;

namespace Lab6.Task3
{
    [Serializable]
    public class MyException : ApplicationException
    {
        public MyException() { }
        public MyException(string message) : base(message) { }
        public MyException(string message, Exception ex) : base(message, ex) { }
        
        // Конструктор для серіалізації
        protected MyException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

    public static class Task3Runner
    {
        public static void Run()
        {
            Console.WriteLine("\n ЗАВДАННЯ 3 ");

            try
            {
                Console.WriteLine("Спроба згенерувати власний виняток...");
                throw new MyException("ПОМИЛКА: Неправильні дані документа!");
            }
            catch (MyException ex)
            {
                Console.WriteLine($"Перехоплено власний виняток: {ex.Message}");
            }

            try
            {
                Console.WriteLine("\nСпроба згенерувати IndexOutOfRangeException...");
                int[] arr = new int[2];
                arr[5] = 10; 
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Перехоплено системний виняток: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Блок finally виконано.");
            }
        }
    }
}