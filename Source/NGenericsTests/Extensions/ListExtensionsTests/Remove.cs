/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Collections.Generic;
using NGenerics.Extensions;
using NUnit.Framework;

namespace NGenerics.Tests.Extensions.ListExtensionsTests
{
    [TestFixture]
    public class Remove
    {
        [Test]
        public void RemoveSingular()
        {
            IList<int> iList = new List<int> { 1, 2, 3, 4 };

            var iListRemovedCount = iList.RemoveAll(Match3);

            Assert.AreEqual(1, iListRemovedCount);
            EnsureListsAreTheSame(new List<int> { 1, 2, 4 }, iList);
        }

        [Test]
        public void RemoveMultiple()
        {
            IList<int> iList = new List<int> { 1, 2, 3, 4, 3 };

            var iListRemovedCount = iList.RemoveAll(Match3);

            Assert.AreEqual(2, iListRemovedCount);
            EnsureListsAreTheSame(new List<int> { 1, 2, 4 }, iList);
        }
        [Test]
        public void RemoveFirst()
        {
            IList<int> iList = new List<int> { 3, 2, 4, 2 };

            var iListRemovedCount = iList.RemoveAll(Match3);

            Assert.AreEqual(1, iListRemovedCount);
            EnsureListsAreTheSame(new List<int> { 2, 4, 2 }, iList);
        }
        [Test]
        public void RemoveLast()
        {
            IList<int> iList = new List<int> { 1, 2, 4, 3 };

            var iListRemovedCount = iList.RemoveAll(Match3);

            Assert.AreEqual(1, iListRemovedCount);
            EnsureListsAreTheSame(new List<int> { 1, 2, 4 }, iList);
        }
        [Test]
        public void RemoveAll()
        {
            IList<int> iList = new List<int> { 3, 3, 3, 3 };

            var iListRemovedCount = iList.RemoveAll(Match3);

            Assert.AreEqual(4, iListRemovedCount);
            Assert.AreEqual(0, iList.Count);

        }
        [Test]
        public void RemoveNone()
        {
            IList<int> iList = new List<int> { 1, 1, 1, 1 };

            var iListRemovedCount = iList.RemoveAll(Match3);

            Assert.AreEqual(0, iListRemovedCount);
            EnsureListsAreTheSame(new List<int> { 1, 1, 1, 1 }, iList);
        }

        private static void EnsureListsAreTheSame(IList<int> list1, IList<int> list2)
        {
            Assert.AreEqual(list1.Count, list2.Count);
            for (var index = 0; index < list2.Count; index++)
            {
                var iListItem = list2[index];
                var listItem = list1[index];
                Assert.AreEqual(iListItem, listItem);
            }
        }

        private static bool Match3(int obj)
        {
            return obj == 3;
        }
    }

}
