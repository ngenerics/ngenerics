/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System.Collections;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.DequeTests
{
    [TestFixture]
    public class GetEnumerator : DequeTest
    {

        [Test]
        public void Simple()
        {
            var deque = GetTestDeque();
            var enumerator = deque.GetEnumerator();

            var count = 5;

            while (enumerator.MoveNext())
            {
                count--;
                Assert.AreEqual(enumerator.Current, count * 3);
            }

            enumerator.Dispose();
        }

        [Test]
        public void Interface()
        {
            var deque = GetTestDeque();
            var enumerator = ((IEnumerable)deque).GetEnumerator();

            var count = 5;

            while (enumerator.MoveNext())
            {
                count--;
                Assert.AreEqual(enumerator.Current, count * 3);
            }
        }

    }
}