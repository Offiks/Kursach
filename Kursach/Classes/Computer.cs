using System;


namespace Kursach.Classes
{
    internal class Computer : Goods
    {
        private string processor;
        private int ram;
        private string gpu;
        
        public Computer(string company, string name, int price, int maxDiscount, string processor, int ram, string gpu)
            : base(company, name, price, maxDiscount)
        {
            Processor = processor;
            RAM = ram;
            GPU = gpu;
        }
        public string Processor
        {
            get { return processor; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Processor cannot be empty");
                processor = value;
            }
        }
        public int RAM
        {
            get { return ram; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("RAM cannot be negative");
                ram = value;
            }
        }
        public string GPU
        {
            get { return gpu; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("GPU cannot be empty");
                gpu = value;
            }
        }
    }
}
