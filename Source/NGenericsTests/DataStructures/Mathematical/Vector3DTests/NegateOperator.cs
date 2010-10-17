using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector3DTests
{
    [TestFixture]
    public class NegateOperator
    {
        [Test]
        public void Simple()
        {
            var vector3D1 = new Vector3D(1, 2, 3);
            var vector = -vector3D1;
            Assert.AreEqual(-1, vector.X);
            Assert.AreEqual(-2, vector.Y);
            Assert.AreEqual(-3, vector.Z);
            Assert.AreNotSame(vector3D1, vector);
            Assert.AreEqual(1, vector3D1.X);
            Assert.AreEqual(2, vector3D1.Y);
            Assert.AreEqual(3, vector3D1.Z);
        }
    }
}