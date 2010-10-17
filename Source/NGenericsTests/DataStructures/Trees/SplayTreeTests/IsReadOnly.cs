using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.SplayTreeTests
{
    [TestFixture]
    public class IsReadOnly : SplayTreeTest
    {

        [Test]
        public void Simple()
        {
            var splayTree = new SplayTree<int, string>();
            Assert.IsFalse(splayTree.IsReadOnly);

            splayTree = GetTestTree();
            Assert.IsFalse(splayTree.IsReadOnly);
        }

    }
}