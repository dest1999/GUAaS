using System;

namespace GUAaS
{
    //TODO Для прямоугольного поля размера M на N клеток, подсчитать количество путей из верхней левой клетки в правую нижнюю. Известно что ходить можно только на одну клетку вправо или вниз
    public class FindWays
    {
        static Random rnd = new Random();
        const int N = 20;
        const int M = 37;
        const int countBarriers = 15; // количество препятствий
        static void Main(string[] args)
        {
            ulong?[,] arr = new ulong?[N, M];
            
            DeployBarrier(arr, countBarriers);
            ShowMap(arr);
            ulong? ways = WayTracer(arr);
            ShowMap(arr);

            if (ways > 0)
            {
                Console.WriteLine($"Total ways: {ways}");
            }
            else
            {
                Console.WriteLine("Path not found");
            }
        }

        public static ulong? WayTracer(ulong?[,] arr)
        {
            int i, j;
            ulong? currentWayCell;
            for (j = 0; j < arr.GetLength(1); j++)
            {
                arr[0, j] = 1; // Первая строка заполнена единицами
            }
            for (i = 1; i < arr.GetLength(0); i++)
            {
                arr[i, 0] = 1; //заполняем единицами 1-й столбец
                for (j = 1; j < arr.GetLength(1); j++)
                {
                    currentWayCell = (arr[i, j - 1] ?? 0) + (arr[i - 1, j] ?? 0);
                    if (arr[i, j] == 0 || currentWayCell == 0)
                    {
                        continue;
                    }
                    else
                    {
                        if (currentWayCell < (arr[i, j - 1] ?? 0) || currentWayCell < (arr[i - 1, j] ?? 0))
                        { // при подсчете произошло переполнение
                            throw new OverflowException("\nWarning! Wrong result, compute termination\nCheck input array size\n");
                        }
                        arr[i, j] = currentWayCell;
                    }
                }
            }
            return arr[arr.GetLength(0) - 1, arr.GetLength(1) - 1];
        }

        public static void DeployBarrier(ulong?[,] arr, int countBarriers)
        {// размещаем препятствия
            int x, y;
            while (countBarriers !=0)
            {
                x = rnd.Next(1, arr.GetLength(0));
                y = rnd.Next(1, arr.GetLength(1));

                if (arr[x, y] == 0 || (x == arr.GetLength(0) - 1 && y == arr.GetLength(1) - 1) )
                {// в ячейке уже есть препятствие ИЛИ ячейка является правой нижней
                    continue;
                }
                else
                {
                    arr[x, y] = 0;
                }
                countBarriers--;
            }
        }

        public static void ShowMap(ulong?[,] arr)
        {
            Console.WriteLine();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i,j] == 0 )
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("X");
                    }
                    else if (arr[i,j] == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("X");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("+");
                    }
                }
                Console.ResetColor();
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
