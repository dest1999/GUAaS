using Microsoft.VisualStudio.TestTools.UnitTesting;
using GUAaS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUAaS.Tests
{
    [TestClass()]
    public class GraphTests
    {
        Graph graph = new Graph();
        public GraphTests()
        {
            int[] values = { 1, 2, 3, 4, 5 };
            /*               2  1  1  2  1
             *               3  3  2     3
             *               5  4  5
             *               это будет неорграф
             */


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
        }



        [TestMethod()]
        public void BFSTest_InitValue3()
        {
            int initValue = 3;
            int i = 0;
            int[] expected = { 3, 1, 2, 5, 4 };
            int[] actual = new int[graph.Count];

            foreach (var item in graph.BFS(graph.FindNode(initValue)))
            {
                actual[i++] = item.Value;
            }

            for (i = 0; i < actual.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
            Assert.AreEqual(expected.Length, actual.Length);
        }

        [TestMethod()]
        public void DFSTest_InitValue3()
        {
            int initValue = 3;
            int i = 0;
            int[] expected = { 3, 5, 2, 4, 1 };
            int[] actual = new int[graph.Count];

            foreach (var item in graph.DFS(graph.FindNode(initValue)))
            {
                actual[i++] = item.Value;
            }

            for (i = 0; i < actual.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
            Assert.AreEqual(expected.Length, actual.Length);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void BFSTest_InitValue10_ExpectedExeption()
        {
            int initValue = 10;
            int i = 0;
            int[] actual = new int[graph.Count];

            foreach (var item in graph.BFS(graph.FindNode(initValue)))
            {
                actual[i++] = item.Value;
            }

        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void DFSTest_InitValue10_ExpectedExeption()
        {
            int initValue = 10;
            int i = 0;
            int[] actual = new int[graph.Count];

            foreach (var item in graph.DFS(graph.FindNode(initValue)))
            {
                actual[i++] = item.Value;
            }

        }

    }
}