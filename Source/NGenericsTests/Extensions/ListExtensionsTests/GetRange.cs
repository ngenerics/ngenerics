/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System.Collections.Generic;
using NGenerics.Extensions;
using NUnit.Framework;

namespace NGenerics.Tests.Extensions.ListExtensionsTests
{
    [TestFixture]
    public class GetRange
    {
        [Test]
        public void Simple1()
        {
            var list = new List<int> { 1, 2, 3, 4, 7, 8 }; ;
            IList<int> iList = list;

            var listRange = list.GetRange(0, 2);
            var iListRange = iList.GetRange(0, 2);
            AssertListsAreTheSame(listRange, iListRange);
        }

        [Test]
        public void Simple2()
        {
            var list = new List<int> { 1, 2, 3, 4, 7, 8 }; ;
            IList<int> iList = list;

            var listRange = list.GetRange(2, 3);
            var iListRange = iList.GetRange(2, 3);
            AssertListsAreTheSame(listRange, iListRange);
        }

        private static void AssertListsAreTheSame(IList<int> list1, IList<int> list2)
        {
            Assert.AreEqual(list1.Count, list2.Count);
            for (var index = 0; index < list1.Count; index++)
            {
                Assert.AreEqual(list1[index], list2[index]);
            }
        }

    }
}