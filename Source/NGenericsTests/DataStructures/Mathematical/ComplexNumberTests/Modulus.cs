using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.ComplexNumberTests
{
    [TestFixture]
    public class Modulus
    {

        [Test]
        public void Simple()
        {
            var complex = new ComplexNumber(0, 10);
            var modulus = complex.Modulus;

            Assert.AreEqual(modulus, 10);

            complex = new ComplexNumber(10, 0);
            modulus = complex.Modulus;

            Assert.AreEqual(modulus, 10);

            complex = new ComplexNumber(1.576, -53.47);
            modulus = complex.Modulus;

            var answer = Math.Sqrt(1.576 * 1.576 + (-53.47 * -53.47));
            Assert.AreEqual(modulus, answer);
        }

    }
}