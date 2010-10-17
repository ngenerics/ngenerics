using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.ComplexNumberTests
{
    [TestFixture]
    public class Divide
    {

        [Test]
        public void Operator()
        {
            var complexNumber1 = new ComplexNumber(-8, 4);
            var complexNumber2 = new ComplexNumber(3, 1);

            var divComplexNumber = complexNumber1 / complexNumber2;

            Assert.AreEqual(-2, divComplexNumber.Real);
            Assert.AreEqual(2, divComplexNumber.Imaginary);

            divComplexNumber = complexNumber1 / 4;
            Assert.AreEqual(-2, divComplexNumber.Real);
            Assert.AreEqual(1, divComplexNumber.Imaginary);

            complexNumber1 = new ComplexNumber(2, 6);
            complexNumber2 = new ComplexNumber(4, 1);

            divComplexNumber = complexNumber1 / complexNumber2;

            Assert.AreEqual(14 / (double) 17, divComplexNumber.Real);
            Assert.AreEqual(22 / (double) 17, divComplexNumber.Imaginary);
        }

        [Test]
        public void Simple()
        {
            var complexNumber1 = new ComplexNumber(-8, 4);
            var complexNumber2 = new ComplexNumber(3, 1);

            var divComplexNumber = complexNumber1.Divide(complexNumber2);

            Assert.AreEqual(-2, divComplexNumber.Real);
            Assert.AreEqual(2, divComplexNumber.Imaginary);

            divComplexNumber = complexNumber1.Divide(4);
            Assert.AreEqual(-2, divComplexNumber.Real);
            Assert.AreEqual(1, divComplexNumber.Imaginary);

            complexNumber1 = new ComplexNumber(2, 6);
            complexNumber2 = new ComplexNumber(4, 1);

            divComplexNumber = complexNumber1.Divide(complexNumber2);

            Assert.AreEqual(14 / (double) 17, divComplexNumber.Real);
            Assert.AreEqual(22 / (double) 17, divComplexNumber.Imaginary);
        }

    }
}