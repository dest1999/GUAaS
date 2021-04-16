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
    public class CheckSimpleNumberTests
    {
        [TestMethod()]
        public void IsNumberIsSimpleTest_Input3_ReturnsTrue()
        {
            var result = CheckSimpleNumber.IsNumberIsSimple(3);
            
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void IsNumberIsSimpleTest_Input4_ReturnsFalse()
        {
            var result = CheckSimpleNumber.IsNumberIsSimple(4);

            Assert.IsFalse(result);
        }


        [TestMethod()]
        public void IsNumberIsSimpleTest_Input5_ReturnsFalse() // сдесь условия нарушены
        {
            var result = CheckSimpleNumber.IsNumberIsSimple(5);

            Assert.IsFalse(result);
        }


        [TestMethod()]
        public void IsNumberIsSimpleTest_Input7_ReturnsTrue()
        {
            var result = CheckSimpleNumber.IsNumberIsSimple(7);

            Assert.IsTrue(result);
        }


        [TestMethod()]
        public void IsNumberIsSimpleTest_Input11_ReturnsTrue() // сдесь условия нарушены
        {
            var result = CheckSimpleNumber.IsNumberIsSimple(11);

            Assert.IsFalse(result);
        }

    }
}