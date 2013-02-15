/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector3DTests
{
    [TestFixture]
    public class ToArray
    {

        [Test]
        public void Simple()
        {
            var vector = new Vector3D(8, 3, 6);

            var actual = vector.ToArray();

            Assert.AreEqual(3, actual.Length);

            Assert.AreEqual(8, actual[0]);
            Assert.AreEqual(3, actual[1]);
            Assert.AreEqual(6, actual[2]);
        }

    }
}