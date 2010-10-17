using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.GeneralTreeTests
{
    [TestFixture]
    public class IsLeafNode : GeneralTreeTest
    {

        [Test]
        public void Simple()
        {
            var generalTree = GetTestTree();
            Assert.IsFalse(generalTree.IsLeafNode);
            Assert.IsTrue(generalTree.GetChild(0).GetChild(0).IsLeafNode);

            generalTree.Clear();
            Assert.IsTrue(generalTree.IsLeafNode);
        }

    }
}