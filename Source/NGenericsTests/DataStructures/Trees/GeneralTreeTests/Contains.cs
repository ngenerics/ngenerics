using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.GeneralTreeTests
{
    [TestFixture]
    public class Contains : GeneralTreeTest
    {

        [Test]
        public void Simple()
        {
            var generalTree = GetTestTree();
            Assert.IsTrue(generalTree.Contains(5));
            Assert.IsTrue(generalTree.Contains(2));
            Assert.IsTrue(generalTree.Contains(3));
            Assert.IsTrue(generalTree.Contains(1));
            Assert.IsTrue(generalTree.Contains(9));
            Assert.IsTrue(generalTree.Contains(12));
            Assert.IsTrue(generalTree.Contains(13));
            Assert.IsFalse(generalTree.Contains(4));
        }

    }
}