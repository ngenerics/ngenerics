/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/


using System;
using System.Collections.Generic;
using NGenerics.DataStructures.General;

namespace NGenerics.DataStructures.Mathematical
{
    /// <summary>
    /// An interface describing a mathematical Vector.
    /// </summary>
    /// <typeparam name="T">The type of vector.</typeparam>
    public interface IVector<T> : IEnumerable<T>, IEquatable<IVector<T>>
#if (!SILVERLIGHT)
        , ICloneable
#endif
    {
        
        /// <summary>
        /// Gets or sets the element in the specified dimension.
		/// </summary>
		/// <exception cref="IndexOutOfRangeException"><paramref name="index"/> is > <see cref="DimensionCount"/>.</exception>
        T this[int index] { get; set; }

        /// <summary>
        /// Get the value of the absolute maximum dimension.
        /// </summary>
        /// <returns>The value of the absolute maximum dimension</returns>
        T AbsoluteMaximum();

        /// <summary>
        /// Get the index of the absolute minimum dimension.
        /// </summary>
        /// <returns>The index of the absolute minimum dimension</returns>
        int AbsoluteMaximumIndex();

        /// <summary>
        /// Get the value of the absolute minimum dimension.
        /// </summary>
        /// <returns>The value of the absolute minimum dimension</returns>
        T AbsoluteMinimum();

        /// <summary>
        /// Get the index of the absolute maximum dimension.
        /// </summary>
        /// <returns>The index of the absolute maximum dimension</returns>
        int AbsoluteMinimumIndex();

        /// <summary>
        /// Adds a <see cref="IVector{T}"/> to the current <see cref="IVector{T}"/>.
        /// </summary>
		/// <param name="vector">The <see cref="IVector{T}"/> to add to this <see cref="IVector{T}"/>.</param>
		/// <exception cref="ArgumentNullException"><paramref name="vector"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
		/// <exception cref="ArgumentException">The <see cref="IVector{T}.DimensionCount"/> of the current instance does not equal the <see cref="IVector{T}.DimensionCount"/> of <paramref name="vector"/>.</exception>
        void Add(IVector<T> vector);

        /// <summary>
        /// Adds a <typeparamref name="T"/> to each dimension.
        /// </summary>
        /// <param name="number">The <typeparamref name="T"/> to add to this <see cref="IVector{T}"/>.</param>
        void Add(T number);

        /// <summary>
        /// Sets the value of each dimension to zero.
        /// </summary>
        void Clear();

        /// <summary>
        /// Get the cross product of this <see cref="IVector{T}"/> and <paramref name="vector"/>.
        /// </summary>
        /// <remarks>
        /// Consider two vectors, a = (1,2,3) and b = (4,5,6). The cross product a × b is
        /// a × b = (1,2,3) × (4,5,6) = ((2 × 6 - 3 × 5),(3 × 4 - 1 × 6), (1 × 5 - 2 × 4)) = (-3,6,-3). 
        /// </remarks>
        /// <param name="vector">The <see cref="IVector{T}"/> to calculate the cross product with.</param>
		/// <returns>The cross product of this <see cref="IVector{T}"/> and <paramref name="vector"/>.</returns>
		/// <exception cref="InvalidOperationException"><see cref="DimensionCount"/> of this <see cref="IVector{T}"/> does not equal 3.</exception>
		/// <exception cref="ArgumentException"><see cref="DimensionCount"/> of this <paramref name="vector"/> does not equal 3.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="vector"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        IVector<T> CrossProduct(IVector<T> vector);

        /// <summary>
        /// Decrement each dimension by 1.
        /// </summary>
        void Decrement();

        /// <summary>
        /// Gets the dimension count of the <see cref="IVector{T}"/>.
        /// </summary>
        int DimensionCount { get;}

        /// <summary>
        /// Calculate the dot product.
        /// </summary>
        /// <param name="vector">The <see cref="IVector{T}"/> to calculate the dot product with.</param>
		/// <returns>The dot product of the current instance and <paramref name="vector"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="vector"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
		/// <exception cref="ArgumentException">The <see cref="IVector{T}.DimensionCount"/> of the current instance does not equal the <see cref="IVector{T}.DimensionCount"/> of <paramref name="vector"/>.</exception>
        T DotProduct(IVector<T> vector);

        /// <summary>
        /// Computes the sum of the elements of the <see cref="IVector{T}"/>.
        /// </summary>
        /// <returns>The sum of the elements of the <see cref="IVector{T}"/>.</returns>
        T Sum();

        /// <summary>
        /// Computes the product of the elements of the <see cref="IVector{T}"/>.
        /// </summary>
        /// <returns>The product of the elements of the <see cref="IVector{T}"/>.</returns>
        T Product();

        /// <summary>
        /// Increment each dimension by 1.
        /// </summary>
        void Increment();

        /// <summary>
        /// Gets the magnitude of this <see cref="IVector{T}"/>.
        /// </summary>
        /// <returns>The magnitude of the elements of the <see cref="IVector{T}"/>.</returns>
        T Magnitude();

        /// <summary>
        /// Divide each dimension by a number.
        /// </summary>
        /// <param name="number">The <typeparamref name="T"/> to divide by.</param>
        void Divide(T number);

        /// <summary>
        /// Divide by a <see cref="IVector{T}"/>.
        /// </summary>
		/// <param name="vector">The <see cref="IVector{T}"/> to divide by.</param>
		/// <exception cref="ArgumentNullException"><paramref name="vector"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
		/// <exception cref="ArgumentException">The <see cref="IVector{T}.DimensionCount"/> of the current instance does not equal the <see cref="IVector{T}.DimensionCount"/> of <paramref name="vector"/>.</exception>
        void Divide(IVector<T> vector);

        /// <summary>
        /// Negate each dimension.
        /// </summary>
        void Negate();

        /// <summary>
        /// Normalize each dimension.
        /// </summary>
        /// <remarks>
        /// Results in the <see cref="IVector{T}"/> having a <see cref="Magnitude"/> of 1.
        /// </remarks>
        void Normalize();

        /// <summary>
        /// Get the value of the maximum dimension.
        /// </summary>
        /// <returns>The value of the maximum dimension.</returns>
        T Maximum();

        /// <summary>
        /// Get the index of the maximum dimension.
        /// </summary>
        /// <returns>The index of the maximum dimension.</returns>
        int MaximumIndex();

        /// <summary>
        /// Get the value of the minimum dimension.
        /// </summary>
        /// <returns>The value of the minimum dimension.</returns>
        T Minimum();

        /// <summary>
        /// Get the index of the minimum dimension.
        /// </summary>
        /// <returns>The index of the minimum dimension.</returns>
        int MinimumIndex();

        /// <summary>
        /// Multiply the current <see cref="IVector{T}"/> with another <see cref="IVector{T}"/>.
        /// </summary>
        /// <param name="vector">The <see cref="IVector{T}"/> to multiply by.</param>
		/// <returns>The result of the multiply operation.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="vector"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
		/// <exception cref="ArgumentException">The <see cref="IVector{T}.DimensionCount"/> of the current instance does not equal the <see cref="IVector{T}.DimensionCount"/> of <paramref name="vector"/>.</exception>
        IMatrix<T> Multiply(IVector<T> vector);

        /// <summary>
        /// Multiply the current <see cref="IVector{T}"/> with a <typeparamref name="T"/>.
        /// </summary>
        /// <param name="number">The <typeparamref name="T"/> to multiply by.</param>
        void Multiply(T number);

        /// <summary>
        /// Subtracts a <see cref="IVector{T}"/> from the current instance.
        /// </summary>
        /// <param name="vector">The <see cref="IVector{T}"/> to subtract from this <see cref="IVector{T}"/>.</param>
        void Subtract(IVector<T> vector); 
   
        /// <summary>
        /// Subtracts a <typeparamref name="T"/> from the current instance.
        /// </summary>
        /// <param name="number">The <typeparamref name="T"/> to subtract from this <see cref="IVector{T}"/>.</param>
        void Subtract(T number);

        /// <summary>
        /// Set the values of the <see cref="IVector{T}"/>
        /// </summary>
		/// <param name="values">The values to set.</param>
		/// <exception cref="ArgumentNullException"><paramref name="values"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
		/// <exception cref="ArgumentOutOfRangeException">The length of <paramref name="values"/> does not equal <see cref="IVector{T}.DimensionCount"/>.</exception>
        void SetValues(params T[] values);

        /// <summary>
        /// Swap all the values with another <see cref="IVector{T}"/>.
        /// </summary>
        /// <param name="other">The <see cref="IVector{T}"/> to swap values with.</param>
        void Swap(IVector<T> other);

        /// <summary>
        /// Copies the elements of the <see cref="IVector{T}"/> to a new <typeparamref name="T"/> array. 
        /// </summary>
        /// <returns>A <typeparamref name="T"/> array containing copies of the elements of the <see cref="IVector{T}"/>.</returns>
        T[] ToArray();


        /// <summary>
        /// Copies the elements of the <see cref="IVector{T}"/> to a new <see cref="Matrix"/>. 
        /// </summary>
        /// <returns>A <see cref="Matrix"/> array containing copies of the elements of the <see cref="IVector{T}"/>.</returns>
        IMatrix<T> ToMatrix();
    }
}
