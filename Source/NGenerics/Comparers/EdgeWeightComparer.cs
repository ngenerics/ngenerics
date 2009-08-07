/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/

#if (!SILVERLIGHT)
using System;
#endif
using System.Collections.Generic;
using NGenerics.DataStructures.General;

namespace NGenerics.Comparers
{
    /// <summary>
    /// A comparer for comparing weights on graph edges.
	/// </summary>
    /// <typeparam name="T">The type of the objects to compare.</typeparam>
#if (!SILVERLIGHT)
    [Serializable]
#endif
    public sealed class EdgeWeightComparer<T> : IComparer<Edge<T>>
    {

        #region IComparer<Edge<T>> Members

		/// <inheritdoc />
        public int Compare(Edge<T> x, Edge<T> y)
        {
            return x.Weight.CompareTo(y.Weight);
        }

        #endregion
    }
}
