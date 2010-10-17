using NGenerics.DataStructures.Queues.Observable;
using NGenerics.Tests.TestObjects;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.ObservableCircularQueueTests
{
    [TestFixture]
    public class Contruction
    {
        [Test]
        public void Serialization()
        {
            var deserialize = SerializeUtil.BinarySerializeDeserialize(new ObservableCircularQueue<int>(2));
            ObservableCollectionTester.CheckMonitor(deserialize);
        }

        [Test]
        public void Monitor1()
        {
            ObservableCollectionTester.CheckMonitor(new ObservableCircularQueue<int>(2));
        }
    }
}