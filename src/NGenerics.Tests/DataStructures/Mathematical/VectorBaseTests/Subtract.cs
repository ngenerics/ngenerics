/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NGenerics.Tests.DataStructures.Mathematical.VectorBaseTestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorBaseTests
{
    [TestFixture]
    public class Subtract
    {

        [Test]
        public void Exception()
        {
            var vector1 = new VectorBaseTestObject(2);
            var vector2 = new VectorBaseTestObject(2);
            Assert.Throws<NotImplementedException>(() => vector1.Subtract(vector2), "SubtractSafe");
        }

        [Test]
        public void ExceptionVectorNull()
        {
            var vector1 = new VectorBaseTestObject(2);
            Assert.Throws<ArgumentNullException>(() => vector1.Subtract(null));
        }


        [Test]
        public void ExceptionDifferentDimensions()
        {
            var vector1 = new VectorBaseTestObject(2);
            var vector2 = new VectorBaseTestObject(3);
            Assert.Throws<ArgumentException>(() => vector1.Subtract(vector2));;
        }

    }
}