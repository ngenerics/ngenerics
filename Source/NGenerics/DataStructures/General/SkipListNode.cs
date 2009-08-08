/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


#if (!SILVERLIGHT)
using System;
#endif


namespace NGenerics.DataStructures.General
{
#if (!SILVERLIGHT)
    [Serializable]
#endif
	internal sealed class SkipListNode<TKey, TValue>
	{

		#region Construction


		internal SkipListNode()	{}

		/// <param name="key">The key.</param>
		/// <param name="val">The value.</param>
		internal SkipListNode(TKey key, TValue val)
		{
			Key = key;
			Value = val;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the key.
		/// </summary>
		/// <value>The key.</value>
		internal TKey Key
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <value>The value.</value>
		internal TValue Value
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the right node.
		/// </summary>
		/// <value>The right node.</value>
		internal SkipListNode<TKey, TValue> Right
		{
			get;
			set;
		}

		

		/// <summary>
		/// Gets or sets the down node.
		/// </summary>
		/// <value>The down node.</value>
		internal SkipListNode<TKey, TValue> Down
		{
			get;
			set;
		}

		#endregion
	}
}
