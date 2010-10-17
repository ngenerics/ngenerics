/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector3DTests
{
    [TestFixture]
    public class DecrementOperator
    {
        [Test]
        public void Simple()
        {
            var vector3D = new Vector3D(4, 7, 8);

            vector3D--;

            Assert.AreEqual(3, vector3D.X);
            Assert.AreEqual(6, vector3D.Y);
            Assert.AreEqual(7, vector3D.Z);
        }
    }
}