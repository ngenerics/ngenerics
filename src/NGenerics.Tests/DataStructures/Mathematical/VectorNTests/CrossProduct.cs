/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorNTests
{
    [TestFixture]
    public class CrossProduct
    {

        [Test]
        public void Simple3x3()
        {
            var vector1 = new VectorN(3);
            vector1.SetValues(1, 2, 3);
            var vector2 = new VectorN(3);
            vector2.SetValues(4, 5, 6);

            var vector = vector1.CrossProduct(vector2);

            Assert.AreEqual(-3, vector[0]);
            Assert.AreEqual(6, vector[1]);
            Assert.AreEqual(-3, vector[2]);
        }

        [Test]
        public void Simple2x2()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(2, 3);
            var vector2 = new VectorN(2);
            vector2.SetValues(4, 5);

            var vector = vector1.CrossProduct(vector2);

            Assert.AreEqual(0, vector[0]);
            Assert.AreEqual(0, vector[1]);
            Assert.AreEqual(-2, vector[2]);
        }

        [Test]
        public void Simple2x3()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(2, 3);
            var vector2 = new VectorN(3);
            vector2.SetValues(4, 5, 6);

            var vector = vector1.CrossProduct(vector2);

            Assert.AreEqual(18, vector[0]);
            Assert.AreEqual(-12, vector[1]);
            Assert.AreEqual(-2, vector[2]);
        }

        [Test]
        public void Simple3x2()
        {
            var vector1 = new VectorN(3);
            vector1.SetValues(1, 2, 3);
            var vector2 = new VectorN(2);
            vector2.SetValues(4, 5);

            var vector = vector1.CrossProduct(vector2);

            Assert.AreEqual(-15, vector[0]);
            Assert.AreEqual(12, vector[1]);
            Assert.AreEqual(-3, vector[2]);
        }

    }
}