using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.MatrixTests
{
    [TestFixture]
    public class IsSquare
    {

        [Test]
        public void Simple()
        {
            var matrix = new Matrix(10, 10);

            Assert.IsTrue(matrix.IsSquare);

            matrix = new Matrix(3, 4);
            Assert.IsFalse(matrix.IsSquare);

            matrix = new Matrix(35, 35);
            Assert.IsTrue(matrix.IsSquare);

            matrix = new Matrix(45, 44);
            Assert.IsFalse(matrix.IsSquare);
        }

    }
}