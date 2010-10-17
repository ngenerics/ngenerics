/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ListTests
{
    [TestFixture]
    public class Reverse
    {
        [Test]
        public void Simple()
        {
            var listBase = new ListBase<string> { "a", "b" };
            listBase.Reverse();

            Assert.AreEqual("b", listBase[0]);
            Assert.AreEqual("a", listBase[1]);
        }
        [Test]
        public void Complex()
        {
            var listBase = new ListBase<string> { "a", "b" };
            listBase.Reverse(0, 2);

            Assert.AreEqual("b", listBase[0]);
            Assert.AreEqual("a", listBase[1]);
        }
    }
}