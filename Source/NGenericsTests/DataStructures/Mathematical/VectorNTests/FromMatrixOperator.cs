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

namespace NGenerics.Tests.DataStructures.Mathematical.VectorNTests
{
    [TestFixture]
    public class FromMatrixOperator
    {
        [Test]
        public void Simple()
        {

            var matrix = new Matrix(2, 1);
            matrix[0, 0] = 4;
            matrix[1, 0] = 7;
            var actual = (VectorN)matrix;

            Assert.AreEqual(2, actual.DimensionCount);

            Assert.AreEqual(4, actual[0]);
            Assert.AreEqual(7, actual[1]);
        }

        [Test]
        [ExpectedException(typeof(InvalidCastException))]
        public void ExceptionInvalidColumns()
        {

            var matrix = new Matrix(2, 2);
            var actual = (VectorN)matrix;

        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionMatrixNull()
        {
            const Matrix matrix = null;
            var actual = (VectorN)matrix;
        }
    }
}