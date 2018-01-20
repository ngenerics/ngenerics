/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
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
        public void UnsuccessfulRowNegative()
        {
            Assert.Throws<ArgumentException>(() => new Matrix(-1, 2));
        }

        [Test]
        public void ExceptionRowZero()
        {
            Assert.Throws<ArgumentException>(() => new Matrix(0, 2));
        }

        [Test]
        public void ExceptionColumnNegative()
        {
            Assert.Throws<ArgumentException>(() => new Matrix(2, -1));
        }

        [Test]
        public void ExceptionColumnZero()
        {
            Assert.Throws<ArgumentException>(() => new Matrix(2, 0));
        }

    }
}