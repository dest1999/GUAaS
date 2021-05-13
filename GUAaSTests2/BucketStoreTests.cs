﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GUAaS;

namespace GUAaS.Sorts.Tests
{
    [TestClass()]
    public class BucketStoreTests
    {
        [TestMethod()]
        public void ToArrayTest_GenerateRandomArrayAndSort_ExpectedArraysAreEqual()
        {
            int arrSize = 500;
            Random rnd = new();
            int[] arr = new int[arrSize];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(50);
            }

            BucketStore bucketStore = new BucketStore(arr);

            Array.Sort(arr);

            var actual = bucketStore.ToArray();

            CollectionAssert.AreEqual(arr, actual);

        }

    }
}