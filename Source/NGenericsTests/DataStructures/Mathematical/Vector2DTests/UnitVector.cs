using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector2DTests
{
    [TestFixture]
    public class UnitVector
    {

        [Test]
        public void Simple()
        {
            var vector = Vector2D.UnitVector;
            Assert.AreEqual(1, vector.X);
            Assert.AreEqual(1, vector.Y);
        }

    }
}