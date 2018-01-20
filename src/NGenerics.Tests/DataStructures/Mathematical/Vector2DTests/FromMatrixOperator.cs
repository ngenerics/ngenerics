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

namespace NGenerics.Tests.DataStructures.Mathematical.Vector2DTests
{
    [TestFixture]
    public class FromMatrixOperator
    {
        [Test]
        public void Simple2()
        {

            var matrix = new Matrix(2, 1);
            matrix[0, 0] = 7;
            matrix[1, 0] = 4;

            var actual = (Vector2D)matrix;

            Assert.AreEqual(7, actual.X);
            Assert.AreEqual(4, actual.Y);
        }

        [Test]
        public void Simple1()
        {

            var matrix = new Matrix(1, 1);
            matrix[0, 0] = 7;

            var actual = (Vector2D)matrix;

            Assert.AreEqual(7, actual.X);
            Assert.AreEqual(0, actual.Y);
        }


        [Test]
        [ExpectedException(typeof(InvalidCastException))]
        public void ExceptionInvalidColumns()
        {

            var matrix = new Matrix(2, 2);
            var actual = (Vector2D)matrix;

        }

        [Test]
        [ExpectedException(typeof(InvalidCastException))]
        public void ExceptionInvalidRows()
        {

            var matrix = new Matrix(3, 1);
            var actual = (Vector2D)matrix;

        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullMatrix()
        {
            const Matrix matrix = null;
            var actual = (Vector2D)matrix;
        }
    }
}