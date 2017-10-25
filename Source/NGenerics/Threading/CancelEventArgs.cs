/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

#if (SILVERLIGHT)

using System;

namespace NGenerics.Threading
{
    /// <summary>
    /// Event arguments for a cancel event.
    /// </summary>
    public class CancelEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CancelEventArgs"/> class.
        /// </summary>
        public CancelEventArgs(): this(false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CancelEventArgs"/> class.
        /// </summary>
        /// <param name="cancel">if set to <c>true</c> [cancel].</param>
        public CancelEventArgs(bool cancel)
        {
            Cancel = cancel;
        }


        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CancelEventArgs"/> is cancelelled.
        /// </summary>
        /// <value><c>true</c> if cancel; otherwise, <c>false</c>.</value>
        public bool Cancel { get; set; }
    }
}

#endif