using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SingletonTests
{
    [TestFixture]
    public class PrivateConstruction : SingletonTest
    {

        private class InstanceWithPrivateConstructor
        {
            public int val;

            private InstanceWithPrivateConstructor()
            {
                val = 15;
            }
        }


        [TestFixtureSetUp]
        public void SetupSingleton()
        {
            var type = typeof(InstanceWithPrivateConstructor);
            var ctor = TypeExtensions.New<InstanceWithPrivateConstructor>(type);
            Singleton<InstanceWithPrivateConstructor>.ConstructWith = () => ctor();
        }

        [Test]
        public void Call_Private_Generic_New_Constructor()
        {
            Assert.AreEqual(Singleton<InstanceWithPrivateConstructor>.Instance.val, 15);
        }
    }
}