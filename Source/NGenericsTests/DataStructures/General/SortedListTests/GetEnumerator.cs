/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System.Collections;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SortedListTests
{
    [TestFixture]
    public class GetEnumerator
    {

        [Test]
        public void Simple()
        {
            var sortedList = new SortedList<int>();

            for (var i = 0; i < 20; i++)
            {
                sortedList.Add(i);
            }

            var counter = 0;
            var enumerator = sortedList.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Assert.AreEqual(enumerator.Current, counter);
                counter++;
            }

            Assert.AreEqual(counter, 20);
        }

        [Test]
        public void Interface()
        {
            var sortedList = new SortedList<int>();

            for (var i = 0; i < 20; i++)
            {
                sortedList.Add(i);
            }

            var counter = 0;

            var enumerator = ((IEnumerable)sortedList).GetEnumerator();

            while (enumerator.MoveNext())
            {
                Assert.AreEqual((int)enumerator.Current, counter);
                counter++;
            }

            Assert.AreEqual(counter, 20);
        }

    }
}