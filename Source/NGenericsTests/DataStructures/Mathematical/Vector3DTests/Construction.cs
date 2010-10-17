using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector3DTests
{
    [TestFixture]
    public class Construction
    {

        [Test]
        public void Simple()
        {
            var vector = new Vector3D();
            Assert.AreEqual(3, vector.DimensionCount);
            Assert.AreEqual(0, vector.X);
            Assert.AreEqual(0, vector.Y);
            Assert.AreEqual(0, vector.Z);
        }

    }
}