using System;
namespace homework_two_one
{

    class Program
    {
        static double Fact(double n)
        {
            double fact = 1;
            for (int i = 1; i <= n; i++)
            {
                fact *= i;
            }
            return fact;
                
        }
        static void Main()
        {
            Console.Write("Введите число х: ");
            double x = Convert.ToDouble(Console.ReadLine());
            double result = 1 + x;


            while (result > Math.Pow(10, -6))
            {
                for (int i = 0; i < 10000000; i++)
                {
                    result = result + (Math.Pow(x, i) / Fact(i));
                }
                Console.WriteLine(result);
            }

            
        }
    }
}