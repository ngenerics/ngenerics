using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.ComplexNumberTests
{
    [TestFixture]
    public class OperatorDouble
    {

        [Test]
        public void Simple()
        {
            ComplexNumber complexNumber = 7;
            Assert.AreEqual(7, complexNumber.Real);
            Assert.AreEqual(0, complexNumber.Imaginary);

        }

    }
}