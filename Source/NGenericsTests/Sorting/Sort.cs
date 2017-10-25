/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System.Collections.Generic;
using NUnit.Framework;
using NGenerics.Sorting;
using Rhino.Mocks;

namespace NGenerics.Tests.Sorting
{

    [TestFixture]
    public class Sort
    {
        [Test]
        public void Simple_Sort()
        {
            var mocks = new MockRepository();
            var sorter = mocks.StrictMock<ISorter<int>>();

            var list = GetTestList();
            sorter.Sort(list);

            mocks.ReplayAll();

            list.Sort(sorter);

            mocks.VerifyAll();
        }

        [Test]
        public void Sort_With_Order()
        {
            var mocks = new MockRepository();
            var sorter = mocks.StrictMock<ISorter<int>>();

            var list = GetTestList();
            sorter.Sort(list, SortOrder.Ascending);
            sorter.Sort(list, SortOrder.Descending);

            mocks.ReplayAll();

            list.Sort(sorter, SortOrder.Ascending);
            list.Sort(sorter, SortOrder.Descending);

            mocks.VerifyAll();
        }

        #region Private Members

        //private static void AssertSorted(IList<int> list, SortOrder sortOrder)
        //{
        //    if (sortOrder == SortOrder.Ascending)
        //    {
        //        for (var i = 0; i< 10; i++)
        //        {
        //            Assert.AreEqual(list[i], i);
        //        }
        //    }
        //    else
        //    {
        //        for (var i = 9; i >= 0; i--)
        //        {
        //            Assert.AreEqual(list[9-i], i);
        //        }

        //    }
        //}

        private static IList<int> GetTestList()
        {
            return new List<int>
                       {
                           3,
                           2,
                           4,
                           1,
                           8,
                           9,
                           0,
                           5,
                           6,
                           7
                       };
        }

        #endregion
    }





}