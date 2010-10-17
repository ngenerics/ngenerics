using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.ComplexNumberTests
{
    [TestFixture]
    public class MultiplicativeIdentity
    {

        [Test]
        public void Simple()
        {
            var complexNumber = ComplexNumber.MultiplicativeIdentity;
            Assert.AreEqual(0, complexNumber.Imaginary);
            Assert.AreEqual(1, complexNumber.Real);
        }

    }
}