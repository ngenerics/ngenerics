using System;
using NGenerics.DataStructures.Trees.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.ObservableBinaryTreeTests
{
    [TestFixture]
    public class RemoveLeft
    {
        [Test]
        public void Simple()
        {
            var rootBinaryTree = new ObservableBinaryTree<string>("root")
                                     {
                                         "foo"
                                     };
            ObservableCollectionTester.ExpectEvents(rootBinaryTree, obj => obj.RemoveLeft(), "Count", "Item[]", "IsEmpty");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionReentrancy()
        {
            var rootBinaryTree = new ObservableBinaryTree<string>("root")
                                     {
                                         "foo"
                                     };
            new ReentracyTester<ObservableBinaryTree<string>>(rootBinaryTree, obj => obj.RemoveLeft());
        }
    }
}