using System;

namespace Lab6.Task2
{
    // Інтерфейс, який успадковує стандартний інтерфейс .NET
    public interface ISoftware : IComparable
    {
        string Title { get; set; }
        string Manufacturer { get; set; }
        void ShowInfo();
        bool IsUsable();
    }

    class FreeSoftware : ISoftware
    {
        public string Title { get; set; }
        public string Manufacturer { get; set; }

        public FreeSoftware(string t, string m) { Title = t; Manufacturer = m; }
        public void ShowInfo() => Console.WriteLine($"[Вільне ПЗ] {Title} від {Manufacturer}");
        public bool IsUsable() => true;
        public int CompareTo(object obj) => string.Compare(this.Title, ((ISoftware)obj).Title);
    }

    class SharewareSoftware : ISoftware
    {
        public string Title { get; set; }
        public string Manufacturer { get; set; }
        public DateTime InstallDate { get; set; }
        public int TermDays { get; set; }

        public SharewareSoftware(string t, string m, DateTime d, int days) { Title = t; Manufacturer = m; InstallDate = d; TermDays = days; }
        public void ShowInfo() => Console.WriteLine($"[Shareware] {Title} | Встановлено: {InstallDate.ToShortDateString()}");
        public bool IsUsable() => (DateTime.Today - InstallDate).Days <= TermDays;
        public int CompareTo(object obj) => string.Compare(this.Title, ((ISoftware)obj).Title);
    }

    class CommercialSoftware : ISoftware
    {
        public string Title { get; set; }
        public string Manufacturer { get; set; }
        public DateTime InstallDate { get; set; }
        public int UsageDays { get; set; }

        public CommercialSoftware(string t, string m, DateTime d, int days) { Title = t; Manufacturer = m; InstallDate = d; UsageDays = days; }
        public void ShowInfo() => Console.WriteLine($"[Комерційне] {Title} | Ліцензія на {UsageDays} днів");
        public bool IsUsable() => (DateTime.Today - InstallDate).Days <= UsageDays;
        public int CompareTo(object obj) => string.Compare(this.Title, ((ISoftware)obj).Title);
    }

    public static class Task2Runner
    {
        public static void Run()
        {
            Console.WriteLine("\n ЗАВДАННЯ 2 ");
            ISoftware[] software = new ISoftware[]
            {
                new CommercialSoftware("Office", "Microsoft", DateTime.Today.AddDays(-400), 365), // Прострочено
                new FreeSoftware("Linux", "Canonical"),
                new SharewareSoftware("WinRAR", "RAR LAB", DateTime.Today.AddDays(-10), 30) // Дійсне
            };

            Console.WriteLine("Повний список:");
            foreach (var s in software) s.ShowInfo();

            Console.WriteLine("\nПошук ПЗ, яке припустимо використовувати сьогодні:");
            foreach (var s in software)
            {
                if (s.IsUsable()) s.ShowInfo();
            }
        }
    }
}