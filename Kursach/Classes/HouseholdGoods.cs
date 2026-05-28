using System;


namespace Kursach
{
    public abstract class HouseholdGoods : Goods
    {
        private int power;
        private double cordLength;

        public HouseholdGoods() : this ("N/A", "N/A", 0, 0, 0, 0) { }

        public HouseholdGoods(string company, string name, int price, int maxDiscount, double cordLength, int power)
            : base(company, name, price, maxDiscount)
        {
            Power = power;
            CordLength = cordLength;
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
        public double CordLength
        {
            get { return cordLength; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Cord length cannot be negative");
                cordLength = value;
            }
        }
        public override string ToString()
        {
            return $"Побутовий товар: Компанія: {Company} | Назва: {Name} | Ціна: {Price} грн | Макс. знижка: {MaxDiscount}% | Потужність: {Power} Вт | Довжина шнура: {CordLength} м";
        }
    }
}
