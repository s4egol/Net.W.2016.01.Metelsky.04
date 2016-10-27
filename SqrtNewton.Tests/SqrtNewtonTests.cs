using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3;

namespace SqrtNewton.Tests
{
    [TestClass]
    public class SqrtNewtonTests
    {
        [TestMethod]
        public void SqrtN_2Sqrt4_2Returned()
        {
            int power = 2;
            int value = 4;

            double result = Task3.SqrtNewton.SqrtN(power, value);

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SqrtN_2SqrtMinus4_ArgumentExceptionReturned()
        {
            int power = 2;
            int value = -4;

            double result = Task3.SqrtNewton.SqrtN(power, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SqrtN_minus2Sqrt4_ArgumentExceptionReturned()
        {
            int power = -2;
            int value = 4;

            double result = Task3.SqrtNewton.SqrtN(power, value);
        }

        [TestMethod]
        public void SqrtN_2Sqrt0_0Returned()
        {
            int power = 2;
            int value = 0;

            double result = Task3.SqrtNewton.SqrtN(power, value);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void SqrtN_2SqrtIntMaxValue_46341Returned()
        {
            int power = 2;
            int value = int.MaxValue;

            double result = Task3.SqrtNewton.SqrtN(power, value);

            Assert.AreEqual(46340.95, result);
        }

        [TestMethod]
        public void SqrtN_3SqrtIntMinValue_minus1290Returned()
        {
            int power = 3;
            int value = int.MinValue;

            double result = Task3.SqrtNewton.SqrtN(power, value);

            Assert.AreEqual(-1290.16, result);
        }

    }
}
