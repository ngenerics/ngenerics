using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector2DTests
{
    [TestFixture]
    public class NegateOperator
    {
        [Test]
        public void Simple()
        {
            var vector2D = new Vector2D { X = 1, Y = 2 };
            var vector = -vector2D;
            Assert.AreEqual(-1, vector.X);
            Assert.AreEqual(-2, vector.Y);
            Assert.AreEqual(1, vector2D.X);
            Assert.AreEqual(2, vector2D.Y);
            Assert.AreNotSame(vector2D, vector);
        }

    }
}