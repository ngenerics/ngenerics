using System;
using NGenerics.DataStructures.General.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.Observable.ObservableSortedListTests
{
    [TestFixture]
    public class Clear
    {
        [Test]
        public void Simple()
        {
            var hashList = new ObservableSortedList<string>
                               {
                                   "foo"
                               };

            ObservableCollectionTester.ExpectEvents(hashList, obj => obj.Clear(), "Count", "Item[]", "IsEmpty");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionReentrancy()
        {
            var hashList = new ObservableSortedList<string>
                               {
                                   "foo"
                               };
            new ReentracyTester<ObservableSortedList<string>>(hashList, obj => obj.Clear());
        }
    }

}