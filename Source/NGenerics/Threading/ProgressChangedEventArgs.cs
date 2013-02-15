/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html. 
*/

using System;
using System.ComponentModel;
#if (!SILVERLIGHT)
using System.Security.Permissions;
#endif

namespace NGenerics.Threading
{
    /// <summary>
    /// An event argument for when the progress of the task changed.
    /// </summary>
	/// <typeparam name="TState">The type of the state.</typeparam>
#if (!SILVERLIGHT && !WINDOWSPHONE)
    [HostProtection(SecurityAction.LinkDemand, SharedState = true)]
#endif
    public class ProgressChangedEventArgs<TState> : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressChangedEventArgs&lt;TState&gt;"/> class.
        /// </summary>
        /// <param name="progressPercentage">The progress percentage.</param>
        /// <param name="userState">State of the user.</param>
        public ProgressChangedEventArgs(int progressPercentage, TState userState)
        {
            ProgressPercentage = progressPercentage;
            UserState = userState;
        }

        // Properties
        /// <summary>
        /// Gets or sets the progress percentage.
        /// </summary>
        /// <value>The progress percentage.</value>
        [Description("Async_ProgressChangedEventArgs_ProgressPercentage")]
        public int ProgressPercentage { get; private set; }

        /// <summary>
        /// Gets or sets the state of the user.
        /// </summary>
        /// <value>The state of the user.</value>
        [Description("Async_ProgressChangedEventArgs_UserState")]
        public TState UserState { get; private set; }
    }
}