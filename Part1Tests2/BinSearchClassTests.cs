using Microsoft.VisualStudio.TestTools.UnitTesting;
using GUAaS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUAaS.Tests
{
    [TestClass()]
    public class BinSearchClassTests
    {
        [TestMethod()]
        public void BinarySearchTest_Create1000RndElements_ExpectedFound()
        {
            var rnd = new Random();
            int arraySize = 1000;
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

            int index = rnd.Next(arraySize);
            int expected = arr[index];
            int actual = BinSearchClass.BinarySearch(arr, expected);

            Console.WriteLine($"\nInit index: {index},\nSearching value: {expected}\nFound at: {actual}");

            Assert.AreEqual(expected, arr[actual]);
        }

        [TestMethod()]
        public void BinarySearchTest_Create1000RndElements_ExpectedNotFound()
        {
            var rnd = new Random();
            int arraySize = 1000;
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

            int expected = -1;
            int actual = BinSearchClass.BinarySearch(arr, -99);

            Assert.AreEqual(expected, actual);
        }


    }
}