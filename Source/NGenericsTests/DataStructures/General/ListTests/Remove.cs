/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System.Collections;
using NGenerics.DataStructures.General;
using NUnit.Framework;
using Rhino.Mocks;

namespace NGenerics.Tests.DataStructures.General.ListTests
{
    [TestFixture]
    public class Remove : ListBase<int>
    {
        [Test]
        public void Simple()
        {
            var listBase = new ListBase<int> { 4, 7, 9 };
            Assert.IsTrue(listBase.Remove(7));
            Assert.AreEqual(4, listBase[0]);
            Assert.AreEqual(9, listBase[1]);
            Assert.AreEqual(2, listBase.Count);
        }
        [Test]
        public void Interface()
        {
            var listBase = (IList)new ListBase<int> { 4, 7, 9 };
            listBase.Remove(7);
            Assert.AreEqual(4, listBase[0]);
            Assert.AreEqual(9, listBase[1]);
            Assert.AreEqual(2, listBase.Count);
        }
        [Test]
        public void InvalidType()
        {
            var listBase = (IList)new ListBase<int> ();
            listBase.Remove("d");
        }


        [Test]
        public void EnsureRemoveItem()
        {
            var mockRepository = new MockRepository();
            var listBase = mockRepository.PartialMock<Remove>();
            listBase.RemoveItem(1, 7);
            mockRepository.ReplayAll();
            listBase.Add(4);
            listBase.Add(7);
            listBase.Add(8);
            listBase.Remove(7);
            mockRepository.VerifyAll();
        }
        [Test]
        public void InterfaceEnsureRemoveItem()
        {
            var mockRepository = new MockRepository();
            var listBase = mockRepository.PartialMock<Remove>();
            listBase.RemoveItem(1, 7);
            mockRepository.ReplayAll();
            listBase.Add(4);
            listBase.Add(7);
            listBase.Add(8);
            ((IList) listBase).Remove(7);
            mockRepository.VerifyAll();
        }


    }
}