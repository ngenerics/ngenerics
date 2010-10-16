using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SingletonTests
{
    [TestFixture]
    public class AssignConstructWith : SingletonTest
    {
        [TestFixtureSetUp]
        public void SetupSingleton()
        {
            Singleton<float>.ConstructWith = () => 7;
            Singleton<float>.ConstructWith = () => 15;
        }

        [Test]
        public void ConstructWith_Assigned_Once()
        {
            Assert.AreEqual(Singleton<float>.Instance, 7);
        }
    }
}