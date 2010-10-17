using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector3DTests
{
    [TestFixture]
    public class Add
    {

        [Test]
        public void Double()
        {
            var vector = new Vector3D(4, 7, 3)
                             {
                                 1
                             };
            Assert.AreEqual(5, vector.X);
            Assert.AreEqual(8, vector.Y);
            Assert.AreEqual(4, vector.Z);
        }

        [Test]
        public void Vector3D()
        {
            var vector1 = new Vector3D(4, 7, -1);

            var vector2 = new Vector3D(3, 4, 2);

            vector1.Add(vector2);

            Assert.AreEqual(7, vector1.X);
            Assert.AreEqual(11, vector1.Y);
            Assert.AreEqual(1, vector1.Z);

            Assert.AreEqual(3, vector2.X);
            Assert.AreEqual(4, vector2.Y);
            Assert.AreEqual(2, vector2.Z);
        }

        [Test]
        public void IVector()
        {
            var vector1 = new Vector3D(4, 7, -1);

            var vector2 = new VectorN(3);
            vector2.SetValues(3, 4, 2);

            vector1.Add(vector2);

            Assert.AreEqual(7, vector1.X);
            Assert.AreEqual(11, vector1.Y);
            Assert.AreEqual(1, vector1.Z);

            Assert.AreEqual(3, vector2[0]);
            Assert.AreEqual(4, vector2[1]);
            Assert.AreEqual(2, vector2[2]);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVector()
        {
            new Vector3D
                {
                    null
                };
        }

    }
}