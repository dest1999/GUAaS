using System;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();
            int tmp;

            int[] arr = { 65, 33, 51, 88, 83, 57, 46, 71, 22, 99 }; //{23, 41, 62, 73, 17, 32, 23, 41, 43, 11};


            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
                tree.AddItem(arr[i]);
            }
            Console.WriteLine("\n****************************");
            Console.WriteLine("Tree count: " + tree.count);
            tree.PrintTree();
        }
    }
}
