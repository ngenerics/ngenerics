using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector2DTests
{
    [TestFixture]
    public class Normalize
    {

        [Test]
        public void Simple()
        {
            var vector = new Vector2D(23, 21);

            vector.Normalize();

            Assert.AreEqual(1, vector.Magnitude());
        }

    }
}