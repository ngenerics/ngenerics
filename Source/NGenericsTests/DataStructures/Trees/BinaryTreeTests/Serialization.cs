using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinaryTreeTests
{
    [TestFixture]
    public class Serialization : BinaryTreeTest
    {

        [Test]
        public void Simple()
        {
            var binaryTree = GetTestTree();
            var newTree = SerializeUtil.BinarySerializeDeserialize(binaryTree);

            Assert.AreNotSame(binaryTree, newTree);
            Assert.AreEqual(binaryTree.Count, newTree.Count);

            var treeEnumerator = binaryTree.GetEnumerator();
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