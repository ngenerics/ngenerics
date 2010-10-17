using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NGenerics.DataStructures.General.Observable;
using NGenerics.Tests.TestObjects;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.Observable.ObservableHeapTests
{
    [TestFixture]
    public class Contruction
    {

        [Test]
        public void Serialization()
        {
            var deserialize = SerializeUtil.BinarySerializeDeserialize(new ObservableHeap<int>(HeapType.Minimum));
            ObservableCollectionTester.CheckMonitor(deserialize);
        }
        [Test]
        public void Monitor1()
        {
            ObservableCollectionTester.CheckMonitor(new ObservableHeap<int>(HeapType.Minimum));
        }
        [Test]
        public void Monitor2()
        {
            ObservableCollectionTester.CheckMonitor(new ObservableHeap<int>(HeapType.Minimum, Comparer<int>.Default));
        }
        [Test]
        public void Monitor3()
        {
            ObservableCollectionTester.CheckMonitor(new ObservableHeap<int>(HeapType.Minimum, 2));
        }
        [Test]
        public void Monitor4()
        {
            ObservableCollectionTester.CheckMonitor(new ObservableHeap<int>(HeapType.Minimum, 2, Comparer<int>.Default));
        }
    }
}