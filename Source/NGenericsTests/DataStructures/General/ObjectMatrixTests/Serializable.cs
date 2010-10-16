using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ObjectMatrixTests
{
    [TestFixture]
    public class Serializable:ObjectMatrixTest
    {
        [Test]
        public void Simple()
        {
            var matrix = GetTestMatrix();
            var newMatrix = SerializeUtil.BinarySerializeDeserialize(matrix);

            TestIfEqual(matrix, newMatrix);
        }
    }
}