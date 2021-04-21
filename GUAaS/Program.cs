using Part1;
using System;
//TODO Требуется реализовать класс двусвязного списка и операции вставки, удаления и поиска элемента в нём в соответствии с интерфейсом
namespace GUAaS
{
    class Program : BinSearchClass
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int arraySize = 1;
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


            int result = BinarySearch(arr, 10);
            Console.WriteLine((result == -1) ? "not found" : result);




        }
    }
}
