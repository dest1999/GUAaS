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

            for (int i = 0; i < 16; i++)
            {
                tmp = rnd.Next(10, 100);
                Console.Write(tmp + " ");
                tree.AddItem(tmp);
            }
            Console.WriteLine("\n****************************");
            Console.WriteLine("Tree count: " + tree.count);
            tree.PrintTree();
            Console.WriteLine();
        }
    }
}
