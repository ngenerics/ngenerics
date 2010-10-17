/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System.Collections;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ListTests
{
    [TestFixture]
    public class Contains
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
            var listBase = new ListBase<int> {3};
            Assert.IsTrue(((IList)listBase).Contains(3));
        }
    }
}