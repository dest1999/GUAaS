using Microsoft.VisualStudio.TestTools.UnitTesting;
using Part1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part1.Tests
{
    [TestClass()]
    public class LinkedListTests
    {
        [TestMethod()]
        public void AddNodeTest_Add5ElementsToList_ExpectedCount5()
        {
            var list = new LinkedList();
            for (int i = 1; i <= 5; i++)
            {
                list.AddNode(i);
            }
            int expected = 5;
            int actual = list.GetCount();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCountTest_Add5ElementsToList_ExpectedCount11()
        {
            var list = new LinkedList();
            for (int i = 1; i <= 11; i++)
            {
                list.AddNode(i);
            }
            int expected = 11;
            int actual = list.GetCount();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FindNodeTest_Add5ElementsToListSeekForValue3_ExpectedNodeValue3()
        {
            var list = new LinkedList();
            for (int i = 1; i <= 5; i++)
            {
                list.AddNode(i);
            }
            int expected = 3;
            int actual = list.FindNode(expected).Value;

            Assert.AreEqual(3, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void FindNodeTest_Add5ElementsToListSeekForValue30_ExpectedExeption()
        {
            var list = new LinkedList();
            for (int i = 1; i <= 5; i++)
            {
                list.AddNode(i);
            }
            int seekValue = 30;
            _ = list.FindNode(seekValue).Value;
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void FindNodeTest_Add5ElementsToListSeekForValueNeg30_ExpectedExeption()
        {
            var list = new LinkedList();
            for (int i = 1; i <= 5; i++)
            {
                list.AddNode(i);
            }
            int seekValue = -30;
            _ = list.FindNode(seekValue).Value;
        }
        
        [TestMethod()]
        public void AddNodeAfterTest_Add5ElementsToListAddValue7After2_ExpectedListValue127345()
        {
            var list = new LinkedList();
            for (int i = 1; i <= 5; i++)
            {
                list.AddNode(i);
            }
            int seekValue = 2;
            int insertValue = 7;
            
            list.AddNodeAfter(list.FindNode(seekValue), insertValue);

            var expected = new int[] { 1, 2, 7, 3, 4, 5 };
            var actual = list.ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RemoveNodeTest_Add5ElementsToListThenRemoveByIndex2_ExpectedListValue1245()
        {
            var list = new LinkedList();
            for (int i = 1; i <= 5; i++)
            {
                list.AddNode(i);
            }
            int seekIndex = 2;
            list.RemoveNode(seekIndex);

            var expected = new int[] { 1, 2, 4, 5 };
            var actual = list.ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RemoveNodeTest_Add5ElementsToListThenRemoveByPointerSeek3_ExpectedListValue1245()
        {
            var list = new LinkedList();
            for (int i = 1; i <= 5; i++)
            {
                list.AddNode(i);
            }
            int seekValue = 3;
            Node n = list.FindNode(seekValue);

            list.RemoveNode(n);
            
            var expected = new int[] { 1, 2, 4, 5 };
            var actual = list.ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }


    }
}