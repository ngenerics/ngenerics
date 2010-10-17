using System;
using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinaryTreeTests
{
    [TestFixture]
    public class Add : BinaryTreeTest
    {

        [Test]
        public void Simple()
        {
            var binaryTree = new BinaryTree<int>(5);

            Assert.AreEqual(binaryTree.Count, 0);
            Assert.AreEqual(binaryTree.Degree, 0);
            Assert.AreEqual(binaryTree.Data, 5);

            binaryTree.Add(3);

            Assert.AreEqual(binaryTree.Count, 1);
            Assert.AreEqual(binaryTree.Degree, 1);
            Assert.AreEqual(binaryTree.Data, 5);

            Assert.AreEqual(binaryTree.Left.Data, 3);
            Assert.IsNull(binaryTree.Right);

            binaryTree.Add(4);

            Assert.AreEqual(binaryTree.Count, 2);
            Assert.AreEqual(binaryTree.Degree, 2);
            Assert.AreEqual(binaryTree.Data, 5);

            Assert.AreEqual(binaryTree.Left.Data, 3);
            Assert.AreEqual(binaryTree.Right.Data, 4);
        }

        [Test]
        public void Interface()
        {
            ITree<int> binaryTree = new BinaryTree<int>(5);

            var child = new BinaryTree<int>(4);
            binaryTree.Add(child);
            Assert.AreEqual(binaryTree.Degree, 1);
            Assert.AreEqual(binaryTree.GetChild(0), child);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionBadAdd1()
        {
            new BinaryTree<int>(5, new BinaryTree<int>(3), new BinaryTree<int>(4))
                {
                    99
                };
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionBadAdd2()
        {
            new BinaryTree<int>(5, new BinaryTree<int>(3), new BinaryTree<int>(4))
                {
                    new BinaryTree<int>(99)
                };
        }

    }
}