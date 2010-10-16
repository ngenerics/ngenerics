using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.AssociationTests
{
    [TestFixture]
    public class Key
    {
        [Test]
        public void Simple()
        {
            var assoc = new Association<int, string>(5, "aa");

            Assert.AreEqual(assoc.Key, 5);

            assoc.Key = 2;

            Assert.AreEqual(assoc.Key, 2);
        }

    }
}