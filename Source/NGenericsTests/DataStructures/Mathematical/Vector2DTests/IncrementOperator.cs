using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector2DTests
{
    [TestFixture]
    public class IncrementOperator
    {
        [Test]
        public void Simple()
        {
            var vector = new Vector2D(4, 7);

            vector++;

            Assert.AreEqual(5, vector.X);
            Assert.AreEqual(8, vector.Y);
        }
    }
}