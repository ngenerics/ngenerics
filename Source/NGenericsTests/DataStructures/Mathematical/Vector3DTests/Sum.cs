using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector3DTests
{
    [TestFixture]
    public class Sum
    {

        [Test]
        public void Simple()
        {
            var vector = new Vector3D(2, 3, 5);

            Assert.AreEqual(10, vector.Sum());

            Assert.AreEqual(2, vector.X);
            Assert.AreEqual(3, vector.Y);
            Assert.AreEqual(5, vector.Z);
        }

    }
}