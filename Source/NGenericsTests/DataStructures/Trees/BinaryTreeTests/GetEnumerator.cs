using System.Collections;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinaryTreeTests
{
    [TestFixture]
    public class GetEnumerator : BinaryTreeTest
    {

        [Test]
        public void Simple()
        {
            var binaryTree = GetTestTree();
            var enumerator = binaryTree.GetEnumerator();

            var itemCount = 6;

            while (enumerator.MoveNext())
            {
                itemCount--;
            }

            Assert.AreEqual(itemCount, 0);
        }

        [Test]
        public void Interface()
        {
            IEnumerable binaryTree = GetTestTree();
            var enumerator = binaryTree.GetEnumerator();

            var itemCount = 6;

            while (enumerator.MoveNext())
            {
                itemCount--;
            }

            Assert.AreEqual(itemCount, 0);
        }

    }
}