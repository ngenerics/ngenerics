using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector3DTests
{
    [TestFixture]
    public class Clone
    {

        [Test]
        public void Simple()
        {
            var vector = new Vector3D(3, 7, 9);

            var clone = (Vector3D)vector.Clone();

            Assert.AreEqual(3, vector.X);
            Assert.AreEqual(7, vector.Y);
            Assert.AreEqual(9, vector.Z);

            Assert.AreEqual(3, clone.X);
            Assert.AreEqual(7, clone.Y);
            Assert.AreEqual(9, clone.Z);

            Assert.AreNotSame(clone, vector);
        }

    }
}