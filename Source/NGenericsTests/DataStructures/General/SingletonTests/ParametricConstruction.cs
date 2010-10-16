using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SingletonTests
{
    [TestFixture]
    public class ParametricConstruction : SingletonTest
    {

        private class InstanceWithParametricConstructor
        {
            public int val;

            private InstanceWithParametricConstructor(int value)
            {
                val = value;
            }
        }

        [TestFixtureSetUp]
        public void SetupSingleton()
        {
            var type = typeof(InstanceWithParametricConstructor);
            var ctor = TypeExtensions.New<int, InstanceWithParametricConstructor>(type);
            Singleton<InstanceWithParametricConstructor>.ConstructWith = () => ctor(7);
        }

        [Test]
        public void Call_Generic_Parametric_New_Constructor()
        {
            Assert.AreEqual(Singleton<InstanceWithParametricConstructor>.Instance.val, 7);
        }
    }
}