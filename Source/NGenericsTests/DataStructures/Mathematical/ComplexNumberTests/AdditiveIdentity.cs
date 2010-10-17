using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.ComplexNumberTests
{
    [TestFixture]
    public class AdditiveIdentity
    {

        [Test]
        public void Simple()
        {
            var complexNumber = ComplexNumber.AdditiveIdentity;
            Assert.AreEqual(0, complexNumber.Real);
            Assert.AreEqual(0, complexNumber.Imaginary);
        }

    }
}