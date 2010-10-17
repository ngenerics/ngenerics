using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector3DTests
{
    [TestFixture]
    public class Product
    {

        [Test]
        public void Simple()
        {
            var vector3D = new Vector3D(2, 3, 5);

            Assert.AreEqual(30, vector3D.Product());
            Assert.AreEqual(2, vector3D.X);
            Assert.AreEqual(3, vector3D.Y);
            Assert.AreEqual(5, vector3D.Z);
        }

    }
}