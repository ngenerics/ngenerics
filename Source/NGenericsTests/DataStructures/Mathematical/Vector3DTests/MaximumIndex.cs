using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector3DTests
{
    [TestFixture]
    public class MaximumIndex
    {

        [Test]
        public void Simple()
        {
            var vector1 = new Vector3D(1, -4, 3);

            Assert.AreEqual(2, vector1.MaximumIndex());

            Assert.AreEqual(1, vector1.X);
            Assert.AreEqual(-4, vector1.Y);
            Assert.AreEqual(3, vector1.Z);

            var vector2 = new Vector3D(4, -4, 3);

            Assert.AreEqual(0, vector2.MaximumIndex());

            Assert.AreEqual(4, vector2.X);
            Assert.AreEqual(-4, vector2.Y);
            Assert.AreEqual(3, vector2.Z);

            var vector3 = new Vector3D(1, 4, 3);

            Assert.AreEqual(1, vector3.MaximumIndex());

            Assert.AreEqual(1, vector3.X);
            Assert.AreEqual(4, vector3.Y);
            Assert.AreEqual(3, vector3.Z);



            var vector4 = new Vector3D(3, 4, 9);

            Assert.AreEqual(2, vector4.MaximumIndex());

            Assert.AreEqual(3, vector4.X);
            Assert.AreEqual(4, vector4.Y);
            Assert.AreEqual(9, vector4.Z);
        }

    }
}