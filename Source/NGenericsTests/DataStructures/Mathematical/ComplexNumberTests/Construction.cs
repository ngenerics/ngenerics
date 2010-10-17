using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.ComplexNumberTests
{
    [TestFixture]
    public class Construction
    {

        [Test]
        public void Simple()
        {
            var complexNumber = new ComplexNumber(5, 10);

            Assert.AreEqual(5, complexNumber.Real);
            Assert.AreEqual(10, complexNumber.Imaginary);

            complexNumber = new ComplexNumber(double.MaxValue, double.Epsilon);

            Assert.AreEqual(double.MaxValue, complexNumber.Real);
            Assert.AreEqual(double.Epsilon, complexNumber.Imaginary);

            complexNumber = new ComplexNumber();
            Assert.AreEqual(0, complexNumber.Real);
            Assert.AreEqual(0, complexNumber.Imaginary);
        }

        [Test]
        public void Set()
        {
            var complexNumber = new ComplexNumber(5, 10);

            Assert.AreEqual(5, complexNumber.Real);
            Assert.AreEqual(10, complexNumber.Imaginary);

            complexNumber.Real = 6;
            complexNumber.Imaginary = 11;

            Assert.AreEqual(6, complexNumber.Real);
            Assert.AreEqual(11, complexNumber.Imaginary);
        }

    }
}