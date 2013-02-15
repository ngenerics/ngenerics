/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.Comparers.ComparisonComparerTests
{
    [TestFixture]
    public class Compare : ComparisonComparerTest
    {
        [Test]
        public void Simple()
        {
            var s1 = new SimpleClass("a");
            var s2 = new SimpleClass("b");
            var s3 = new SimpleClass("c");
            var s4 = new SimpleClass("a");

            var comparer = GetTestComparer();

            Assert.AreEqual(comparer.Compare(s1, s2), -1);
            Assert.AreEqual(comparer.Compare(s1, s3), -1);
            Assert.AreEqual(comparer.Compare(s1, s4), 0);

            Assert.AreEqual(comparer.Compare(s2, s1), 1);
            Assert.AreEqual(comparer.Compare(s3, s1), 1);
            Assert.AreEqual(comparer.Compare(s4, s1), 0);
        }
    }
}