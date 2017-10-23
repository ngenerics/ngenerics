/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SortedListTests
{
    [TestFixture]
    public class Add : SortedListTest
    {
        [Test]
        public void Simple()
        {
            var sortedList = new SortedList<int>
                                 {
                                     5
                                 };

            Assert.AreEqual(sortedList.Count, 1);
            Assert.IsFalse(sortedList.IsEmpty);
            Assert.AreEqual(sortedList[0], 5);

            sortedList = GetTestList();
            sortedList.Add(-5);
            Assert.AreEqual(sortedList[0], -5);
        }

        [Test]
        public void Sorting()
        {
            var sortedList = new SortedList<int>();

            for (var i = 200; i >= 0; i--)
            {
                sortedList.Add(i * 2);
            }

            for (var i = 0; i <= 200; i++)
            {
                Assert.AreEqual(sortedList[i], i * 2);
            }
        }

        [Test]
        public void StressTestList()
        {

            var sortedList = new SortedList<int>();

            for (var i = 1000; i > 0; i--)
            {
                sortedList.Add(i);
            }

            for (var i = 1000; i > 0; i--)
            {
                sortedList.Add(i);
            }

            var counter = 0;
            var val = 1;

            while (counter <= 1000)
            {
                Assert.AreEqual(sortedList[counter], val);
                counter++;

                Assert.AreEqual(sortedList[counter], val);
                counter++;
                val++;
            }

        }
    }
}