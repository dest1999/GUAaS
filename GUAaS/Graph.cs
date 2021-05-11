using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUAaS
{
    public class Node //Вершина
    {
        public int Value { get; set; } // ?в дальнейшем заменить на <T>?
        public List<Edge> Edges { get; set; } //исходящие связи
        public bool Visited { get; set; } = false;
        public Node(int value, List<Edge> edges)
        {
            Value = value;
            Edges = edges;
        }
        public Node(int value)
        {
            Value = value;
            Edges = new List<Edge>();
        }
        public Node()
        {
        }

        public void AddEdge(Edge edge)
        {
            Edges.Add(edge);
        }

        public void AddEdge(Node node)
        {
            Edges.Add(new Edge(node));
        }

        public void AddEdge(Node node, int weight = 0)
        {
            AddEdge(new Edge(node, weight));
        }

        public override string ToString()
        {
            string str = Value + " -> ";

            foreach (var item in Edges)
            {
                str += item.Node.Value + " ";
            }
            str = str.Trim();
            return str;
        }

    }

    public class Edge //Ребро
    {
        public int Weight { get; set; } //вес связи, по умолчанию ноль
        public Node Node { get; set; } // узел, на который связь ссылается

        public Edge(Node node, int weight = 0)
        {
            Node = node;
            Weight = weight;
        }
        public Edge()
        {
        }
    }
    public class Graph
    {
        public List<Node> Nodes { get; set; }
        public int Count => Nodes.Count;

        public Graph()
        {
            Nodes = new List<Node>();
        }

        public void AddNode(int value)
        {
            Nodes.Add(new Node(value));
        }

        public void AddNode(Node node)
        {
            Nodes.Add(node);
        }

        public Node FindNode(int value)
        {
            foreach (var item in Nodes)
            {
                if (item.Value == value)
                {
                    return item;
                }
            }
            return null;
        }

        public List<Node> BFS(Node startNode)
        {
            Queue<Node> queue = new Queue<Node>();
            List<Node> nodesList = new List<Node>();
            Node tmpNode;
            if (startNode == null)
            {
                throw new Exception("Start node not found");
            }

            foreach (var item in Nodes)
            {
                item.Visited = false;
            }

            startNode.Visited = true;
            queue.Enqueue(startNode);
            while (queue.Count != 0)
            {
                tmpNode = queue.Dequeue();
                nodesList.Add(tmpNode);

                foreach (var item in tmpNode.Edges)
                {
                    if (!item.Node.Visited)
                    {
                        queue.Enqueue(item.Node);
                        item.Node.Visited = true;
                    }
                }
            }
            return nodesList;
        }

        public List<Node> DFS(Node startNode)
        {
            Stack<Node> stack = new Stack<Node>();
            List<Node> nodesList = new List<Node>();
            Node tmpNode;
            if (startNode == null)
            {
                throw new Exception("Start node not found");
            }

            foreach (var item in Nodes)
            {
                item.Visited = false;
            }

            startNode.Visited = true;
            stack.Push(startNode);
            while (stack.Count != 0)
            {
                tmpNode = stack.Pop();
                nodesList.Add(tmpNode);

                foreach (var item in tmpNode.Edges)
                {
                    if (!item.Node.Visited)
                    {
                        stack.Push(item.Node);
                        item.Node.Visited = true;
                    }
                }
            }
            return nodesList;
        }

    }
}
