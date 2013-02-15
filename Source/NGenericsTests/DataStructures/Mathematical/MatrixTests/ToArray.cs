/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.MatrixTests
{
    [TestFixture]
    public class ToArray
    {

        [Test]
        public void Simple()
        {
            var matrix = new Matrix(3, 2);

            // [ 1,  4,  7 ]
            // [ 2,  5,  8 ]
            // [ 3,  6,  9 ]


            matrix[0, 0] = 1;
            matrix[0, 1] = 4;

            matrix[1, 0] = 2;
            matrix[1, 1] = 5;

            matrix[2, 0] = 3;
            matrix[2, 1] = 6;

            var array = matrix.ToArray();

            Assert.AreEqual(1, array[0,0]);
            Assert.AreEqual(4, array[0,1]);
            Assert.AreEqual(2, array[1,0]);
            Assert.AreEqual(5, array[1,1]);
            Assert.AreEqual(3, array[2,0]);
            Assert.AreEqual(6, array[2,1]);
        }

    }
}