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
    public class NegateOperator
    {
        [Test]
        public void Simple()
        {
            var vector1 = new VectorN(2);
            vector1[0] = 1;
            vector1[1] = 2;

            IVector<double> vector = -vector1;

            Assert.AreEqual(-1, vector[0]);
            Assert.AreEqual(-2, vector[1]);

            Assert.AreEqual(1, vector1[0]);
            Assert.AreEqual(2, vector1[1]);

            Assert.AreNotSame(vector1, vector);
        }
    }
}