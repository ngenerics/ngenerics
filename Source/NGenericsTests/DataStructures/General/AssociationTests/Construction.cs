using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.AssociationTests
{
    [TestFixture]
    public class Construction
    {

        [Test]
        public void Simple()
        {
            var assoc = new Association<int, string>(5, "aa");

            Assert.AreEqual(assoc.Key, 5);
            Assert.AreEqual(assoc.Value, "aa");

        }
        [Test]
        public void Equality()
        {
            var assoc = new Association<int, string>(5, "aa");
            var assoc2 = new Association<int, string>(5, "aa");
            Assert.AreEqual(assoc.Key, assoc2.Key);
            Assert.AreEqual(assoc.Key, assoc2.Key);
            Assert.AreEqual(assoc, assoc2);

        }

    }
}