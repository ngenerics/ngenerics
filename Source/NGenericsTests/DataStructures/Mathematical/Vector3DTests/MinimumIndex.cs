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
    public class MinimumIndex
    {

        [Test]
        public void Simple()
        {
            var vector1 = new Vector3D(1, -4, 3);

            Assert.AreEqual(1, vector1.MinimumIndex());

            Assert.AreEqual(1, vector1.X);
            Assert.AreEqual(-4, vector1.Y);
            Assert.AreEqual(3, vector1.Z);


            var vector2 = new Vector3D(1, 4, 3);

            Assert.AreEqual(0, vector2.MinimumIndex());

            Assert.AreEqual(1, vector2.X);
            Assert.AreEqual(4, vector2.Y);
            Assert.AreEqual(3, vector2.Z);


            var vector3 = new Vector3D(1, 4, -3);

            Assert.AreEqual(2, vector3.MinimumIndex());

            Assert.AreEqual(1, vector3.X);
            Assert.AreEqual(4, vector3.Y);
            Assert.AreEqual(-3, vector3.Z);


            var vector4 = new Vector3D(6, 4, -3);

            Assert.AreEqual(2, vector4.MinimumIndex());

            Assert.AreEqual(6, vector4.X);
            Assert.AreEqual(4, vector4.Y);
            Assert.AreEqual(-3, vector4.Z);
        }

    }
}