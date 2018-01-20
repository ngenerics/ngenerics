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
    public class CrossProduct
    {

        [Test]
        public void Exception3x3()
        {
            var vector1 = new VectorBaseTestObject(3);
            var vector2 = new VectorBaseTestObject(3);
            Assert.Throws<NotImplementedException>(() => vector1.CrossProduct(vector2));
        }

        [Test]
        public void Exception2x3()
        {
            var vector1 = new VectorBaseTestObject(2);
            var vector2 = new VectorBaseTestObject(3);
            Assert.Throws<NotImplementedException>(() => vector1.CrossProduct(vector2));
        }

        [Test]
        public void Exception3x2()
        {
            var vector1 = new VectorBaseTestObject(3);
            var vector2 = new VectorBaseTestObject(2);
            Assert.Throws<NotImplementedException>(() => vector1.CrossProduct(vector2));
        }

        [Test]
        public void Exception2x2()
        {
            var vector1 = new VectorBaseTestObject(2);
            var vector2 = new VectorBaseTestObject(2);
            Assert.Throws<NotImplementedException>(() => vector1.CrossProduct(vector2));
        }

        [Test]
        public void Exception1x2()
        {
            var vector1 = new VectorBaseTestObject(1);
            var vector2 = new VectorBaseTestObject(2);
            Assert.Throws<InvalidOperationException>(() => vector1.CrossProduct(vector2));
        }

        [Test]
        public void Exception4x2()
        {
            var vector1 = new VectorBaseTestObject(4);
            var vector2 = new VectorBaseTestObject(2);
            Assert.Throws<InvalidOperationException>(() => vector1.CrossProduct(vector2));
        }

        [Test]
        public void Exception2x1()
        {
            var vector1 = new VectorBaseTestObject(2);
            var vector2 = new VectorBaseTestObject(1);
            Assert.Throws<ArgumentException>(() => vector1.CrossProduct(vector2));
        }

        [Test]
        public void ExceptionDifferentDimensions1()
        {
            var vector1 = new VectorBaseTestObject(2);
            var vector2 = new VectorBaseTestObject(4);
            Assert.Throws<ArgumentException>(() => vector1.CrossProduct(vector2));
        }

        [Test]
        public void ExceptionNullVector()
        {
            var vector1 = new VectorBaseTestObject(2);
            Assert.Throws<ArgumentNullException>(() => vector1.CrossProduct(null));
        }

    }
}