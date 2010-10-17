using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector3DTests
{
    [TestFixture]
    public class NotEqualsOperator
    {
        [Test]
        public void Simple()
        {
            var vector3D1 = new Vector3D(1, 2, 5);
            var vector3D2 = new Vector3D(1, 2, 5);
            Assert.IsFalse(vector3D1 != vector3D2);
            Assert.AreEqual(1, vector3D1.X);
            Assert.AreEqual(2, vector3D1.Y);
            Assert.AreEqual(5, vector3D1.Z);
            Assert.AreEqual(1, vector3D2.X);
            Assert.AreEqual(2, vector3D2.Y);
            Assert.AreEqual(5, vector3D2.Z);
        }
    }
}