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
    public class NotEqualsOperator
    {
        [Test]
        public void Simple()
        {
            var vector1 = new VectorN(2);
            vector1[0] = 1;
            vector1[1] = 2;

            var vector2 = new VectorN(2);
            vector2[0] = 1;
            vector2[1] = 2;

            Assert.IsFalse(vector1 != vector2);
        }
    }
}