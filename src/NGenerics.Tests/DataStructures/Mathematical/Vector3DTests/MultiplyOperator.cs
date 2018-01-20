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
    public class MultiplyOperator
    {
        [Test]
        public void Simple()
        {
            var vector3D1 = new Vector3D(4, 7, 8);
            var vector = vector3D1 * 2;
            Assert.AreEqual(8, vector.X);
            Assert.AreEqual(14, vector.Y);
            Assert.AreEqual(16, vector.Z);
            Assert.AreNotSame(vector3D1, vector);
            Assert.AreEqual(4, vector3D1.X);
            Assert.AreEqual(7, vector3D1.Y);
            Assert.AreEqual(8, vector3D1.Z);
        }


        [Test]
        public void Vector()
        {
            var vector3D1 = new Vector3D(4, 7, 2);

            var vector3D2 = new Vector3D(3, 4, 9);

            var matrix = vector3D1 * vector3D2;
            Assert.AreEqual(3, matrix.Columns);
            Assert.AreEqual(3, matrix.Rows);

            Assert.AreEqual(12, matrix[0, 0]);
            Assert.AreEqual(16, matrix[0, 1]);
            Assert.AreEqual(36, matrix[0, 2]);

            Assert.AreEqual(21, matrix[1, 0]);
            Assert.AreEqual(28, matrix[1, 1]);
            Assert.AreEqual(63, matrix[1, 2]);

            Assert.AreEqual(6, matrix[2, 0]);
            Assert.AreEqual(8, matrix[2, 1]);
            Assert.AreEqual(18, matrix[2, 2]);

            Assert.AreEqual(4, vector3D1.X);
            Assert.AreEqual(7, vector3D1.Y);
            Assert.AreEqual(2, vector3D1.Z);

            Assert.AreEqual(3, vector3D2.X);
            Assert.AreEqual(4, vector3D2.Y);
            Assert.AreEqual(9, vector3D2.Z);
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionDifferentDimensions()
        {
            var vector3D = new Vector3D();
            VectorBase<double> vectorBase = new VectorN(2);
            var matrix = vector3D * vectorBase;
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionLeftNull()
        {
            var vector3D1 = new Vector3D();
            var matrix = null * vector3D1;
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionRightNull()
        {
            var vector3D1 = new Vector3D();
            var matrix = vector3D1 * null;
        }
    }
}