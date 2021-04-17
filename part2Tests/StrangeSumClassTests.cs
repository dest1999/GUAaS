using Microsoft.VisualStudio.TestTools.UnitTesting;
using part2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part2.Tests
{
    [TestClass()]
    public class StrangeSumClassTests
    {
        [TestMethod()]
        public void StrangeSumTest_InputAssertArray_Returns147()
        {
            var ssc = new StrangeSumClass();
            int[] ArrangeArray = { 1, 2, 3 };
            int expected = 147;
            int actual = ssc.StrangeSum(ArrangeArray);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void StrangeSumTest_InputAssertArray_Returns930()
        {
            var ssc = new StrangeSumClass();
            int[] ArrangeArray = { 5, -2, 90 };
            int expected = 930;
            int actual = ssc.StrangeSum(ArrangeArray);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void StrangeSumTest_InputAssertArray_Returns93()
        {
            var ssc = new StrangeSumClass();
            int[] ArrangeArray = { 10, 20, -30 };
            int expected = 93;
            int actual = ssc.StrangeSum(ArrangeArray);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void StrangeSumTest_InputAssertArray_Returns39()
        {
            var ssc = new StrangeSumClass();
            int[] ArrangeArray = { -3, -2, -1 };
            int expected = 39;
            int actual = ssc.StrangeSum(ArrangeArray);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void StrangeSumTest_InputAssertArray_ReturnsNeg429()
        {
            var ssc = new StrangeSumClass();
            int[] ArrangeArray = { -33, -22, -3 };
            int expected = -429;
            int actual = ssc.StrangeSum(ArrangeArray);
            Assert.AreEqual(expected, actual);
        }


    }
}