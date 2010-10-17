/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.General;
using NUnit.Framework;
using Rhino.Mocks;

namespace NGenerics.Tests.DataStructures.General.ListTests
{
    [TestFixture]
    public class RemoveAll : ListBase<string>
    {
        [Test]
        public void Simple()
        {
            var listBase = new ListBase<string> { "as", "bs", "c" };
            Assert.AreEqual(2, listBase.RemoveAll(EndsWiths));
            Assert.AreEqual("c", listBase[0]);
            Assert.AreEqual(1, listBase.Count);
        }


        [Test]
        public void EnsureRemoveItem()
        {
            var mockRepository = new MockRepository();
            var listBase = mockRepository.PartialMock<RemoveAll>();
            listBase.RemoveItem(0, "as");
            listBase.RemoveItem(0, "bs");
            mockRepository.ReplayAll();
            listBase.Add("as");
            listBase.Add("bs");
            listBase.Add("c");
            listBase.RemoveAll(EndsWiths);
            mockRepository.VerifyAll();
        }

        private static bool EndsWiths(string s)
        {
            return s.EndsWith("s");
        }

    }
}