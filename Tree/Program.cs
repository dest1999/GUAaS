using System;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Tree tree = new Tree();
            int tmp;

            for (int i = 0; i < 20; i++)
            {
                tmp = rnd.Next(10, 100);
                Console.Write(tmp + " ");
                tree.AddItem(tmp);
            }
            Console.WriteLine();
            Console.WriteLine(tree.count);

            foreach (var item in TreeHelper.GetTreeInLine(tree))
            {
                Console.Write(item.Node.Value + " ");
            }

            Console.Clear();

            //TEST!!!!!!!!!!!!111111111111111111111
            tree.Clear();
            int[] arr = { 48, 22, 92, 35, 22, 57, 31, 10, 49, 65, 19, 23, 50, 64, 76, 86, 57, 56, 52, 75, 72, 71, 81 };
            foreach (var item in arr)
            {
                tree.AddItem(item);
            }


            foreach (var item in TreeHelper.GetTreeInLine(tree))
            {
                Console.WriteLine($"{item.Node.Value} - {item.Depth}");
            }

            Console.WriteLine("****************************");

            tree.PrintTree();




        }
    }
}
