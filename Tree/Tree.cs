﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class Tree : ITree
    {
        public TreeNode root { get; set; }
        private TreeNode parent;
        bool direction;
        public int count { get; set; }

        public void AddItem(int value)
        {
            if (root == null)
            {// дерево пустое, заполняем 1-й элемент
                root = new TreeNode() { Value = value, LeftChild = null, RightChild = null };
            }
            else
            {
                TreeNode tmpNode = root;
                while (true)
                {
                    if (value > tmpNode.Value)
                    {// идём на право
                        if (tmpNode.RightChild != null)
                        {// занято
                            tmpNode = tmpNode.RightChild;
                            continue;
                        }
                        else
                        {
                            tmpNode.RightChild = new TreeNode() { Value = value, LeftChild = null, RightChild = null };
                            break;
                        }
                    }
                    else
                    {// идём на лево
                        if (tmpNode.LeftChild != null)
                        {// занято
                            tmpNode = tmpNode.LeftChild;
                            continue;
                        }
                        else
                        {
                            tmpNode.LeftChild = new TreeNode() { Value = value, LeftChild = null, RightChild = null };
                            break;
                        }
                    }
                }
            }
            count++;
        }

        public TreeNode GetNodeByValue(int value)
        {
            if (root == null)
            {
                throw new Exception("Tree is empty");
            }
            TreeNode tmpNode = root;
            while (tmpNode.Value != value)
            {
                if (value > tmpNode.Value && tmpNode.RightChild != null)
                {// идём на право
                    parent = tmpNode;
                    direction = true;
                    tmpNode = tmpNode.RightChild;
                }
                else if (value < tmpNode.Value && tmpNode.LeftChild != null)
                {// идём на лево
                    parent = tmpNode;
                    direction = false;
                    tmpNode = tmpNode.LeftChild;
                }
                else
                {
                    return null;
                }
            }
            return tmpNode;
        }

        public TreeNode GetRoot()
        {
            return root;
        }

        public void PrintTree()
        {
            var bufer = new Queue<NodeInfo>();
            var returnList = new List<NodeInfo>();
            int depth = 1;
            returnList.Add(new NodeInfo() { Node = root, Depth = depth });
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

            int counter = returnList.Count - 1;
            while (returnList[counter].Node == null)
            {// удаляем nulls из хвоста
                returnList.RemoveAt(counter);
                counter--;
            }

            var strings = new List<string>( returnList[returnList.Count - 1].Depth );

            for (int i = 0; i < strings.Capacity; i++)
            {
                strings.Add("");
            }

            string space = "ss", emptyElement = "  ";
            foreach (var nodeInfo in returnList)
            {// формируем строки для дальнейшего вывода
                if ( strings[nodeInfo.Depth - 1] !=  "" )
                {
                    strings[nodeInfo.Depth - 1] += space;
                }
                if (nodeInfo.Node == null)
                {
                    strings[nodeInfo.Depth - 1] += emptyElement;
                }
                else
                {
                    strings[nodeInfo.Depth - 1] += nodeInfo.Node.Value;
                }
            }

            strings[strings.Count - 1] = strings[strings.Count - 1].Replace("ss", "  ");
            int strLength = 2 * ((int)Math.Pow(2, strings.Count - 1) * 2 - 1); // количество символов в последней строке

            strings[0] = new string(' ', (strLength - strings[0].Length) / 2) + strings[0];

            for (int i = 1; i < strings.Count - 1; i++)
            {
                int qtySpaces = (strLength - (int)(Math.Pow(2, i) * 2)) / (int)Math.Pow(2, i);
                string spaceDivider = new string(' ', qtySpaces+1);
                strings[i] = new string(' ', qtySpaces / 2) + strings[i].Replace("ss", spaceDivider);
            }
            foreach (var item in strings)
            {
                Console.WriteLine("\n");
                Console.WriteLine(item);
            }
        }

        public void RemoveItem(int value)
        {
            var nodeToDel = GetNodeByValue(value);
            if (nodeToDel == null)
            {
                throw new Exception("Element not found");
            }
            // у удаляемого элемента нет потомков
            if (nodeToDel.LeftChild == null && nodeToDel.RightChild == null)
            {
                if (direction)
                {
                    parent.RightChild = null;
                }
                else
                {
                    parent.LeftChild = null;
                }
            }
            // у удаляемого элемента потомок справа
            else if (nodeToDel.LeftChild == null && nodeToDel.RightChild != null)
            {
                if (direction)
                {
                    parent.RightChild = nodeToDel.RightChild;
                }
                else
                {
                    parent.LeftChild = nodeToDel.RightChild;
                }
            }
            // у удаляемого элемента потомок слева
            else if (nodeToDel.LeftChild != null && nodeToDel.RightChild == null)
            {
                if (direction)
                {
                    parent.RightChild = nodeToDel.LeftChild;
                }
                else
                {
                    parent.LeftChild = nodeToDel.LeftChild;
                }
            }
            // он весь в потомках
            // Решение: взять любого сына с одним внуком, либо если таких нет, то стыкуем поддеревья
            // PS Если берем сына справа то у него не должно быть ветви влево и наоборот

            else
            {
                if (nodeToDel.LeftChild.RightChild == null)
                {// левый подходит
                    nodeToDel.LeftChild.RightChild = nodeToDel.RightChild;
                    if (direction)
                    {
                        parent.RightChild = nodeToDel.LeftChild;
                    }
                    else
                    {
                        parent.LeftChild = nodeToDel.LeftChild;
                    }
                }
                else if (nodeToDel.RightChild.LeftChild == null)
                {// правый подходит
                    nodeToDel.RightChild.LeftChild = nodeToDel.LeftChild;
                    if (direction)
                    {
                        parent.RightChild = nodeToDel.RightChild;
                    }
                    else
                    {
                        parent.LeftChild = nodeToDel.RightChild;
                    }
                }
                else
                {   //ни один не подходит
                    //1 определяем результирующую длину плечей
                    //2 стыкуем плечи с минимальной суммарной длиной

                    int rightLength, leftLength;

                    (rightLength, leftLength) = ReconnectBranches(nodeToDel);

                    //if (leftLength >= rightLength)
                    //{// стыкуем правые плечи

                    //}
                    //else
                    //{// стыкуем левые плечи

                    //}






                }
            }



            count--;
        }

        private (int, int) ReconnectBranches(TreeNode nodeToDel)
        {
            int rightLength = 0, leftLength = 0;
            TreeNode tmpNode = nodeToDel;
            TreeNode right1, right2, left1, left2;

            while (tmpNode.LeftChild != null)
            {
                leftLength++;
                tmpNode = tmpNode.LeftChild;
            }
            left2 = tmpNode;
            tmpNode = nodeToDel.RightChild;
            while (tmpNode.LeftChild != null)
            {
                leftLength++;
                tmpNode = tmpNode.LeftChild;
            }
            left1 = tmpNode;



            tmpNode = nodeToDel;
            while (tmpNode.RightChild != null)
            {
                rightLength++;
                tmpNode = tmpNode.RightChild;
            }
            right2 = tmpNode;
            tmpNode = nodeToDel.LeftChild;
            while (tmpNode.RightChild != null)
            {
                rightLength++;
                tmpNode = tmpNode.RightChild;
            }
            right1 = tmpNode;

            if (leftLength >= rightLength)
            {// стыкуем правые плечи
                right1.RightChild = nodeToDel.RightChild;
                if (direction)
                {
                    parent.RightChild = right1;
                }
                else
                {
                    parent.LeftChild = right1;
                }
            }
            else
            {// стыкуем левые плечи
                left1.LeftChild = nodeToDel.LeftChild;
                if (direction)
                {
                    parent.RightChild = left1;
                }
                else
                {
                    parent.LeftChild = left1;
                }
            }



            return (rightLength, leftLength);
        }





    }
}
