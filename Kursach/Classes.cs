
using System;

namespace Kursach
{
    public class Goods
    {
        private string company;
        private string name;
        private int price;
        private int maxDiscount;

        public Goods(string company, string name, int price, int maxDiscount)
        {
            Company = company;
            Name = name;
            Price = price;
            MaxDiscount = maxDiscount;
        }

        public string Company
        {
            get { return company; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Company cannot be empty");
                company = value;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty");
                name = value;
            }
        }

        public int Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Price cannot be negative");
                price = value;
            }
        }

        public int MaxDiscount
        {
            get { return maxDiscount; }
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException("Discount must be 0-100");
                maxDiscount = value;
            }
        }

        public int GetPriceWithDiscount(int discount)
        {
            if (discount > MaxDiscount)
                discount = MaxDiscount;

            return Price - (Price * discount / 100);
        }
    }

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

    public class RegularCustomer : Customer
    {
        private string name;
        private int totalAmountSpent;

        public RegularCustomer(int balance, string name, int total)
            : base(balance)
        {
            Name = name;
            TotalAmountSpent = total;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty");
                name = value;
            }
        }

        public int TotalAmountSpent
        {
            get { return totalAmountSpent; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Total cannot be negative");
                totalAmountSpent = value;
            }
        }

        public override bool Buy(Goods goods, int discount)
        {
            int price = goods.GetPriceWithDiscount(discount);

            if (base.Buy(goods, discount))
            {
                TotalAmountSpent += price;
                return true;
            }

            return false;
        }
    }
}