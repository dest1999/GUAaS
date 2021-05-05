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
    public class TreeTests
    {
        Tree tree = new Tree();
        void Init()
        {
            int[] arr = { 65, 33, 51, 88, 83, 57, 46, 71, 22, 99 }; //{23, 41, 62, 73, 17, 32, 23, 41, 43, 11};

            for (int i = 0; i < arr.Length; i++)
            {
                tree.AddItem(arr[i]);
            }
        }

        public TreeTests()
        {
            int[] arr = { 65, 33, 51, 88, 83, 57, 46, 71, 22, 99 }; //{23, 41, 62, 73, 17, 32, 23, 41, 43, 11};

            for (int i = 0; i < arr.Length; i++)
            {
                tree.AddItem(arr[i]);
            }
        }

        [TestMethod()]
        public void GetRootTest_Expected65()
        {
            int expected = 65;
            int actual = tree.GetRoot().Value;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetNodeByValueTest_Seek88_Expected88()
        {
            int expected = 88;
            var node = tree.GetNodeByValue(expected);
            int actual = node.Value;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetNodeByValueTest_SeekZero_ExpectedNull()
        {

            Assert.IsNull(tree.GetNodeByValue(0));
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void RemoveItemTest_Remove90_ExpectedExeption()
        {
            tree.RemoveItem(90);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void RemoveItemTest_Remove88_ExpectedExeption()
        {
            int toDel = 88;
            tree.RemoveItem(toDel);

            tree.GetNodeByValue(toDel);
        }
    }
}