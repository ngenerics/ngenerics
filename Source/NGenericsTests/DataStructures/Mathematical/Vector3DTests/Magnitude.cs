using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector3DTests
{
    [TestFixture]
    public class Magnitude
    {

        [Test]
        public void Simple()
        {
            var vector3D = new Vector3D(4, 3, 12);

            Assert.AreEqual(13, vector3D.Magnitude());
            Assert.AreEqual(4, vector3D.X);
            Assert.AreEqual(3, vector3D.Y);
            Assert.AreEqual(12, vector3D.Z);
        }

    }
}