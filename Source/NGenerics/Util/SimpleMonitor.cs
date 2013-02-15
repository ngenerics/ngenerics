/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html. 
*/

using System;

namespace NGenerics.Util {
#if (!SILVERLIGHT && ! WINDOWSPHONE)
    [Serializable]
#endif
    internal class SimpleMonitor : IDisposable
    {
        // Fields
        private int busyCount;

        // Methods
        public void Dispose()
        {
            busyCount--;
            GC.SuppressFinalize(this);
        }

        public void Enter()
        {
            busyCount++;
        }

        // Properties
        public bool Busy
        {
            get
            {
                return (busyCount > 0);
            }
        }
    }
}