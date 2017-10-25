/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NGenerics.Util;

namespace NGenerics.Patterns.Visitor
{
    /// <summary>
    /// A general visitor that executes the specified <see cref="Predicate{T}"/> delegate.
    /// </summary>
    /// <typeparam name="T">The type of item to visit.</typeparam>
    public class GeneralVisitor<T> : IVisitor<T>
    {
        #region Globals

        private bool completed;
        private readonly Predicate<T> predicate;

        #endregion

        #region Construction

        /// <param name="hasCompletedPredicate">The <see cref="Predicate{T}"/> delegate.  The return value is used to indicate whether the visitor has completed.</param>
        public GeneralVisitor(Predicate<T> hasCompletedPredicate)
        {
            #region Validation

            Guard.ArgumentNotNull(hasCompletedPredicate, "hasCompletedPredicate");

            #endregion

            predicate = hasCompletedPredicate;
        }

        #endregion

        #region IVisitor<T> Members

        /// <inheritdoc />
        public bool HasCompleted
        {
            get { return completed; }
            set { completed = value; }
        }

        /// <inheritdoc />
        public void Visit(T obj)
        {
            completed = predicate(obj);
        }

        #endregion
    }
}