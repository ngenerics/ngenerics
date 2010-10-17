using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.MatrixTests
{
    [TestFixture]
    public class FrobeniusNorm
    {

        [Test]
        public void Simple()
        {
            var matrix = new Matrix(1, 2);
            matrix[0, 0] = 3;
            matrix[0, 1] = 4;

            Assert.AreEqual(matrix.FrobeniusNorm, 5);
        }

    }
}