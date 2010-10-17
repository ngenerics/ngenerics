using System;
using System.Collections.Generic;
using NGenerics.DataStructures.General.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.Observable.ObservableHashListTests
{
    [TestFixture]
    public class AddItem
    {


        [Test]
        public void KeyValue()
        {
            var hashList = new ObservableHashList<string, string>();
            ObservableCollectionTester.ExpectEvents(hashList, obj => obj.AddItem(new KeyValuePair<string, string>("foo", "foo")), "Count", "Item[]", "IsEmpty", "ValueCount", "KeyCount");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionReentrancy()
        {
            var hashList = new ObservableHashList<string, string>();
            new ReentracyTester<ObservableHashList<string, string>>(hashList, obj => obj.AddItem(new KeyValuePair<string, string>("foo", "foo")));
        }

    }
}