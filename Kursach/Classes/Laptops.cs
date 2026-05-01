using System;


namespace Kursach.Classes
{
    internal class Laptops : Computer
    {
        private double weight;
        private double batteryLife;
        private double diagonal;

        public Laptops(string company, string name, int price, int maxDiscount, string processor, int ram, string gpu, double weight, double batteryLife, double diagona)
            : base(company, name, price, maxDiscount, processor, ram, gpu)
        {
            Weight = weight;
            BatteryLife = batteryLife;
            Diagonal = diagona;
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
        public double Diagonal
        {
            get { return diagonal; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Diagonal cannot be negative");
                diagonal = value;
            }
        }
        
    }
}
