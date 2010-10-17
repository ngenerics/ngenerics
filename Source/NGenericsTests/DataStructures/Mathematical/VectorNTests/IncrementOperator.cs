/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorNTests
{
    [TestFixture]
    public class IncrementOperator
    {
        [Test]
        public void Simple()
        {
            VectorBase<double> vector1 = new VectorN(2);
            vector1.SetValues(4, 7);

            vector1++;

            Assert.AreEqual(5, vector1[0]);
            Assert.AreEqual(8, vector1[1]);
        }
    }
}