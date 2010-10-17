using System;
using NGenerics.DataStructures.General.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.Observable.ObservableBagTests
{
    [TestFixture]
    public class Clear
    {
        [Test]
        public void Simple()
        {
            var bag = new ObservableBag<string> { "foo" };

            ObservableCollectionTester.ExpectEvents(bag, obj => obj.Clear(), "Count", "Item[]", "IsEmpty");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionReentrancy()
        {
            var bag = new ObservableBag<string> { "foo" };
            new ReentracyTester<ObservableBag<string>>(bag, obj => obj.Clear());
        }
    }
}