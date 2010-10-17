using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.GeneralTreeTests
{
    [TestFixture]
    public class IsReadOnly : GeneralTreeTest
    {

        [Test]
        public void Simple()
        {
            var generalTree = new GeneralTree<int>(4);
            Assert.IsFalse(generalTree.IsReadOnly);

            generalTree = GetTestTree();
            Assert.IsFalse(generalTree.IsReadOnly);
        }

    }
}