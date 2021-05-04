using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        int seekValue;
        private static Tree InitTree()
        {
            Tree tree = new Tree();
            int[] arr = { 48, 22, 92, 35, 22 };
            foreach (var item in arr)
            {
                tree.AddItem(item);
            }

            return tree;
        }

        #region BFS testing

        [TestMethod()]
        public void BFSTest_Add5ElementsToBT_ExpectedOutputListExist22()
        {
            var tree = InitTree();

            var nodes = Program.BFS(tree);

            seekValue = 22;

            Assert.IsTrue(nodes.Exists(SearchExpected));
        }


        [TestMethod()]
        public void BFSTest_Add5ElementsToBT_ExpectedOutputListExist35()
        {
            var tree = InitTree();

            var nodes = Program.BFS(tree);

            seekValue = 35;

            Assert.IsTrue(nodes.Exists(SearchExpected));
        }

        [TestMethod()]
        public void BFSTest_Add5ElementsToBT_ExpectedOutputListExist48()
        {
            var tree = InitTree();

            var nodes = Program.BFS(tree);

            seekValue = 48;

            Assert.IsTrue(nodes.Exists(SearchExpected));
        }

        [TestMethod()]
        public void BFSTest_Add5ElementsToBTSeek10_ExpectedOutputListElementNotFound()
        {
            var tree = InitTree();

            var nodes = Program.BFS(tree);

            seekValue = 10;

            Assert.IsFalse(nodes.Exists(SearchExpected));
        }

        [TestMethod()]
        public void BFSTest_Add5ElementsToBTSeekNeg517_ExpectedOutputListElementNotFound()
        {
            var tree = InitTree();

            var nodes = Program.BFS(tree);

            seekValue = -517;

            Assert.IsFalse(nodes.Exists(SearchExpected));
        }
        #endregion

        #region DFS testing

        [TestMethod()]
        public void DFSTest_Add5ElementsToBT_ExpectedOutputListExist22()
        {
            var tree = InitTree();

            var nodes = Program.BFS(tree);

            seekValue = 22;

            Assert.IsTrue(nodes.Exists(SearchExpected));
        }

        [TestMethod()]
        public void DFSTest_Add5ElementsToBT_ExpectedOutputListExist35()
        {
            var tree = InitTree();

            var nodes = Program.BFS(tree);

            seekValue = 35;

            Assert.IsTrue(nodes.Exists(SearchExpected));
        }

        [TestMethod()]
        public void DFSTest_Add5ElementsToBT_ExpectedOutputListExist48()
        {
            var tree = InitTree();

            var nodes = Program.BFS(tree);

            seekValue = 48;

            Assert.IsTrue(nodes.Exists(SearchExpected));
        }

        [TestMethod()]
        public void DFSTest_Add5ElementsToBTSeek10_ExpectedOutputListElementNotFound()
        {
            var tree = InitTree();

            var nodes = Program.BFS(tree);

            seekValue = 10;

            Assert.IsFalse(nodes.Exists(SearchExpected));
        }

        [TestMethod()]
        public void DFSTest_Add5ElementsToBTSeekNeg517_ExpectedOutputListElementNotFound()
        {
            var tree = InitTree();

            var nodes = Program.BFS(tree);

            seekValue = -517;

            Assert.IsFalse(nodes.Exists(SearchExpected));
        }


        #endregion

        private bool SearchExpected(NodeInfo node)
        {
            return node.Node.Value == seekValue;
        }
    }
}