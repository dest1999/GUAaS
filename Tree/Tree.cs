using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Tree : ITree
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
            //Пока не готово
            var bufer = new Queue<NodeInfo>();
            var returnList = new List<NodeInfo>();
            //var root = new NodeInfo() { Node = Root };
            bufer.Enqueue(new NodeInfo() { Node = root, Depth = 1 });
            int depth;

            while (bufer.Count != 0)
            {
                var element = bufer.Dequeue();
                returnList.Add(element);

                depth = element.Depth + 1;

                if (element.Node.LeftChild != null)
                {
                    bufer.Enqueue(new NodeInfo() { Node = element.Node.LeftChild, Depth = depth });
                }
                else
                {
                    returnList.Add(new NodeInfo() { Node = null, Depth = depth });
                }

                if (element.Node.RightChild != null)
                {
                    bufer.Enqueue(new NodeInfo() { Node = element.Node.LeftChild, Depth = depth });
                }
                else
                {
                    returnList.Add(new NodeInfo() { Node = null, Depth = depth });
                }

            }


            foreach (var item in returnList)
            {
                Console.WriteLine($"{item.Depth} {(item.Node != null ? item.Node.Value : 0)} ");
            }
            //Console.WriteLine("Not ready");
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
            else
            {
                throw new NotImplementedException();
            }



            count--;
        }
    }
}
