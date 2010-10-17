using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector3DTests
{
    [TestFixture]
    public class Negate
    {

        [Test]
        public void Simple()
        {
            var vector = new Vector3D(1, 2, -5);

            vector.Negate();

            Assert.AreEqual(-1, vector.X);
            Assert.AreEqual(-2, vector.Y);
            Assert.AreEqual(5, vector.Z);
        }

    }
}