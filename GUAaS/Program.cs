using Part1;
using System;
//TODO Требуется реализовать класс двусвязного списка и операции вставки, удаления и поиска элемента в нём в соответствии с интерфейсом
namespace GUAaS
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            var list = new LinkedList();

            for (int i = 1; i <= 5; i++)
            {
                list.AddNode(i);
            }

            foreach (var item in list.ToArray())
            {
                Console.WriteLine(item); ;
            }

            //Node n = list.FindNode(6);
            list.RemoveNode(4);
            //list.RemoveNode(4);
            list.RemoveNode(3);
            list.RemoveNode(2);
            list.RemoveNode(1);
            list.RemoveNode(0);

            foreach (var item in list.ToArray())
            {
                Console.WriteLine("* "+ item);
            }

            list.AddNode(1);
            list.AddNode(2);
            list.AddNode(3);
            list.AddNode(4);
            list.AddNode(5);
            list.AddNode(6);
            list.AddNode(7);

            foreach (var item in list.ToArray())
            {
                Console.WriteLine(item); ;
            }






        }
    }
}
