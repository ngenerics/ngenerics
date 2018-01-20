/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/



using System.Collections.Generic;

namespace NGenerics.Tests.Util
{
    public class IntComparer : IComparer<int>
    {
        #region IComparer<int> Members

        public int Compare(int x, int y)
        {
            return x.CompareTo(y);
        }

        #endregion
    }
}
