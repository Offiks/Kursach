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
            Session session = new Session();

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


            // Програма
            while (true)
            {
                if (session.CurrentShop == null)
                {
                    session.CurrentShop = Menu.ShowShopSelectMenu(ShopList);

                    if (session.CurrentShop == null)
                        break;
                }

                if (session.CurrentCustomer == null)
                {
                    var result = Menu.ShowCustomerSelectMenu(CustomerList, session.CurrentShop);

                    session.SecurityLevel = result.securityLevel;
                    session.CurrentCustomer = result.customer;
                }

                //Головне вікно
                int choicePage = Menu.ShowMainMenu(session.CurrentShop, session.SecurityLevel, session.CurrentCustomer);
                if (choicePage == 0) {
                    session.CurrentShop = null;
                    session.CurrentCustomer = null;
                    session.SecurityLevel = 0;
                    continue;
                }
                switch (choicePage)
                {
                    // Перегляд товарів
                    case 1:
                        {
                            Menu.ShowProducts(session.CurrentShop, session.CurrentCustomer);
                            break;
                        }
                    // Перегляд інформації про магазин
                    case 2:
                        {
                            Menu.ShowInfo(session.CurrentShop);
                            break;
                        }

                    // Перегляд, додавання та видалення постійних покупців
                    case 3 when session.SecurityLevel >= 2:
                        {
                            Menu.ShowCustomersManager(session.CurrentShop, CustomerList);
                            break;
                        }

                    // Додавання товару
                    case 4 when session.SecurityLevel >= 2:
                        {
                            Menu.ShowAddProduct(session.CurrentShop);
                            break;

                        }

                    // Перегляд історії покупок
                    case 5 when session.SecurityLevel >= 2:
                        {
                            Menu.ShowHistory(session.CurrentShop);
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