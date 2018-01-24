/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/



using System;
using System.Collections.Generic;

using System.Collections;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using NGenerics.Util;

namespace NGenerics.DataStructures.General
{
    /// <summary>
    /// A data structure for representing a other of objects and common operations performed on sets.
    /// </summary>
	[SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    [Serializable]
    public class PascalSet : ICollection<int>, ISet, IEquatable<PascalSet>
    {
        #region Globals

        private readonly BitArray data;
        private readonly int lowerBound;
        private readonly int upperBound;

        #endregion

        #region Construction

        #region Public Constructors

		/// <param name="upperBound">The upper bound.  The lower bound defaults as 0.</param>
		/// <exception cref="ArgumentException"><paramref name="upperBound"/> is less than 1.</exception>
        public PascalSet(int upperBound) : this(0, upperBound) { }

        /// <param name="upperBound">The upper bound.  The lower bound defaults as 0.</param>
        /// <param name="initialValues">The initial values.</param>
		/// <exception cref="ArgumentException"><paramref name="upperBound"/> is less than 1.</exception>
		public PascalSet(int upperBound, int[] initialValues) : this(0, upperBound, initialValues) { }

        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        /// <param name="initialValues">The initial values.</param>
        /// <exception cref="ArgumentNullException"><paramref name="initialValues"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
		/// <exception cref="ArgumentException"><paramref name="lowerBound"/> is less than 0.</exception>
		/// <exception cref="ArgumentException"><paramref name="upperBound"/> is not greater than <paramref name="lowerBound"/>.</exception>
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PascalSet(int lowerBound, int upperBound, int[] initialValues)
            : this(lowerBound, upperBound)
        {
            Guard.ArgumentNotNull(initialValues, "initialValues");

            for (var i = 0; i < initialValues.Length; i++)
            {
                Add(initialValues[i]);
            }
        }

        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        /// <exception cref="ArgumentException"><paramref name="lowerBound"/> is less than 0.</exception>
        /// <exception cref="ArgumentException"><paramref name="upperBound"/> is not greater than <paramref name="lowerBound"/>.</exception>
        public PascalSet(int lowerBound, int upperBound)
        {
            #region Validation

            if (lowerBound < 0)
            {
                throw new ArgumentException("The lower bound must be larger or equal to zero.", "lowerBound");
            }

            if (upperBound < lowerBound)
            {
                throw new ArgumentException("The upper bound must be larger than the lower bound specified.", "upperBound");
            }

            #endregion

            this.lowerBound = lowerBound;
            this.upperBound = upperBound;

            data = new BitArray(upperBound - lowerBound + 1, false);
        }

        #endregion

        #region Private Constructors

        /// <param name="initialData">The initial data.</param>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        private PascalSet(BitArray initialData, int lowerBound, int upperBound)
        {
            #region Asserts

            Debug.Assert(lowerBound >= 0, "The lower bound must be larger or equal to zero.");
            Debug.Assert(lowerBound <= upperBound, "The upper bound must be larger than the lower bound specified.");
            Debug.Assert(initialData != null, "Initial data can not be null.");
            Debug.Assert((upperBound - lowerBound + 1) == initialData.Length, "The length of the bit array and the number of items in the universe does not match.");

            #endregion

            this.upperBound = upperBound;
            this.lowerBound = lowerBound;

            data = initialData;

            // Recalculate the count for this array
            for (var i = 0; i < data.Length; i++)
            {
                if (data[i])
                {
                    Count++;
                }
            }
        }

        #endregion

        #endregion

        #region Public Members

        /// <summary>
        /// Gets the lower bound.
        /// </summary>
        /// <value>The lower bound.</value>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\PascalSetExamples.cs" region="LowerBound" lang="cs" title="The following example shows how to use the LowerBound property."/>
        /// </example>
        public int LowerBound
        {
            get
            {
                return lowerBound;
            }
        }

        /// <summary>
        /// Gets the upper bound.
        /// </summary>
        /// <value>The upper bound.</value>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\PascalSetExamples.cs" region="UpperBound" lang="cs" title="The following example shows how to use the UpperBound property."/>
        /// </example>
        public int UpperBound
        {
            get
            {
                return upperBound;
            }
        }

        /// <summary>
        /// Gets the capacity of the other (the amount of items that can be contained).
        /// </summary>
        /// <value>The capacity of the other.</value>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\PascalSetExamples.cs" region="Capacity" lang="cs" title="The following example shows how to use the Capacity property."/>
        /// </example>
        public int Capacity
        {
            get
            {
                return upperBound - lowerBound + 1;
            }
        }
        /// <summary>
        /// Computes the union of this other and the specified other.
        /// </summary>
        /// <param name="set">The other.</param>
        /// <returns>The union between this other and the other specified.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="set"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
		/// <exception cref="ArgumentException"><paramref name="set"/> is not in the same universe as this instance.</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\PascalSetExamples.cs" region="Union" lang="cs" title="The following example shows how to use the Union method."/>
        /// </example>
        public PascalSet Union(PascalSet set)
        {
            #region Validation

            Guard.ArgumentNotNull(set, "other");

            CheckIfUniverseTheSame(set);

            #endregion

            return new PascalSet(data.Or(set.data), lowerBound, upperBound);
        }

        /// <summary>
        /// Computes the difference between this other and the specified other.
        /// </summary>
        /// <param name="set">The other.</param>
        /// <returns>The result of the difference operation.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="set"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
		/// <exception cref="ArgumentException"><paramref name="set"/> is not in the same universe as this instance.</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\PascalSetExamples.cs" region="Subtract" lang="cs" title="The following example shows how to use the Subtract method."/>
        /// </example>
        public PascalSet Subtract(PascalSet set)
        {
            #region Validation


            Guard.ArgumentNotNull(set, "other");

            CheckIfUniverseTheSame(set);

            #endregion

            return new PascalSet(data.Xor(set.data), lowerBound, upperBound);
        }

        /// <summary>
        /// Computes the intersection between this other and the specified other.
        /// </summary>
        /// <param name="set">The other.</param>
        /// <returns>The result of the intersection operation.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="set"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
		/// <exception cref="ArgumentException"><paramref name="set"/> is not in the same universe as this instance.</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\PascalSetExamples.cs" region="Intersection" lang="cs" title="The following example shows how to use the Intersection method."/>
        /// </example>
        public PascalSet Intersection(PascalSet set)
        {
            #region Validation

            Guard.ArgumentNotNull(set, "other");

            CheckIfUniverseTheSame(set);

            #endregion

            return new PascalSet(data.And(set.data), lowerBound, upperBound);
        }

        /// <summary>
        /// Returns a other with items not in this other.
        /// </summary>		
        /// <returns>The other with items not included in this other.</returns>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\PascalSetExamples.cs" region="Inverse" lang="cs" title="The following example shows how to use the Inverse method."/>
        /// </example>
        public PascalSet Inverse()
        {
            return new PascalSet(data.Not(), lowerBound, upperBound);
        }

        /// <summary>
        /// Determines whether this other is a subset of the specified other.
        /// </summary>
        /// <param name="set">The other to be compared against.</param>
        /// <returns>
        /// 	<c>true</c> if this other is a subset of the specified other]; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="set"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
		/// <exception cref="ArgumentException"><paramref name="set"/> is not in the same universe as this instance.</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\PascalSetExamples.cs" region="IsSubsetOf" lang="cs" title="The following example shows how to use the IsSubsetOf method."/>
        /// </example>
        public bool IsSubsetOf(PascalSet set)
        {
            #region Validation

            Guard.ArgumentNotNull(set, "other");

            CheckIfUniverseTheSame(set);

            #endregion

            for (var i = 0; i < data.Length; i++)
            {
                if (data[i] && !set.data[i]) return false;
            }

            return true;
        }

        /// <summary>
        /// Determines whether this other is a proper subset of the specified other.
        /// </summary>
        /// <param name="set">The other to be compared against.</param>
        /// <returns>
        /// 	<c>true</c> if this is a proper subset of the specified other; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="set"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
	    /// <exception cref="ArgumentException"><paramref name="set"/> is not in the same universe as this instance.</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\PascalSetExamples.cs" region="IsProperSubsetOf" lang="cs" title="The following example shows how to use the IsProperSubsetOf method."/>
        /// </example>
        public bool IsProperSubsetOf(PascalSet set)
        {
            #region Validation

            Guard.ArgumentNotNull(set, "other");

            CheckIfUniverseTheSame(set);

            #endregion

            // A is a proper subset of a if the b is a subset of a and a != b
            return (IsSubsetOf(set) && !set.IsSubsetOf(this));
        }

        /// <summary>
        /// Determines whether this other is a superset of the specified other.
        /// </summary>
        /// <param name="set">The other to be compared against.</param>
        /// <returns>
        /// 	<c>true</c> if this other is a superset of the specified other; otherwise, <c>false</c>.
        /// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="set"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
		/// <exception cref="ArgumentException"><paramref name="set"/> is not in the same universe as this instance.</exception>
        public bool IsSupersetOf(PascalSet set)
        {
            #region Validation


            Guard.ArgumentNotNull(set, "other");

            CheckIfUniverseTheSame(set);

            #endregion

            for (var i = 0; i < data.Length; i++)
            {
                if (set.data[i] && !data[i]) return false;
            }

            return true;
        }

        /// <summary>
        /// Determines whether this other is a proper superset of the specified other.
        /// </summary>
        /// <param name="set">The other to be compared against.</param>
        /// <returns>
        /// 	<c>true</c> if this is a proper superset of the specified other; otherwise, <c>false</c>.
        /// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="set"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
		/// <exception cref="ArgumentException"><paramref name="set"/> is not in the same universe as this instance.</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\PascalSetExamples.cs" region="IsProperSupersetOf" lang="cs" title="The following example shows how to use the IsProperSupersetOf method."/>
        /// </example>
        public bool IsProperSupersetOf(PascalSet set)
        {
            #region Validation


            Guard.ArgumentNotNull(set, "other");

            CheckIfUniverseTheSame(set);

            #endregion

            // B is a proper superset of a if b is a superset of a and a != b
            return (IsSupersetOf(set) && !set.IsSupersetOf(this));
        }

        #endregion

        #region Operator Overloads

        /// <summary>
        /// Operator + : Performs a union between two sets.
        /// </summary>
        /// <param name="left">The left hand other.</param>
        /// <param name="right">The right hand other.</param>
        /// <returns>The result of the union operation.</returns>    
        /// <exception cref="ArgumentNullException"><paramref name="left"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>  
        /// <exception cref="ArgumentNullException"><paramref name="right"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>  
        /// <exception cref="ArgumentException"><paramref name="left"/> and <paramref name="right"/> are not in the same universe as this instance.</exception>
        [SuppressMessage("Microsoft.Design", "CA1013:OverloadOperatorEqualsOnOverloadingAddAndSubtract")]
        public static PascalSet operator +(PascalSet left, PascalSet right)
        {
            Guard.ArgumentNotNull(left, "left");
            return left.Union(right);
        }

        /// <summary>
        /// Operator - : Performs a difference operation between two sets.
        /// </summary>
        /// <param name="left">The left hand other.</param>
        /// <param name="right">The right hand other.</param>
        /// <returns>The result of the difference operation.</returns>  
        /// <exception cref="ArgumentNullException"><paramref name="left"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentNullException"><paramref name="right"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>      
        /// <exception cref="ArgumentException"><paramref name="left"/> and <paramref name="right"/> are not in the same universe as this instance.</exception>
        [SuppressMessage("Microsoft.Design", "CA1013:OverloadOperatorEqualsOnOverloadingAddAndSubtract")]
        public static PascalSet operator -(PascalSet left, PascalSet right)
        {
            Guard.ArgumentNotNull(left, "left");
            return left.Subtract(right);
        }

        /// <summary>
        /// Operator * : Performs a intersection between two sets.
        /// </summary>
        /// <param name="left">The left hand other.</param>
        /// <param name="right">The right hand other.</param>
        /// <returns>The result of the intersection operation.</returns> 
        /// <exception cref="ArgumentNullException"><paramref name="left"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentNullException"><paramref name="right"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentException"><paramref name="left"/> and <paramref name="right"/> are not in the same universe as this instance.</exception>
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static PascalSet operator *(PascalSet left, PascalSet right)
        {
            Guard.ArgumentNotNull(left, "left");
            return left.Intersection(right);
        }

        /// <summary>
        /// Operator &lt;= : Checks if the left hand other is a subset of the right hand other.
        /// </summary>
        /// <param name="left">The left hand other.</param>
        /// <param name="right">The right hand other.</param>
        /// <returns>A value indicating whether the left hand other is a subset of the right hand other.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="left"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentNullException"><paramref name="right"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentException"><paramref name="left"/> and <paramref name="right"/> are not in the same universe as this instance.</exception>
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static bool operator <=(PascalSet left, PascalSet right)
        {
            Guard.ArgumentNotNull(left, "left");
            return left.IsSubsetOf(right);
        }

        /// <summary>
        /// Operator &gt;= : Checks if the left hand other is a superset of the right hand other.
        /// </summary>
        /// <param name="left">The left hand other.</param>
        /// <param name="right">The right hand other.</param>
        /// <returns>A value indicating whether the left hand other is a superset of the right hand other.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="left"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentNullException"><paramref name="right"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentException"><paramref name="left"/> and <paramref name="right"/> are not in the same universe as this instance.</exception>
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static bool operator >=(PascalSet left, PascalSet right)
        {
            Guard.ArgumentNotNull(left, "left");
            return left.IsSupersetOf(right);
        }


        /// <summary>
        /// Operator &lt;= : Checks if the left hand other is a proper subset of the right hand other.
        /// </summary>
        /// <param name="left">The left hand other.</param>
        /// <param name="right">The right hand other.</param>
        /// <returns>A value indicating whether the left hand other is a proper subset of the right hand other.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="left"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentException"><paramref name="left"/> and <paramref name="right"/> are not in the same universe as this instance.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="right"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static bool operator <(PascalSet left, PascalSet right)
        {
            Guard.ArgumentNotNull(left, "left");
            return left.IsProperSubsetOf(right);
        }

        /// <summary>
        /// Operator &gt;= : Checks if the left hand other is a proper superset of the right hand other.
        /// </summary>
        /// <param name="left">The left hand other.</param>
        /// <param name="right">The right hand other.</param>
        /// <returns>A value indicating whether the left hand other is a proper superset of the right hand other.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="left"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentNullException"><paramref name="right"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentException"><paramref name="left"/> and <paramref name="right"/> are not in the same universe as this instance.</exception>
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static bool operator >(PascalSet left, PascalSet right)
        {
            Guard.ArgumentNotNull(left, "left");
            return left.IsProperSupersetOf(right);
        }

        /// <summary>
        /// Operator ! : Performs the inverse operation on this other.
        /// </summary>
        /// <param name="set">The inverse of other.</param>
        /// <returns>The result of the inverse operation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="set"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static PascalSet operator !(PascalSet set)
        {
            Guard.ArgumentNotNull(set, "other");
            return set.Inverse();
        }

        /// <summary>
        /// Indicates whether an item is present in this other.
        /// </summary>
        public bool this[int item]
        {
            get
            {
                #region Validation

                CheckValidIndex(item);

                #endregion

                return data[GetOffSet(item)];
            }
        }
        

        #endregion

        #region Private Members

        /// <summary>
        /// Gets the offset of the specified index.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The offset of the item at the specified index.</returns>
        private int GetOffSet(int item)
        {
            return item - lowerBound;
        }

        /// <summary>
        /// Determines whether [is universe the same] [the specified other].
        /// </summary>
        /// <param name="set">The other.</param>
        /// <returns>
        /// 	<c>true</c> if [is universe the same] [the specified other]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsUniverseTheSame(PascalSet set)
        {
            return
                (set.lowerBound == lowerBound) &&
                (set.upperBound == upperBound);
        }

        /// <summary>
        /// Checks if the universe is the same.
        /// </summary>
        /// <param name="other">The other set to compare against.</param>
        private void CheckIfUniverseTheSame(PascalSet other)
        {
            if (!IsUniverseTheSame(other))
       
            {
                throw new ArgumentException("The operation requested can only be done if the sets share the same universe.", nameof(other));
            }
        }

        /// <summary>
        /// Determines whether [is index valid] [the specified index].
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>
        /// 	<c>true</c> if [is index valid] [the specified index]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsIndexValid(int index)
        {
            return ((index >= lowerBound) && (index <= upperBound));
        }

        /// <summary>
        /// Checks if the value supplied is a valid index.
        /// </summary>
        /// <param name="index">The index.</param>
        private void CheckValidIndex(int index)
        {
            if (!IsIndexValid(index))
            {
                throw new ArgumentException("The item is not in the universe of the other.", "index");
            }
        }

        #endregion

        #region ICollection<int> Members

		/// <inheritdoc />  
        /// <exception cref="ArgumentException"><paramref name="item"/> is not in the same universe.</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\PascalSetExamples.cs" region="Add" lang="cs" title="The following example shows how to use the Add method."/>
        /// </example>
        public void Add(int item)
        {
            #region Validation

            CheckValidIndex(item);

            #endregion
            var offset = GetOffSet(item);

            if (!data[offset])
            {
            	AddItem(item, offset);
            }
        }

        /// <summary>
        /// Adds the item to the other.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <param name="offset">The offset in which to add the item.</param>
        /// <remarks>
        /// 	<b>Notes to Inheritors: </b>
        /// Derived classes can override this method to change the behavior of the <see cref="Add"/> method.
        /// </remarks>
		protected virtual void AddItem(int item, int offset)
		{
			Count++;
			data[offset] = true;
		}

		/// <inheritdoc />  
		/// <exception cref="ArgumentException"><paramref name="item"/> is not in the same universe.</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\PascalSetExamples.cs" region="Remove" lang="cs" title="The following example shows how to use the Remove method."/>
        /// </example>
        public bool Remove(int item)
        {
            #region Validation

            CheckValidIndex(item);

            #endregion

            var offset = GetOffSet(item);

            if (data[offset])
            {
				RemoveItem(item, offset);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Removes the item from the other.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        /// <param name="offset">The offset at which to remove the item.</param>
        /// <remarks>
        /// 	<b>Notes to Inheritors: </b>
        /// Derived classes can override this method to change the behavior of the <see cref="Remove"/> method.
        /// </remarks>
		protected virtual void RemoveItem(int item, int offset)
		{
			Count--;
			data[offset] = false;
		}

		/// <inheritdoc />  
		/// <exception cref="ArgumentException"><paramref name="item"/> is not in the same universe.</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\PascalSetExamples.cs" region="Contains" lang="cs" title="The following example shows how to use the Contains method."/>
        /// </example>
        public bool Contains(int item)
        {
            #region Validation

            CheckValidIndex(item);

            #endregion

            return data[item];
        }

		/// <inheritdoc />  
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\PascalSetExamples.cs" region="Clear" lang="cs" title="The following example shows how to use the Clear method."/>
        /// </example>
        public void Clear()
        {
            ClearItems();
		}	
		
		/// <summary>
		/// Clears all the objects in this instance.
		/// </summary>
		/// <remarks>
		/// <b>Notes to Inheritors: </b>
		///  Derived classes can override this method to change the behavior of the <see cref="Clear"/> method.
		/// </remarks>
        protected virtual void ClearItems()
        {
            data.SetAll(false);
            Count = 0;
        }

		/// <inheritdoc />  
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\PascalSetExamples.cs" region="CopyTo" lang="cs" title="The following example shows how to use the CopyTo method."/>
        /// </example>
        public void CopyTo(int[] array, int arrayIndex)
        {
            #region Validation

            Guard.ArgumentNotNull(array, "array");

            if ((array.Length - arrayIndex) < Count)
            {
                throw new ArgumentException(Constants.NotEnoughSpaceInTheTargetArray, "array");
            }

            #endregion

            foreach (var item in this)
            {
                array.SetValue(item, arrayIndex++);
            }
        }

        /// <inheritdoc />  
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\PascalSetExamples.cs" region="Count" lang="cs" title="The following example shows how to use the Count property."/>
        /// </example>
        public int Count { get; private set; }

		/// <inheritdoc />  
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\PascalSetExamples.cs" region="IsFull" lang="cs" title="The following example shows how to use the IsFull property."/>
        /// </example>
        public bool IsFull
        {
            get
            {
                return Capacity == Count;
            }
        }

        #endregion

        #region IEnumerable<T> Members

		/// <inheritdoc />  
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\PascalSetExamples.cs" region="GetEnumerator" lang="cs" title="The following example shows how to use the GetEnumerator method."/>
        /// </example>
        public IEnumerator<int> GetEnumerator()
        {
            for (var i = 0; i < data.Count; i++)
            {
                if (data[i])
                {
                    yield return i + lowerBound;
                }
            }
        }

        #endregion

        #region ICollection<int> Members

		/// <inheritdoc />  
        /// <value>
        /// 	Always <c>false</c>.
        /// </value>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\PascalSetExamples.cs" region="IsReadOnly" lang="cs" title="The following example shows how to use the IsReadOnly property."/>
        /// </example>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        #endregion

        #region IEnumerable Members

		/// <inheritdoc />  
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\PascalSetExamples.cs" region="GetEnumerator" lang="cs" title="The following example shows how to use the GetEnumerator method."/>
        /// </example>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region ISet Members

		/// <inheritdoc />  
        ISet ISet.Subtract(ISet other)
        {
            return Subtract((PascalSet)other);
        }

		/// <inheritdoc />  
        ISet ISet.Intersection(ISet other)
        {
            return Intersection((PascalSet)other);
        }

		/// <inheritdoc />  
        ISet ISet.Inverse()
        {
            return Inverse();
        }

		/// <inheritdoc />  
        bool ISet.IsProperSubsetOf(ISet other)
        {
            return IsProperSubsetOf((PascalSet)other);
        }

		/// <inheritdoc />  
        bool ISet.IsProperSupersetOf(ISet other)
        {
            return IsProperSupersetOf((PascalSet)other);
        }

		/// <inheritdoc />  
        bool ISet.IsSubsetOf(ISet other)
        {
            return IsSubsetOf((PascalSet)other);
        }

		/// <inheritdoc />  
        bool ISet.IsSupersetOf(ISet other)
        {
            return IsSupersetOf((PascalSet)other);
        }

		/// <inheritdoc />  
        ISet ISet.Union(ISet other)
        {
            return Union((PascalSet)other);
        }

        #endregion

        #region IEquatable<PascalSet> Members

		/// <inheritdoc />  
        public bool Equals(PascalSet other)
        {
            if ((other == null) || (!IsUniverseTheSame(other)))
            {
                return false;
            }
		    
		    for (var i = 0; i < data.Length; i++)
		    {
		        if (data[i] != other.data[i])
		        {
		            return false;
		        }
		    }

		    return true;
        }

        #endregion
    }
}