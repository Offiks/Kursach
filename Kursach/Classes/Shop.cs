using System;
using System.Collections.Generic;

namespace Kursach.Classes
{
    public class Shop
    {
        private string address;
        private int storageCapacity;
        private string managerName;
        public List<Goods> GoodsList { get; set; } = new List<Goods>();
        public List<Purchase> History { get; set; } = new List<Purchase>();

        public Shop() : this("N/A", 0, "N/A") { }
        public Shop(string address, int storageCapacity, string managerName)
        {
            Address = address;
            StorageCapacity = storageCapacity;
            ManagerName = managerName;
        }

        public string Address
        {
            get { return address; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Address cannot be empty");
                address = value;
            }
        }

        public int StorageCapacity
        {
            get { return storageCapacity; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Storage capacity cannot be negative");
                storageCapacity = value;
            }
        }
        public string ManagerName
        {
            get { return managerName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Manager name cannot be empty");
                managerName = value;
            }
        }

        public bool PrintGoods()
        {
            Console.WriteLine($"Товари в магазині за адресою: {Address}");
            if (GoodsList == null) {
                Console.WriteLine("У магазині не має товарів");
                Console.WriteLine("Ддя продовження натисніть будь яку кнопку");
                Console.ReadKey();
                return false;
                    }
            else
            {
                for (int i = 0; i < GoodsList.Count; i++)
                {
                    Console.WriteLine($"{i + 1} {GoodsList[i]}");
                }
                return true;
            }
        }

        public void AddPurchase(Customer buyer, Goods product, int price) { 
            History.Add(new Purchase(buyer, product, price));
        }

        public bool CheckManagerName(string name)
        {
            return name == ManagerName;
        }

        public void PrintHistory()
        {
            Console.WriteLine($"Історія покупок в магазині за адресою: {Address}");
            if (History.Count == 0)
            {
                Console.WriteLine("Історія покупок порожня");
            }
            else
            {
                foreach (var purchase in History)
                {
                    Console.WriteLine(purchase);
                }
            }
        }

        public override string ToString()
        {
            return $"Магазин: Адреса: {Address} \nЄмність складу: {StorageCapacity} одиниць \nКількість товарів: {GoodsList.Count} \nНомер гарячої лінії: (049) 949-23-32 \n\nГрафік роботи: \nПн-Пт 9:00-20:00 \nСб 10:00-18:00 \nНеділя вихідний";

        }
    }
}
