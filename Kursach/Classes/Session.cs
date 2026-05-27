using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Kursach.Classes
{
    public class Session
    {
        private Shop currentShop;
        private Customer currentCustomer;
        private int securityLevel;

        private List<Shop> shopList = AddStandartShops();
        private List<Customer> customerList = AddStandartCustomers();

        public Session()
        {
            CurrentShop = null;
            CurrentCustomer = null;
            SecurityLevel = 0;
        }

        public Shop CurrentShop {
            get { return currentShop; }
            set { currentShop = value; }
        }

        public Customer CurrentCustomer
        {
            get { return currentCustomer; }
            set { currentCustomer = value; }
        }

        public int SecurityLevel
        {
            get { return securityLevel; }
            set { securityLevel = value; }
        }

        public List<Customer> CustomerList {
            get { return customerList; }
        }
        public List<Shop> ShopList
        {
            get { return shopList; }
        }

        public static List<Customer> AddStandartCustomers()
        {
            var list = new List<Customer>();
            Random random = new Random();
            int CustomersCount = random.Next(1, 4);
            var usedIndexes = new HashSet<int>();

            list.Add(new Customer());

            for (int i = 0; i < CustomersCount; i++)
            {
                int index = random.Next(StandartCustomer.Count);
                list.Add(StandartCustomer[index]);
            }
            return list;
        }

        public static List<Shop> AddStandartShops()
        {
            var list = new List<Shop>();
            Random random = new Random();
            int ShopsCount = random.Next(3, 5);
            var usedIndexes = new HashSet<int>();
            for (int i = 0; i < ShopsCount; i++)
            {
                int index = random.Next(StandartShop.Count);
                list.Add(StandartShop[index]);
            }
            return list;
        }

        public void Reset()
        {
            CurrentShop = null;
            CurrentCustomer = null;
            SecurityLevel = 0;
        }

        public static readonly List<Customer> StandartCustomer = new List<Customer>
        {
            new RegularCustomer(0, "Andrii", 175000),
            new RegularCustomer(0, "Maksym", 98000),
            new RegularCustomer(0, "Oleksandr", 250000),
            new RegularCustomer(0, "Dmytro", 55000),
            new RegularCustomer(0, "Serhii", 310000),
            new RegularCustomer(0, "Vladyslav", 67000),
            new RegularCustomer(0, "Yaroslav", 145000),
            new RegularCustomer(0, "Bohdan", 89000)
        };
        public static readonly List<Shop> StandartShop = new List<Shop>
        {
            new Shop("23 Shevchenka Ave", 20, "Petrenko"),
            new Shop("78 Prymorska St", 35, "Koval"),
            new Shop("10 Deribasivska St", 50, "Shevchenko"),
            new Shop("5 Fontanska Rd", 15, "Bondar"),
            new Shop("120 Lustdorfska Rd", 40, "Melnyk"),
            new Shop("44 Balkivska St", 60, "Tkachenko"),
            new Shop("9 Hretska Sq", 25, "Ivanenko")
        };
    }
}