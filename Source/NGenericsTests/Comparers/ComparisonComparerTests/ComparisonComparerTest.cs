/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using NGenerics.Comparers;
using NGenerics.Tests.Util;

namespace NGenerics.Tests.Comparers.ComparisonComparerTests
{

    public class ComparisonComparerTest
    {
        internal static ComparisonComparer<SimpleClass> GetTestComparer()
        {
            return new ComparisonComparer<SimpleClass>((x, y) => x.TestProperty.CompareTo(y.TestProperty));
        }
    }
}
