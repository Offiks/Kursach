using System;

namespace Kursach.Classes
{
    internal class Camera
    {
        private int megapixels;
        private double sensorSize;

        public Camera(int megapixels, double sensorSize)
        {
            Megapixels = megapixels;
            SensorSize = sensorSize;
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

        public double SensorSize
        {
            get { return sensorSize; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Sensor size cannot be negative");
                sensorSize = value;
            }
        }
    }
}
