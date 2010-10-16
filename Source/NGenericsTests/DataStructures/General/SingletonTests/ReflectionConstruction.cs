using System.Reflection;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SingletonTests
{
    [TestFixture]
    public class ReflectionConstruction : SingletonTest
    {

        private class InstanceWithReflectionConstructor
        {
            public int val;

            public InstanceWithReflectionConstructor(int value, int increment)
            {
                val = value + increment;
            }
        }


        private static T Construct<T>(int value, int increment)
        {
            return (T)typeof(T).InvokeMember(typeof(T).Name,
                                             BindingFlags.CreateInstance |
                                             BindingFlags.Instance |
                                             BindingFlags.Public,
                                             null, null, new object[] { value, increment });
        }


        [TestFixtureSetUp]
        public void SetupSingleton()
        {
            Singleton<InstanceWithReflectionConstructor>.ConstructWith =
                () => Construct<InstanceWithReflectionConstructor>(7, 13);
        }

        [Test]
        public void Call_Reflection_Constructor_With_Parameters()
        {
            Assert.AreEqual(Singleton<InstanceWithReflectionConstructor>.Instance.val, 20);
        }
    }
}