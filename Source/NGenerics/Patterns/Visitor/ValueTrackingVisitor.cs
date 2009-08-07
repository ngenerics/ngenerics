/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/


using System.Collections.Generic;

namespace NGenerics.Patterns.Visitor
{
    /// <summary>
    /// A visitor that tracks (stores) keys from KeyValuePairs in the order they were visited.
    /// </summary>
    /// <typeparam name="TKey">The type of key of the KeyValuePair.</typeparam>
    /// <typeparam name="TValue">The type of value of the KeyValuePair.</typeparam>
    public sealed class ValueTrackingVisitor<TKey, TValue> : IVisitor<KeyValuePair<TKey, TValue>>
    {
        #region Globals

        private readonly List<TValue> tracks;

        #endregion

        #region Construction


        /// <inheritdoc/>
        public ValueTrackingVisitor()
        {
            tracks = new List<TValue>();
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gets the tracking list.
        /// </summary>
        /// <value>The tracking list.</value>
        public IList<TValue> TrackingList
        {
            get
            {
                return tracks;
            }
        }

        #endregion

        #region IVisitor<KeyValuePair<TKey,TValue>> Members


        /// <inheritdoc />
        public void Visit(KeyValuePair<TKey, TValue> obj)
        {
            tracks.Add(obj.Value);
        }

        /// <inheritdoc />
        public bool HasCompleted
        {
            get
            {
                return false;
            }
        }

        #endregion
    }
}