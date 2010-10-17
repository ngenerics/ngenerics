using System;
using System.Collections.Generic;
using NGenerics.DataStructures.General.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.Observable.ObservableSkipListTests
{
    [TestFixture]
    public class Add
    {
        [Test]
        public void Simple()
        {
            var skipList = new ObservableSkipList<string, string>();
            ObservableCollectionTester.ExpectEvents(skipList, obj => obj.Add("foo", "bar"), "Count", "CurrentListLevel", "IsEmpty", "Values");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionSimpleReentrancy()
        {
            var skipList = new ObservableSkipList<string, string>();
            new ReentracyTester<ObservableSkipList<string, string>>(skipList, obj => obj.Add("foo", "bar"));
        }
        [Test]
        public void KeyValuePair()
        {
            var skipList = new ObservableSkipList<string, string>();
            var keyValuePair = new KeyValuePair<string, string>("foo", "bar");
            ObservableCollectionTester.ExpectEvents(skipList, obj => obj.Add(keyValuePair), "Count", "CurrentListLevel", "IsEmpty", "Values");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionKeyValuePairReentrancy()
        {
            var skipList = new ObservableSkipList<string, string>();
            var keyValuePair = new KeyValuePair<string, string>("foo", "bar");
            new ReentracyTester<ObservableSkipList<string, string>>(skipList, obj => obj.Add(keyValuePair));
        }

    }
}