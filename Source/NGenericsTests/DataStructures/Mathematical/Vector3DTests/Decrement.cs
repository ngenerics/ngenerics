using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector3DTests
{
    [TestFixture]
    public class Decrement
    {

        [Test]
        public void Simple()
        {
            var vector = new Vector3D(4, 7, 9);

            vector.Decrement();

            Assert.AreEqual(3, vector.X);
            Assert.AreEqual(6, vector.Y);
            Assert.AreEqual(8, vector.Z);
        }

    }
}