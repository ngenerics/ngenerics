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

namespace NGenerics.Tests.DataStructures.Mathematical.Vector3DTests
{
    [TestFixture]
    public class SubtractOperator
    {
        [Test]
        public void Simple()
        {
            var vector3D = new Vector3D(4, 7, 6);
            var vector = vector3D - 2;

            Assert.AreEqual(2, vector.X);
            Assert.AreEqual(5, vector.Y);
            Assert.AreEqual(4, vector.Z);

            Assert.AreNotSame(vector3D, vector);

            Assert.AreEqual(4, vector3D.X);
            Assert.AreEqual(7, vector3D.Y);
            Assert.AreEqual(6, vector3D.Z);
        }


        [Test]
        public void Vector()
        {
            var vector3D1 = new Vector3D(4, 7, 8);
            var vector3D2 = new Vector3D(3, 4, 2);
            var vector = vector3D1 - vector3D2;

            Assert.AreEqual(1, vector.X);
            Assert.AreEqual(3, vector.Y);
            Assert.AreEqual(6, vector.Z);

            Assert.AreNotSame(vector3D1, vector);
            Assert.AreNotSame(vector3D2, vector);

            Assert.AreEqual(4, vector3D1.X);
            Assert.AreEqual(7, vector3D1.Y);
            Assert.AreEqual(8, vector3D1.Z);

            Assert.AreEqual(3, vector3D2.X);
            Assert.AreEqual(4, vector3D2.Y);
            Assert.AreEqual(2, vector3D2.Z);
        }


        [Test]
        public void ExceptionDifferentDimensions()
        {
            var vector3D = new Vector3D();
            VectorBase<double> vectorBase = new VectorN(4);
            IVector<double> vector;
            Assert.Throws<ArgumentException>(() => vector = vector3D - vectorBase);
        }


        [Test]
        public void ExceptionLeftNull()
        {
            var vector3D1 = new Vector3D();
            Vector3D vector;
            Assert.Throws<ArgumentNullException>(() => vector = null - vector3D1);
        }


        [Test]
        public void ExceptionRightNull()
        {
            var vector3D1 = new Vector3D();
            Vector3D vector;
            Assert.Throws<ArgumentNullException>(() => vector = vector3D1 - null);
        }
    }
}