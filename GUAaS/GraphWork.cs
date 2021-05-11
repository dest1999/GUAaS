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
            
            Graph graph = new Graph();

            foreach (var item in values)
            {
                graph.AddNode(new Node(item));
            }

            graph.Nodes[0].AddEdge(graph.Nodes[1]);
            graph.Nodes[0].AddEdge(graph.Nodes[2]);
            graph.Nodes[0].AddEdge(graph.Nodes[4]);

            graph.Nodes[1].AddEdge(graph.Nodes[0]);
            graph.Nodes[1].AddEdge(graph.Nodes[2]);
            graph.Nodes[1].AddEdge(graph.Nodes[3]);

            graph.Nodes[2].AddEdge(graph.Nodes[0]);
            graph.Nodes[2].AddEdge(graph.Nodes[1]);
            graph.Nodes[2].AddEdge(graph.Nodes[4]);

            graph.Nodes[3].AddEdge(graph.Nodes[1]);

            graph.Nodes[4].AddEdge(graph.Nodes[0]);
            graph.Nodes[4].AddEdge(graph.Nodes[2]);

            int n = 3;
            Console.WriteLine("BFS");
            foreach (var item in graph.BFS(graph.FindNode(n)))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\nDFS");
            foreach (var item in graph.DFS(graph.FindNode(n)))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(graph.Count);
        }










    }

}
