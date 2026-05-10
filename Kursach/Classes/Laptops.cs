using System;


namespace Kursach.Classes
{
    public class Laptop : Computer
    {
        private double weight;
        private double batteryLife;

        public Laptop() : this("N/A", "N/A", 0, 0, "N/A", 0, "N/A", 0, 0) { }
        public Laptop(string company, string name, int price, int maxDiscount, string processor, int ram, string gpu, double weight, double batteryLife)
            : base(company, name, price, maxDiscount, processor, ram, gpu)
        {
            Weight = weight;
            BatteryLife = batteryLife;
        }
        public double Weight
        {
            get { return weight; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Weight cannot be negative");
                weight = value;
            }
        }
        public double BatteryLife
        {
            get { return batteryLife; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Battery life cannot be negative");
                batteryLife = value;
            }
        }
        public override string ToString()
        {
            return $"Ноутбук:   Компанія: {Company} | Назва: {Name} | Ціна: {Price} грн | Макс. знижка: {MaxDiscount}% | Процесор: {Processor} | ОЗУ: {RAM} ГБ | Відеокарта: {GPU} | Вага: {Weight} кг | Час роботи від батареї: {BatteryLife} год";
        }
    }
}
