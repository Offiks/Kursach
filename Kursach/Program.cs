using Kursach.Classes;
using System;
using System.Collections.Generic;

namespace Kursach
{
    public class Program
    {
        static void Main()
        {

            //Списки, товари, покупці за замовчуванням
            List<Shop> ShopList = new List<Shop>();
            List<Customer> CustomerList = new List<Customer>();

            ShopList.Add(new Shop("123 Main St", 10, "Doe"));
            ShopList.Add(new Shop("231 Oak Ave", 30, "Smith"));
            ShopList.Add(new Shop("39 Oak St", 50, "Johnson"));

            ShopList[0].GoodsList.Add(new VacuumСleaner("BOSCH", "BGC05AAA1", 3699, 10, 78, 6, 700));
            ShopList[0].GoodsList.Add(new Camera("Canon", "PowerShots SX40 HS", 15999, 15, 12));
            ShopList[1].GoodsList.Add(new DSLR("Sony", "Alpha DSLR-A100 Kit", 23500, 10, 10, true, 4000));
            ShopList[1].GoodsList.Add(new Computer("Custom Build", "Ultimate WorkStation", 94500, 10, "i9-14900K", 64, "RTX 4080 S"));
            ShopList[2].GoodsList.Add(new Laptop("ASUS", "Vivobook 16X", 42000, 10, "i7-12700H", 16, "RTX 3050", 1.7, 10));

            CustomerList.Add(new Customer(0));
            CustomerList.Add(new RegularCustomer(0, "Ivan", 200000));
            CustomerList.Add(new RegularCustomer(0, "Peter", 52000));
            CustomerList.Add(new RegularCustomer(1000000, "deBug", 10000000));

            Customer currentSessionCustomer = null;
            int currentSecurityLevel = 0;
            Shop currentShop = null;

            // Програма
            while (true)
            {
                if (currentShop == null)
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("Виберіть магазин:");
                        Console.WriteLine("№  | Адреса");
                        Console.WriteLine("---+--------");
                        for (int i = 0; i < ShopList.Count; i++)
                        {
                            Console.WriteLine($"{i + 1:D2} | {ShopList[i].Address}");
                        }
                        Console.WriteLine("\n0 Вихід");

                        int shopIndex = int.Parse(Console.ReadLine());
                        if (shopIndex < 0 || shopIndex > ShopList.Count)
                        {
                            Console.WriteLine("Такого магазина не має, спробуйте ще раз. \nДля продовження натисніть будь яку клавішу");
                            Console.ReadKey();
                            continue;
                        }
                        if (shopIndex == 0)
                        {
                            break;
                        }
                        currentShop = ShopList[shopIndex - 1];
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Некоректне значення! Спробуйте ще раз. \nДля продовження натисніть будь яку клавішу");
                        Console.ReadKey();
                        continue;
                    }

                }
                if (currentSessionCustomer == null)
                {
                    Console.WriteLine("Доброго Дня! Ви постійний клієнт?");
                    Console.WriteLine("y - так, n - ні");

                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "n":
                            {
                                while (true)
                                {
                                    try
                                    {
                                        Console.WriteLine("Введіть свій баланс");

                                        int CustomerBalance = int.Parse(Console.ReadLine());

                                        currentSessionCustomer = CustomerList[0];
                                        CustomerList[0].Balance = CustomerBalance;
                                        currentSecurityLevel = 0;

                                        break;
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Некоректне значення! Спробуйте ще раз. \nДля продовження натисніть будь яку клавішу");
                                        Console.ReadKey();
                                    }
                                }

                                break;
                            }

                        case "y":
                            {
                                Console.WriteLine("Введіть своє ПІБ");
                                string cheakName = Console.ReadLine();
                                Customer foundCustomer = null;

                                for (int i = 1; i < CustomerList.Count; i++)
                                {
                                    RegularCustomer regularCustomer = (RegularCustomer)CustomerList[i];

                                    if (regularCustomer.Name == cheakName)
                                    {
                                        foundCustomer = CustomerList[i];
                                        Console.WriteLine("Введіть свій баланс");
                                        int CustomerBalance = int.Parse(Console.ReadLine());
                                        foundCustomer.Balance = CustomerBalance;
                                        currentSessionCustomer = foundCustomer;
                                        currentSecurityLevel = 1;
                                        break;
                                    }
                                }

                                if (foundCustomer == null)
                                {
                                    Console.WriteLine("Покупця з таким ім’ям не знайдено");
                                }
                                break;
                            }

                        case "a":
                            {
                                Console.WriteLine("Введіть своє ПІБ");
                                string checkName = Console.ReadLine();

                                if (currentShop.CheckManagerName(checkName))
                                {
                                    currentSessionCustomer = new RegularCustomer(0, currentShop.ManagerName, 0);
                                    currentSecurityLevel = 2;
                                }
                                else
                                {
                                    Console.WriteLine("Невірне ім’я менеджера!");
                                }

                                break;
                            }

                        default: {
                                Console.WriteLine("Невірне значення. Для продовження натисніть будь яку клавішу.");
                                Console.ReadKey();
                                continue;
                            }
                    }
                }

                //Головне вікно
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
                    Console.WriteLine("Виберіть дію: ");
                }
                else
                {
                    Console.WriteLine("1 Переглянути товари\n2 Передевитися інформацію про магазин\n3 Переглянути постійних покупців\n4 Додати товар\n5 Передевитися історію покупок.\n\n0 Вийти з магазина");
                }

                int choicePage;
                try
                {
                    choicePage = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Помилка вводу. Введіть коректне число.");
                    Console.ReadKey();
                    continue;
                }

                if (choicePage == 0)
                {
                    currentShop = null;
                    currentSessionCustomer = null;
                    continue;
                }

                if (!currentShop.CheckSecurity(currentSecurityLevel, choicePage))
                {
                    Console.WriteLine("Ви спробували зайти до розділу призначеного для менеджера. Натисніть будь яку кнопку щоб повернутись назад.");
                    Console.ReadKey();
                    continue;
                }
                if (choicePage < 1 || choicePage > 5)
                {
                    Console.WriteLine("Невірний вибір. Натисніть будь-яку клавішу для продовження");
                    Console.ReadKey();
                    continue;
                }

                switch (choicePage)
                {
                    // Перегляд товарів
                    case 1:
                        {
                            while (true)
                            {
                                Console.Clear();
                                if (currentShop.PrintGoods())
                                {
                                    Console.WriteLine("Щоб купити товар, введіть його номер");
                                    Console.WriteLine("Для виходу введіть 0");
                                    int choiceGoods;
                                    try
                                    {
                                        choiceGoods = int.Parse(Console.ReadLine());
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Помилка вводу. Введіть коректне число.");
                                        Console.ReadKey();
                                        continue;
                                    }
                                    if (choiceGoods == 0) break;
                                    else
                                    {
                                        if ( choiceGoods < 1 || choiceGoods > currentShop.GoodsList.Count)
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
                            }
                            break;
                        }
                    // Перегляд інформації про магазин
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine(currentShop.ToString());
                            Console.WriteLine("Натисніть будь-яку клавішу для продовження");
                            Console.ReadKey();
                        }
                        break;
                    // Перегляд, додавання та видалення постійних покупців
                    case 3:
                        {
                            Console.Clear();
                            Customer.PrintCustomer(CustomerList);

                            Console.WriteLine("\n1 Додати постійного клієнта\n2 Видалити постійного клієнта\n\n0 Назад");
                            Console.WriteLine("Виберіть дію: ");
                            int choice = int.Parse(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Введіть ім’я нового постійного клієнта");
                                        string name = Console.ReadLine();
                                        Console.WriteLine("Введіть загальну суму витрат нового постійного клієнта");
                                        int totalAmountSpent = int.Parse(Console.ReadLine());
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
                            break;
                        }
                    // Додавання товару
                    case 4:
                        {
                            try
                            {
                                Console.Clear();
                                Console.WriteLine("ВИБЕРІТЬ ТИП ТОВАРУ:");
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
                    // Перегляд історії покупок
                    case 5:
                        {
                            Console.Clear();
                            currentShop.PrintHistory();
                            Console.WriteLine("Для продовження натисніть будь-яку клавішу");
                            Console.ReadKey();
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Невірний вибір! Натисніть будь-яку клавішу для продовження");
                            Console.ReadKey();
                            break;
                        }

                }
            }
        }
    }
}