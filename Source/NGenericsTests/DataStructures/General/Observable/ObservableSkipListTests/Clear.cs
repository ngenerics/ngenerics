using System;
using System.Collections.Generic;
using NGenerics.DataStructures.General.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.Observable.ObservableSkipListTests
{
    [TestFixture]
    public class Clear
    {
        [Test]
        public void Simple()
        {

            var skipList = new ObservableSkipList<string, string> { new KeyValuePair<string, string>("foo", "bar") };

            ObservableCollectionTester.ExpectEvents(skipList, obj => obj.Clear(), "Count", "CurrentListLevel", "IsEmpty", "Values");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionReentrancy()
        {
            var skipList = new ObservableSkipList<string, string> { new KeyValuePair<string, string>("foo", "bar") };
            new ReentracyTester<ObservableSkipList<string, string>>(skipList, obj => obj.Clear());
        }
    }
}