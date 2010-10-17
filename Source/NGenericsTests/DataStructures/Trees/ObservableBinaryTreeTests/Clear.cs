using System;
using NGenerics.DataStructures.Trees.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.ObservableBinaryTreeTests
{
    [TestFixture]
    public class Clear
    {
        [Test]
        public void Simple()
        {
            var binaryTree = new ObservableBinaryTree<string>("root")
                                 {
                                     "foo"
                                 };
            ObservableCollectionTester.ExpectEvents(binaryTree, obj => obj.Clear(), "Count", "Item[]", "IsEmpty");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionSimpleReentrancy()
        {
            var binaryTree = new ObservableBinaryTree<string>("root");
            new ReentracyTester<ObservableBinaryTree<string>>(binaryTree, obj => obj.Add("foo"));
        }
    }
}