using System;
using System.Collections.Generic;
using System.Net;

namespace Kursach
{
    public class Customer
    {
        private int balance;

        public Customer() : this(0) { }

        public Customer(int balance)
        {
            Balance = balance;
        }

        public int Balance
        {
            get { return balance; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Balance cannot be negative");
                balance = value;
            }
        }

        public static bool PrintCustomer(List<Customer> list)
        {
            Console.WriteLine($"Список постійних покупців");
            if (list == null)
            {
                Console.WriteLine("Список постійних покупців порожній.");
                Console.WriteLine("Ддя продовження натисніть будь яку кнопку");
                Console.ReadKey();
                return false;
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine($"{i + 1} {list[i]}");
                }
                return true;
            }
        }

        public virtual (string Name, int PersonalDiscount) GetDiscount(Goods goods)
        {
            return (string.Empty, 0);
        }
        public virtual bool Buy(Goods goods)
        {
            var (customerName, discount) = GetDiscount(goods);

            int finalPrice = goods.Price - (goods.Price * discount / 100);
            if (Balance >= finalPrice)
            {
                Balance -= finalPrice;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"Покупець: Баланс: {Balance}";
        }
    }
}
