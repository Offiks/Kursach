using System;
using System.Collections.Generic;

namespace Kursach.Classes
{
    public class Shop
    {
        private string address;
        private int storageCapacity;
        private string managerName;
        private List<Goods> goodsList = AddDefaultGoods();
        private List<Purchase> history = new List<Purchase>();

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
        public List<Goods> GoodsList
        {
            get { return goodsList; }
        }

        public List<Purchase> History
        {
            get { return history; }
        }

        public bool HasGoods()
        {
            return GoodsList != null && GoodsList.Count > 0;
        }

        public void PrintGoods()
        {
            Console.Clear();
            Console.WriteLine($"Товари в магазині за адресою: {Address}");

            if (GoodsList == null) {
                Console.WriteLine("У магазині не має товарів");
                Console.WriteLine("Ддя продовження натисніть будь яку кнопку");
                Console.ReadKey();
                return;
             }
            
            for (int i = 0; i < GoodsList.Count; i++)
            {
                Console.WriteLine($"{i + 1} {GoodsList[i]}");
            }
            Console.WriteLine("Щоб купити товар, введіть його номер");
            Console.WriteLine("Для виходу введіть 0");
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

        public string ToString(int securityLevel)
        {
            if (securityLevel >= 2)
                return $"Магазин: Адреса: {Address} \nЄмність складу: {StorageCapacity} одиниць \nКількість товарів: {GoodsList.Count} \nНомер гарячої лінії: (049) 949-23-32 \n\nГрафік роботи: \nПн-Пт 9:00-20:00 \nСб 10:00-18:00 \nНеділя вихідний";
            else
            {
                return $"Магазин: Адреса: {Address} \nНомер гарячої лінії: (049) 949-23-32 \n\nГрафік роботи: \nПн-Пт 9:00-20:00 \nСб 10:00-18:00 \nНеділя вихідний";
            }
        }

        public static List<Goods> AddDefaultGoods()
        {

            var list = new List<Goods>();
            Random random = new Random();
            int itemsCount = random.Next(3,7);
            var usedIndexes = new HashSet<int>(); 


            for (int i = 0; i < itemsCount; i++)
            {
                int index = random.Next(StandartCatalog.Count);
                list.Add(StandartCatalog[index]);
            }
            return list;
        }
        

        public static readonly List<Goods> StandartCatalog = new List<Goods>
        {
                new VacuumСleaner("Bosch", "BGC05AAA1", 3699, 10, 78, 6, 700),
                new VacuumСleaner("Samsung", "VC07M2110SR", 4200, 10, 80, 7, 750),
                new VacuumСleaner("Philips", "FC9332", 4999, 10, 79, 6, 900),
                new VacuumСleaner("Xiaomi", "Mi Vacuum 1C", 6500, 10, 82, 6, 1200),
                new VacuumСleaner("Rowenta", "RO3731", 5200, 10, 77, 5, 800),

                new Camera("Canon", "PowerShot SX40 HS", 15999, 15, 12),
                new Camera("Nikon", "Coolpix B500", 13999, 15, 16),
                new Camera("Sony", "DSC-H300", 12500, 15, 20),
                new Camera("Panasonic", "Lumix DMC-FZ82", 18500, 15, 18),
                new Camera("Kodak", "PixPro AZ401", 11000, 15, 16),
         

                new DSLR("Sony", "Alpha A100", 23500, 10, 10, true, 4000),
                new DSLR("Canon", "EOS 2000D", 24999, 10, 24, true, 5000),
                new DSLR("Nikon", "D3500", 26000, 10, 24, true, 4500),
                new DSLR("Pentax", "K-70", 28000, 10, 24, true, 4200),
                new DSLR("Canon", "EOS 90D", 42000, 10, 32, true, 6000),
 
                new Computer("Custom", "WorkStation Pro", 94500, 10, "i9-14900K", 64, "RTX 4080"),
                new Computer("HP", "OMEN 45L", 85000, 10, "i7-14700K", 32, "RTX 4070"),
                new Computer("Dell", "XPS Desktop", 78000, 10, "i7-13700", 32, "RTX 4060"),
                new Computer("Lenovo", "Legion Tower 7", 90000, 10, "i9-13900", 64, "RTX 4080"),
                new Computer("Acer", "Predator Orion", 82000, 10, "i7-13700KF", 32, "RTX 4070"),

                new Laptop("ASUS", "Vivobook 16X", 42000, 10, "i7-12700H", 16, "RTX 3050", 1.7, 10),
                new Laptop("Lenovo", "IdeaPad 5", 35000, 10, "i5-1235U", 16, "Intel Iris Xe", 1.6, 12),
                new Laptop("HP", "Pavilion 15", 38000, 10, "i5-12450H", 16, "RTX 2050", 1.8, 11),
                new Laptop("Acer", "Swift 3", 33000, 10, "i5-1135G7", 8, "Intel Iris Xe", 1.2, 13),
                new Laptop("MSI", "Modern 15", 45000, 10, "i7-1260P", 16, "MX550", 1.6, 10)
        };
    }
}
