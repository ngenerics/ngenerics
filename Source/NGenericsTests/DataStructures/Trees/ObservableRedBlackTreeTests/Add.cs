using System;
using System.Collections.Generic;
using NGenerics.DataStructures.Trees.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.ObservableRedBlackTreeTests
{
    [TestFixture]
    public class Add
    {
        [Test]
        public void Simple()
        {
            var redBlackTree = new ObservableRedBlackTree<string, string>();
            ObservableCollectionTester.ExpectEvents(redBlackTree, obj => obj.Add("foo", "bar"), "Count", "Item[]", "IsEmpty");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionSimpleReentrancy()
        {
            var redBlackTree = new ObservableRedBlackTree<string, string>();
            new ReentracyTester<ObservableRedBlackTree<string, string>>(redBlackTree, obj => obj.Add("foo", "bar"));
        }

        [Test]
        public void KeyValue()
        {
            var redBlackTree = new ObservableRedBlackTree<string, string>();
            var keyValuePair = new KeyValuePair<string, string>("foo", "bar");
            ObservableCollectionTester.ExpectEvents(redBlackTree, obj => obj.Add(keyValuePair), "Count", "Item[]", "IsEmpty");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionKeyValueReentrancy()
        {
            var redBlackTree = new ObservableRedBlackTree<string, string>();
            var keyValuePair = new KeyValuePair<string, string>("foo", "bar");
            new ReentracyTester<ObservableRedBlackTree<string, string>>(redBlackTree, obj => obj.Add(keyValuePair));
        }
    }
}