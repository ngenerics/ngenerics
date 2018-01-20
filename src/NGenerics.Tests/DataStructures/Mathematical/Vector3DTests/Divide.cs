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
    public class Divide
    {

        [Test]
        public void Double()
        {
            var vector = new Vector3D(9, 3, 18);

            vector.Divide(3);

            Assert.AreEqual(3, vector.X);
            Assert.AreEqual(1, vector.Y);
            Assert.AreEqual(6, vector.Z);
        }

        [Test]
        public void Vector3D()
        {
            var vector1 = new Vector3D(24, 48, 72);

            var vector2 = new Vector3D(2, 3, 4);

            vector1.Divide(vector2);

            Assert.AreEqual(1, vector1.X);
            Assert.AreEqual(2, vector1.Y);
            Assert.AreEqual(3, vector1.Z);

            Assert.AreEqual(2, vector2.X);
            Assert.AreEqual(3, vector2.Y);
            Assert.AreEqual(4, vector2.Z);
        }

        [Test]
        public void IVector()
        {
            var vector3D = new Vector3D(24, 48, 72);

            var vectorN = new VectorN(3);
            vectorN.SetValues(2, 3, 4);

            vector3D.Divide(vectorN);

            Assert.AreEqual(1, vector3D.X);
            Assert.AreEqual(2, vector3D.Y);
            Assert.AreEqual(3, vector3D.Z);

            Assert.AreEqual(2, vectorN[0]);
            Assert.AreEqual(3, vectorN[1]);
            Assert.AreEqual(4, vectorN[2]);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExcetionNullVector()
        {
            var vector = new Vector3D();
            vector.Divide(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionDifferentDimensions()
        {
            var vector = new Vector3D();
            VectorBase<double> vectorBase = new VectorN(4);
            vector.Divide(vectorBase);
        }

    }
}