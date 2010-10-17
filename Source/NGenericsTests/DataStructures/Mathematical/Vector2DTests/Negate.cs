using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector2DTests
{
    [TestFixture]
    public class Negate
    {

        [Test]
        public void Simple()
        {
            var vector = new Vector2D(1, 2);

            vector.Negate();

            Assert.AreEqual(-1, vector.X);
            Assert.AreEqual(-2, vector.Y);
        }

    }
}