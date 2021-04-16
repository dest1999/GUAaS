using System;

namespace GUAaS
{
    class Program
    {





        static void Main(string[] args)
        {
            int n;
            do
            {
                Console.Write("input number: ");
            } while (!int.TryParse(Console.ReadLine(), out n));
            Console.WriteLine($"number is simple: {IsNumberIsSimple(n)}");




        }

        private static bool IsNumberIsSimple(int n)
        {
            int d = 0,
                i = 2;

            while (i < n) //сложность O(n)
            {
                if (n % i == 0)
                {
                    d++;
                }
                i++;
            }

            if (d == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
