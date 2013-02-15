/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html. 
*/

using System;
#if (!SILVERLIGHT)
using System.ComponentModel;
using System.Security.Permissions;
#endif

namespace NGenerics.Threading
{
    /// <summary>
    /// An event argument fo when the worker has completed running.
    /// </summary>
	/// <typeparam name="TState">The type of the state.</typeparam>
#if (!SILVERLIGHT && !WINDOWSPHONE)
    [HostProtection(SecurityAction.LinkDemand, SharedState = true)]
#endif
    public class RunWorkerCompletedEventArgs<TState> : AsyncCompletedEventArgs<TState> {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="RunWorkerCompletedEventArgs&lt;TState&gt;"/> class.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="error">The error.</param>
        /// <param name="cancelled">if set to <c>true</c> [cancelled].</param>
        public RunWorkerCompletedEventArgs(TState result, Exception error, bool cancelled)
            : base(error, cancelled, result)
        {
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gets or sets the state of the user.
        /// </summary>
		/// <value>The state of the user.</value>
#if (!SILVERLIGHT && !WINDOWSPHONE)
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
#endif
        public override TState UserState
        {
            get
            {
                RaiseExceptionIfNecessary();
                return base.UserState;
            }
        }

        #endregion
    }
}