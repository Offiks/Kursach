using System;

namespace Kursach.Classes
{
    public class Camera : Goods
    {
        private int megapixels;

        public Camera() : this("N/A", "N/A", 0, 0, 0) { }


        public Camera(string company, string name, int price, int maxDiscount, int megapixels)
            : base(company, name, price, maxDiscount)
        {
            Megapixels = megapixels;
        }
        public int Megapixels
        {
            get { return megapixels; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Megapixels cannot be negative");
                megapixels = value;
            }

        }
            public override string ToString()
            {
                return $"Камера:   Компанія: {Company} | Назва: {Name} | Ціна: {Price} грн | Макс. знижка: {MaxDiscount}% | Мегапікселі: {Megapixels} МП";
        }
    }
}
