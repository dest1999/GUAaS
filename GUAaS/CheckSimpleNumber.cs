using System;

namespace GUAaS
{
    public class CheckSimpleNumber
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

        public static bool IsNumberIsSimple(int n) //сложность метода O(n)
        {
            int d = 0,
                i = 2;

            while (i < n)
            {
                if (n % i == 0)
                {
                    d++;
                }
                i++;
            }

            return d == 0 ? true : false;
        }
    }
}
