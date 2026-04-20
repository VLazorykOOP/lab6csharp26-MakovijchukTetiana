using System;

namespace Lab6.Task1
{
    
    // Базовий інтерфейс користувача, який успадковує .NET інтерфейс IComparable
    public interface IDocument : IComparable 
    {
        string DocNumber { get; set; }
        void Show(); // Інтерфейсний метод
    }

    // Другий інтерфейс користувача
    public interface IPrintable
    {
        void Print(); // Інтерфейсний метод
    }

    
    class Receipt : IDocument, IPrintable
    {
        public string DocNumber { get; set; }
        public double Amount { get; set; }

        public Receipt(string num, double amount) { DocNumber = num; Amount = amount; }
        
        // Реалізація інтерфейсних методів
        public void Show() => Console.WriteLine($"[Квитанція] №{DocNumber}, Сума: {Amount}");
        public void Print() => Console.WriteLine($"   [Друк інтерфейсу IPrintable] Друкується квитанція №{DocNumber}...");
        public int CompareTo(object obj) => string.Compare(this.DocNumber, ((IDocument)obj).DocNumber);
        
        // ОСОБИСТИЙ МЕТОД 
        public void Pay() => Console.WriteLine("  [Особистий метод] Квитанцію успішно оплачено.");
    }

    class Waybill : IDocument, IPrintable
    {
        public string DocNumber { get; set; }
        public int Count { get; set; }

        public Waybill(string num, int count) { DocNumber = num; Count = count; }
        
        // Реалізація інтерфейсних методів
        public void Show() => Console.WriteLine($"[Накладна] №{DocNumber}, Кількість: {Count}");
        public void Print() => Console.WriteLine($"   [Друк інтерфейсу IPrintable] Друкується накладна №{DocNumber}...");
        public int CompareTo(object obj) => string.Compare(this.DocNumber, ((IDocument)obj).DocNumber);
        
        // ОСОБИСТИЙ МЕТОД 
        public void Ship() => Console.WriteLine("  [Особистий метод] Товар за накладною відвантажено.");
    }

    class Bill : IDocument
    {
        public string DocNumber { get; set; }
        public string Payer { get; set; }

        public Bill(string num, string payer) { DocNumber = num; Payer = payer; }
        
        // Реалізація інтерфейсних методів
        public void Show() => Console.WriteLine($"[Рахунок] №{DocNumber}, Платник: {Payer}");
        public int CompareTo(object obj) => string.Compare(this.DocNumber, ((IDocument)obj).DocNumber);
        
        // ОСОБИСТИЙ МЕТОД 
        public void SendToBank() => Console.WriteLine("  [Особистий метод] Рахунок відправлено до банку.");
    }

    public static class Task1Runner
    {
        public static void Run()
        {
            Console.WriteLine(" ЗАВДАННЯ 1 ");

            // Створення об'єктів
            Receipt rec = new Receipt("R-01", 100.5);
            Waybill way = new Waybill("W-02", 50);
            Bill bill = new Bill("B-03", "Іванов І.І.");

            // 3. СТВОРЕННЯ МАСИВІВ (МНОЖИНА) ІНТЕРФЕЙСНИХ ПОСИЛАНЬ
            IDocument[] docArray = new IDocument[] { rec, way, bill };
            IPrintable[] printableArray = new IPrintable[] { rec, way }; // У Рахунка немає друку

            // 4. ДЛЯ ВСІХ ЕЛЕМЕНТІВ МАСИВІВ ВИКЛИКАТИ ІНТЕРФЕЙСНІ МЕТОДИ
            Console.WriteLine("\n1. Виклик методів для масиву IDocument:");
            foreach (IDocument doc in docArray)
            {
                doc.Show(); 
            }

            Console.WriteLine("\n2. Виклик методів для масиву IPrintable:");
            foreach (IPrintable p in printableArray)
            {
                p.Print();
            }

            Console.WriteLine("\n3. Виклик окремого методу для особистих методів (Type Pattern):");
            ProcessPersonalMethods(docArray);
        }

        // 5. НАПИСАТИ МЕТОД ЯКИЙ ДЛЯ КОЖНОГО ЕЛЕМЕНТУ МАСИВУ ВИВОДИТЬ ОСОБЛИВІ МЕТОДИ (TYPE PATTERN)
        static void ProcessPersonalMethods(IDocument[] array)
        {
            foreach (var item in array)
            {
                // Використання паттерну типу (switch з типами)
                switch (item)
                {
                    case Receipt r:
                        r.Pay();
                        break;
                    case Waybill w:
                        w.Ship();
                        break;
                    case Bill b:
                        b.SendToBank();
                        break;
                }
            }
        }
    }
}