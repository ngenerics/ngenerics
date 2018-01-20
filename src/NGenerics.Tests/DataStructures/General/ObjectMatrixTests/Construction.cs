/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ObjectMatrixTests
{
    [TestFixture]
    public class Construction:ObjectMatrixTest
    {
        [Test]
        public void Simple()
        {
            var matrix = new ObjectMatrix<int>(10, 15);
            Assert.AreEqual(matrix.Rows, 10);
            Assert.AreEqual(matrix.Columns, 15);

            matrix = new ObjectMatrix<int>(5, 13);
            Assert.AreEqual(matrix.Rows, 5);
            Assert.AreEqual(matrix.Columns, 13);
        }

        [Test]
        public void ExceptionNegativeRows()
        {
            Assert.Throws<ArgumentException>(() => new ObjectMatrix<int>(-1, 20));
        }

        [Test]
        public void ExceptionZeroRows()
        {
            Assert.Throws<ArgumentException>(() => new ObjectMatrix<int>(0, 20));
        }

        [Test]
        public void ExceptionNegativeColomns()
        {
            Assert.Throws<ArgumentException>(() => new ObjectMatrix<int>(50, -1));
        }

        [Test]
        public void ExceptionZeroColumns()
        {
            Assert.Throws<ArgumentException>(() => new ObjectMatrix<int>(50, 0));
        }
    }
}