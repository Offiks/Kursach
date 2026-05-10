using System;

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

        public virtual (string Name, int PersonalDiscount) GetDiscount(Goods goods)
        {
            return (string.Empty, 0);
        }
        // Метод покупки который надо довести до ума
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
                throw new ArgumentException("Insufficient balance");
            }
        }
    }
}
