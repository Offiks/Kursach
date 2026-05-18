using System;


namespace Kursach.Classes
{
    public class DSLR : Camera
    {
        private bool interchangeableLens;
        private int maxShutterSpeed;

        public DSLR() : this("N/A", "N/A", 0, 0, 0, false, 0) { }

        public DSLR(string company, string name, int price, int maxDiscount, int megapixels, bool interchangeableLens, int maxShutterSpeed)
            : base(company, name, price, maxDiscount, megapixels)
        {
            InterchangeableLens = interchangeableLens;
            MaxShutterSpeed = maxShutterSpeed;
        }

        public bool InterchangeableLens
        {
            get { return interchangeableLens; }
            set { interchangeableLens = value; }
        }

        public int MaxShutterSpeed
        {
            get { return maxShutterSpeed; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Max shutter speed cannot be negative");
                maxShutterSpeed = value;
            }
        }
        
        public override string ToString()
        {
            return $"DSLR: Компанія: {Company} | Назва: {Name} | Ціна: {Price} грн | Макс. знижка: {MaxDiscount}% | Мегапікселі: {Megapixels} МП | Змінний об'єктив: {InterchangeableLens} | Макс. витримка: {MaxShutterSpeed} с";
        }
    }
}