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
    public class Magnitude
    {

        [Test]
        public void Simple()
        {
            var vector3D = new Vector3D(4, 3, 12);

            Assert.AreEqual(13, vector3D.Magnitude());
            Assert.AreEqual(4, vector3D.X);
            Assert.AreEqual(3, vector3D.Y);
            Assert.AreEqual(12, vector3D.Z);
        }

    }
}