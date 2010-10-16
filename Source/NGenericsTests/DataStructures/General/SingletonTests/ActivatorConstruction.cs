using System;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SingletonTests
{
    [TestFixture]
    public class ActivatorConstruction : SingletonTest
    {

        private class InstanceWithActivatorConstructor
        {
            public int val;

            public InstanceWithActivatorConstructor(int value, int increment)
            {
                val = value + increment;
            }
        }


        private static T Construct<T>(int value, int increment)
        {
            return (T)Activator.CreateInstance(typeof(T), new object[] { value, increment });
        }

        [TestFixtureSetUp]
        public void SetupSingleton()
        {
            Singleton<InstanceWithActivatorConstructor>.ConstructWith =
                () => Construct<InstanceWithActivatorConstructor>(57, 13);
        }

        [Test]
        public void Call_Activator_Constructor_With_Parameters()
        {
            Assert.AreEqual(Singleton<InstanceWithActivatorConstructor>.Instance.val, 70);
        }
    }
}