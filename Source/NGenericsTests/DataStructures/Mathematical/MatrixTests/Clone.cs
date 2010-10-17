/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
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