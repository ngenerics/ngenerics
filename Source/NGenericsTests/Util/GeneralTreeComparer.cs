/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using System.Collections.Generic;
using NGenerics.DataStructures.Trees;

namespace NGenerics.Tests.Util
{
    internal class GeneralTreeComparer<T> : IComparer<GeneralTree<T>> where T : IComparable
    {
        #region IComparer<GeneralTree<T>> Members

        public int Compare(GeneralTree<T> x, GeneralTree<T> y)
        {
            return x.Data.CompareTo(y.Data);
        }

        #endregion
    }
}
