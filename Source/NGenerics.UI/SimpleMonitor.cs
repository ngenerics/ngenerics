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