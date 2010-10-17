using System;
using NGenerics.DataStructures.General.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.Observable.ObservableHashListTests
{
    [TestFixture]
    public class RemoveAll
    {
        [Test]
        public void Simple()
        {
            var hashList = new ObservableHashList<string, string> { "foo" };

            ObservableCollectionTester.ExpectEvents(hashList, obj => obj.RemoveAll("foo"), "Count", "Item[]", "IsEmpty", "ValueCount", "KeyCount");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionReentrancy()
        {
            var hashList = new ObservableHashList<string, string> { "foo" };
            new ReentracyTester<ObservableHashList<string, string>>(hashList, obj => obj.RemoveAll("foo"));
        }
    }
}