using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Tree : ITree
    {
        public TreeNode Root { get; set; }
        private TreeNode parent;
        bool direction; // право true, лево false
        public int count { get; set; }

        public void Clear()
        {
            Root = null;
        }
        public void AddItem(int value)
        {
            if (Root == null)
            {// дерево пустое, заполняем 1-й элемент
                Root = new TreeNode() { Value = value, LeftChild = null, RightChild = null };
            }
            else
            {
                TreeNode tmpNode = Root;
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
            if (Root == null)
            {
                throw new Exception("Tree is empty");
            }
            TreeNode tmpNode = Root;
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
            return Root;
        }

        public void PrintTree()
        {
            //Пока не готово
            //var bufer = new Queue<NodeInfo>();
            //var returnList = new List<NodeInfo>();
            ////var root = new NodeInfo() { Node = Root };
            //bufer.Enqueue(new NodeInfo() { Node = Root, Depth = 1 });
            //int depth;

            //while (bufer.Count != 0)
            //{
            //    var element = bufer.Dequeue();
            //    returnList.Add(element);

            //    depth = element.Depth + 1;

            //    if (element.Node.LeftChild != null)
            //    {
            //        bufer.Enqueue(new NodeInfo() { Node = element.Node.LeftChild, Depth = depth });
            //    }
            //    else
            //    {
            //        returnList.Add(new NodeInfo() { Node = null, Depth = depth });
            //    }

            //    if (element.Node.RightChild != null)
            //    {
            //        bufer.Enqueue(new NodeInfo() { Node = element.Node.LeftChild, Depth = depth });
            //    }
            //    else
            //    {
            //        returnList.Add(new NodeInfo() { Node = null, Depth = depth });
            //    }

            //}


            //foreach (var item in returnList)
            //{
            //    Console.WriteLine($"{item.Depth} {(item.Node != null ? item.Node.Value : 0 )} ");
            //}
            Console.WriteLine("Not ready");

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

            while(tmpNode.LeftChild != null)
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
