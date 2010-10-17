using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.ComplexNumberTests
{
    [TestFixture]
    public class Conjugate
    {

        [Test]
        public void Simple()
        {
            var complexNumber1 = new ComplexNumber(1, 2);
            var conjugateComplexNumber = complexNumber1.Conjugate;

            Assert.AreEqual(1, conjugateComplexNumber.Real);
            Assert.AreEqual(-2, conjugateComplexNumber.Imaginary);

            complexNumber1.Imaginary = -1;
            conjugateComplexNumber = complexNumber1.Conjugate;
            Assert.AreEqual(1, conjugateComplexNumber.Real);
            Assert.AreEqual(1, conjugateComplexNumber.Imaginary);

        }

    }
}