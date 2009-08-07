/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/


using System;
using System.Collections.Generic;
using NGenerics.DataStructures.General;

namespace NGenerics.Comparers
{
    /// <summary>
    /// A comparer for comparing keys using the Association class.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
#if (!SILVERLIGHT)
    [Serializable]
#endif
    public class AssociationKeyComparer<TKey, TValue> : IAssociationKeyComparer<TKey, TValue> where TKey : IComparable {
        
        #region Globals

        private readonly IComparer<TKey> comparer;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="AssociationKeyComparer&lt;TKey, TValue&gt;"/> class.
        /// </summary>
        public AssociationKeyComparer()
        {
            comparer = Comparer<TKey>.Default;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AssociationKeyComparer&lt;TKey, TValue&gt;"/> class.
        /// </summary>
        /// <param name="comparer">The comparer.</param>
        public AssociationKeyComparer(IComparer<TKey> comparer)
        {
            this.comparer = comparer;
        }

        #endregion

        /// <summary>
        /// Gets the default comparer for the type of association specified.
        /// </summary>
        /// <value>The default comparer.</value>
        public static IAssociationKeyComparer<TKey, TValue> DefaultComparer
        {
            get { return new AssociationKeyComparer<TKey, TValue>(); }
        }

        #region IComparer<Association<TKey,TValue>> Members

        /// <inheritdoc />
        public int Compare(Association<TKey, TValue> x, Association<TKey, TValue> y)
        {
            return comparer.Compare( x.Key,y.Key);
        }

        #endregion

        #region IComparer<TKey> Members

        /// <inheritdoc />
        public int Compare(TKey x, TKey y)
        {
            return comparer.Compare(x,y);
        }

        #endregion
    }

}