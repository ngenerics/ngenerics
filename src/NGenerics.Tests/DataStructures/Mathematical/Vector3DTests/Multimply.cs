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
    public class Multimply
    {

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVector()
        {
            var vector = new Vector3D();
            vector.Multiply(null);
        }

        [Test]
        public void Double()
        {
            var vector = new Vector3D(1, 2, 9);

            vector.Multiply(2);

            Assert.AreEqual(2, vector.X);
            Assert.AreEqual(4, vector.Y);
            Assert.AreEqual(18, vector.Z);
        }

        [Test]
        public void Vector3D()
        {
            var vector1 = new Vector3D(1, 2, 8);

            var vector2 = new Vector3D(3, 4, 2);

            var matrix = vector1.Multiply(vector2);

            Assert.AreEqual(3, matrix.Columns);
            Assert.AreEqual(3, matrix.Rows);

            Assert.AreEqual(3, matrix[0, 0]);
            Assert.AreEqual(4, matrix[0, 1]);
            Assert.AreEqual(2, matrix[0, 2]);

            Assert.AreEqual(6, matrix[1, 0]);
            Assert.AreEqual(8, matrix[1, 1]);
            Assert.AreEqual(4, matrix[1, 2]);

            Assert.AreEqual(24, matrix[2, 0]);
            Assert.AreEqual(32, matrix[2, 1]);
            Assert.AreEqual(16, matrix[2, 2]);

            Assert.AreEqual(1, vector1.X);
            Assert.AreEqual(2, vector1.Y);
            Assert.AreEqual(8, vector1.Z);

            Assert.AreEqual(3, vector2.X);
            Assert.AreEqual(4, vector2.Y);
            Assert.AreEqual(2, vector2.Z);
        }

        [Test]
        public void IVector()
        {
            var vector3D = new Vector3D(1, 2, 8);

            var vectorN = new VectorN(3);
            vectorN.SetValues(3, 4, 2);

            var matrix = vector3D.Multiply(vectorN);

            Assert.AreEqual(3, matrix.Columns);
            Assert.AreEqual(3, matrix.Rows);

            Assert.AreEqual(3, matrix[0, 0]);
            Assert.AreEqual(4, matrix[0, 1]);
            Assert.AreEqual(2, matrix[0, 2]);

            Assert.AreEqual(6, matrix[1, 0]);
            Assert.AreEqual(8, matrix[1, 1]);
            Assert.AreEqual(4, matrix[1, 2]);

            Assert.AreEqual(24, matrix[2, 0]);
            Assert.AreEqual(32, matrix[2, 1]);
            Assert.AreEqual(16, matrix[2, 2]);

            Assert.AreEqual(1, vector3D.X);
            Assert.AreEqual(2, vector3D.Y);
            Assert.AreEqual(8, vector3D.Z);

            Assert.AreEqual(3, vectorN[0]);
            Assert.AreEqual(4, vectorN[1]);
            Assert.AreEqual(2, vectorN[2]);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionDifferentDimensions()
        {
            var vector = new Vector3D();
            VectorBase<double> vectorBase = new VectorN(2);
            vector.Multiply(vectorBase);
        }

    }
}