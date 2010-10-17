using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector3DTests
{
    [TestFixture]
    public class DimensionCount
    {

        [Test]
        public void Simple()
        {
            var vector3D = new Vector3D();
            Assert.AreEqual(3, vector3D.DimensionCount);
            Assert.AreEqual(0, vector3D.X);
            Assert.AreEqual(0, vector3D.Y);
            Assert.AreEqual(0, vector3D.Z);
        }

    }
}