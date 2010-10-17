using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.LUDecompositionTests
{
    [TestFixture]
    public class NonSingular
    {

        [Test]
        public void Simple()
        {
            var matrix = new Matrix(3, 3);

            // [ 4,  4,  4 ]
            // [ 4,  4,  4 ]
            // [ 4,  4,  4 ]
            // Determinant = 0

            matrix[0, 0] = 4;
            matrix[0, 1] = 4;
            matrix[0, 2] = 4;

            matrix[1, 0] = 4;
            matrix[1, 1] = 4;
            matrix[1, 2] = 4;

            var decomposition = new LUDecomposition(matrix);
            Assert.IsFalse(decomposition.NonSingular);
        }

    }
}