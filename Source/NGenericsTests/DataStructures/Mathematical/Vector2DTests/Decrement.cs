using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector2DTests
{
    [TestFixture]
    public class Decrement
    {

        [Test]
        public void Simple()
        {
            var vector = new Vector2D(4, 7);

            vector.Decrement();

            Assert.AreEqual(3, vector.X);
            Assert.AreEqual(6, vector.Y);
        }

    }
}