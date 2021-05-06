using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUAaS
{
    public class Node //Вершина
    {
        public int Value { get; set; } // ?в дальнейшем заменить на object?
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
    class Graph
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
            throw new Exception("Not complete");
        }





    }
}
