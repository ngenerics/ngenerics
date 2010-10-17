using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.ComplexNumberTests
{
    [TestFixture]
    public class ToStringObj
    {

        [Test]
        public void Simple()
        {
            var complexNumber = ComplexNumber.MultiplicativeIdentity;
            var s = complexNumber.ToString();

            Assert.IsNotNull(s);
            Assert.IsNotEmpty(s);
            Assert.IsTrue(s.Contains("i"));
            Assert.IsTrue(s.Contains("+"));
        }

        [Test]
        public void StringConversionTest()
        {
            var complexNumber = ComplexNumber.MultiplicativeIdentity;
            var s = (string) complexNumber;

            Assert.IsNotNull(s);
            Assert.IsNotEmpty(s);
            Assert.IsTrue(s.Contains("i"));
            Assert.IsTrue(s.Contains("+"));
        }

    }
}