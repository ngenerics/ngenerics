using System;
using NGenerics.DataStructures.General.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.Observable.ObservableDictionaryTests
{
    [TestFixture]
    public class Add
    {
        [Test]
        public void Simple()
        {
            var observableDictionary = new ObservableDictionary<string, string>();
            ObservableCollectionTester.ExpectEvents(observableDictionary, obj => obj.Add("foo", "bar"), "Count", "Item[]", "IsEmpty", "ValueCount", "KeyCount");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionSimpleReentrancy()
        {
            var observableDictionary = new ObservableDictionary<string, string>();
            new ReentracyTester<ObservableDictionary<string, string>>(observableDictionary, obj => obj.Add("foo", "bar"));
        }


        [Test]
        public void KeyValue()
        {
            var observableDictionary = new ObservableDictionary<string, string>();
            ObservableCollectionTester.ExpectEvents(observableDictionary, obj => obj.Add("foo", "Value"), "Count", "Item[]", "IsEmpty", "ValueCount", "KeyCount");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionKeyValueReentrancy()
        {
            var observableDictionary = new ObservableDictionary<string, string>();
            new ReentracyTester<ObservableDictionary<string, string>>(observableDictionary, obj => obj.Add("foo", "Value"));
        }
    }
}