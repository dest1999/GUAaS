using System;
using System.Collections.Generic;

namespace GUAaS
{
    //TODO Модифицируйте DFS и BFS из предыдущего урока, но уже для графа, также с выводом каждого шага
    class GraphWork
    {
        static void Main(string[] args)
        {
            
            int[] values = { 1, 2, 3, 4, 5 };
            /*               2  1  1  2  1
             *               3  3  2     3
             *               5  4  5
             *               это будет неорграф
             */
            //List<Node> graph = new List<Node>();

            Graph graph = new Graph();

            foreach (var item in values)
            {
                var node = new Node(item);
                graph.AddNode(node);
            }

            var edgs = new List<Edge>();
            edgs.Add(new Edge(graph.Nodes[1]));
            edgs.Add(new Edge(graph.Nodes[2]));
            edgs.Add(new Edge(graph.Nodes[4]));
            Node n = new Node(1, edgs);

            //graph.Nodes[1].AddEdge(graph.Nodes[2]);
            //graph.Nodes[1].AddEdge(graph.Nodes[3]);
            //graph.Nodes[1].AddEdge(graph.Nodes[5]);

            //graph.Nodes[2].AddEdge(graph.Nodes[1]);
            //graph.Nodes[2].AddEdge(graph.Nodes[3]);
            //graph.Nodes[2].AddEdge(graph.Nodes[4]);

            //graph.Nodes[3].AddEdge(graph.Nodes[1]);
            //graph.Nodes[3].AddEdge(graph.Nodes[2]);
            //graph.Nodes[3].AddEdge(graph.Nodes[5]);

            //graph.Nodes[4].AddEdge(graph.Nodes[2]);

            //graph.Nodes[5].AddEdge(graph.Nodes[1]);
            //graph.Nodes[5].AddEdge(graph.Nodes[3]);



            Console.WriteLine(n);
        }










    }

}
