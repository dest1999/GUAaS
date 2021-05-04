using System;
using System.Collections.Generic;

namespace BinaryTree
{
    public class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();
            int tmp;

            #region отладка с заполнением случайными числами
            
            Random rnd = new Random();
            Console.Write("Sequence is: ");
            for (int i = 0; i < rnd.Next(10, 100); i++)
            {
                tmp = rnd.Next(10, 100);
                Console.Write(tmp + " ");
                tree.AddItem(tmp);
            }


            #endregion

            #region отладка с предзаданными значениями
            //Console.Clear();
            //tree.Clear();
            //int[] arr = { 48, 22, 92, 35, 22, 57, 31, 10 , 49, 65, 19, 23, 50, 64, 76, 86, 57, 56, 52, 75, 72, 71, 81 };
            //foreach (var item in arr)
            //{
            //    Console.Write(item + " ");
            //    tree.AddItem(item);
            //}

            #endregion


            Console.WriteLine("\nBFS in action:");
            tmp = 0;
            foreach (var item in BFS(tree))
            {
                Console.Write($"Step {++tmp}: ");
                Console.WriteLine($"node value { (item.Node != null ? item.Node.Value : "is empty") } on {item.Depth} level");
            }
            Console.ReadKey();

            Console.WriteLine("\n\nDFS in action:");
            tmp = 0;
            foreach (var item in DFS(tree))
            {
                Console.Write($"Step {++tmp}: ");
                Console.WriteLine($"node value { (item.Node != null ? item.Node.Value : "is empty") } on {item.Depth} level");
            }
        }

        //TODO Реализуйте DFS и BFS для дерева с выводом каждого шага в консоль.
        public static List<NodeInfo> BFS(ITree tree)
        {
            var bufer = new Queue<NodeInfo>();
            var returnList = new List<NodeInfo>(); //в коллекции сохраняются шаги, выведение в консоль вне метода
            int depth = 1;
            returnList.Add(new NodeInfo() { Node = tree.GetRoot(), Depth = depth });
            bufer.Enqueue(returnList[0]);

            while (bufer.Count != 0)
            {
                var element = bufer.Dequeue();
                
                depth = element.Depth + 1;

                returnList.Add(new NodeInfo() { Node = element.Node.LeftChild, Depth = depth });
                
                if (element.Node.LeftChild != null)
                {
                    bufer.Enqueue(returnList[returnList.Count - 1]);
                }
                
                returnList.Add(new NodeInfo() { Node = element.Node.RightChild, Depth = depth });

                if (element.Node.RightChild != null)
                {
                    bufer.Enqueue(returnList[returnList.Count - 1]);
                }

            }
            RemoveAllNullNodes(ref returnList);
            //RemoveEmptyOnTail(ref returnList);
            return returnList;
        }

        public static List<NodeInfo> DFS(ITree tree)
        {
            var bufer = new Stack<NodeInfo>();
            var returnList = new List<NodeInfo>(); //в коллекции сохраняются шаги, выведение в консоль вне метода
            int depth = 1;
            returnList.Add(new NodeInfo() { Node = tree.GetRoot(), Depth = depth });
            bufer.Push(returnList[0]);

            while (bufer.Count != 0)
            {
                var element = bufer.Pop();

                depth = element.Depth + 1;

                returnList.Add(new NodeInfo() { Node = element.Node.LeftChild, Depth = depth });

                if (element.Node.LeftChild != null)
                {
                    bufer.Push(returnList[returnList.Count - 1]);
                }

                returnList.Add(new NodeInfo() { Node = element.Node.RightChild, Depth = depth });

                if (element.Node.RightChild != null)
                {
                    bufer.Push(returnList[returnList.Count - 1]);
                }

            }
            RemoveAllNullNodes(ref returnList);
            //RemoveEmptyOnTail(ref returnList);
            return returnList;
        }

        private static void RemoveAllNullNodes(ref List<NodeInfo> returnList)
        {
            int counter = 0;
            var emptyNodesList = new List<int>();
            foreach (var item in returnList)
            {
                if (item.Node == null)
                {
                    emptyNodesList.Add(counter);
                }
                counter++;
            }

            returnList.RemoveAll(NodeIsNull);

        }

        private static bool NodeIsNull(NodeInfo node)
        {
            return node.Node == null;
        }

        private static void RemoveEmptyOnTail(ref List<NodeInfo> returnList)
        {
            int counter = returnList.Count - 1;
            while (returnList[counter].Node == null)
            {
                returnList.RemoveAt(counter);
                counter--;
            }

        }
    }
}
