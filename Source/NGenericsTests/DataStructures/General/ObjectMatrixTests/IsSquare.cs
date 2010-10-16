using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ObjectMatrixTests
{
    [TestFixture]
    public class IsSquare:ObjectMatrixTest
    {
        [Test]
        public void Simple()
        {
            var matrix = new ObjectMatrix<int>(10, 15);
            Assert.IsFalse(matrix.IsSquare);

            matrix = new ObjectMatrix<int>(3, 3);
            Assert.IsTrue(matrix.IsSquare);

            matrix = new ObjectMatrix<int>(9, 9);
            Assert.IsTrue(matrix.IsSquare);

            matrix = new ObjectMatrix<int>(2, 3);
            Assert.IsFalse(matrix.IsSquare);
        }
    }
}