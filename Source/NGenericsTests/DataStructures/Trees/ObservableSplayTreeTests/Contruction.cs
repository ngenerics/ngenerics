using System.Collections.Generic;
using NGenerics.DataStructures.Trees.Observable;
using NGenerics.Tests.TestObjects;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.ObservableSplayTreeTests
{
    [TestFixture]
    public class Contruction
    {
        [Test]
        public void Serialization()
        {
            var deserialize = SerializeUtil.BinarySerializeDeserialize(new ObservableSplayTree<int, int>());
            ObservableCollectionTester.CheckMonitor(deserialize);
        }

        [Test]
        public void Monitor1()
        {
            ObservableCollectionTester.CheckMonitor(new ObservableSplayTree<int, int>());
        }
        [Test]
        public void Monitor2()
        {
            ObservableCollectionTester.CheckMonitor(new ObservableSplayTree<int, int>(Comparer<int>.Default));
        }

    }
}