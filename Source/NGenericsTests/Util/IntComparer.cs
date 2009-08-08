/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
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
