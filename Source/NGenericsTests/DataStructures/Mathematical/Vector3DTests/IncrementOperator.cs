using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector3DTests
{
    [TestFixture]
    public class IncrementOperator
    {
        [Test]
        public void Simple()
        {
            var vector3D = new Vector3D(4, 7, 8);

            vector3D++;

            Assert.AreEqual(5, vector3D.X);
            Assert.AreEqual(8, vector3D.Y);
            Assert.AreEqual(9, vector3D.Z);
        }
    }
}