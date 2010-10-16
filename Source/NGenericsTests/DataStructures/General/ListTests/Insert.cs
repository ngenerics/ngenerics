using System;
using System.Collections;
using NGenerics.DataStructures.General;
using NUnit.Framework;
using Rhino.Mocks;

namespace NGenerics.Tests.DataStructures.General.ListTests
{
    [TestFixture]
    public class Insert : ListBase<int>
    {
        [Test]
        public void Simple()
        {

            var listBase = new ListBase<int>(); 
            listBase.Insert(0,3);
            Assert.IsTrue(listBase.Contains(3));
        }
        [Test]
        public void Interface()
        {
            var listBase = (IList)new ListBase<int>(); 
            listBase.Insert(0,3);
            Assert.IsTrue(listBase.Contains(3));
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionInvalidType()
        {
            var listBase = (IList)new ListBase<int>(); 
            listBase.Insert(0,"d");
        }
        [Test]
        public void EnsureInsertItemCall()
        {
            var mockRepository = new MockRepository();
            var listBase = mockRepository.StrictMock<Insert>();
            listBase.InsertItem(0, 5);
            mockRepository.ReplayAll();
            listBase.Insert(0, 5);
            mockRepository.VerifyAll();
        }

        [Test]
        public void InterfaceEnsureInsertItemCall()
        {
            var mockRepository = new MockRepository();
            var listBase = mockRepository.StrictMock<Insert>();
            listBase.InsertItem(0, 5);
            mockRepository.ReplayAll();
            ((IList)listBase).Insert(0,5);
            mockRepository.VerifyAll();
        }
    }
}