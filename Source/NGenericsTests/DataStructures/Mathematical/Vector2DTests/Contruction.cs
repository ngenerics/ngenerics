using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector2DTests
{
    [TestFixture]
    public class Contruction
    {

        [Test]
        public void Simple()
        {
            var vector2D = new Vector2D();
            Assert.AreEqual(2, vector2D.DimensionCount);
            Assert.AreEqual(0, vector2D.X);
            Assert.AreEqual(0, vector2D.Y);
        }

    }
}