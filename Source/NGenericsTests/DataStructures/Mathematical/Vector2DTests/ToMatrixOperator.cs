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
    public class ToMatrixOperator
    {
        [Test]
        public void Simple()
        {
            var vector = new Vector2D(8, 3);

            Matrix actual = vector;

            Assert.AreEqual(2, actual.Rows);
            Assert.AreEqual(1, actual.Columns);

            Assert.AreEqual(8, actual[0, 0]);
            Assert.AreEqual(3, actual[1, 0]);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVector()
        {
            const Vector2D vector = null;
            Matrix actual = vector;
        }
    }


}