using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SetTests
{
    [TestFixture]
    public class Remove
    {

        [Test]
        public void Simple()
        {
            var s1 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });

            Assert.AreEqual(s1.Count, 5);
            Assert.IsTrue(s1.Remove(20));
            Assert.AreEqual(s1.Count, 4);

            Assert.IsFalse(s1.Remove(20));
            Assert.AreEqual(s1.Count, 4);

            Assert.IsTrue(s1.Remove(40));
            Assert.AreEqual(s1.Count, 3);
        }

    }
}