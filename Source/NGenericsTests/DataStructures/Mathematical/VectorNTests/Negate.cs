using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorNTests
{
    [TestFixture]
    public class Negate
    {

        [Test]
        public void Simple()
        {
            var vector1 = new VectorN(2);
            vector1[0] = 1;
            vector1[1] = 2;
            vector1.Negate();
            Assert.AreEqual(-1, vector1[0]);
            Assert.AreEqual(-2, vector1[1]);
        }

    }
}