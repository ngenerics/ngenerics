/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector3DTests
{
    [TestFixture]
    public class EqualsOperator
    {
        [Test]
        public void Simple()
        {
            var vector3D1 = new Vector3D(1, 2, 6);
            var vector3D2 = new Vector3D(1, 2, 6);
            Assert.IsTrue(vector3D1 == vector3D2);
            Assert.AreEqual(1, vector3D1.X);
            Assert.AreEqual(2, vector3D1.Y);
            Assert.AreEqual(6, vector3D1.Z);
            Assert.AreEqual(1, vector3D2.X);
            Assert.AreEqual(2, vector3D2.Y);
            Assert.AreEqual(6, vector3D2.Z);
        }


        [Test]
        public void LeftNull()
        {
            var vector3D1 = new Vector3D();
            const Vector3D vector3D2 = null;
            Assert.IsFalse(vector3D2 == vector3D1);
        }


        [Test]
        public void ReferenceEquals()
        {
            var vector3D1 = new Vector3D();
            var vector3D2 = vector3D1;
            Assert.IsTrue(vector3D1 == vector3D2);
        }


        [Test]
        public void RightNull()
        {
            var vector3D1 = new Vector3D();
            const Vector3D vector3D2 = null;
            Assert.IsFalse(vector3D1 == vector3D2);
        }
    }
}