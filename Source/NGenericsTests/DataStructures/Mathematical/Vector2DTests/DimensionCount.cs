using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector2DTests
{
    [TestFixture]
    public class DimensionCount
    {

        [Test]
        public void Simple()
        {
            var vector = new Vector2D();
            Assert.AreEqual(2, vector.DimensionCount);
        }

    }
}