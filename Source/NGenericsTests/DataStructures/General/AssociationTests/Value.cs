using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.AssociationTests
{
    [TestFixture]
    public class Value
    {

        [Test]
        public void Simple()
        {
            var assoc = new Association<int, string>(5, "aa");

            Assert.AreEqual(assoc.Value, "aa");

            assoc.Value = "bla";

            Assert.AreEqual(assoc.Value, "bla");
        }

    }
}