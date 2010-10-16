using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ObjectMatrixTests
{
    [TestFixture]
    public class IsReadOnly:ObjectMatrixTest
    {
        [Test]
        public void Simple()
        {
            var matrix = new ObjectMatrix<int>(5, 5);
            Assert.IsFalse(matrix.IsReadOnly);

            matrix = GetTestMatrix();
            Assert.IsFalse(matrix.IsReadOnly);
        }
    }
}