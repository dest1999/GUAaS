using Microsoft.VisualStudio.TestTools.UnitTesting;
using part3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part3.Tests
{
    [TestClass()]
    public class FibonacciesComputeTests
    {
        //данные для тестирования
        readonly int[,] testArray = { { 0, 2, 5, 9, 43, 46 }, { 0, 1, 5, 34, 433494437, 1836311903 } };
        int index, actual;

        //тестирование цикла

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void FibonacciCycleTest_InputNegative_ReturnExeption()
        {
            FibonacciesCompute.FibonacciCycle(-5);
        }


        [TestMethod()]
        public void FibonacciCycleTest_testArray_Element0()
        {
            index = 0;
            actual = FibonacciesCompute.FibonacciCycle(testArray[0, index]);

            Assert.AreEqual(testArray[1, index], actual);
        }

        [TestMethod()]
        public void FibonacciCycleTest_testArray_Element1()
        {
            index = 1;
            actual = FibonacciesCompute.FibonacciCycle(testArray[0, index]);

            Assert.AreEqual(testArray[1, index], actual);
        }

        [TestMethod()]
        public void FibonacciCycleTest_testArray_Element2()
        {
            index = 2;
            actual = FibonacciesCompute.FibonacciCycle(testArray[0, index]);

            Assert.AreEqual(testArray[1, index], actual);
        }

        [TestMethod()]
        public void FibonacciCycleTest_testArray_Element3()
        {
            index = 3;
            actual = FibonacciesCompute.FibonacciCycle(testArray[0, index]);

            Assert.AreEqual(testArray[1, index], actual);
        }

        [TestMethod()]
        public void FibonacciCycleTest_testArray_Element4()
        {
            index = 4;
            actual = FibonacciesCompute.FibonacciCycle(testArray[0, index]);

            Assert.AreEqual(testArray[1, index], actual);
        }

        [TestMethod()]
        public void FibonacciCycleTest_testArray_Element5()
        {
            index = 5;
            actual = FibonacciesCompute.FibonacciCycle(testArray[0, index]);

            Assert.AreEqual(testArray[1, index], actual);
        }

        //далее тестирование рекурсии
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void FibonacciRecurseTest_InputNegative_ReturnExeption()
        {
            FibonacciesCompute.FibonacciRecurse(-5);

        }

        [TestMethod()]
        public void FibonacciRecurseTest_testArray_Element0()
        {
            index = 0;
            actual = FibonacciesCompute.FibonacciRecurse(testArray[0, index]);

            Assert.AreEqual(testArray[1, index], actual);
        }

        [TestMethod()]
        public void FibonacciRecurseTest_testArray_Element1()
        {
            index = 1;
            actual = FibonacciesCompute.FibonacciRecurse(testArray[0, index]);

            Assert.AreEqual(testArray[1, index], actual);
        }

        [TestMethod()]
        public void FibonacciRecurseTest_testArray_Element2()
        {
            index = 2;
            actual = FibonacciesCompute.FibonacciRecurse(testArray[0, index]);

            Assert.AreEqual(testArray[1, index], actual);
        }

        [TestMethod()]
        public void FibonacciRecurseTest_testArray_Element3()
        {
            index = 3;
            actual = FibonacciesCompute.FibonacciRecurse(testArray[0, index]);

            Assert.AreEqual(testArray[1, index], actual);
        }

        [TestMethod()]
        public void FibonacciRecurseTest_testArray_Element4()
        {
            index = 4;
            actual = FibonacciesCompute.FibonacciRecurse(testArray[0, index]);

            Assert.AreEqual(testArray[1, index], actual);
        }

        [TestMethod()]
        public void FibonacciRecurseTest_testArray_Element5()
        {
            index = 5;
            actual = FibonacciesCompute.FibonacciRecurse(testArray[0, index]);

            Assert.AreEqual(testArray[1, index], actual);
        }

    }
}