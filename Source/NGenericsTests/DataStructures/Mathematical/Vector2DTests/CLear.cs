using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector2DTests
{
    [TestFixture]
    public class CLear
    {

        [Test]
        public void Simple()
        {
            var vector = new Vector2D(3, 7);

            vector.Clear();

            Assert.AreEqual(0, vector.X);
            Assert.AreEqual(0, vector.Y);
        }

    }
}