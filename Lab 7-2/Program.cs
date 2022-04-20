using System;

namespace Lab_7_2
{
    delegate double Operation(double a, double b);
    delegate double Power(double a, double b);
    class Program
    {
        static double Addition(double a, double b)
        {
            return a + b;
        }

        static double Mul(double a, double b)
        {
            return a * b;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Operation add = Addition;
            double result = add.Invoke(3, 2);
            Console.WriteLine(result);
            add = Mul;
            Console.WriteLine(add.Invoke(3, 2));
            Func<double, double, double> Operator = Addition;
            Func<double, double, double> Div = delegate (double x, double y)
            {
                return x / y;

            };

            Func<int> RandomInt = delegate ()
            {
                return new Random().Next(30);
            };
            Console.WriteLine(RandomInt);

            Predicate<int> InRangeFrom0To100 = delegate (int value)
            {
                return value >= 0 && value <= 100;
            };
            Console.WriteLine(InRangeFrom0To100.Invoke(45));
            Func<int, int, int, bool> InRange = delegate (int value, int min, int max)
            {
                return value >= min && value <= max;
            };


            Action<string, int> Print = delegate (string s, int a)
            {
                Console.WriteLine(s + a);
            };
            Print.Invoke("abc", 5);

            Operation AddLambda = (a, b) => a + b;
            Func<double, double, double> DivLambda = (x, y) =>
            {
                if (y != 0)
                {
                    return x / y;

                }
                else
                {
                    throw new Exception("y is zero!");
                }
            };
            Predicate<string> ThreeCharacters = text => text.Length == 3;

            Action<string> PrintUpperLambda = s => Console.WriteLine(s.ToUpper());
        }
        
    }
}
