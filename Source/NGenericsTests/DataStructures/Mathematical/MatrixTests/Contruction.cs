/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

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
    public class Contruction
    {

        [Test]
        public void Simple()
        {
            var matrix = new Matrix(2, 3);
            Assert.AreEqual(matrix.Rows, 2);
            Assert.AreEqual(matrix.Columns, 3);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void UnsuccessfulRowNegative()
        {
            new Matrix(-1, 2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionRowZero()
        {
            new Matrix(0, 2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionColumnNegative()
        {
            new Matrix(2, -1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionColumnZero()
        {
            new Matrix(2, 0);
        }

    }
}