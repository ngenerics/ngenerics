/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SkipListTests
{
    [TestFixture]
    public class Remove
    {

        [Test]
        public void Simple()
        {
            var skipList = new SkipList<int, string>();

            for (var i = 0; i < 100; i++)
            {
                skipList.Add(i, i.ToString());
            }

            for (var i = 0; i < 100; i++)
            {
                if ((i % 2) == 0)
                {
                    Assert.IsTrue(skipList.Remove(i));
                }
                else
                {
                    Assert.IsTrue(skipList.Remove(new KeyValuePair<int, string>(i, "a")));
                }

                Assert.AreEqual(skipList.Count, 99 - i);
                Assert.IsFalse(skipList.ContainsKey(i));
            }
        }
        [Test]
        public void ItemNotInList1()
        {
            var skipList = new SkipList<int, string>();
            Assert.IsFalse(skipList.Remove(4));
        }

        [Test]
        public void ItemNotInList2()
        {
            var skipList = new SkipList<int, string>();
            Assert.IsFalse(skipList.Remove(new KeyValuePair<int, string>(3, "3")));
        }

    }
}