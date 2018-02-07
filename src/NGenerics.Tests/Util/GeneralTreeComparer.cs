/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
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
