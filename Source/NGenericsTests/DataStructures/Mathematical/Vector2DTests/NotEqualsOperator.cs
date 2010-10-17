using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector2DTests
{
    [TestFixture]
    public class NotEqualsOperator
    {
        [Test]
        public void Simple()
        {
            var vector2D1 = new Vector2D(1, 2);
            var vector2D2 = new Vector2D(1, 2);
            Assert.IsFalse(vector2D1 != vector2D2);
            Assert.AreEqual(1, vector2D1.X);
            Assert.AreEqual(2, vector2D1.Y);
            Assert.AreEqual(1, vector2D2.X);
            Assert.AreEqual(2, vector2D2.Y);
        }
    }
}