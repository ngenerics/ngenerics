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
    public class EqualsObj
    {

        [Test]
        public void DifferentDimensions()
        {
            var vector3D = new Vector3D();
            var vectorN = new VectorN(4);
            Assert.IsFalse(vector3D.Equals(vectorN));
        }

        [Test]
        public void DifferentValues()
        {
            var vector1 = new Vector3D { X = 1 };

            var vector2 = new Vector3D { X = 2 };

            Assert.IsFalse(vector1.Equals(vector2));

            Assert.AreEqual(1, vector1.X);
            Assert.AreEqual(2, vector2.X);
        }

        [Test]
        public void Null()
        {
            var vector = new Vector3D();
            Assert.IsFalse(vector.Equals(null));
        }

        [Test]
        public void NullVector()
        {
            var vector3D1 = new Vector3D();
            const Vector3D nullVector = null;
            Assert.IsFalse(vector3D1.Equals(nullVector));
        }

        [Test]
        public void SameValues()
        {
            var vector1 = new Vector3D(1, 2, 5);

            var vector2 = new Vector3D(1, 2, 5);

            Assert.IsTrue(vector1.Equals(vector2));

            Assert.AreEqual(1, vector1.X);
            Assert.AreEqual(2, vector1.Y);
            Assert.AreEqual(5, vector1.Z);

            Assert.AreEqual(1, vector2.X);
            Assert.AreEqual(2, vector2.Y);
            Assert.AreEqual(5, vector2.Z);
        }

    }
}