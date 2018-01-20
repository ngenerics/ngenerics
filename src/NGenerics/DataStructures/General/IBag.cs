/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/




using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace NGenerics.DataStructures.General
{
	/// <summary>
	///  An interface for a <see cref="Bag{T}"/> data structure.
    /// </summary>
    /// <remarks>
    /// A Bag (sometimes also called a multiset) is a group of object in which each 
    /// each member has a multiplicity, which is a natural number indicating (loosely speaking)
    /// how many times it is a member. For example, in the bag { a, a, b, b, b, c }, the 
    /// multiplicities of the members a, b, and c are respectively 2, 3, and 1.
    /// </remarks>
	/// <typeparam name="T">The type of elements in the bag.</typeparam>
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    public interface IBag<T> : ICollection<T>, IEnumerable<KeyValuePair<T, int>>
	{

		/// <summary>
        /// Adds n * the specified item to the <see cref="Bag{T}"/>.
		/// </summary>
		/// <param name="item">The item.</param>
		/// <param name="amount">The amount.</param>
		void Add(T item, int amount);

		/// <summary>
        /// Applies the Difference operation on two <see cref="Bag{T}"/>s.
		/// </summary>
        /// <param name="bag">The other <see cref="Bag{T}"/>.</param>
        /// <returns>The difference between the current <see cref="Bag{T}"/> and the specified <see cref="Bag{T}"/>.</returns>
		IBag<T> Subtract(IBag<T> bag);

		/// <summary>
        /// Applies the Intersection operation on two <see cref="Bag{T}"/>s.
		/// </summary>
		/// <param name="bag">The other bag.</param>
        /// <returns>The intersection of the current <see cref="Bag{T}"/> and the specified <see cref="Bag{T}"/>.</returns>
		IBag<T> Intersection(IBag<T> bag);
        	
		/// <summary>
        /// Removes the specified amount of items from the <see cref="Bag{T}"/>.
		/// </summary>
		/// <param name="item">The item.</param>
		/// <param name="maximum">The maximum amount of items to remove.</param>
		/// <returns>An indication of whether the items were found (and removed).</returns>
		bool Remove(T item, int maximum);

		/// <summary>
        /// Gets the count of the specified item contained in the <see cref="Bag{T}"/>.
		/// </summary>
		int this[T item] { get; }

		/// <summary>
        /// Applies the Union operation with two <see cref="Bag{T}"/>s.
		/// </summary>
        /// <param name="bag">The other <see cref="Bag{T}"/>.</param>
        /// <returns>The union of the current bag and the specified <see cref="Bag{T}"/>.</returns>
		IBag<T> Union(IBag<T> bag);

        /// <summary>
        /// Gets an enumerator that returns both the items, and the
        /// count of the items in the bag.
        /// </summary>
        /// <returns>An enumerator to cycle through the items in the bag.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        IEnumerator<KeyValuePair<T, int>> GetCountEnumerator();
	}
}
