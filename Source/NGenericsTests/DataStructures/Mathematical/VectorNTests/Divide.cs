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
    public class Divide
    {

        [Test]
        public void Double()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(9, 3);
            vector1.Divide(3);
            Assert.AreEqual(3, vector1[0]);
            Assert.AreEqual(1, vector1[1]);
        }

        [Test]
        public void Vector()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(6, 16);
            var vector2 = new VectorN(2);
            vector2.SetValues(2, 4);
            vector1.Divide(vector2);
            Assert.AreEqual(3, vector1[0]);
            Assert.AreEqual(4, vector1[1]);
        }

    }
}