using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.ComplexNumberTests
{
    [TestFixture]
    public class Minus
    {

        [Test]
        public void Simple2()
        {
            var complexNumber1 = new ComplexNumber(4, 3);
            var complexNumber2 = new ComplexNumber(6, 2);
            var complexNumber3 = new ComplexNumber(-2, -4);
            var complexNumber4 = new ComplexNumber(3, -8);
            var complexNumber5 = new ComplexNumber(8, 3);

            var resultComplexNumber = complexNumber1 - complexNumber2;

            Assert.AreEqual(1, resultComplexNumber.Imaginary);
            Assert.AreEqual(-2, resultComplexNumber.Real);

            resultComplexNumber = complexNumber1 - complexNumber3;

            Assert.AreEqual(7, resultComplexNumber.Imaginary);
            Assert.AreEqual(6, resultComplexNumber.Real);

            resultComplexNumber = complexNumber1 - complexNumber4;

            Assert.AreEqual(11, resultComplexNumber.Imaginary);
            Assert.AreEqual(1, resultComplexNumber.Real);

            resultComplexNumber = complexNumber1 - complexNumber5;

            Assert.AreEqual(0, resultComplexNumber.Imaginary);
            Assert.AreEqual(-4, resultComplexNumber.Real);
        }

        [Test]
        public void Simple1()
        {
            var complexNumber1 = new ComplexNumber(4, 3);
            var complexNumber2 = new ComplexNumber(6, 2);
            var complexNumber3 = new ComplexNumber(-2, -4);
            var complexNumber4 = new ComplexNumber(3, -8);
            var complexNumber5 = new ComplexNumber(8, 3);

            var resultComplexNumber = complexNumber1.Subtract(complexNumber2);

            Assert.AreEqual(1, resultComplexNumber.Imaginary);
            Assert.AreEqual(-2, resultComplexNumber.Real);

            resultComplexNumber = complexNumber1.Subtract(complexNumber3);

            Assert.AreEqual(7, resultComplexNumber.Imaginary);
            Assert.AreEqual(6, resultComplexNumber.Real);

            resultComplexNumber = complexNumber1.Subtract(complexNumber4);

            Assert.AreEqual(11, resultComplexNumber.Imaginary);
            Assert.AreEqual(1, resultComplexNumber.Real);

            resultComplexNumber = complexNumber1.Subtract(complexNumber5);

            Assert.AreEqual(0, resultComplexNumber.Imaginary);
            Assert.AreEqual(-4, resultComplexNumber.Real);
        }

    }
}