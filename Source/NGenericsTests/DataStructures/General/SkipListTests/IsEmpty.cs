/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SkipListTests
{
    [TestFixture]
    public class IsEmpty
    {

        [Test]
        public void Simple()
        {
            var skipList = new SkipList<int, string>();
            Assert.IsTrue(skipList.IsEmpty);

            skipList.Add(4, "a");
            Assert.IsFalse(skipList.IsEmpty);

            skipList.Clear();
            Assert.IsTrue(skipList.IsEmpty);
        }

    }
}