using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector3DTests
{
    [TestFixture]
    public class AbsoluteMinimum
    {

        [Test]
        public void Simple()
        {
            var vector = new Vector3D { X = 1, Y = (-4), Z = 3 };
            Assert.AreEqual(1, vector.AbsoluteMinimum());
            Assert.AreEqual(1, vector.X);
            Assert.AreEqual(-4, vector.Y);
            Assert.AreEqual(3, vector.Z);
        }

    }
}