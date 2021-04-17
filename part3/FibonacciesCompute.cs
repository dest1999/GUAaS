using System;

namespace part3
{
    public class FibonacciesCompute
    {
        static void Main(string[] args)
        {
            
            const int n = 2;//вычисляем от 46

            //далее сравнение производительности цикла и рекурсии
            DateTime timeRec = DateTime.Now;
            int resultR = FibonacciRecurse(n);
            TimeSpan tsRec = DateTime.Now - timeRec;

            DateTime timeCicle = DateTime.Now;
            int resultC = FibonacciCycle(n);
            TimeSpan tsCicle = DateTime.Now - timeCicle;

            Console.WriteLine($"Recursively: {resultR}, time: {tsRec}");
            Console.WriteLine($"Cicle: {resultC}, time {tsCicle}");
        }

        public static int FibonacciCycle(int n) //сложность метода O(n)
        {
            if (n < 0)
            {
                throw new Exception("Argument can not be negative");
            }

            int a = 0, b = 1, tmp;

            for (int i = 0; i < n; i++)
            {
                tmp = a;
                a = b;
                b += tmp;
            }

            return a;

        }

        public static int FibonacciRecurse(int n) //сложность метода O(n^2)
        {
            if (n < 0)
            {
                throw new Exception("Argument can not be negative");
            }

            if (n == 0 || n == 1)
            {
                return n;
            }
            else
            {
                return FibonacciRecurse(n - 1) + FibonacciRecurse(n - 2);
            }
        }
    }
}
