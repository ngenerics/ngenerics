using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.MatrixTests
{
    [TestFixture]
    public class CopyTo
    {

        [Test]
        public void Simple()
        {
            var matrix = MatrixTest.GetTestMatrix();

            var array = new double[matrix.Rows * matrix.Columns];

            matrix.CopyTo(array, 0);

            var list = new List<double>(array);

            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    Assert.IsTrue(list.Contains(i + j));
                }
            }
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullArray()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.CopyTo(null, 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionInvalidArrayLength12()
        {
            var matrix = MatrixTest.GetTestMatrix();

            var array = new double[matrix.Rows * matrix.Columns];

            matrix.CopyTo(array, 1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionInvalidArrayLength1()
        {
            var matrix = MatrixTest.GetTestMatrix();

            var array = new double[matrix.Rows * matrix.Columns - 1];

            matrix.CopyTo(array, 0);
        }

    }
}