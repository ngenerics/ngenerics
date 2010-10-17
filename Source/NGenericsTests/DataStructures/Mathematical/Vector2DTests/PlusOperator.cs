using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector2DTests
{
    [TestFixture]
    public class PlusOperator
    {
        [Test]
        public void Double()
        {
            var vector2D = new Vector2D(4, 7);
            var vector = vector2D + 2;
            Assert.AreEqual(6, vector.X);
            Assert.AreEqual(9, vector.Y);
            Assert.AreEqual(4, vector2D.X);
            Assert.AreEqual(7, vector2D.Y);
            Assert.AreNotSame(vector2D, vector);
        }


        [Test]
        public void Vector()
        {
            var vector1 = new Vector2D(4, 7);
            var vector2 = new Vector2D(3, 4);
            var vector = vector1 + vector2;
            Assert.AreEqual(7, vector.X);
            Assert.AreEqual(11, vector.Y);
            Assert.AreEqual(4, vector1.X);
            Assert.AreEqual(7, vector1.Y);
            Assert.AreEqual(3, vector2.X);
            Assert.AreEqual(4, vector2.Y);
            Assert.AreNotSame(vector1, vector);
            Assert.AreNotSame(vector2, vector);
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionDifferentDimensions()
        {
            var vector2D = new Vector2D();
            var vector3D = new Vector3D();
            IVector<double> vector = vector2D + vector3D;
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionLeftNull()
        {
            var vector2D1 = new Vector2D();
            var vector = null + vector2D1;
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionRightNull()
        {
            var vector2D1 = new Vector2D();
            var vector = vector2D1 + null;
        }
    }
}