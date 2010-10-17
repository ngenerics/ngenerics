using System;
using NGenerics.DataStructures.General.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.Observable.ObservableDictionaryTests
{
    [TestFixture]
    public class Clear
    {
        [Test]
        public void Simple()
        {
            var observableDictionary = new ObservableDictionary<string, string>
                                           {
                                               {"foo", "Bar"}
                                           };

            ObservableCollectionTester.ExpectEvents(observableDictionary, obj => obj.Clear(), "Count", "Item[]", "IsEmpty", "ValueCount", "KeyCount");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionReentrancy()
        {
            var observableDictionary = new ObservableDictionary<string, string>
                                           {
                                               {"foo", "Bar"}
                                           };
            new ReentracyTester<ObservableDictionary<string, string>>(observableDictionary, obj => obj.Clear());
        }
    }
}