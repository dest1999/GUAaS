using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUAaS
{
    // Методы подготовки для External Sort
    public static class RndIntFileReaderWriter
    {
        static List<string> parts = new();

        static int[] RndGenerator(int qty, int min = 10, int max = 100)
        {
            Random rnd = new();
            int[] arr = new int[qty];
            for (int i = 0; i < qty; i++)
            {
                arr[i] = rnd.Next(min, max);
            }
            //после отладки убрать
            Console.WriteLine("Generate sequence");
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            //после отладки убрать
            return arr;
        }

        public static void FileReader(string fileName)
        {
            BinaryReader reader = new BinaryReader(File.OpenRead(fileName));

            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                Console.Write(reader.ReadInt32() + " ");
            }
            Console.WriteLine($"\nCompleted from file {fileName}\n");
            reader.Close();
        } // выводит содержимое файла на консоль, для отладки

        public static int[] FileReadAndDeleteFromTheEnd(string fileName, long qtyElements)
        {// считали и передали инфу в массиве, то что считано - удалили из файла, начинаем с хвоста

            BinaryReader reader = new BinaryReader(File.OpenRead(fileName));
            if (reader.BaseStream.Length / 4 < qtyElements)
            {// можем ли считать желаемое кол-во эл-тов, если нет - уменьшаем до максимально возможного
                qtyElements = reader.BaseStream.Length / 4;
            }
            reader.BaseStream.Position = reader.BaseStream.Length - qtyElements * 4; // работаем с int32, => * 4

            int[] arr = new int[qtyElements];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = reader.ReadInt32();
                //Console.Write(arr[i] + " "); //for debugging
            }
            reader.Close();

            BinaryWriter writer = new(File.Open(fileName, FileMode.Open));
            writer.BaseStream.SetLength(writer.BaseStream.Length - qtyElements * 4);
            writer.Close();

            #region ForDebuggin
            //Console.WriteLine("After read and delete");
            //BinaryReader reader1 = new BinaryReader(File.OpenRead(fileName));
            //while (reader1.BaseStream.Position != reader1.BaseStream.Length)
            //{
            //    Console.Write(reader1.ReadInt32() + " ");
            //}
            //reader1.Close();
            //Console.WriteLine();
            #endregion

            return arr;
        }

        public static void IntFileWriter(string fileName, int[] arr)
        {
            BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create));

            foreach (var item in arr)
            {
                writer.Write(item);
            }
            
            writer.Close();
            Console.WriteLine("\nWriting to file completed\n");
        }

        static string ReversiveWriteArrToFile(int[] arr)
        {
            string fileName = Path.GetTempFileName().Split('\\')[^1]; // имя файла для части отсортированного массива случайно

            BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create));
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                writer.Write(arr[i]);
            }
            writer.Close();
            return fileName;
        }




        public static void InitExtSort()
        {
            string fileName = "TestingRandomIntegers.bin";

            IntFileWriter(fileName, RndGenerator(200));

            long fileLength;
            do
            {
                fileLength = new FileInfo(fileName).Length;
                int[] arr = FileReadAndDeleteFromTheEnd(fileName, 22); // 22 - кол-во считываемых из файла значений
                BucketStore b1 = new(arr); // метод сортировки из ДЗ 8-1
                arr = b1.ToArray();
                parts.Add(ReversiveWriteArrToFile(arr));
            } while (fileLength > 4);// длина файла не должна быть меньше 4 байт

            foreach (var item in parts)
            {
                FileReader(item);
            }






        }

    }
}
