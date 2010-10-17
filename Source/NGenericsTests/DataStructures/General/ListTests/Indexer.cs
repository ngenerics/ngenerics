/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using System.Collections;
using NGenerics.DataStructures.General;
using NUnit.Framework;
using Rhino.Mocks;

namespace NGenerics.Tests.DataStructures.General.ListTests
{
    [TestFixture]
    public class Indexer : ListBase<int>
    {
        [Test]
        public void Simple()
        {

            var listBase = new ListBase<int> {3};
            listBase[0] = 4;
            Assert.IsTrue(listBase.Contains(4));
            Assert.IsFalse(listBase.Contains(3));
        }
        [Test]
        public void Interface()
        {
            var listBase = (IList)new ListBase<int>();
            listBase.Add(3);
            listBase[0] = 4;
            Assert.IsTrue(listBase.Contains(4));
            Assert.IsFalse(listBase.Contains(3));
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionInvalidType()
        {
            var listBase = (IList)new ListBase<int>();
            listBase.Add(3);
            listBase[0] = "a";
        }
        [Test]
        public void SimpleEnsureInsertItemCall()
        {
            var mockRepository = new MockRepository();
            var listBase = mockRepository.PartialMock<Indexer>();
            listBase.SetItem(0, 4);
            mockRepository.ReplayAll();
            listBase.Add(3);
            listBase[0] = 4;
            mockRepository.VerifyAll();
        }

        [Test]
        public void InterfaceEnsureInsertItemCall()
        {
            var mockRepository = new MockRepository();
            var listBase = mockRepository.PartialMock<Indexer>();
            listBase.SetItem(0, 4);
            mockRepository.ReplayAll();
            listBase.Add(3);
            ((IList)listBase)[0] = 4;
            mockRepository.VerifyAll();
        }
    }
}