using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ObjectMatrixTests
{
    [TestFixture]
    public class Count:ObjectMatrixTest
    {
        [Test]
        public void Simple()
        {
            ICollection<int> matrix = new ObjectMatrix<int>(10, 15);

            Assert.AreEqual(matrix.Count, 150);

            matrix = new ObjectMatrix<int>(3, 3);
            Assert.AreEqual(matrix.Count, 9);
        }
    }
}