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
        public void Sort()
        {
            list.Sort();
        }
        public void Add(int Value)
        {
            list.Add(Value);
        }

        public int CompareTo(Bucket bucket)
        {
            if (this.Min > bucket.Min)
                return 1;
            if (this.Min < bucket.Min)
                return -1;
                
            return 0;
                
        }

        public int Count => list.Count;
    }

    public class BucketStore
    {
        List<Bucket> store;
        int[] inputArray;
        public BucketStore(int[] arr)
        {
            store = new();

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
                    store.Add(new Bucket(item / 10 * 10, (item / 10 * 10) + 10, item));
                }
            }
            store.Sort();

            foreach (var item in store)
            {
                item.Sort();
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
            Random rnd = new();
            int[] arr = new int[300];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(30000);
            }
            BucketStore b1 = new(arr);
            Array.Sort(arr);
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");
            //Console.WriteLine(b1.ToString());

            var bucketArr = b1.ToArray();
            foreach (var item in bucketArr)
            {
                Console.Write(item + " ");
            }



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
            Console.ReadKey();



        }


    }
}
