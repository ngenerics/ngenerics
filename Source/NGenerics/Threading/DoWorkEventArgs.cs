/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html. 
*/

using System.ComponentModel;
#if (!SILVERLIGHT)
using System.Security.Permissions;
#endif

namespace NGenerics.Threading
{

#if (!SILVERLIGHT && !WINDOWSPHONE)
    /// <summary>
    /// The information for an event when work begins.
    /// </summary>
    /// <typeparam name="TArgument">The type of the argument.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    [HostProtection(SecurityAction.LinkDemand, SharedState = true)]
#endif
    public class DoWorkEventArgs<TArgument, TResult> : CancelEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DoWorkEventArgs&lt;TArgument, TResult&gt;"/> class.
        /// </summary>
        /// <param name="argument">The argument.</param>
        public DoWorkEventArgs(TArgument argument)
        {
            Argument = argument;
        }

        /// <summary>
        /// Gets or sets the argument.
        /// </summary>
        /// <value>The argument.</value>
        [Description("BackgroundWorker_DoWorkEventArgs_Argument")]
        public TArgument Argument { get; private set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>The result.</value>
        [Description("BackgroundWorker_DoWorkEventArgs_Result")]
        public TResult Result { get; set; }
    }
}