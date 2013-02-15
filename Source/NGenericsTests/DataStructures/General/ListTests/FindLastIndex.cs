/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.General;
using NGenerics.Extensions;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ListTests
{
    [TestFixture]
    public class FindLastIndex
    {
        [Test]
        public void Simple()
        {
            var listBase = new ListBase<string> { "as", "bs", "c" };
            Assert.AreEqual(1, listBase.FindLastIndex(EndsWiths));
        }
        [Test]
        public void Index()
        {
            var listBase = new ListBase<string> { "as", "bs", "c" };
            Assert.AreEqual(1, listBase.FindLastIndex(2, EndsWiths));
        }
        [Test]
        public void IndexCount()
        {
            var listBase = new ListBase<string> { "as", "bs", "c" };
            Assert.AreEqual(1, listBase.FindLastIndex(2,2,EndsWiths));
        }

        private static bool EndsWiths(string s)
        {
            return s.EndsWith("s");
        }

    }
}