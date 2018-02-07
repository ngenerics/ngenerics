/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/


using NGenerics.DataStructures.General;

namespace NGenerics.Tests.DataStructures.General.SortedListTests
{

    public class SortedListTest
    {
        public static SortedList<int> GetTestList()
        {
            var sortedList = new SortedList<int>();

            for (var i = 50; i >= 0; i--)
            {
                sortedList.Add(i * 2);
            }

            return sortedList;
        }
    }
}
