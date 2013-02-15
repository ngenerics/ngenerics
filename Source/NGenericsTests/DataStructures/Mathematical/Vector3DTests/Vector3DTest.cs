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
    public class ToMatrix
    {

        [Test]
        public void Simple()
        {
            var vector = new Vector3D(8, 3, 7);

            var actual = vector.ToMatrix();

            Assert.AreEqual(3, actual.Rows);
            Assert.AreEqual(1, actual.Columns);

            Assert.AreEqual(8, actual[0, 0]);
            Assert.AreEqual(3, actual[1, 0]);
            Assert.AreEqual(7, actual[2, 0]);
        }

    }

    [TestFixture]
    public class UnitVector
    {

        [Test]
        public void Simple()
        {
            var vector = Vector3D.UnitVector;
            Assert.AreEqual(1, vector.X);
            Assert.AreEqual(1, vector.Y);
            Assert.AreEqual(1, vector.Z);
        }

    }

    [TestFixture]
    public class ZeroVector
    {

        [Test]
        public void Simple()
        {
            var vector = Vector3D.ZeroVector;
            Assert.AreEqual(0, vector.X);
            Assert.AreEqual(0, vector.Y);
            Assert.AreEqual(0, vector.Z);
        }

    }


}