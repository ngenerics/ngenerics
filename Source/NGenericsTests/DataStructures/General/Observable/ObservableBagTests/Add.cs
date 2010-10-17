using System;
using NGenerics.DataStructures.General.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.Observable.ObservableBagTests
{
    [TestFixture]
    public class Add
    {
        [Test]
        public void Simple()
        {
            var bag = new ObservableBag<string>();
            ObservableCollectionTester.ExpectEvents(bag, obj => obj.Add("foo"), "Count", "Item[]", "IsEmpty");
        }

        [Test]
        public void Amount()
        {
            var bag = new ObservableBag<string>();
            ObservableCollectionTester.ExpectEvents(bag, obj => obj.Add("foo", 2), "Count", "Item[]", "IsEmpty");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionReentrancy()
        {
            var bag = new ObservableBag<string>();
            new ReentracyTester<ObservableBag<string>>(bag, obj => obj.Add("foo"));
        }
    }
}