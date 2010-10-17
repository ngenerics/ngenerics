using System;
using System.Collections.Generic;
using NGenerics.DataStructures.Trees.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.ObservableSplayTreeTests
{
    [TestFixture]
    public class Add
    {
        [Test]
        public void Simple()
        {
            var splayTree = new ObservableSplayTree<string, string>();
            ObservableCollectionTester.ExpectEvents(splayTree, obj => obj.Add("foo", "bar"), "Count", "Item[]", "IsEmpty");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionSimpleReentrancy()
        {
            var splayTree = new ObservableSplayTree<string, string>();
            new ReentracyTester<ObservableSplayTree<string, string>>(splayTree, obj => obj.Add("foo", "bar"));
        }
        [Test]
        public void KeyValue()
        {
            var splayTree = new ObservableSplayTree<string, string>();
            var keyValuePair = new KeyValuePair<string, string>("foo", "bar");
            ObservableCollectionTester.ExpectEvents(splayTree, obj => obj.Add(keyValuePair), "Count", "Item[]", "IsEmpty");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionKeyValueReentrancy()
        {
            var splayTree = new ObservableSplayTree<string, string>();
            var keyValuePair = new KeyValuePair<string, string>("foo", "bar");
            new ReentracyTester<ObservableSplayTree<string, string>>(splayTree, obj => obj.Add(keyValuePair));
        }

    }
}