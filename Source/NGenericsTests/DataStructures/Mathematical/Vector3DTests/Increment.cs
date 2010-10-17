using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector3DTests
{
    [TestFixture]
    public class Increment
    {

        [Test]
        public void Simple()
        {
            var vector = new Vector3D(4, 7, 9);

            vector.Increment();

            Assert.AreEqual(5, vector.X);
            Assert.AreEqual(8, vector.Y);
            Assert.AreEqual(10, vector.Z);
        }

    }
}