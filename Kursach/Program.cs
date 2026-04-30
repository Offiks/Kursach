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
                List<Goods> goodsList = new List<Goods>
            {
                new Goods("CompanyA", "Product1", 100, 20),
                new Goods("CompanyB", "Product2", 200, 30),
                new Goods("CompanyC", "Product3", 300, 40)
            };

                Customer customer = new Customer(500);
                RegularCustomer regular = new RegularCustomer(500, "Ivan", 0);

                Console.WriteLine("Список товаров:");
                for (int i = 0; i < goodsList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {goodsList[i].Name} - {goodsList[i].Price}");
                }

                Console.Write("\nВыберите товар: ");
                int selected = int.Parse(Console.ReadLine());

                if (customer.Buy(goodsList[selected - 1], 10))
                {
                    goodsList.RemoveAt(selected - 1);
                    Console.WriteLine("Покупка успешна");
                }

                Console.WriteLine("Список товаров:");
                for (int i = 0; i < goodsList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {goodsList[i].Name} - {goodsList[i].Price}");
                }

                Console.Write("\nВыберите товар: ");
                selected = int.Parse(Console.ReadLine());

                if (regular.Buy(goodsList[selected - 1], 10))
                {
                    Console.WriteLine("Покупка успешна");
                }
                Console.WriteLine($"Обычный клиент: {customer.Balance}");
                Console.WriteLine($"Постоянный клиент: {regular.Balance}, {regular.Name}, {regular.TotalAmountSpent}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
