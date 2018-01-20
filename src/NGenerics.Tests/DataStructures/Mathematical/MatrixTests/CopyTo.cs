/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

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
        public void ExceptionNullArray()
        {
            var matrix = MatrixTest.GetTestMatrix();
            Assert.Throws<ArgumentNullException>(() => matrix.CopyTo(null, 0));
        }

        [Test]
        public void ExceptionInvalidArrayLength12()
        {
            var matrix = MatrixTest.GetTestMatrix();
            var array = new double[matrix.Rows * matrix.Columns];

            Assert.Throws<ArgumentException>(() => matrix.CopyTo(array, 1));
        }

        [Test]
        public void ExceptionInvalidArrayLength1()
        {
            var matrix = MatrixTest.GetTestMatrix();
            var array = new double[matrix.Rows * matrix.Columns - 1];

            Assert.Throws<ArgumentException>(() => matrix.CopyTo(array, 0));
        }
    }
}