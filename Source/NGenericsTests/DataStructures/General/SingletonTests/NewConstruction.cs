using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SingletonTests
{
    [TestFixture]
    public class NewConstruction : SingletonTest
    {

        private class InstanceWithDefaultConstructor
        {
            public int val;

            public InstanceWithDefaultConstructor()
            {
                val = 15;
            }
        }


        private static T Construct<T>()
            where T : new()
        {
            // new T() is equal to Activator.CreateInstance<T>
            return new T();
        }


        [TestFixtureSetUp]
        public void SetupSingleton()
        {
            Singleton<InstanceWithDefaultConstructor>.ConstructWith =
                () =>
                    {
                        var instance = Construct<InstanceWithDefaultConstructor>();
                        if (instance != null)
                            instance.val = 99;
                        return instance;
                    };
        }

        [Test]
        public void Call_New_Constructor()
        {
            Assert.AreEqual(Singleton<InstanceWithDefaultConstructor>.Instance.val, 99);
        }
    }
}