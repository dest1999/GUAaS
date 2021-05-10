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
    public class FindWaysTests
    {

        [TestMethod()]
        public void WayTracerTest_Array3x4_Expected210()
        {
            ulong?[,] arr = new ulong?[3, 4];

            ulong? expected = 10;
            ulong? actual = (ulong?)FindWays.WayTracer(arr);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void WayTracerTest_Array5x7_Expected210()
        {
            ulong?[,] arr = new ulong?[5, 7];

            ulong? expected = 210;
            ulong? actual = (ulong?)FindWays.WayTracer(arr);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void WayTracerTest_Array4x3With1Barrier_Expected4()
        {
            ulong?[,] arr = new ulong?[4, 3];
            arr[1, 1] = 0;

            ulong? expected = 4;
            ulong? actual = (ulong?)FindWays.WayTracer(arr);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void WayTracerTest_Array5x5_Expected15()
        {
            ulong?[,] arr = new ulong?[5, 5];

            ulong? expected = 70;
            ulong? actual = (ulong?)FindWays.WayTracer(arr);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void WayTracerTest_Array5x5With2Barrier_Expected15()
        {
            ulong?[,] arr = new ulong?[5, 5];
            arr[3, 3] = 0;
            arr[2, 4] = 0;

            ulong? expected = 15;
            ulong? actual = (ulong?)FindWays.WayTracer(arr);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void WayTracerTest_Array5x5With2Barrier_ExpectedNull()
        {// Конечная точка недостижима, результат null
            ulong?[,] arr = new ulong?[5, 5];
            arr[4, 3] = 0;
            arr[3, 4] = 0;

            Assert.IsNull(FindWays.WayTracer(arr));
        }

        [TestMethod()]
        [ExpectedException(typeof(OverflowException))]
        public void WayTracerTest_Array50x50_ExpectedExeption()
        {
            ulong?[,] arr = new ulong?[50, 50];

            FindWays.WayTracer(arr);
        }

    }
}