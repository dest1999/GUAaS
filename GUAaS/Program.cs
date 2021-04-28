using System;
using System.IO;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

//Заполните массив и HashSet случайными строками, не менее 10 000 строк. Строки можно сгенерировать.
//Потом выполните замер производительности проверки наличия строки в массиве и HashSet. Выложите код и результат замеров
namespace GUAaS
{
    public class Bench
    {
        static int size = 10_000;
        static string[] strArray = new string [size];
        static string strToFind;
        static HashSet<string> hashset;
        static Random rnd = new Random();
        static bool foundInArray, foundInHashSet;

        public Bench()
        {
            FillRandomString();
            strToFind = strArray[rnd.Next(strArray.Length)];
        }

        [Benchmark]
        public void FindInArrayByIndexOf()
        {
            Array.IndexOf(strArray, strToFind);
        }

        [Benchmark]
        public void FindInArray()
        {
            foundInArray = false;
            foreach (var item in strArray)
            {
                if (item == strToFind)
                {
                    foundInArray = true;
                    break;
                }
            }

        }
        [Benchmark]
        public void FindInHashSet()
        {
            if (hashset.Contains(strToFind))
            {
                foundInHashSet = true;
            }
            else
            {
                foundInHashSet = false;
            }
        }




        private void FillRandomString()
        {
            hashset = new HashSet<string>();
            for (int i = 0; i < strArray.Length; i++)
            {
                strArray[i] = Path.GetRandomFileName().Replace(".", string.Empty) +
                              Path.GetRandomFileName().Replace(".", string.Empty) +
                              Path.GetRandomFileName().Replace(".", string.Empty) +
                              Path.GetRandomFileName().Replace(".", string.Empty);

                hashset.Add(strArray[i]);
            }
        }

    }



    public class Program
    {


        static void Main(string[] args)
        {
            
            BenchmarkRunner.Run(typeof(Program).Assembly);
        }

    }
}
