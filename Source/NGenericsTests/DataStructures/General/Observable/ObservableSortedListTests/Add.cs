using System;
using NGenerics.DataStructures.General.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.Observable.ObservableSortedListTests
{
    [TestFixture]
    public class Add
    {
        [Test]
        public void Simple()
        {
            var hashList = new ObservableSortedList<string>();
            ObservableCollectionTester.ExpectEvents(hashList, obj => obj.Add("foo"), "Count", "Item[]", "IsEmpty");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionSimpleReentrancy()
        {
            var hashList = new ObservableSortedList<string>();
            new ReentracyTester<ObservableSortedList<string>>(hashList, obj => obj.Add("foo"));
        }



    }
}