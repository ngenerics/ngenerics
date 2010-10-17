using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.MatrixTests
{
    [TestFixture]
    public class InfinityNorm
    {

        [Test]
        public void Simple()
        {
            var matrix = new Matrix(2, 2);
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[1, 0] = 3;
            matrix[1, 1] = 4;

            Assert.AreEqual(matrix.InfinityNorm, 7);
        }

    }
}