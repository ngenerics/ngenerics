using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector2DTests
{
    [TestFixture]
    public class EqualsObj
    {

        [Test]
        public void DifferentDimensions()
        {
            var vector2D = new Vector2D();
            var vector3D = new Vector3D();
            Assert.IsFalse(vector2D.Equals(vector3D));
        }

        [Test]
        public void DifferentValues()
        {
            var vector1 = new Vector2D(1, 0);
            var vector2 = new Vector2D(2, 0);

            Assert.IsFalse(vector1.Equals(vector2));

            Assert.AreEqual(1, vector1.X);
            Assert.AreEqual(2, vector2.X);
        }

        [Test]
        public void Null()
        {
            var vector = new Vector2D();
            Assert.IsFalse(vector.Equals(null));
        }

        [Test]
        public void NullVector()
        {
            var vector = new Vector2D();
            const Vector3D nullVector = null;
            Assert.IsFalse(vector.Equals(nullVector));
        }

        [Test]
        public void SameValues()
        {
            var vector1 = new Vector2D(1, 2);

            var vector2 = new Vector2D(1, 2);

            Assert.IsTrue(vector1.Equals(vector2));

            Assert.AreEqual(1, vector1.X);
            Assert.AreEqual(2, vector1.Y);

            Assert.AreEqual(1, vector2.X);
            Assert.AreEqual(2, vector2.Y);
        }

    }
}