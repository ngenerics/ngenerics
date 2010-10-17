using System;
using System.Collections.Generic;
using NGenerics.DataStructures.Trees.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.ObservableBinarySearchTreeTests
{
    [TestFixture]
    public class Clear
    {
        [Test]
        public void Simple()
        {
            var binarySearchTree = new ObservableBinarySearchTree<string, string>
                                       {
                                           new KeyValuePair<string, string>("foo", "bar")
                                       };
            ObservableCollectionTester.ExpectEvents(binarySearchTree, obj => obj.Clear(), "Count", "Item[]", "IsEmpty");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionReentrancy()
        {
            var binarySearchTree = new ObservableBinarySearchTree<string, string>
                                       {
                                           new KeyValuePair<string, string>("foo", "bar")
                                       };
            new ReentracyTester<ObservableBinarySearchTree<string, string>>(binarySearchTree, obj => obj.Clear());
        }
    }
}