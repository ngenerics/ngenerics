/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ObjectMatrixTests
{
    [TestFixture]
    public class CopyTo:ObjectMatrixTest
    {
        [Test]
        public void Simple()
        {
            var matrix = GetTestMatrix();

            var array = new int[matrix.Rows * matrix.Columns];

            matrix.CopyTo(array, 0);

            var list = new List<int>(array);

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
            var matrix = GetTestMatrix();
            matrix.CopyTo(null, 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionIncorrectArrayLength1()
        {
            var matrix = GetTestMatrix();

            var array = new int[matrix.Rows * matrix.Columns];

            matrix.CopyTo(array, 1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionIncorrectArrayLength2()
        {
            var matrix = GetTestMatrix();

            var array = new int[matrix.Rows * matrix.Columns - 1];

            matrix.CopyTo(array, 0);
        }
    }
}