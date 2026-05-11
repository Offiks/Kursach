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
            CustomerList.Add(new RegularCustomer(0, "Ivan", 200000));
            CustomerList.Add(new RegularCustomer(0, "Peter", 52000));
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
                                        Console.WriteLine("Введите свой баланс");
                                        int CustomerBalance = int.Parse(Console.ReadLine());
                                        foundCustomer.Balance = CustomerBalance;
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
                    if (currentSessionCustomer is RegularCustomer rc)
                    {
                        Console.WriteLine($"Вы авторизованны как {rc.Name}, баланс: {rc.Balance}, общия сумма трат: {rc.TotalAmountSpent}");
                    }
                    else
                    {
                        Console.WriteLine($"Вы авторизованы как гость, баланс: {currentSessionCustomer.Balance}");
                    }
                    Console.WriteLine("1 Просмотреть товары\n2 Просмотреть постоянных покупателей\n3 Добавить товар\n\n0 Выйти");
                    Console.WriteLine("Выберите действие: ");

                    int choicePage = int.Parse(Console.ReadLine());
                    if (choicePage == 0) break;
                    switch (choicePage)
                    {
                        // Просмотр товаров
                        case 1:
                            {

                                while (true)
                                {
                                    Console.Clear();
                                    // Надо доделать проверка что список не пуст 
                                    for (int i = 0; i < GoodsList.Count; i++)
                                    {
                                        Console.WriteLine($"{i + 1} {GoodsList[i]}");
                                    }
                                    Console.WriteLine("Что бы купить товар напешите его номер");
                                    Console.WriteLine("Для выхода напишите 0");
                                    int choiceGoods = int.Parse(Console.ReadLine()); // Проверку на коректность вводаъ
                                    if (choiceGoods == 0) break;
                                    else
                                    {
                                        if (currentSessionCustomer.Buy(GoodsList[choiceGoods - 1]))
                                        {
                                            GoodsList.RemoveAt(choiceGoods - 1);
                                            Console.WriteLine("Покупка успешна!");
                                            Console.WriteLine("Нажмите любую клавишу для продолжения");
                                            Console.ReadKey();
                                        }
                                    }
                                }
                                break;
                            }
                        // Просмотр, добавление и удаление постоянных покупателей
                        case 2:
                            {
                                Console.Clear();
                                Console.WriteLine("Список постоянных покупателей");
                                for (int i = 0; i < CustomerList.Count; i++)
                                {
                                    if (CustomerList[i] is RegularCustomer rcl)
                                    {
                                        Console.WriteLine($"{i}. Ім'я: {rcl.Name}, Витрачено: {rcl.TotalAmountSpent}");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{i}. Анонімний покупець, Баланс: {CustomerList[i].Balance}");
                                    }
                                }

                                Console.WriteLine("\n1 Добавить постоянного клиента\n2 Удалить постоянного клиента\n\n0 Назад");
                                Console.WriteLine("Выберите действие: ");
                                int choice = int.Parse(Console.ReadLine());
                                switch (choice)
                                {
                                    case 1:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Введите имя нового постоянного клиента");
                                            string name = Console.ReadLine();
                                            Console.WriteLine("Введите общую сумму трат нового постоянного клиента");
                                            int totalAmountSpent = int.Parse(Console.ReadLine());
                                            CustomerList.Add(new RegularCustomer(0, name, totalAmountSpent));
                                            Console.WriteLine("Постоянный клиент добавлен!");
                                            Console.WriteLine("Нажмите любую клавишу для продолжения");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.WriteLine("Введите номер постоянного клиента которого хотите удалить");
                                            int num = int.Parse(Console.ReadLine());
                                            CustomerList.RemoveAt(num);
                                            Console.WriteLine("Постоянный клиент удален!");
                                            Console.WriteLine("Нажмите любую клавишу для продолжения");
                                            Console.ReadKey();
                                            break;
                                        }
                                }break;
                            }
                        
                        // Добавление товара
                        case 3:
                            {
                                try
                                {
                                    Console.Clear();
                                    Console.WriteLine("ВЫБЕРИТЕ ТИП ТОВАРА:");
                                    Console.WriteLine("1-Пылесос, 2-Компьютер, 3-Ноутбук, 4-Камера, 5-DSLR");
                                    int goodTypeChoosen = int.Parse(Console.ReadLine());

                                    Console.Write("Компания: ");
                                    string comp = Console.ReadLine();

                                    Console.Write("Модель: ");
                                    string model = Console.ReadLine();

                                    Console.Write("Цена: ");
                                    int pr = int.Parse(Console.ReadLine());

                                    Console.Write("Макс. скидка %: ");
                                    int ds = int.Parse(Console.ReadLine());

                                    switch (goodTypeChoosen)
                                    {
                                        case 1:
                                            Console.Write("Шум(дБ): ");
                                            int noise = int.Parse(Console.ReadLine());

                                            Console.Write("Кабель(м): ");
                                            int len = int.Parse(Console.ReadLine());

                                            Console.Write("Мощность: ");
                                            int pwr = int.Parse(Console.ReadLine());

                                            GoodsList.Add(new VacuumСleaner(comp, model, pr, ds, noise, len, pwr));
                                            break;

                                        case 2:
                                            Console.Write("Процессор: ");
                                            string cpu = Console.ReadLine();

                                            Console.Write("ОЗУ: ");
                                            int ram = int.Parse(Console.ReadLine());

                                            Console.Write("Видеокарта: ");
                                            string gpu = Console.ReadLine();

                                            GoodsList.Add(new Computer(comp, model, pr, ds, cpu, ram, gpu));
                                            break;

                                        case 3:
                                            Console.Write("Процессор: ");
                                            string Cpu = Console.ReadLine();

                                            Console.Write("ОЗУ: ");
                                            int Ram = int.Parse(Console.ReadLine());

                                            Console.Write("Видеокарта: ");
                                            string Gpu = Console.ReadLine();

                                            Console.Write("Вес: ");
                                            double weight = double.Parse(Console.ReadLine());

                                            Console.Write("Батарея(ч): ");
                                            int battery = int.Parse(Console.ReadLine());

                                            GoodsList.Add(new Laptop(comp, model, pr, ds, Cpu, Ram, Gpu, weight, battery));
                                            break;

                                        case 4:
                                            Console.Write("Мп: ");
                                            int mp = int.Parse(Console.ReadLine());

                                            GoodsList.Add(new Camera(comp, model, pr, ds, mp));
                                            break;

                                        case 5:
                                            Console.Write("Мп: ");
                                            int d_mp = int.Parse(Console.ReadLine());

                                            Console.Write("Сменный объектив (true/false): ");
                                            bool lens = bool.Parse(Console.ReadLine());

                                            Console.Write("Выдержка: ");
                                            int sh = int.Parse(Console.ReadLine());

                                            GoodsList.Add(new DSLR(comp, model, pr, ds, d_mp, lens, sh));
                                            break;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    Console.ReadKey();
                                    break;
                                }
                                Console.WriteLine("Товар добавлен!");
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                                break;

                            }
                            
                    }
                }

            }

        }
    }
}
