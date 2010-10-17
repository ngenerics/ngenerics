using NGenerics.DataStructures.General.Observable;
using NGenerics.Tests.TestObjects;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.Observable.ObservablePascalSetTests
{
    [TestFixture]
    public class Contruction
    {

        [Test]
        public void Serialization()
        {
            var deserialize = SerializeUtil.BinarySerializeDeserialize(new ObservablePascalSet(0, 10));
            ObservableCollectionTester.CheckMonitor(deserialize);
        }
        [Test]
        public void Monitor1()
        {
            ObservableCollectionTester.CheckMonitor(new ObservablePascalSet(0,10));
        }
        [Test]
        public void Monitor2()
        {
            ObservableCollectionTester.CheckMonitor(new ObservablePascalSet(0,10,new []{1}));
        }
        [Test]
        public void Monitor3()
        {
            ObservableCollectionTester.CheckMonitor(new ObservablePascalSet(10));
        }
        [Test]
        public void Monitor4()
        {
            ObservableCollectionTester.CheckMonitor(new ObservablePascalSet(10, new[] { 1 }));
        }
    }
}