using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SingletonTests
{
    [TestFixture]
    public class DefaultConstruction : SingletonTest
    {
        [TestFixtureSetUp]
        public void SetupSingleton()
        {
            var temp = Singleton<int>.Instance;
            Singleton<int>.ConstructWith = () => temp + 88;
        }

        [Test]
        public void ConstructWith_Should_Be_Called_Before_Instance_Get()
        {
            Assert.AreEqual(Singleton<long>.Instance, 0);
        }
    }
}