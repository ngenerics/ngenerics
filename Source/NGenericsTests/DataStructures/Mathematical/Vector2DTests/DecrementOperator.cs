using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector2DTests
{
    [TestFixture]
    public class DecrementOperator
    {
        [Test]
        public void Simple()
        {
            var vector2D = new Vector2D(4, 7);

            vector2D--;

            Assert.AreEqual(3, vector2D.X);
            Assert.AreEqual(6, vector2D.Y);
        }
    }
}