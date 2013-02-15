/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ObjectMatrixTests
{
    [TestFixture]
    public class GetSubMatrix:ObjectMatrixTest
    {
        [Test]
        public void Interface()
        {
            var matrix = GetTestMatrix();

            var result = (ObjectMatrix<int>) ((IMatrix<int>) matrix).GetSubMatrix(0, 0, 3, 3);

            Assert.AreEqual(result.Rows, 3);
            Assert.AreEqual(result.Columns, 3);

            for (var i = 0; i < result.Rows; i++)
            {
                for (var j = 0; j < result.Columns; j++)
                {
                    Assert.AreEqual(result[i, j], i + j);
                }
            }

            result = (ObjectMatrix<int>) ((IMatrix<int>) matrix).GetSubMatrix(1, 2, 3, 3);

            for (var i = 0; i < result.Rows; i++)
            {
                for (var j = 0; j < result.Columns; j++)
                {
                    Assert.AreEqual(result[i, j], i + 1 + j + 2);
                }
            }
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExcetionInvalid1()
        {
            var matrix = GetTestMatrix();
            matrix.GetSubMatrix(-1, 0, 1, 1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExcetionInvalid2()
        {
            var matrix = GetTestMatrix();
            matrix.GetSubMatrix(0, -1, 1, 1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExcetionInvalid3()
        {
            var matrix = GetTestMatrix();
            matrix.GetSubMatrix(0, 0, 0, 1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExcetionInvalid4()
        {
            var matrix = GetTestMatrix();
            matrix.GetSubMatrix(0, 0, 1, 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExcetionInvalid5()
        {
            var matrix = GetTestMatrix();
            matrix.GetSubMatrix(0, 0, 16, 6);
        }

        [Test]
        public void Simple()
        {
            var matrix = GetTestMatrix();

            var result = matrix.GetSubMatrix(0, 0, 3, 3);

            Assert.AreEqual(result.Rows, 3);
            Assert.AreEqual(result.Columns, 3);

            for (var i = 0; i < result.Rows; i++)
            {
                for (var j = 0; j < result.Columns; j++)
                {
                    Assert.AreEqual(result[i, j], i + j);
                }
            }

            result = matrix.GetSubMatrix(1, 2, 3, 3);

            for (var i = 0; i < result.Rows; i++)
            {
                for (var j = 0; j < result.Columns; j++)
                {
                    Assert.AreEqual(result[i, j], i + 1 + j + 2);
                }
            }
        }
    }
}