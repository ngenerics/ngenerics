/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorNTests
{
    [TestFixture]
    public class GetUnitVector
    {

        [Test]
        public void Simple()
        {
            var vector = VectorN.GetUnitVector(3);

            Assert.AreEqual(3, vector.DimensionCount);
            Assert.AreEqual(1, vector[0]);
            Assert.AreEqual(1, vector[1]);
            Assert.AreEqual(1, vector[2]);
        }

        [Test]
        public void ExceptionDimensionCountZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => VectorN.GetUnitVector(0));
        }

        [Test]
        public void ExceptionDimensionCountNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => VectorN.GetUnitVector(-1));
        }
    }
}