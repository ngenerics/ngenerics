/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using System.Collections;
using Moq;
using NGenerics.DataStructures.General;
using NUnit.Framework;

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
        public void ExceptionInvalidType()
        {
            var listBase = (IList)new ListBase<int>();
            Assert.Throws<ArgumentException>(() => listBase.Insert(0, "d"));
        }
        [Test]
        public void EnsureInsertItemCall()
        {
            var listBase = new Mock<Insert>();
            listBase.Object.Insert(0, 5);
            listBase.Verify(x => x.InsertItem(0, 5));
        }

        [Test]
        public void InterfaceEnsureInsertItemCall()
        {
            var listBase = new Mock<Insert>();
            ((IList)listBase.Object).Insert(0,5);
            listBase.Verify(x => x.InsertItem(0, 5));
        }
    }
}