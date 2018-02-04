/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/



using System;
using System.Collections.Generic;
using System.Reflection;
using NGenerics.Sorting;
using NUnit.Framework;

namespace NGenerics.Tests.Sorting
{
    [TestFixture]
    public partial class TestSort
    {

        [Test]
        public void TestSortInvalidSortOrder()
        {
            Exception argException = null;
            try
            {
                var sorterImplementation = new SorterImplementation();
                var method =
                    typeof(SorterImplementation).GetMethod("Sort", new[] {typeof(IList<int>), typeof(SortOrder)});
                method.Invoke(sorterImplementation, new object[] {new List<int>(), -1});
            }
            catch (TargetInvocationException e)
            {
                argException = e.InnerException;
            }

            Assert.IsNotNull(argException);
        }

        private class SorterImplementation : ComparisonSorter<int>
        {
            protected override void SortItems(IList<int> list, IComparer<int> comparer)
            {
                throw new NotImplementedException();
            }
        }
    }
}