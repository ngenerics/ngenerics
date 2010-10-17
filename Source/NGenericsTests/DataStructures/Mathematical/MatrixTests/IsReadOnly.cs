using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.MatrixTests
{
    [TestFixture]
    public class IsReadOnly
    {

        [Test]
        public void Simple()
        {
            var matrix = new Matrix(5, 5);
            Assert.IsFalse(matrix.IsReadOnly);

            matrix = MatrixTest.GetTestMatrix();
            Assert.IsFalse(matrix.IsReadOnly);
        }

    }
}