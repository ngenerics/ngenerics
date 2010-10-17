using System;
using NGenerics.DataStructures.General;
using NGenerics.DataStructures.General.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.Observable.ObservableHeapTests
{
    [TestFixture]
    public class Clear
    {
        [Test]
        public void Simple()
        {
            var heap = new ObservableHeap<string>(HeapType.Minimum)
                           {
                               "foo"
                           };

            ObservableCollectionTester.ExpectEvents(heap, obj => obj.Clear(), "Count", "Root", "IsEmpty");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionReentrancy()
        {
            var heap = new ObservableHeap<string>(HeapType.Minimum)
                           {
                               "foo"
                           };
            new ReentracyTester<ObservableHeap<string>>(heap, obj => obj.Clear());
        }
    }
}