/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace NGenerics.DataStructures.General
{
	/// <summary>
	/// An interface for the Set data structure
	/// </summary>
	public interface ISet
	{
		/// <summary>
		/// Applies the difference operation to two <see cref="ISet"/>.
		/// </summary>
		/// <param name="other">The other <see cref="ISet"/>.</param>
		/// <returns>The result of the difference operation.</returns>
		ISet Subtract(ISet other);

		/// <summary>
		/// Applies the Intersection operation to two <see cref="ISet"/>s.
		/// </summary>
		/// <param name="other">The other <see cref="ISet"/>.</param>
		/// <returns>The result of the intersection operation.</returns>
		ISet Intersection(ISet other);

		/// <summary>
		/// Inverses this instance.
		/// </summary>
		/// <returns>The Inverse representation of the current <see cref="ISet"/>.</returns>
		ISet Inverse();
				
		/// <summary>
		/// Determines whether the current instance is a proper subset specified <see cref="ISet"/>.
		/// </summary>
		/// <param name="other">The <see cref="ISet"/>.</param>
		/// <returns>
		/// 	<c>true</c> if [is proper subset of] [the specified set]; otherwise, <c>false</c>.
		/// </returns>
		bool IsProperSubsetOf(ISet other);

		/// <summary>
		/// Determines whether the current instance is a proper superset of specified <see cref="ISet"/>.
		/// </summary>
		/// <param name="other">The set.</param>
		/// <returns>
		/// 	<c>true</c> if [is proper superset of] [the specified set]; otherwise, <c>false</c>.
		/// </returns>
		bool IsProperSupersetOf(ISet other);

		/// <summary>
		/// Determines whether the current instance is a subset of the specified <see cref="ISet"/>.
		/// </summary>
		/// <param name="other">The set.</param>
		/// <returns>
		/// 	<c>true</c> if [is subset of] [the specified set]; otherwise, <c>false</c>.
		/// </returns>
		bool IsSubsetOf(ISet other);

		/// <summary>
		/// Determines whether the current instance is a superset of the specified <see cref="ISet"/>.
		/// </summary>
		/// <param name="other">The set.</param>
		/// <returns>
		/// 	<c>true</c> if [is superset of] [the specified set]; otherwise, <c>false</c>.
		/// </returns>
		bool IsSupersetOf(ISet other);

		/// <summary>
		/// Performs the union operation on two <see cref="ISet"/>s.
		/// </summary>
		/// <param name="other">The set.</param>
		/// <returns>The union of this <see cref="ISet"/> and <paramref name="other"/>.</returns>
		ISet Union(ISet other);
	}
}
