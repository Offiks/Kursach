using Kursach.Classes;
using System;
using System.Collections.Generic;

namespace Kursach
{
    public class Program
    {
        static void Main()
        {
            Session session = new Session();

            while (true)
            {
                if (session.CurrentShop == null)
                {
                    session.CurrentShop = Menu.ShowShopSelectMenu(session.ShopList);

                    if (session.CurrentShop == null)
                        break;
                }

                if (session.CurrentCustomer == null)
                {
                    var result = Menu.ShowCustomerSelectMenu(session.CustomerList, session.CurrentShop);

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
                            Menu.ShowInfo(session.CurrentShop, session.SecurityLevel);
                            break;
                        }

                    // Перегляд, додавання та видалення постійних покупців
                    case 3 when session.SecurityLevel >= 2:
                        {
                            Menu.ShowCustomersManager(session.CurrentShop, session.CustomerList);
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