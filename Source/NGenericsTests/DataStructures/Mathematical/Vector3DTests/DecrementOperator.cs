using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector3DTests
{
    [TestFixture]
    public class DecrementOperator
    {
        [Test]
        public void Simple()
        {
            var vector3D = new Vector3D(4, 7, 8);

            vector3D--;

            Assert.AreEqual(3, vector3D.X);
            Assert.AreEqual(6, vector3D.Y);
            Assert.AreEqual(7, vector3D.Z);
        }
    }
}