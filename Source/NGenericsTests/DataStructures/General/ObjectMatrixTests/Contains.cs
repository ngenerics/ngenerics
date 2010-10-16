using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ObjectMatrixTests
{
    [TestFixture]
    public class Contains:ObjectMatrixTest
    {
        [Test]
        public void Simple()
        {
            var matrix = new ObjectMatrix<int>(10, 15);

            matrix[5, 5] = 13;

            Assert.IsTrue(matrix.Contains(13));
            Assert.IsFalse(matrix.Contains(15));

            matrix[2, 3] = 15;

            Assert.IsTrue(matrix.Contains(13));
            Assert.IsTrue(matrix.Contains(15));
            Assert.IsFalse(matrix.Contains(17));
        }
    }
}