using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector2DTests
{
    [TestFixture]
    public class MultiplyOperator
    {
        [Test]
        public void Double()
        {
            var vector2D = new Vector2D(4, 7);
            var vector = vector2D * 2;
            Assert.AreEqual(8, vector.X);
            Assert.AreEqual(14, vector.Y);
            Assert.AreEqual(4, vector2D.X);
            Assert.AreEqual(7, vector2D.Y);
            Assert.AreNotSame(vector2D, vector);
        }


        [Test]
        public void Vector()
        {
            var vector2D1 = new Vector2D(4, 7);
            var vector2D2 = new Vector2D(3, 4);
            var matrix = vector2D1 * vector2D2;
            Assert.AreEqual(2, matrix.Columns);
            Assert.AreEqual(2, matrix.Rows);

            Assert.AreEqual(12, matrix[0, 0]);
            Assert.AreEqual(16, matrix[0, 1]);
            Assert.AreEqual(21, matrix[1, 0]);
            Assert.AreEqual(28, matrix[1, 1]);

            Assert.AreEqual(4, vector2D1.X);
            Assert.AreEqual(7, vector2D1.Y);
            Assert.AreEqual(3, vector2D2.X);
            Assert.AreEqual(4, vector2D2.Y);
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionDifferentDimensions()
        {
            var vector2D1 = new Vector2D();
            VectorBase<double> vectorBase = new VectorN(4);
            var matrix = vector2D1 * vectorBase;
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionLeftNull()
        {
            var vector2D1 = new Vector2D();
            var matrix = null * vector2D1;
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionRightNull()
        {
            var vector2D1 = new Vector2D();
            var matrix = vector2D1 * null;
        }
    }
}