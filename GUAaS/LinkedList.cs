using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part1
{
    public class LinkedList : ILinkedList
    {
        int count = 0;
        Node head, tail;
        
        public int[] ToArray()
        {
            var arr = new int[count];
            Node currentNode = head;

            for (int i = 0; i < count; i++)
            {
                arr[i] = currentNode.Value;
                currentNode = currentNode.NextNode;
            }

            return arr;
        }

        public void AddNode(int value)
        {// добавляем в конец, сложность метода O(1)
            if (count == 0)
            {// empty, add first node
                head = tail = new Node()
                {
                    Value = value,
                    PrevNode = null,
                    NextNode = null
                };
            }
            else
            {
                tail = tail.NextNode = new Node()
                {
                    Value = value,
                    PrevNode = tail,
                    NextNode = null
                };
            }
            count++;
        }

        public void AddNodeAfter(Node node, int value)
        {// сложность метода O(1)
            if (count == 0 || node.NextNode == null)
            {
                AddNode(value);
            }
            else
            {
                node.NextNode = node.NextNode.PrevNode = new Node()
                {
                    PrevNode = node,
                    NextNode = node.NextNode,
                    Value = value
                };
                count++;
            }
        }

        public Node FindNode(int searchValue)
        {// сложность метода O(n)
            Node currentNode = head;
            while (currentNode.Value != searchValue && currentNode.NextNode != null)
            {
                currentNode = currentNode.NextNode;
            }
            if (currentNode.Value == searchValue)
            {
                return currentNode;
            }
            else
            {
                throw new Exception("Value not found");
            }
        }

        public int GetCount()
        {// сложность метода O(1)
            return count;
        }

        public void RemoveNode(int index)
        {// сложность метода O(n)
            if (index < count && index >= 0)
            {
                Node node = head;
                for (int i = 0; i < index; i++)
                {
                    node = node.NextNode;
                }
                RemoveNode(node);
            }
            else
            {
                throw new Exception("Index not found");
            }
        }

        public void RemoveNode(Node node)
        {// сложность метода O(1)
            if (count > 1)
            {
                if (node.PrevNode != null)
                {
                    node.PrevNode.NextNode = node.NextNode;
                }
                else
                {
                    head = node.NextNode;
                    node.NextNode.PrevNode = null;
                }

                if (node.NextNode != null)
                {
                    node.NextNode.PrevNode = node.PrevNode;
                }
                else
                {
                    tail = node.PrevNode;
                    node.NextNode = null;
                }
            }
            else
            {
                head = tail = null;
            }
            count--;
        }
    }
}
