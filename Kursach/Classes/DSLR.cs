using System;


namespace Kursach.Classes
{
    internal class DSLR : Camera
    {
        private bool interchangeableLens;
        private int maxShutterSpeed;
        public DSLR(int megapixels, double sensorSize, bool interchangeableLens, int maxShutterSpeed)
            : base(megapixels, sensorSize)
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
    }
}