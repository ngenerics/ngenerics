using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.SplayTreeTests
{
    [TestFixture]
    public class Clear : SplayTreeTest
    {

        [Test]
        public void Simple()
        {
            var splayTree = new SplayTree<int, string>();
            splayTree.Clear();

            Assert.AreEqual(splayTree.Count, 0);

            splayTree = GetTestTree();
            Assert.IsTrue(splayTree.ContainsKey(19));

            splayTree.Clear();
            Assert.AreEqual(splayTree.Count, 0);
            Assert.IsFalse(splayTree.ContainsKey(19));
        }

    }
}