using System.Collections;
using NGenerics.DataStructures.General;
using NUnit.Framework;
using Rhino.Mocks;

namespace NGenerics.Tests.DataStructures.General.ListTests
{
    [TestFixture]
    public class Add : ListBase<int>
    {
        [Test]
        public void Simple()
        {

            var listBase = new ListBase<int> {3};
            Assert.IsTrue(listBase.Contains(3));
        }
        [Test]
        public void Interface()
        {
            var listBase = (IList)new ListBase<int>(); 
            listBase.Add(3);
            Assert.IsTrue(listBase.Contains(3));
        }
        [Test]
        public void SimpleEnsureInsertItemCall()
        {
            var mockRepository = new MockRepository();
            var listBase = mockRepository.StrictMock<Add>();
            listBase.InsertItem(0, 5);
            mockRepository.ReplayAll();
            listBase.Add(5);
            mockRepository.VerifyAll();
        }

        [Test]
        public void InterfaceEnsureInsertItemCall()
        {
            var mockRepository = new MockRepository();
            var listBase = mockRepository.StrictMock<Add>();
            listBase.InsertItem(0, 5);
            mockRepository.ReplayAll();
            ((IList)listBase).Add(5);
            mockRepository.VerifyAll();
        }
    }
}