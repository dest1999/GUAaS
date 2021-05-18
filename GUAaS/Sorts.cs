using System;
using System.IO;
using System.Collections.Generic;

namespace GUAaS
{
    public class Bucket : IComparable<Bucket>
    {
        public int Min { get; }
        public int Max { get; }
        public List<int> list { get; }
        public int Count => list.Count;
        public Bucket()
        {
            list = new List<int>();
        }
        public Bucket(int min, int max) : this()
        {
            Min = min;
            Max = max;
        }
        public Bucket(int min, int max, int value) : this()
        {
            Min = min;
            Max = max;
            list.Add(value);
        }

        public void Add(int Value)
        {
            if (Value == Min)
            {// вставляемый эл-т имеет минимальное значение
                list.Insert(0, Value);
            }
            else
            {// Список изначально формируется сортированым, для поиска места вставки эл-та используем BinarySearch
                int index = list.BinarySearch(Value);
                if (index < 0)
                {
                    list.Insert(~index, Value);
                }
                else
                {
                    list.Insert(index, Value);
                }
            }
        }
        public int CompareTo(Bucket bucket)
        {
            if (this.Min > bucket.Min)
                return 1;
            if (this.Min < bucket.Min)
                return -1;
                
            return 0;
                
        }

    }

    public class BucketStore
    {
        List<Bucket> store;
        int[] inputArray;
        public BucketStore(int[] arr)
        {
            store = new();
            /*
            if (arr.Length > 0)
            {
                int min = arr[0] / 10 * 10;
                int max = min + 10;
                store.Add(new Bucket(min, max));
            }
            else
            {
                throw new Exception("Input array can not be empty");
            }
            */
            inputArray = arr;
            Distribution();
        }

        private void Distribution()
        {
            foreach (var item in inputArray)
            {
                bool added = false;
                foreach (var bucket in store)
                {
                    if (item >= bucket.Min && item < bucket.Max)
                    {
                        bucket.Add(item);
                        added = true;
                        break;
                    }
                }
                if (!added)
                {
                    int min = item / 10 * 10;
                    int index = store.BinarySearch(new Bucket(min, min + 10));
                    if (index < 0)
                    {
                        store.Insert(~index, new Bucket(item / 10 * 10, (item / 10 * 10) + 10, item));
                    }
                    else
                    {
                        store.Insert(index, new Bucket(item / 10 * 10, (item / 10 * 10) + 10, item));
                    }
                }
            }
        }

        public override string ToString()
        {
            string str = "";
            foreach (var bucket in store)
            {
                foreach (var item in bucket.list)
                {
                    str += item + " ";
                }
            }

            return str;
        }

        public int[] ToArray()
        {
            int index = 0;
            int lenght = 0;
            foreach (var item in store)
            {
                lenght += item.Count;
            }

            int[] outArr = new int[lenght];
            foreach (var bucket in store)
            {
                bucket.list.ToArray().CopyTo(outArr, index);
                index += bucket.Count;
            }
            return outArr;
        }

    }

    public class Sorts
    {


        static void Main(string[] args)
        {
            #region BucketSorting
            //Random rnd = new();
            //int[] arr = new int[300];
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    arr[i] = rnd.Next(30000);
            //}
            //BucketStore b1 = new(arr);
            //Array.Sort(arr);
            //foreach (var item in arr)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine("\n");
            ////Console.WriteLine(b1.ToString());

            //var bucketArr = b1.ToArray();
            //foreach (var item in bucketArr)
            //{
            //    Console.Write(item + " ");
            //}
            #endregion




            #region File Read-Write
            //Console.Clear();
            //Console.WriteLine("Begin random write: " + DateTime.Now.ToLocalTime());
            //string fileName = "RandomIntegers.bin";
            //RndIntFileReaderWriter.RandomIntFileWriter(fileName, 40_000_000_000);
            //Console.WriteLine("Writing complete: " + DateTime.Now.ToLocalTime());
            //RandomIntFileWriter(fileName, 100);
            //Console.WriteLine("\n");
            //RndIntFileReaderWriter.FileReader(fileName);
            //Console.WriteLine("\n");
            #endregion

            
            RndIntFileReaderWriter.InitExtSort();



        }


    }
}
