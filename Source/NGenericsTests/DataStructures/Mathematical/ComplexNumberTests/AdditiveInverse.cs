using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.ComplexNumberTests
{
    [TestFixture]
    public class AdditiveInverse
    {

        [Test]
        public void Simple()
        {
            var complexNumber1 = new ComplexNumber(4, -2);
            var complexNumber2 = new ComplexNumber(-2, 6);

            var resultComplexNumber = complexNumber1.AdditiveInverse;

            Assert.AreEqual(-4, resultComplexNumber.Real);
            Assert.AreEqual(2, resultComplexNumber.Imaginary);

            resultComplexNumber = complexNumber2.AdditiveInverse;

            Assert.AreEqual(2, resultComplexNumber.Real);
            Assert.AreEqual(-6, resultComplexNumber.Imaginary);
        }

    }
}