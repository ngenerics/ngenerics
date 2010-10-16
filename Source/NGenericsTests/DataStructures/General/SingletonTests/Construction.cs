using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SingletonTests
{
    [TestFixture]
    public class Construction : SingletonTest
    {
        [TestFixtureSetUp]
        public void SetupSingleton()
        {
            Singleton<TestInstance>.Instance.val = 5;
        }

        [Test]
        public void Simple()
        {
            Assert.AreEqual(Singleton<TestInstance>.Instance.val, 5);
        }
    }
}