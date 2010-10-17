using System;
using NGenerics.DataStructures.General;
using NGenerics.DataStructures.General.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.Observable.ObservableHeapTests
{
    [TestFixture]
    public class Add
    {
        [Test]
        public void Simple()
        {
            var heap = new ObservableHeap<string>(HeapType.Minimum);
            ObservableCollectionTester.ExpectEvents(heap, obj => obj.Add("foo"), "Count", "Root", "IsEmpty");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionReentrancy()
        {
            var heap = new ObservableHeap<string>(HeapType.Minimum);
            new ReentracyTester<ObservableHeap<string>>(heap, obj => obj.Add("foo"));
        }
    }
}