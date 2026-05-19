using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;


namespace Kursach.Classes
{
    internal class Menu
    {
        public static Shop ShowShopSelectMenu(List<Shop> shopList)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Виберіть магазин:");
                Console.WriteLine("№  | Адреса");
                Console.WriteLine("---+--------");

                for (int i = 0; i < shopList.Count; i++)
                {
                    Console.WriteLine($"{i + 1:D2} | {shopList[i].Address}");
                }

                Console.WriteLine("\n0 Вихід");

                if (!int.TryParse(Console.ReadLine(), out int shopIndex))
                {
                    Console.WriteLine("Некоректне значення!");
                    Console.WriteLine("Натисніть будь-яку клавішу...");
                    Console.ReadKey();
                    continue;
                }

                if (shopIndex == 0)
                {
                    return null;
                }

                if (shopIndex < 1 || shopIndex > shopList.Count)
                {
                    Console.WriteLine("Такого магазину не існує!");
                    Console.WriteLine("Натисніть будь-яку клавішу...");
                    Console.ReadKey();

                    continue;
                }

                return shopList[shopIndex - 1];
            }
        }
        public static (int securityLevel, Customer customer) ShowCustomerSelectMenu(List<Customer> CustomerList, Shop currentShop)
        {
            while (true)
            {
                int currentSecurityLevel = 0;
                Customer currentSessionCustomer = null;

                Console.Clear();
                Console.WriteLine("Доброго Дня! Ви постійний клієнт?");
                Console.WriteLine("y - так, n - ні");
                Console.Write("Ваш вибір: ");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "n":
                        {
                            Console.Write("Введіть свій баланс: ");

                            if (!int.TryParse(Console.ReadLine(), out int CustomerBalance))
                            {
                                Console.WriteLine("Некоректне значення!");
                                Console.WriteLine("Натисніть будь-яку клавішу...");
                                Console.ReadKey();
                                continue;
                            }

                            CustomerList[0].Balance = CustomerBalance;
                            currentSecurityLevel = 0;

                            return (currentSecurityLevel, CustomerList[0]);
                        }
                    case "y":
                        {
                            Console.Write("Введіть своє ПІБ: ");
                            string cheakName = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(cheakName))
                            {
                                Console.WriteLine("Ім’я не може бути порожнім!");
                                Console.WriteLine("Натисніть будь-яку клавішу щоб продовжити");
                                Console.ReadKey();
                                continue;
                            }

                            Customer foundCustomer = null;

                            for (int i = 1; i < CustomerList.Count; i++)
                            {
                                if (CustomerList[i] is RegularCustomer regularCustomer &&
                                    regularCustomer.Name == cheakName)
                                {
                                    foundCustomer = CustomerList[i];
                                    break;
                                }
                            }
                            if (foundCustomer == null)
                            {
                                Console.WriteLine("Клієнт з таким ім’ям не знайдений!");
                                Console.WriteLine("Натисніть будь-яку клавішу щоб продовжити");
                                Console.ReadKey();
                                continue;
                            }
                            Console.WriteLine($"Клієнта знайдено");
                            Console.Write("Введіть свій баланс: ");

                            if (!int.TryParse(Console.ReadLine(), out int customerBalance))
                            {
                                Console.WriteLine("Некоректне значення!");
                                Console.ReadKey();
                                continue;
                            }
                            foundCustomer.Balance = customerBalance;
                            currentSecurityLevel = 1;

                            return (currentSecurityLevel, foundCustomer);
                        }
                    case "a":
                        {
                            Console.WriteLine("Введіть своє ПІБ");
                            string checkName = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(checkName))
                            {
                                Console.WriteLine("Ім’я не може бути порожнім!");
                                Console.WriteLine("Натисніть будь-якую клавішу щоб продовжити");
                                Console.ReadKey();
                                continue;
                            }

                            if (currentShop.CheckManagerName(checkName))
                            {
                                currentSessionCustomer = new RegularCustomer(0, currentShop.ManagerName, 0);
                                currentSecurityLevel = 2;

                                return (currentSecurityLevel, currentSessionCustomer);
                            }
                            else
                            {
                                Console.WriteLine("Невірне ім’я менеджера!");
                                Console.ReadKey();
                                continue;
                            }
                        }
                    default:
                        {
                            Console.WriteLine("Невірне значення. Для продовження натисніть будь яку клавішу.");
                            Console.ReadKey();
                            continue;
                        }
                }
            }
        }
        public static int ShowMainMenu(Shop currentShop, int currentSecurityLevel, Customer currentSessionCustomer)
        {
            while (true)
            {
                Console.Clear();
                if (currentSecurityLevel == 0)
                {
                    Console.WriteLine($"Ви авторизовані як гість, баланс: {currentSessionCustomer.Balance}");
                }
                else if (currentSecurityLevel == 1 && currentSessionCustomer is RegularCustomer rc)
                {
                    Console.WriteLine($"Ви авторизовані як {rc.Name}, баланс: {rc.Balance}, загальна сума витрат: {rc.TotalAmountSpent}");
                }
                else if (currentSecurityLevel == 2)
                {
                    Console.WriteLine($"Ви авторизовані як менеджер {currentShop.ManagerName}.");
                }

                if (currentSecurityLevel <= 1)
                {
                    Console.WriteLine("1 Переглянути товари\n2 Передевитися інформацію про магазин\n\n0 Вийти з магазина");
                }
                else
                {
                    Console.WriteLine("1 Переглянути товари\n2 Передевитися інформацію про магазин\n3 Переглянути постійних покупців\n4 Додати товар\n5 Передевитися історію покупок.\n\n0 Вийти з магазина");
                }
                Console.Write("Оберіть дію: ");
                int choicePage;
                if (!int.TryParse(Console.ReadLine(), out choicePage))
                {
                    Console.WriteLine("Некоректне значення!");
                    Console.WriteLine("Натисніть будь-якую клавішу щоб продовжити");
                    Console.ReadKey();
                    continue;
                }
                if (choicePage < 0 || choicePage > 5)
                {
                    Console.WriteLine("Невірний вибір. Натисніть будь-яку клавішу для продовження");
                    Console.ReadKey();
                    continue;
                }
                return choicePage;
            }
        }
        public static void ShowProducts(Shop currentShop, Customer currentSessionCustomer)
        {
            while (true)
            {
                Console.Clear();
                currentShop.PrintGoods();
                if (!currentShop.HasGoods()) break;

                if (!int.TryParse(Console.ReadLine(), out int choiceGoods))
                {
                    Console.WriteLine("Помилка вводу. Введіть коректне число.");
                    Console.ReadKey();
                    continue;
                }
                if (choiceGoods == 0) break;
                if (choiceGoods < 1 || choiceGoods > currentShop.GoodsList.Count)
                {
                    Console.WriteLine("Невірний вибір. Натисніть будь-якую клавішу для продовження");
                    Console.ReadKey();
                    continue;
                }
                if (currentSessionCustomer.Buy(currentShop.GoodsList[choiceGoods - 1]))
                {
                    currentShop.AddPurchase(currentSessionCustomer, currentShop.GoodsList[choiceGoods - 1], currentShop.GoodsList[choiceGoods - 1].Price);
                    currentShop.GoodsList.RemoveAt(choiceGoods - 1);
                    Console.WriteLine("Покупка успішна!");
                    Console.WriteLine("Натисніть будь-яку клавішу для продовження");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Недостатньо коштів для покупки цього товару!");
                    Console.WriteLine("Натисніть будь-яку клавішу для продовження");
                    Console.ReadKey();
                    continue;
                }
            }
        }
        public static void ShowInfo(Shop currentShop)
        {
            Console.Clear();
            Console.WriteLine(currentShop);
            Console.WriteLine("Натисніть будь-яку клавішу для продовження");
            Console.ReadKey();
        }
        public static void ShowCustomersManager(Shop currentShop, List<Customer> CustomerList)
        {
            while (true)
            {
                Console.Clear();
                Customer.PrintCustomer(CustomerList);

                Console.WriteLine("\n1 Додати постійного клієнта\n2 Видалити постійного клієнта\n\n0 Назад");
                Console.Write("Виберіть дію: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Помилка вводу. Введіть коректне число.");
                    Console.ReadKey();
                    continue;
                }
                if (choice == 0) break;
                switch (choice)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine("Введіть ім’я нового постійного клієнта");
                            string name = Console.ReadLine();

                            Console.WriteLine("Введіть загальну суму витрат нового постійного клієнта");
                            if (!int.TryParse(Console.ReadLine(), out int totalAmountSpent))
                            {
                                Console.WriteLine("Помилка вводу. Введіть коректне число.");
                                Console.ReadKey();
                                continue;
                            }
                            CustomerList.Add(new RegularCustomer(0, name, totalAmountSpent));

                            Console.WriteLine("Постійного клієнта додано!");
                            Console.WriteLine("Натисніть будь-яку клавішу для продовження");
                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Введіть номер постійного клієнта, якого хочете видалити");
                            int num = int.Parse(Console.ReadLine());
                            CustomerList.RemoveAt(num);

                            Console.WriteLine("Постійного клієнта видалено!");
                            Console.WriteLine("Натисніть будь-яку клавішу для продовження");
                            Console.ReadKey();
                            break;
                        }
                }
            }
        }
        public static void ShowAddProduct(Shop currentShop)
        {
            while (true)
            {
                if (currentShop.GoodsList.Count >= currentShop.StorageCapacity)
                {
                    Console.WriteLine("Склад повний! Для початку треба щоб хтось купив товар, або видалити товар");
                    Console.WriteLine("Натисніть будь-яку клавішу для продовження");
                    Console.ReadKey();
                    break;
                }
                try
                {
                    Console.Clear();
                    Console.WriteLine("Вибферіть тип товару:");
                    Console.WriteLine("1-Пилосос, 2-Комп'ютер, 3-Ноутбук, 4-Камера, 5-DSLR");
                    int goodTypeChoosen = int.Parse(Console.ReadLine());

                    Console.Write("Компанія: ");
                    string comp = Console.ReadLine();

                    Console.Write("Модель: ");
                    string model = Console.ReadLine();

                    Console.Write("Ціна: ");
                    int pr = int.Parse(Console.ReadLine());

                    Console.Write("Макс. знижка %: ");
                    int ds = int.Parse(Console.ReadLine());

                    switch (goodTypeChoosen)
                    {
                        case 1:
                            Console.Write("Шум(дБ): ");
                            int noise = int.Parse(Console.ReadLine());

                            Console.Write("Кабель(м): ");
                            int len = int.Parse(Console.ReadLine());

                            Console.Write("Потужність: ");
                            int pwr = int.Parse(Console.ReadLine());

                            currentShop.GoodsList.Add(new VacuumСleaner(comp, model, pr, ds, noise, len, pwr));
                            break;

                        case 2:
                            Console.Write("Процесор: ");
                            string cpu = Console.ReadLine();

                            Console.Write("ОЗП: ");
                            int ram = int.Parse(Console.ReadLine());

                            Console.Write("Відеокарта: ");
                            string gpu = Console.ReadLine();

                            currentShop.GoodsList.Add(new Computer(comp, model, pr, ds, cpu, ram, gpu));
                            break;

                        case 3:
                            Console.Write("Процесор: ");
                            string Cpu = Console.ReadLine();

                            Console.Write("ОЗП: ");
                            int Ram = int.Parse(Console.ReadLine());

                            Console.Write("Відеокарта: ");
                            string Gpu = Console.ReadLine();

                            Console.Write("Вага: ");
                            double weight = double.Parse(Console.ReadLine());

                            Console.Write("Батарея(год): ");
                            int battery = int.Parse(Console.ReadLine());

                            currentShop.GoodsList.Add(new Laptop(comp, model, pr, ds, Cpu, Ram, Gpu, weight, battery));
                            break;

                        case 4:
                            Console.Write("Мп: ");
                            int mp = int.Parse(Console.ReadLine());

                            currentShop.GoodsList.Add(new Camera(comp, model, pr, ds, mp));
                            break;

                        case 5:
                            Console.Write("Мп: ");
                            int d_mp = int.Parse(Console.ReadLine());

                            Console.Write("Змінний об’єктив (true/false): ");
                            bool lens = bool.Parse(Console.ReadLine());

                            Console.Write("Витримка: ");
                            int sh = int.Parse(Console.ReadLine());

                            currentShop.GoodsList.Add(new DSLR(comp, model, pr, ds, d_mp, lens, sh));
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                    break;
                }
                Console.WriteLine("Товар додано!");
                Console.WriteLine("Натисніть будь-яку клавішу для продовження");
                Console.ReadKey();
                break;

            }
        }
        public static void ShowHistory(Shop currentShop)
        {
            while (true)
            {
                Console.Clear();
                currentShop.PrintHistory();
                Console.WriteLine("Для продовження натисніть будь-яку клавішу");
                Console.ReadKey();
                break;
            }

        }
    }
}
