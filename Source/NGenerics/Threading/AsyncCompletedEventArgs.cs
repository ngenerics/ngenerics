/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html. 
*/

using System;
using System.ComponentModel;
using System.Reflection;
#if (!SILVERLIGHT)
using System.Security.Permissions;
#endif

namespace NGenerics.Threading
{
    /// <summary>
    /// Event for when async operations complete.
    /// </summary>
	/// <typeparam name="TState">The type of the state.</typeparam>
#if (!SILVERLIGHT && !WINDOWSPHONE)
    [HostProtection(SecurityAction.LinkDemand, SharedState = true)]
#endif
    public class AsyncCompletedEventArgs<TState> : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncCompletedEventArgs&lt;TState&gt;"/> class.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <param name="cancelled">if set to <c>true</c> [cancelled].</param>
        /// <param name="userState">State of the user.</param>
        public AsyncCompletedEventArgs(Exception error, bool cancelled, TState userState)
        {
            Error = error;
            Cancelled = cancelled;
            UserState = userState;
        }

        /// <summary>
        /// Raises the exception if necessary.
        /// </summary>
        protected void RaiseExceptionIfNecessary()
        {
            if (Error != null)
            {
                throw new TargetInvocationException("Async_ExceptionOccurred", Error);
            }
            if (Cancelled)
            {
                throw new InvalidOperationException("Async_OperationCancelled");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="AsyncCompletedEventArgs&lt;TState&gt;"/> is cancelled.
        /// </summary>
        /// <value><c>true</c> if cancelled; otherwise, <c>false</c>.</value>
        [Description("Async_AsyncEventArgs_Cancelled")]
        public bool Cancelled { get; private set; }

        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        /// <value>The error.</value>
        [Description("Async_AsyncEventArgs_Error")]
        public Exception Error { get; private set; }

        /// <summary>
        /// Gets or sets the state of the user.
        /// </summary>
        /// <value>The state of the user.</value>
        [Description("Async_AsyncEventArgs_UserState")]
        public virtual TState UserState { get; private set; }
    }
}