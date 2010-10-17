using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.SplayTreeTests
{
    [TestFixture]
    public class IsEmpty : SplayTreeTest
    {

        [Test]
        public void Simple()
        {
            var splayTree = new SplayTree<int, string>();
            Assert.IsTrue(splayTree.IsEmpty);

            splayTree = GetTestTree();
            Assert.IsFalse(splayTree.IsEmpty);

            splayTree.Clear();
            Assert.IsTrue(splayTree.IsEmpty);
        }

    }
}