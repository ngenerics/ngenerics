/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System.Collections.Generic;
using NGenerics.Comparers;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SortedListTests
{
    [TestFixture]
    public class Construction
    {

        [Test]
        public void Simple()
        {
            var list = new List<int>();

            for (var i = 0; i < 200; i++)
            {
                list.Add(i);
            }

            var sortedList = new SortedList<int>(list);

            for (var i = 0; i < 200; i++)
            {
                Assert.AreEqual(sortedList[i], i);
            }

            sortedList = new SortedList<int>(50);

            for (var i = 0; i < 200; i++)
            {
                sortedList.Add(i * 2);
            }

            for (var i = 0; i < 200; i++)
            {
                Assert.AreEqual(sortedList[i], i * 2);
            }

            sortedList = new SortedList<int>(50, Comparer<int>.Default);
            Assert.AreEqual(sortedList.Comparer, Comparer<int>.Default);
        }

        [Test]
        public void Comparer()
        {
            var comparer = new ReverseComparer<int>();
            var sortedList = new SortedList<int>(comparer);
            Assert.AreEqual(comparer, sortedList.Comparer);
        }

    }
}