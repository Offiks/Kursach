using System;


namespace Kursach
{
    internal class HouseholdGoods : Goods
    {
        private int power;

        public HouseholdGoods(string company, string name, int price, int maxDiscount, int power)
            : base(company, name, price, maxDiscount)
        {
            Power = power;
        }

        public int Power
        {
            get { return power; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Power cannot be negative");
                power = value;
            }
        }
    }
}
