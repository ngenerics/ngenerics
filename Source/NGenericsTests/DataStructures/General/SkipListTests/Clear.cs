/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SkipListTests
{
    [TestFixture]
    public class Clear
    {

        [Test]
        public void Simple()
        {
            var skipList = new SkipList<int, string>();
            Assert.AreEqual(skipList.Count, 0);

            skipList.Add(4, "a");
            Assert.AreEqual(skipList.Count, 1);

            skipList.Clear();
            Assert.AreEqual(skipList.Count, 0);

            skipList.Add(5, "a");
            skipList.Add(6, "a");
            Assert.AreEqual(skipList.Count, 2);

            skipList.Clear();
            Assert.AreEqual(skipList.Count, 0);
        }

    }
}