using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector3DTests
{
    [TestFixture]
    public class GreaterThanOperator
    {
        [Test]
        public void Simple()
        {
            var vector1 = new Vector3D(1, 1, 1);
            var vector2 = new Vector3D(2, 2, 2);
            var vector3 = new Vector3D(2, 2, 2);

            Assert.IsFalse(vector1 > vector2);
            Assert.IsTrue(vector2 > vector1);
            Assert.IsFalse(vector2 > vector3);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionLeftNull()
        {
            const Vector3D vector1 = null;
            var vector2 = new Vector3D(2, 2, 2);

            var condition = vector1 > vector2;
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionRightNull()
        {
            var vector1 = new Vector3D(2, 2, 2);
            const Vector3D vector2 = null;

            var condition = vector1 > vector2;
        }
    }
}