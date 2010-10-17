using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorNTests
{
    [TestFixture]
    public class Normalize
    {

        [Test]
        public void Simple()
        {
            var vector = new VectorN(3);
            vector[0] = 23;
            vector[1] = -21;
            vector[2] = 4;
            vector.Normalize();
            Assert.AreEqual(1, vector.Magnitude());
        }

    }
}