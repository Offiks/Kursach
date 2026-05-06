using System;

namespace Kursach
{
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
            if (base.Buy(goods, discount))
            {
                TotalAmountSpent += goods.GetPriceWithDiscount(discount);
                return true;
            }

            return false;
        }
    }
}