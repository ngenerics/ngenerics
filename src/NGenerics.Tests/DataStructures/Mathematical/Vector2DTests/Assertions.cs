/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector2DTests
{
    public static class Assertions
    {
        public static void AssertEquals(this Vector3D vector, double x, double y, double z)
        {
            Assert.AreEqual(x, vector[0]);
            Assert.AreEqual(y, vector[1]);
            Assert.AreEqual(z, vector[2]);
        }
    }
}
