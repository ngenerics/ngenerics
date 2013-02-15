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
    public class AbsoluteMinimumIndex
    {

        [Test]
        public void Simple()
        {
            var vector1 = new VectorN(5);
            vector1[0] = 7;
            vector1[1] = -4;
            vector1[2] = 3;
            vector1[3] = 5;
            vector1[4] = 1;

            Assert.AreEqual(4, vector1.AbsoluteMinimumIndex());
        }

    }
}