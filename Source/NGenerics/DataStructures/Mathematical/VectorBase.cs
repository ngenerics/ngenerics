/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using NGenerics.DataStructures.General;
using NGenerics.Util;

namespace NGenerics.DataStructures.Mathematical
{
    
    /// <summary>
    /// A Vector data structure.
    /// </summary>
    public abstract partial class VectorBase<T> : IVector<T> 
    {
        #region Globals

        private readonly int dimensionCount;

        #endregion


        #region Constructors

        /// <summary>
        /// Initialise a new instance of the <see cref="VectorBase{T}"/> class.
        /// </summary>
        /// <param name="dimensionCount">The number of dimensions.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="dimensionCount"/> is less than 0.</exception>
        protected VectorBase(int dimensionCount)
        {
           this.dimensionCount = dimensionCount;
        }

        #endregion


        #region Properties

		/// <inheritdoc />
        public int DimensionCount
        {
            get
            {
                return dimensionCount;
            }
        }


		/// <inheritdoc />
        public abstract T this[int index]
        {
            get;
            set;
        }


        #endregion


        #region Methods



		/// <inheritdoc />
        // <example>
        // <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\VectorBaseExamples.cs" region="AddVector" lang="cs" title="The following example shows how to use the Add method."/>
        // <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\VectorBaseExamples.vb" region="AddVector" lang="vbnet" title="The following example shows how to use the Add method."/>
        // </example>
        public void Add(IVector<T> vector)
        {
            Guard.ArgumentNotNull(vector, "vector");
            CheckDimensionsEqual(this, vector);
            AddSafe(vector);
        }


        /// <summary>
        /// Adds a <see cref="IVector{T}"/> to the current <see cref="IVector{T}"/>.
        /// </summary>
        /// <param name="vector">The <see cref="IVector{T}"/> to add to this <see cref="IVector{T}"/>.</param>
        protected abstract void AddSafe(IVector<T> vector);


        /// <summary>
        /// Adds a <typeparamref name="T"/> to each dimension.
        /// </summary>
        /// <param name="number">The <typeparamref name="T"/> to add to this <see cref="IVector{T}"/>.</param>
        // <example>
        // <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\VectorBaseExamples.cs" region="AddT" lang="cs" title="The following example shows how to use the Add method."/>
        // <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\VectorBaseExamples.vb" region="AddT" lang="vbnet" title="The following example shows how to use the Add method."/>
        // </example>
        public abstract void Add(T number);
        
        /// <summary>
        /// Check if the dimensions of two <see cref="IVector{T}"/>s are equal.
        /// </summary>
        /// <param name="left">The left hand <see cref="IVector{T}"/>.</param>
        /// <param name="right">The right hand <see cref="IVector{T}"/>.</param>
        /// <exception cref="ArgumentException">The left <see cref="IVector{T}.DimensionCount"/> does not equal the right <see cref="IVector{T}.DimensionCount"/>.</exception>
        [SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        protected static void CheckDimensionsEqual(IVector<T> left, IVector<T> right)
        {
            if (left.DimensionCount != right.DimensionCount)
            {
                throw new ArgumentException("Vectors must have the same DimensionCount to perform this operation", "right");
            }
        }


		/// <inheritdoc />
        public virtual void Clear()
        {
            for (var index = 0; index < dimensionCount; index++)
            {
                this[index] = default(T);
            }
        }


        ///<summary>
        ///Creates a new object that is a copy of the current instance.
        ///</summary>
        ///<returns>
        ///A new object that is a copy of this instance.
        ///</returns>
        protected abstract IVector<T> DeepClone();

		/// <inheritdoc />
        public object Clone()
        {
            return DeepClone();
        }


		/// <inheritdoc />
        public IVector<T> CrossProduct(IVector<T> vector)
        {
            Guard.ArgumentNotNull(vector, "vector");
            if ((vector.DimensionCount != 2) && (vector.DimensionCount != 3))
            {
                throw new ArgumentException("DimensionCount must be 2 or 3 to calculate the cross product.", "vector");
            }
            if ((DimensionCount != 2) && (DimensionCount != 3))
            {
                throw new InvalidOperationException("DimensionCount must be 2 or 3 to calculate the cross product.");
            }
            return CrossProductSafe(vector);
        }


        /// <summary>
        /// Get the cross product of this <see cref="IVector{T}"/> and <paramref name="vector"/>.
        /// </summary>
        /// <param name="vector">The <see cref="IVector{T}"/> to calculate the cross product with.</param>
        /// <returns>The cross product of this <see cref="IVector{T}"/> and <paramref name="vector"/>.</returns>
        protected abstract IVector<T> CrossProductSafe(IVector<T> vector);


		/// <inheritdoc />
        public abstract void Increment();

		/// <inheritdoc />
        public abstract T Magnitude();


		/// <inheritdoc />
        public abstract T Product();


		/// <inheritdoc />
        public abstract T Sum();


		/// <inheritdoc />
        public abstract void Decrement();


        /// <summary>
        /// Divide by a <see cref="IVector{T}"/>.
        /// </summary>
        /// <param name="vector">The <see cref="IVector{T}"/> to divide by.</param>
        // <example>
        // 	<code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\VectorBaseExamples.cs" region="DivideVector" lang="cs" title="The following example shows how to use the Divide method."/>
        // 	<code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\VectorBaseExamples.vb" region="DivideVector" lang="vbnet" title="The following example shows how to use the Divide method."/>
        // </example>
        public void Divide(IVector<T> vector)
        {
            Guard.ArgumentNotNull(vector, "vector");
            CheckDimensionsEqual(this, vector);
            DivideSafe(vector);
        }


        /// <summary>
        /// Divide by a <see cref="IVector{T}"/>.
        /// </summary>
        /// <param name="vector">The <see cref="IVector{T}"/> to divide by.</param>
        protected abstract void DivideSafe(IVector<T> vector);


		/// <inheritdoc />
        // <example>
        // <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\VectorBaseExamples.cs" region="DivideT" lang="cs" title="The following example shows how to use the Divide method."/>
        // <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\VectorBaseExamples.vb" region="DivideT" lang="vbnet" title="The following example shows how to use the Divide method."/>
        // </example>
        public abstract void Divide(T number);


		/// <inheritdoc />
        // <example>
        // <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\VectorBaseExamples.cs" region="DotProduct" lang="cs" title="The following example shows how to use the DotProduct method."/>
        // <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\VectorBaseExamples.vb" region="DotProduct" lang="vbnet" title="The following example shows how to use the DotProduct method."/>
        // </example>
        public T DotProduct(IVector<T> vector)
        {
            Guard.ArgumentNotNull(vector, "vector");
            CheckDimensionsEqual(this, vector);
            return DotProductSafe(vector);
        }


        /// <summary>
        /// Calculate the dot product.
        /// </summary>
        /// <param name="vector">The <see cref="IVector{T}"/> to calculate the dot product with.</param>
        /// <returns>The dot product of the current instance and <paramref name="vector"/>.</returns>
        protected abstract T DotProductSafe(IVector<T> vector);


		/// <inheritdoc />
        // <example>
        // <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\VectorBaseExamples.cs" region="EqualsObject" lang="cs" title="The following example shows how to use the object.Equals overload."/>
        // <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\VectorBaseExamples.vb" region="EqualsObject" lang="vbnet" title="The following example shows how to use the object.Equals overload."/>
        // </example>
        public override bool Equals(object obj)
        {

            if (obj == null)
            {
                return false;
            }
		    
            var vector = obj as IVector<T>;
		    return (EqualsInternal(vector));
        }


		/// <inheritdoc />
        // <example>
        // <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\VectorBaseExamples.cs" region="EqualsVector" lang="cs" title="The following example shows how to use the Equals method."/>
        // <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\VectorBaseExamples.vb" region="EqualsVector" lang="vbnet" title="The following example shows how to use the Equals method."/>
        // </example>
        public bool Equals(IVector<T> other)
		{
		    return other != null && EqualsInternal(other);
		}


        private bool EqualsInternal(IVector<T> other)
        {

            if (dimensionCount != other.DimensionCount)
            {
                return false;
            }
            for (var i = 0; i < dimensionCount; i++)
            {
                if (!Equals(this[i], other[i]))
                {
                    return false;
                }
            }
            return true;
        }


		/// <inheritdoc />
        public override int GetHashCode()
        {
            var hashCode = 0;
            for (var index = 0; index < dimensionCount; index++)
            {
                hashCode ^= this[index].GetHashCode();
            }
            return hashCode;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        /// <inheritdoc />
        public abstract T AbsoluteMaximum();


		/// <inheritdoc />
        public abstract int AbsoluteMaximumIndex();


		/// <inheritdoc />
        public abstract T AbsoluteMinimum();


		/// <inheritdoc />
        public abstract int AbsoluteMinimumIndex();

		/// <inheritdoc />
        public virtual T Maximum()
        {
            var maximumIndex = MaximumIndex();
            return this[maximumIndex];
        }


		/// <inheritdoc />
        public abstract int MaximumIndex();

		/// <inheritdoc />
        public virtual T Minimum()
        {
            return this[MinimumIndex()];
        }


        /// <summary>
        /// Get the index of the minimum dimension.
        /// </summary>
        /// <returns>The index of the minimum dimension.</returns>
        public abstract int MinimumIndex();


		/// <inheritdoc />
        // <example>
        // <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\VectorBaseExamples.cs" region="Add" lang="cs" title="The following example shows how to use the Multiply method."/>
        // <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\VectorBaseExamples.vb" region="Add" lang="vbnet" title="The following example shows how to use the Multiply method."/>
        // </example>
        public IMatrix<T> Multiply(IVector<T> vector)
        {
            Guard.ArgumentNotNull(vector, "vector");
            CheckDimensionsEqual(this, vector);
            return MultiplySafe(vector);
        }


        /// <summary>
        /// Multiply the current <see cref="IVector{T}"/> with another <see cref="IVector{T}"/>.
        /// </summary>
        /// <param name="vector">The <see cref="IVector{T}"/> to multiply by.</param>
        /// <returns>The result of the multiply operation.</returns>
        protected abstract IMatrix<T> MultiplySafe(IVector<T> vector);

        /// <summary>
        /// Multiply the current <see cref="IVector{T}"/> with a <typeparamref name="T"/>.
        /// </summary>
        /// <param name="number">The <typeparamref name="T"/> to multiply by.</param>
        // <example>
        // 	<code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\VectorBaseExamples.cs" region="MultiplyT" lang="cs" title="The following example shows how to use the Multiply method."/>
        // 	<code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\VectorBaseExamples.vb" region="MultiplyT" lang="vbnet" title="The following example shows how to use the Multiply method."/>
        // </example>
            public abstract void Multiply(T number);

		/// <inheritdoc />
        public abstract void Negate();

		/// <inheritdoc />
        public abstract void Normalize();



		/// <inheritdoc />
        public void SetValues(params T[] values)
        {
            Guard.ArgumentNotNull(values, "values");
            if (values.Length != dimensionCount)
            {
                throw new ArgumentOutOfRangeException("values", "length of array must equal dimension count");
            }
            SetValuesSafe(values);
        }


        /// <summary>
        /// Set the values of the <see cref="IVector{T}"/>
        /// </summary>
        /// <remarks><paramref name="values"/> has already been checked for null and that it is of the correct length.</remarks>
		/// <param name="values">The values to set.</param>
		/// <remarks>
		/// <b>Notes to Inheritors: </b>
		///  Derived classes can override this method to change the behavior of the <see cref="SetValues"/> method.
		/// </remarks>
        protected virtual void SetValuesSafe(T[] values)
        {
            for (var i = 0; i < values.Length; i++)
            {
                this[i] = values[i];
            }
        }



        /// <summary>
        /// Subtracts a <see cref="IVector{T}"/> from the current instance.
        /// </summary>
        /// <param name="vector">The <see cref="IVector{T}"/> to subtract from this <see cref="IVector{T}"/>.</param>
        // <example>
        // <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\VectorBaseExamples.cs" region="SubtractVector" lang="cs" title="The following example shows how to use the Subtract method."/>
        // <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\VectorBaseExamples.vb" region="SubtractVector" lang="vbnet" title="The following example shows how to use the Subtract method."/>
        // </example>
        public void Subtract(IVector<T> vector)
        {
            Guard.ArgumentNotNull(vector, "vector");
            CheckDimensionsEqual(this, vector);
            SubtractSafe(vector);
        }


        /// <summary>
        /// Subtracts a <see cref="IVector{T}"/> from the current instance.
        /// </summary>
        /// <param name="vector">The <see cref="IVector{T}"/> to subtract from this <see cref="IVector{T}"/>.</param>
        /// <returns>The result of the subtraction.</returns>
        protected abstract void SubtractSafe(IVector<T> vector);


        /// <summary>
        /// Subtracts a <typeparamref name="T"/> from the current instance.
        /// </summary>
        /// <param name="number">The <typeparamref name="T"/> to subtract from this <see cref="IVector{T}"/>.</param>
        /// <returns>The result of the subtraction.</returns>
        // <example>
        // <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\VectorBaseExamples.cs" region="SubtractT" lang="cs" title="The following example shows how to use the Subtract method."/>
        // <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\VectorBaseExamples.vb" region="SubtractT" lang="vbnet" title="The following example shows how to use the Subtract method."/>
        // </example>
        public abstract void Subtract(T number);




        /// <summary>
        /// Swap all the values with another <see cref="IVector{T}"/>.
        /// </summary>
        /// <param name="other">The <see cref="IVector{T}"/> to swap values with.</param>
        /// <exception cref="ArgumentNullException"><paramref name="other"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentException">The <see cref="IVector{T}.DimensionCount"/> of the current instance does not equal the <see cref="IVector{T}.DimensionCount"/> of <paramref name="other"/>.</exception>
        public void Swap(IVector<T> other)
        {
            Guard.ArgumentNotNull(other, "other");
            CheckDimensionsEqual(this, other);
            SwapSafe(other);
        }


        /// <summary>
        /// Swap all the values with another <see cref="IVector{T}"/>.
        /// </summary>
        /// <remarks><paramref name="other"/> has been checked for null and that its dimensions match the current <see cref="IVector{T}"/>.</remarks>
		/// <param name="other">The <see cref="IVector{T}"/> to swap value with.</param>
		/// <remarks>
		/// <b>Notes to Inheritors: </b>
		///  Derived classes can override this method to change the behavior of the <see cref="Swap"/> method.
		/// </remarks>
        protected virtual void SwapSafe(IVector<T> other)
        {
            for (var index = 0; index < dimensionCount; index++)
            {
                var temp = this[index];
                this[index] = other[index];
                other[index] = temp;
            }
        }


        /// <summary>
        /// Copies the elements of the <see cref="IVector{T}"/> to a new <typeparamref name="T"/> array. 
        /// </summary>
        /// <returns>A <typeparamref name="T"/> array containing copies of the elements of the <see cref="IVector{T}"/>.</returns>
        public abstract T[] ToArray();


        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public virtual IEnumerator<T> GetEnumerator()
        {
            for (var index = 0; index < dimensionCount; index++)
            {
                yield return this[index];
            }
        }

        /// <summary>
        /// Returns a string representation of the <see cref="IVector{T}"/>.
        /// </summary>
        /// <returns>
        /// A string representation of the <see cref="IVector{T}"/>.
        /// </returns>
        // <example>
        // <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\VectorBaseExamples.cs" region="ToString" lang="cs" title="The following example shows how to use the ToString method."/>
        // <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\VectorBaseExamples.vb" region="ToString" lang="vbnet" title="The following example shows how to use the ToString method."/>
        // </example>
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append('{');
            for (var index = 0; index < dimensionCount; index++)
            {
                stringBuilder.Append(this[index]);
                stringBuilder.Append(",");
            }
            stringBuilder.Remove(stringBuilder.Length - 1, 1);
            stringBuilder.Append('}');
            return stringBuilder.ToString();
        }


        /// <summary>
        /// Copies the elements of the <see cref="IVector{T}"/> to a new <see cref="Matrix"/>. 
        /// </summary>
        /// <returns>A <see cref="Matrix"/> array containing copies of the elements of the <see cref="IVector{T}"/>.</returns>
        public abstract IMatrix<T> ToMatrix();

        #endregion

    }
}