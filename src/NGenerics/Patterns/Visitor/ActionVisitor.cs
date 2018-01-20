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
    /// A general visitor that executes the specified <see cref="Action{T}"/> delegate.
    /// </summary>
    /// <typeparam name="T">The type of item to visit.</typeparam>
    public class ActionVisitor<T> : IVisitor<T>
    {
        #region Globals

        private readonly Action<T> action;

        #endregion

        #region Construction

        /// <param name="action">The <see cref="Action{T}"/> delegate.  The return value is used to indicate whether the visitor has completed.</param>
        public ActionVisitor(Action<T> action)
        {
            #region Validation

            Guard.ArgumentNotNull(action, "action");

            #endregion

            this.action = action;
        }

        #endregion

        #region IVisitor<T> Members

        /// <inheritdoc />
        public bool HasCompleted
        {
            get
            {
                return false;
            }
        }

        /// <inheritdoc />
        public void Visit(T obj)
        {
            action(obj);
        }

        #endregion
    }
}