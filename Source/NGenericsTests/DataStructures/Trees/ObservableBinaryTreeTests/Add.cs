using System;
using NGenerics.DataStructures.Trees;
using NGenerics.DataStructures.Trees.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.ObservableBinaryTreeTests
{
    [TestFixture]
    public class Add
    {
        [Test]
        public void Simple()
        {
            var binaryTree = new ObservableBinaryTree<string>("root");
            ObservableCollectionTester.ExpectEvents(binaryTree, obj => obj.Add("foo"), "Count", "Item[]", "IsEmpty");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionSimpleReentrancy()
        {
            var binaryTree = new ObservableBinaryTree<string>("root");
            new ReentracyTester<ObservableBinaryTree<string>>(binaryTree, obj => obj.Add("foo"));
        }
        [Test]
        public void BinaryTree()
        {
            var rootBinaryTree = new ObservableBinaryTree<string>("root");
            var childBinaryTree = new BinaryTree<string>("child");
            ObservableCollectionTester.ExpectEvents(rootBinaryTree, obj => obj.Add(childBinaryTree), "Count", "Item[]", "IsEmpty");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionBinaryTreeReentrancy()
        {
            var rootBinaryTree = new ObservableBinaryTree<string>("root");
            var childBinaryTree = new BinaryTree<string>("child");
            new ReentracyTester<ObservableBinaryTree<string>>(rootBinaryTree, obj => obj.Add(childBinaryTree));
        }

    }
}