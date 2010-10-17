/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SortedListTests
{
    [TestFixture]
    public class Remove
    {

        [Test]
        public void Simple()
        {
            var sortedList = new SortedList<int>();

            for (var i = 50; i >= 0; i--)
            {
                sortedList.Add(i * 2);
            }

            Assert.AreEqual(sortedList.Count, 51);

            Assert.IsTrue(sortedList.Remove(50));
            Assert.AreEqual(sortedList.Count, 50);

            Assert.IsFalse(sortedList.Remove(3));
            Assert.AreEqual(sortedList.Count, 50);
        }

    }
}