/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System.Collections.Generic;

namespace NGenerics.Tests.TestObjects
{
    public class DummyComparer : IEqualityComparer<string>
    {
        #region IEqualityComparer<string> Members

        public bool Equals(string x, string y)
        {
            return x == y;
        }

        public int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }

        #endregion
    }
}