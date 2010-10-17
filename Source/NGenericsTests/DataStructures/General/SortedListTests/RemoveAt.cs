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
    public class RemoveAt
    {

        [Test]
        public void Simple()
        {
            var sortedList = new SortedList<int> { 5 };

            Assert.AreEqual(sortedList.Count, 1);

            sortedList.RemoveAt(0);

            Assert.AreEqual(sortedList.Count, 0);

            sortedList.Add(5);
            sortedList.Add(2);

            Assert.AreEqual(sortedList.Count, 2);
            sortedList.RemoveAt(1);

            Assert.AreEqual(sortedList.Count, 1);

            sortedList.Add(2);

            Assert.AreEqual(sortedList.Count, 2);
            sortedList.RemoveAt(0);

            Assert.AreEqual(sortedList.Count, 1);
        }

    }
}