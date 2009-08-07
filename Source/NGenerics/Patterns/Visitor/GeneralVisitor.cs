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