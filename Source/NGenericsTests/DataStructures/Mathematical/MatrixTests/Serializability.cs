using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.MatrixTests
{
    [TestFixture]
    public class Serializability
    {

        [Test]
        public void Simple()
        {
            var matrix = MatrixTest.GetTestMatrix();
            var newMatrix = SerializeUtil.BinarySerializeDeserialize(matrix);

            Assert.AreNotSame(matrix, newMatrix);
            Assert.AreEqual(matrix.Rows, newMatrix.Rows);
            Assert.AreEqual(matrix.Columns, newMatrix.Columns);

            Assert.IsTrue(matrix.Equals(newMatrix));
        }

    }
}