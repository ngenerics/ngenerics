using System;
using System.Collections.Generic;
using System.Text;
using NGenerics.DataStructures.Trees;
using NGenerics.Tests.DataStructures.Trees.BinarySearchTreeTests;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees
{
    [TestFixture]
    public class BinarySearchTreeTestsCollection : BinarySearchTreeTest
    {
        [Test]
        public void Clear_Removes_Items_From_Tree()
        {
            var tree = new BinarySearchTree<int, string>();
            tree.Clear();

            Assert.AreEqual(0, tree.Count);

            tree = GetTestTree();
            Assert.IsTrue(tree.ContainsKey(19));

            tree.Clear();
            Assert.AreEqual(0, tree.Count);
            Assert.IsFalse(tree.ContainsKey(19));
        }
    }
}
