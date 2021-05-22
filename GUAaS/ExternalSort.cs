using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUAaS
{
    // Методы подготовки для External Sort
    class PartialFile
    {
        public int partMinValue;
        public string partFileName;
    }
    public static class ExternalSort
    {

        static int? minValue; // значение будет определено при анализе частичных файлов
        static long partSize = 22; // количество элементов в частичном файле
        static int elementSize = 4; // объем элемента в байтах, в данном случае инт = 4 байта
        static string unsortedFileName = "TestingRandomIntegers.bin";
        static List<PartialFile> sortedFileParts = new();

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
            BinaryReader reader = new(File.OpenRead(fileName));

            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                Console.Write(reader.ReadInt32() + " ");
            }
            Console.WriteLine($"Completed from file {fileName}\n");
            reader.Close();
        } // выводит содержимое файла на консоль, для отладки

        static int[] FileReadAndDeleteFromTheEnd(string fileName)
        {// считали и передали инфу в массиве, то что считано - удалили из файла, начинаем с хвоста
            BinaryReader reader = new(File.OpenRead(fileName));
            int[] arr;

            if (minValue == null)
            {// если исходный файл не разбит до конца
                if (reader.BaseStream.Length / elementSize < partSize)
                {// можем ли считать желаемое кол-во эл-тов, если нет - уменьшаем кол-во считываемых эл-тов до максимально возможного
                    partSize = reader.BaseStream.Length / elementSize;
                }
                reader.BaseStream.Position = reader.BaseStream.Length - partSize * elementSize;

                arr = new int[partSize];
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = reader.ReadInt32();
                    //Console.Write(arr[i] + " "); //for debugging
                }
            }
            else
            {// исходный файл разбит полностью, части отсортированы
                //Console.WriteLine("*** Combining files ***");
                List<int> outList = new();
                reader.BaseStream.Position = reader.BaseStream.Length - elementSize;
                int tmp;

                for (long i = reader.BaseStream.Length - elementSize; i >= 0; i -= elementSize)
                {
                    reader.BaseStream.Position = i;
                    tmp = reader.ReadInt32();

                    if (tmp == minValue)
                    {
                        outList.Add(tmp);
                    }
                    else
                    {
                        break;
                    }
                }
                arr = outList.ToArray();
            }
            reader.Close();

            BinaryWriter writer = new(File.Open(fileName, FileMode.Open));
            writer.BaseStream.SetLength(writer.BaseStream.Length - arr.Length * elementSize);
            if (writer.BaseStream.Length < elementSize && fileName != unsortedFileName )
            {
                writer.Close();
                //File.Delete(fileName);
            }
            else
            {
                writer.Close();
            }

            return arr;
        }

        public static void IntFileWriter(string fileName, int[] arr)
        {
            BinaryWriter writer = new(File.Open(fileName, FileMode.OpenOrCreate));
            writer.BaseStream.Position = writer.BaseStream.Length;

            foreach (var item in arr)
            {
                writer.Write(item);
            }
            writer.Close();
        }

        static string ReversiveWriteArrToFile(int[] arr)
        {
            string fileName = Path.GetTempFileName().Split('\\')[^1]; // имя файла для части отсортированного массива случайно

            BinaryWriter writer = new(File.Open(fileName, FileMode.Create));
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                writer.Write(arr[i]);
            }
            writer.Close();
            return fileName;
        }

        static int FindMinElement()
        {
            int tmp, min = int.MaxValue;

            for (int i = 0; i < sortedFileParts.Count; i++)
            {
                var reader = new BinaryReader(File.OpenRead(sortedFileParts[i].partFileName));
                if (reader.BaseStream.Length < elementSize)
                {
                    sortedFileParts.RemoveAt(i);
                }
                reader.BaseStream.Position = reader.BaseStream.Length - elementSize;
                tmp = reader.ReadInt32();
                sortedFileParts[i].partMinValue = tmp;
                //Console.WriteLine($"file: {sortedFileParts[i].partFileName}, last element: {tmp}"); //для отладки
                if (min > tmp)
                {
                    min = tmp;
                }
                reader.Close();
            }
            return min;
        }

        static void CombineFiles()
        {


            foreach (var item in sortedFileParts)
            {
                IntFileWriter(unsortedFileName, FileReadAndDeleteFromTheEnd(item.partFileName));
            }
            CheckForEmptyFileParts();
        }

        static void CheckForEmptyFileParts()
        {
            for (int i = sortedFileParts.Count - 1; i >= 0; i--)
            {
                FileInfo fi = new(sortedFileParts[i].partFileName);
                if (fi.Length < elementSize)
                {// из файла больше нечего считывать, удаляем
                    sortedFileParts.RemoveAt(i);
                }
            }
        }

        static bool IsSequenceCorrect(string fileName)
        {
            BinaryReader reader = new(File.OpenRead(fileName));
            int b, a = reader.ReadInt32();
            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                b = reader.ReadInt32();
                if ( a > b )
                {
                    reader.Close();
                    return false;
                }
            }
            reader.Close();
            return true;
        }

        public static void InitExtSort()
        {
            if (File.Exists(unsortedFileName))
            {
                File.Delete(unsortedFileName);
            }
            IntFileWriter(unsortedFileName, RndGenerator(200, 10, 20));
            long fileLength;
            do
            { // разбиваем исходный файл с сортировкой
                fileLength = new FileInfo(unsortedFileName).Length;
                int[] arr = FileReadAndDeleteFromTheEnd(unsortedFileName);
                BucketStore b1 = new(arr); // метод сортировки из ДЗ 8-1
                arr = b1.ToArray();
                if (arr.Length > 0)
                {// пишем в файл если массив не пустой
                    sortedFileParts.Add( new PartialFile{ partFileName = ReversiveWriteArrToFile(arr) });
                }
            } while (fileLength > elementSize);// длина файла не должна быть меньше 4 байт

            minValue = FindMinElement();

            while (sortedFileParts.Count > 0)
            { // цикл сборки временных файлов
                //Console.WriteLine("\nMinimums: " + minValue); // для отладки
                CombineFiles();
                minValue = FindMinElement();
            }

            Console.WriteLine("Sorted file:");
            FileReader(unsortedFileName);
            Console.WriteLine(IsSequenceCorrect(unsortedFileName) );
        }
    }
}
