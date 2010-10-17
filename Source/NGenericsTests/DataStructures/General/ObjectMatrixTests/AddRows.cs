/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ObjectMatrixTests
{
    [TestFixture]
    public class AddRows:ObjectMatrixTest
    {
        [Test]
        public void Multiple()
        {
            var matrix = GetTestMatrix();

            var columnCount = matrix.Columns;
            var rowCount = matrix.Rows;

            matrix.AddRows(3);

            Assert.AreEqual(matrix.Columns, columnCount);
            Assert.AreEqual(matrix.Rows, rowCount + 3);

            for (var i = 0; i < rowCount; i++)
            {
                for (var j = 0; j < columnCount; j++)
                {
                    Assert.AreEqual(matrix[i, j], i + j);
                }
            }

            for (var i = 0; i < columnCount; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    Assert.AreEqual(matrix[rowCount + j, i], default(double));
                }
            }
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionNegativeRowCount()
        {
            var matrix = GetTestMatrix();
            matrix.AddRows(-1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionZeroRowCount()
        {
            var matrix = GetTestMatrix();
            matrix.AddRows(0);
        }
    }
}