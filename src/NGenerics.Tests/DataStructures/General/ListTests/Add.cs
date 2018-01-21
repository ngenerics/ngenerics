/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System.Collections;
using Moq;
using NGenerics.DataStructures.General;
using NUnit.Framework;

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
            var listBase = new Mock<Add>();
            listBase.Object.Add(5);
            listBase.Verify(x => x.InsertItem(0, 5));
        }

        [Test]
        public void InterfaceEnsureInsertItemCall()
        {
            var listBase = new Mock<Add>();
            ((IList)listBase.Object).Add(5);
            listBase.Verify(x => x.InsertItem(0, 5));
        }
    }
}