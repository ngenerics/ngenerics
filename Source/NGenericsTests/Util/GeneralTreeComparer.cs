/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
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
