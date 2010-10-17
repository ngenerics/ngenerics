using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorNTests
{
    [TestFixture]
    public class FromMatrixOperator
    {
        [Test]
        public void Simple()
        {

            var matrix = new Matrix(2, 1);
            matrix[0, 0] = 4;
            matrix[1, 0] = 7;
            var actual = (VectorN)matrix;

            Assert.AreEqual(2, actual.DimensionCount);

            Assert.AreEqual(4, actual[0]);
            Assert.AreEqual(7, actual[1]);
        }

        [Test]
        [ExpectedException(typeof(InvalidCastException))]
        public void ExceptionInvalidColumns()
        {

            var matrix = new Matrix(2, 2);
            var actual = (VectorN)matrix;

        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionMatrixNull()
        {
            const Matrix matrix = null;
            var actual = (VectorN)matrix;
        }
    }
}