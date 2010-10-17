using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.GeneralTreeTests
{
    [TestFixture]
    public class Serialization : GeneralTreeTest
    {

        [Test]
        public void Simple()
        {
            var tree = GetTestTree();
            var newTree = SerializeUtil.BinarySerializeDeserialize(tree);

            Assert.AreNotSame(tree, newTree);
            Assert.AreEqual(tree.Count, newTree.Count);

            var treeEnumerator = tree.GetEnumerator();
            var newTreeEnumerator = newTree.GetEnumerator();

            while (treeEnumerator.MoveNext())
            {
                Assert.IsTrue(newTreeEnumerator.MoveNext());
                Assert.AreEqual(treeEnumerator.Current, newTreeEnumerator.Current);
                Assert.AreEqual(treeEnumerator.Current, newTreeEnumerator.Current);

                Assert.IsTrue(newTree.Contains(treeEnumerator.Current));
            }

            Assert.IsFalse(newTreeEnumerator.MoveNext());
        }

    }
}