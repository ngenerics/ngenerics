using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector2DTests
{
    [TestFixture]
    public class GetHashCodeObj
    {

        [Test]
        public void Simple()
        {
            var vector = new Vector2D { X = 1, Y = 2 };
            Assert.AreNotEqual(0, vector.GetHashCode());
            Assert.AreEqual(1, vector.X);
            Assert.AreEqual(2, vector.Y);
        }

    }
}