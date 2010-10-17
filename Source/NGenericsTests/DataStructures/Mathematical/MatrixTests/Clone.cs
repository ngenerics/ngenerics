using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.MatrixTests
{
    [TestFixture]
    public class Clone
    {

        [Test]
        public void Simple()
        {
            var matrix = MatrixTest.GetTestMatrix();
            var clone = matrix.Clone();


            Assert.AreEqual(matrix.Rows, clone.Rows);
            Assert.AreEqual(matrix.Columns, clone.Columns);

            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    Assert.AreEqual(matrix[i, j], clone[i, j]);
                }
            }
        }

        [Test]
        public void InterfaceClone()
        {
            var matrix = MatrixTest.GetTestMatrix();
            var clone = (Matrix)((ICloneable)matrix).Clone();


            Assert.AreEqual(matrix.Rows, clone.Rows);
            Assert.AreEqual(matrix.Columns, clone.Columns);

            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    Assert.AreEqual(matrix[i, j], clone[i, j]);
                }
            }
        }

    }
}