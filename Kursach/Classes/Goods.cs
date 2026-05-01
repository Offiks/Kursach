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
}
