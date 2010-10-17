using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.ComplexNumberTests
{
    [TestFixture]
    public class Clone
    {

        [Test]
        public void Simple()
        {
            var complexNumber = new ComplexNumber(5, 6);
            var copy = (ComplexNumber) complexNumber.Clone();

            Assert.AreEqual(copy.Real, complexNumber.Real);
            Assert.AreEqual(copy.Imaginary, complexNumber.Imaginary);

            complexNumber = new ComplexNumber(-2, 3);
            copy = (ComplexNumber) complexNumber.Clone();

            Assert.AreEqual(copy.Real, complexNumber.Real);
            Assert.AreEqual(copy.Imaginary, complexNumber.Imaginary);

            complexNumber = new ComplexNumber(5, -3);
            copy = (ComplexNumber) complexNumber.Clone();

            Assert.AreEqual(copy.Real, complexNumber.Real);
            Assert.AreEqual(copy.Imaginary, complexNumber.Imaginary);

            complexNumber = new ComplexNumber(-9, -4);
            copy = (ComplexNumber) complexNumber.Clone();

            Assert.AreEqual(copy.Real, complexNumber.Real);
            Assert.AreEqual(copy.Imaginary, complexNumber.Imaginary);
        }

    }
}