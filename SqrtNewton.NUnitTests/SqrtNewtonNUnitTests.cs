using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task3;

namespace SqrtNewton.NUnitTests
{
    [TestFixture]
    public class SqrtNewtonNUnitTests
    {
        [TestCase(2, 4, Result = 2)]
        [TestCase(3, -8, Result = -2)]
        [TestCase(2, int.MaxValue, Result = 46340.95)]
        [TestCase(3, int.MinValue, Result = -1290.16)]
        public double SqrtN_Radical(int power, int value)
        {
            return Task3.SqrtNewton.SqrtN(power, value);
        }

        [TestCase(0, 4)]
        [TestCase(2, -8)]
        public void SqrtN_RadicalException(int power, int value)
        {
            Assert.Throws(typeof(ArgumentException), () => Task3.SqrtNewton.SqrtN(power,value));
        }
    }
}
