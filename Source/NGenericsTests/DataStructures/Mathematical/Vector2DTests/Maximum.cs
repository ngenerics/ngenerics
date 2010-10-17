using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector2DTests
{
    [TestFixture]
    public class Maximum
    {

        [Test]
        public void Simple()
        {
            var vector = new Vector2D(1, -4);

            Assert.AreEqual(1, vector.Maximum());

            Assert.AreEqual(1, vector.X);
            Assert.AreEqual(-4, vector.Y);
        }

    }
}