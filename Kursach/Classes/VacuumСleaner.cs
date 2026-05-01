using System;


namespace Kursach.Classes
{
    internal class VacuumСleaner : HouseholdGoods
    {
        private double dustCapacity;
        private int noiseLevel;
        private double cordLength;

        public VacuumСleaner(string company, string name, int price, int maxDiscount, double dustCapacity, int noiseLevel, double cordLength, int power)
            : base(company, name, price, maxDiscount, power)
        {
            DustCapacity = dustCapacity;
            NoiseLevel = noiseLevel;
            CordLength = cordLength;
        }
            public double DustCapacity
            {
                get { return dustCapacity; }
                set
                {
                    if (value < 0)
                        throw new ArgumentException("Dust capacity cannot be negative");
                    dustCapacity = value;
                }
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
    }
}
