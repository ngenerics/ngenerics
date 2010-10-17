using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector3DTests
{
    [TestFixture]
    public class DotProduct
    {

        [Test]
        public void Vector3D()
        {
            var vector1 = new Vector3D(4, 7, 4);

            var vector2 = new Vector3D(3, 4, 8);

            var dotProduct = vector1.DotProduct(vector2);
            Assert.AreEqual(72, dotProduct);

            Assert.AreEqual(4, vector1.X);
            Assert.AreEqual(7, vector1.Y);
            Assert.AreEqual(4, vector1.Z);

            Assert.AreEqual(3, vector2.X);
            Assert.AreEqual(4, vector2.Y);
            Assert.AreEqual(8, vector2.Z);
        }

        [Test]
        public void IVector()
        {
            var vector3D = new Vector3D(4, 7, 4);

            var vectorN = new VectorN(3);
            vectorN.SetValues(3, 4, 8);

            var dotProduct = vector3D.DotProduct(vectorN);
            Assert.AreEqual(72, dotProduct);

            Assert.AreEqual(4, vector3D.X);
            Assert.AreEqual(7, vector3D.Y);
            Assert.AreEqual(4, vector3D.Z);

            Assert.AreEqual(3, vectorN[0]);
            Assert.AreEqual(4, vectorN[1]);
            Assert.AreEqual(8, vectorN[2]);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionDifferentDimensions()
        {
            var vector = new Vector3D();
            VectorBase<double> vectorBase = new VectorN(4);
            vector.DotProduct(vectorBase);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExcetionNullVector()
        {
            var vector = new Vector3D();
            vector.DotProduct(null);
        }

    }
}