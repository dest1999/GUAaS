using Part1;
using System;
//TODO Требуется реализовать класс двусвязного списка и операции вставки, удаления и поиска элемента в нём в соответствии с интерфейсом
namespace GUAaS
{
    class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();
            int arraySize = 300;
            var arr = new int[arraySize];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(100);
            }
            Array.Sort(arr);
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nfound value: ");

            int result = BinSearchClass.BinarySearch(arr, int.Parse(Console.ReadLine()));
            Console.WriteLine($"Index: { ((result == -1) ? "not found" : result) }");

        }
    }
}
