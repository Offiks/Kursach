using Kursach.Classes;
using System;
using System.Collections.Generic;

namespace Kursach
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                Goods VacumCleaner = new VacuumСleaner("BOSCH", "BGC05AAA1", 3699, 10, 78, 6, 700);
                Goods Camera = new Camera("Canon", "PowerShots SX40 HS", 15999, 15, 12);
                Goods DSLR = new DSLR("Sony", "Alpha DSLR-A100 Kit", 23500, 10, 10, true, 4000);
                Goods Computer = new Computer("Custom Build", "Ultimate WorkStation", 94500, 10, "i9-14900K", 64, "RTX 4080 S");
                Goods Laptop = new Laptop("ASUS", "Vivobook 16X", 42000, 10, "i7-12700H", 16, "RTX 3050", 1.7, 10);

                Customer newCustomer = new Customer(50000);
                RegularCustomer regularCustomer = new RegularCustomer(50000, "Ivan", 0);


                Console.WriteLine(VacumCleaner);
                Console.WriteLine(Camera);
                Console.WriteLine(DSLR);
                Console.WriteLine(Computer);
                Console.WriteLine(Laptop);


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
