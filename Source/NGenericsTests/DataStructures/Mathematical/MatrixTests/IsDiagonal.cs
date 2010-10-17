using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.MatrixTests
{
    [TestFixture]
    public class IsDiagonal
    {

        [Test]
        public void DifferentNumberOfRowsAndColumns()
        {
            var matrix = new Matrix(5, 2);
            Assert.IsFalse(matrix.IsDiagonal);
        }

        [Test]
        public void True()
        {
            var matrix = new Matrix(2, 2);

            matrix[0, 0] = 1;
            matrix[0, 1] = 0;
            matrix[1, 0] = 0;
            matrix[1, 1] = 1;
            Assert.IsTrue(matrix.IsDiagonal);
        }

        [Test]
        public void False()
        {
            var matrix = new Matrix(2, 2);
            matrix[0, 0] = 1;
            matrix[0, 1] = 0;
            matrix[1, 0] = 1;
            matrix[1, 1] = 1;
            Assert.IsFalse(matrix.IsDiagonal);
        }
    }
}