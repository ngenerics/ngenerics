using System.Collections;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.CurveTests
{
    [TestFixture]
    public class Add : Curve<int, int>
    {
        [Test]
        public void Simple()
        {
            var curve = new Curve<string, int> { { "alpha", 3 } };
            Assert.IsTrue(curve.Contains("alpha", 3));
        }
        [Test]
        public void Interface()
        {
            var curve = (IList)new Curve<int, int>();
            var a = new Association<int, int>(11, 32);
            curve.Add(a);
            Assert.IsTrue(curve.Contains(a));
        }
        [Test]
        public void AddOne()
        {
            var curve = new Curve<int, int>();
            var a = new Association<int, int>(11, 32);
            curve.Add(a);
            Assert.IsTrue(curve.Contains(a));
            Assert.IsTrue(curve.Contains(11, 32));

        }

        [Test]
        public void AddTwo()
        {
            var curve = new Curve<int, int>
                            {
                                {12, 32}
                            };
            Assert.IsTrue(curve.Contains(12, 32));
        }

    }
}