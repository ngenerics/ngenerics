/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorNTests
{
    [TestFixture]
    public class Multiply
    {

        [Test]
        public void Double()
        {
            var vector1 = new VectorN(2);
            vector1[0] = 1;
            vector1[1] = 2;
            vector1.Multiply(2);
            Assert.AreEqual(2, vector1[0]);
            Assert.AreEqual(4, vector1[1]);
        }

        [Test]
        public void Vector()
        {
            var vector1 = new VectorN(2);
            vector1[0] = 1;
            vector1[1] = 2;
            var vector2 = new VectorN(2);
            vector2[0] = 3;
            vector2[1] = 4;
            var matrix = vector1.Multiply(vector2);
            Assert.AreEqual(2, matrix.Columns);
            Assert.AreEqual(2, matrix.Rows);
            Assert.AreEqual(3, matrix[0, 0]);
            Assert.AreEqual(4, matrix[0, 1]);
            Assert.AreEqual(6, matrix[1, 0]);
            Assert.AreEqual(8, matrix[1, 1]);
        }

    }
}