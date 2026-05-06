using System;


namespace Kursach.Classes
{
    public class VacuumСleaner : HouseholdGoods
    {
        private int noiseLevel;

        public VacuumСleaner(string company, string name, int price, int maxDiscount, int noiseLevel, double cordLength, int power)
            : base(company, name, price, maxDiscount, cordLength, power)
        {
            NoiseLevel = noiseLevel;
        }

        public int NoiseLevel
        {
            get { return noiseLevel; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Noise level cannot be negative");
                noiseLevel = value;
            }
        }
        public override string ToString()
        {
            return $"Пилисос:   Компанія: {Company} | Назва: {Name} | Ціна: {Price} грн | Макс. знижка: {MaxDiscount}% | Потужність: {Power} Вт | Довжина шнура: {CordLength} м | Рівень шуму: {NoiseLevel} дБ";
        }
    }
}

