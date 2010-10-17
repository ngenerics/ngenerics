using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector3DTests
{
    [TestFixture]
    public class Normalize
    {

        [Test]
        public void Simple()
        {
            var vector = new Vector3D(23, -21, 4);

            vector.Normalize();
            Assert.AreEqual(1, vector.Magnitude());
        }

    }
}