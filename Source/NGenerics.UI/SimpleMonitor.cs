/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html. 
*/

using System;

namespace NGenerics.UI
{
#if (!SILVERLIGHT)
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