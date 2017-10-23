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
    public class NotEqualsOperator
    {
        [Test]
        public void Simple()
        {
            var vector3D1 = new Vector3D(1, 2, 5);
            var vector3D2 = new Vector3D(1, 2, 5);
            Assert.IsFalse(vector3D1 != vector3D2);
            Assert.AreEqual(1, vector3D1.X);
            Assert.AreEqual(2, vector3D1.Y);
            Assert.AreEqual(5, vector3D1.Z);
            Assert.AreEqual(1, vector3D2.X);
            Assert.AreEqual(2, vector3D2.Y);
            Assert.AreEqual(5, vector3D2.Z);
        }
    }
}