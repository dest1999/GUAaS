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
        public static void FileReader(string fileName)
        {
            BinaryReader reader = new BinaryReader(File.OpenRead(fileName));

            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                Console.Write(reader.ReadInt32() + " ");
            }

            reader.Close();
        }

        public static void RandomIntFileWriter(string fileName, long elementsQty)
        {
            Random rnd = new();
            BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create));
            //int tmp;
            for (long i = 0; i < elementsQty; i++)
            {
                //tmp = rnd.Next();
                //Console.Write(tmp + " ");
                writer.Write(rnd.Next());
            }

            writer.Close();
        }
    }
}
