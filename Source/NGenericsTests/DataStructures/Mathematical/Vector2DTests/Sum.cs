using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector2DTests
{
    [TestFixture]
    public class Sum
    {

        [Test]
        public void Simple()
        {
            var vector = new Vector2D(2, 3);

            Assert.AreEqual(5, vector.Sum());

            Assert.AreEqual(2, vector.X);
            Assert.AreEqual(3, vector.Y);
        }

    }
}