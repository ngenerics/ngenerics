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
    public class ToArray
    {

        [Test]
        public void Simple()
        {
            var vector = new VectorN(2);
            vector.SetValues(8, 3);

            var actual = vector.ToArray();

            Assert.AreEqual(2, actual.Length);
            Assert.AreEqual(8, actual[0]);
            Assert.AreEqual(3, actual[1]);
        }

    }
}