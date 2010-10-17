using System;
using System.Collections.Generic;
using NGenerics.DataStructures.Trees.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.ObservableRedBlackTreeTests
{
    [TestFixture]
    public class Clear
    {
        [Test]
        public void Simple()
        {
            var redBlackTree = new ObservableRedBlackTree<string, string>
                                   {
                                       new KeyValuePair<string, string>("foo", "bar")
                                   };
            ObservableCollectionTester.ExpectEvents(redBlackTree, obj => obj.Clear(), "Count", "Item[]", "IsEmpty");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionReentrancy()
        {
            var redBlackTree = new ObservableRedBlackTree<string, string>();
            new ReentracyTester<ObservableRedBlackTree<string, string>>(redBlackTree, obj => obj.Clear());
        }

    }
}