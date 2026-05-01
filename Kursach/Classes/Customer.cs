using System;

namespace Kursach
{
    public class Customer
    {
        private int balance;

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

        public virtual bool Buy(Goods goods, int discount)
        {
            int price = goods.GetPriceWithDiscount(discount);

            if (Balance >= price)
            {
                Balance -= price;
                return true;
            }
            else
            {
                throw new ArgumentException("Insufficient balance");
            }
        }
    }
}
