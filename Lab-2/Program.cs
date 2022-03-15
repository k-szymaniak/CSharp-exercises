using System;

namespace Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
          
        }


        public abstract class Vehicle
        {
            public double Weight { get; init; }
            public int MaxSpeed { get; init; }
            protected int _mileage;
            public int Mealeage
            {
                get { return _mileage; }
            }
            public abstract decimal Drive(int distance);
            public override string ToString()
            {
                return $"Vehicle{{ Weight: {Weight}, MaxSpeed: {MaxSpeed}, Mileage: {_mileage} }}";
            }
        }
        public class Car : Vehicle
        {
            public bool isFuel { get; set; }
            public bool isEngineWorking { get; set; }
            public override decimal Drive(int distance)
            {
                if (isFuel && isEngineWorking)
                {
                    _mileage += distance;
                    return (decimal)(distance / (double)MaxSpeed);
                }
                return -1;
            }
            public override string ToString()
            {
                return $"Car{{Weight: {Weight}, MaxSpeed: {MaxSpeed}, Mileage: {_mileage}}}";
            }
        }
        public class Bicycle : Vehicle
        {
            public bool isDriver { get; set; }
            public override decimal Drive(int distance)
            {
                if (isDriver)
                {
                    _mileage += distance;
                    return (decimal)(distance / (double)MaxSpeed);
                }
                return -1;
            }
            public override string ToString()
            {
                return $"Bicycle{{Weight: {Weight}, MaxSpeed: {MaxSpeed}, Mileage: {_mileage}}}"; ;
            }
        }
    }
}
