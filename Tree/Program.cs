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
        }
    }
}
