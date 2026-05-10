using Kursach.Classes;
using System;
using System.Collections.Generic;

namespace Kursach
{
    public class Program
    {
        static void Main()
        {

            //Листы, товары, покупатели по умолчанию
            List<Goods> GoodsList = new List<Goods>();
            List<Customer> CustomerList = new List<Customer>();

            GoodsList.Add(new VacuumСleaner("BOSCH", "BGC05AAA1", 3699, 10, 78, 6, 700));
            GoodsList.Add(new Camera("Canon", "PowerShots SX40 HS", 15999, 15, 12));
            GoodsList.Add(new DSLR("Sony", "Alpha DSLR-A100 Kit", 23500, 10, 10, true, 4000));
            GoodsList.Add(new Computer("Custom Build", "Ultimate WorkStation", 94500, 10, "i9-14900K", 64, "RTX 4080 S"));
            GoodsList.Add(new Laptop("ASUS", "Vivobook 16X", 42000, 10, "i7-12700H", 16, "RTX 3050", 1.7, 10));

            CustomerList.Add(new Customer(0));
            CustomerList.Add(new RegularCustomer(50000, "Ivan", 200000));
            CustomerList.Add(new RegularCustomer(23000, "Peter", 2000));
            CustomerList.Add(new RegularCustomer(1000000, "deBug", 10000000));

            Customer currentSessionCustomer = null;

            while (true)
            {
                if (currentSessionCustomer == null)
                {
                    Console.WriteLine("Вы постоянный клиент?");
                    Console.WriteLine("y - да, n - нет");

                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "n":
                            {
                                Console.WriteLine("Введите свой баланс");
                                
                                int CustomerBalance = int.Parse(Console.ReadLine());
                                
                                currentSessionCustomer = CustomerList[0];
                                CustomerList[0].Balance = CustomerBalance;

                                break;
                            }
                        case "y":
                            {
                                Console.WriteLine("Введите свое ФИО");
                                string cheakName = Console.ReadLine();

                                Customer foundCustomer = null;
                                for (int i = 1; i < CustomerList.Count; i++)
                                {
                                    RegularCustomer regularCustomer = (RegularCustomer)CustomerList[i];

                                    if (regularCustomer.Name == cheakName)
                                    {
                                        foundCustomer = CustomerList[i];
                                        currentSessionCustomer = foundCustomer;
                                        break;
                                    }
                                }

                                if (foundCustomer == null)
                                {
                                    Console.WriteLine("Покупатель с таким именем не найден");
                                }
                                break;
                            }
                    }
                }
                else
            {
                Console.Clear();
                Console.WriteLine("1 Просмотреть товары\n2 Просмотреть покупателей\n3 Добавить товар\n\n0 Выйти");
                Console.WriteLine("Выберите действие: ");

                int choicePage = int.Parse(Console.ReadLine());
                if (choicePage == 0) break;
                switch (choicePage)
                {
                    case 1:
                        {
                            while (true)
                            {
                                Console.Clear();
                                // Проверка что список не пуст 
                                for (int i = 0; i < GoodsList.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1} {GoodsList[i]}");
                                }
                                Console.WriteLine("Введите номер товара");
                                Console.WriteLine("Для выхода напишите 0");
                                int choiceGoods = int.Parse(Console.ReadLine()); // Проверку на коректность ввода
                                                                                 // Проверка на керектность ввода
                                if (choiceGoods == 0) break;

                            }
                            break;
                        }
                    case 2:
                        //Пока ничего не делает
                        //Надо сделать просморт постоянных покупателей
                        break;
                    case 3:
                        //Пока ничего не делает
                        //Надо сделать добавление товаров
                        break;
                    case 4:

                        break;
                    }
                }
            }
        }
    }
}
