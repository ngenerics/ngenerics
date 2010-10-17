using System;
using System.Collections.Generic;
using NGenerics.DataStructures.General.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.Observable.ObservableHashListTests
{
    [TestFixture]
    public class Add
    {
        [Test]
        public void Simple()
        {
            var hashList = new ObservableHashList<string, string>();
            ObservableCollectionTester.ExpectEvents(hashList, obj => obj.Add("foo"), "Count", "Item[]", "IsEmpty", "ValueCount", "KeyCount");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionSimpleReentrancy()
        {
            var hashList = new ObservableHashList<string, string>();
            new ReentracyTester<ObservableHashList<string, string>>(hashList, obj => obj.Add("foo"));
        }


        [Test]
        public void List()
        {
            var hashList = new ObservableHashList<string, string>();
            IList<string> list = new List<string> { "Value1", "Value2" };
            ObservableCollectionTester.ExpectEvents(hashList, obj => obj.Add("foo", list), "Count", "Item[]", "IsEmpty", "ValueCount", "KeyCount");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionListReentrancy()
        {
            var hashList = new ObservableHashList<string, string>();
            IList<string> list = new List<string> { "Value1", "Value2" };
            new ReentracyTester<ObservableHashList<string, string>>(hashList, obj => obj.Add("foo", list));
        }

        [Test]
        public void Params()
        {
            var hashList = new ObservableHashList<string, string>();
            ObservableCollectionTester.ExpectEvents(hashList, obj => obj.Add("foo", "Value1", "Value2"), "Count", "Item[]", "IsEmpty", "ValueCount", "KeyCount");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionParamsReentrancy()
        {
            var hashList = new ObservableHashList<string, string>();
            new ReentracyTester<ObservableHashList<string, string>>(hashList, obj => obj.Add("foo", "Value1", "Value2"));
        }
        [Test]
        public void KeyValue()
        {
            var hashList = new ObservableHashList<string, string>();
            ObservableCollectionTester.ExpectEvents(hashList, obj => obj.Add("foo", "Value"), "Count", "Item[]", "IsEmpty", "ValueCount", "KeyCount");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionKeyValueReentrancy()
        {
            var hashList = new ObservableHashList<string, string>();
            new ReentracyTester<ObservableHashList<string, string>>(hashList, obj => obj.Add("foo", "Value"));
        }
    }
}