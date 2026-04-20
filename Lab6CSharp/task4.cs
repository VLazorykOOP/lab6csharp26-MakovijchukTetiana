using System;
using System.Collections; // Обов'язково для IEnumerable
using Lab6.Task1;         // Беремо клас Document із першого завдання

namespace Lab6.Task4
{
    class DocumentCollection : IEnumerable, IEnumerator
    {
        IDocument[] docs = new IDocument[]
        {
            new Bill("B-10", "Клієнт 1"),
            new Bill("B-11", "Клієнт 2")
        };
        
        int index = -1;

        // Реалізуємо інтерфейс IEnumerable
        public IEnumerator GetEnumerator()
        {
            return this;
        }

        // Реалізуємо інтерфейс IEnumerator
        public bool MoveNext()
        {
            if (index == docs.Length - 1)
            {
                Reset();
                return false;
            }
            index++;
            return true;
        }

        public void Reset()
        {
            index = -1;
        }

        public object Current
        {
            get { return docs[index]; }
        }
    }

    public static class Task4Runner
    {
        public static void Run()
        {
            Console.WriteLine("\n ЗАВДАННЯ 4");
            DocumentCollection collection = new DocumentCollection();

            Console.WriteLine("Перебір колекції через foreach:");
            foreach (IDocument d in collection)
            {
                d.Show(); // Працює завдяки IEnumerable/IEnumerator
            }
        }
    }
}