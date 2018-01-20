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
    public class IndexOf
    {

        [Test]
        public void Simple()
        {
            var sortedList = new SortedList<int>();
            Assert.Less(sortedList.IndexOf(2), 0);

            sortedList.Add(5);
            Assert.AreEqual(sortedList.IndexOf(5), 0);

            sortedList.Add(2);
            Assert.AreEqual(sortedList.IndexOf(5), 1);
            Assert.AreEqual(sortedList.IndexOf(2), 0);

            Assert.Less(sortedList.IndexOf(10), 0);
        }

    }
}