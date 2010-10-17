using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector3DTests
{
    [TestFixture]
    public class ToStringObj
    {

        [Test]
        public void Simple()
        {
            var vector = new Vector3D();
            var actual = vector.ToString();
            Assert.AreEqual("{0,0,0}", actual);
            vector.X = 1;
            vector.Y = 2;
            vector.Z = 7;
            actual = vector.ToString();
            Assert.AreEqual("{1,2,7}", actual);
            Assert.AreEqual(1, vector.X);
            Assert.AreEqual(2, vector.Y);
            Assert.AreEqual(7, vector.Z);
        }

    }
}