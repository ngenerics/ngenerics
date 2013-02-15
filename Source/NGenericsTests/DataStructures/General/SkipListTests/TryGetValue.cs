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
    public class TryGetValue
    {

        [Test]
        public void Simple()
        {
            var skipList = new SkipList<int, string>();
            string val;
            Assert.IsFalse(skipList.TryGetValue(5, out val));

            skipList.Add(3, "4");
            Assert.IsFalse(skipList.TryGetValue(5, out val));
            Assert.IsTrue(skipList.TryGetValue(3, out val));
            Assert.AreEqual(val, "4");
        }

    }
}