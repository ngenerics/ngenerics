/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/



using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NGenerics.DataStructures.General;
using NGenerics.Util;

namespace NGenerics.DataStructures.Mathematical
{
    /// <summary>
    /// A Vector data structure.
    /// </summary>
    public partial class Vector2D : VectorBase<double>
    {
        #region Globals

    	#endregion

        #region Constructors

        /// <inheritdoc/>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.cs" region="Constructor" lang="cs" title="The following example shows how to use the default constructor."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.vb" region="Constructor" lang="vbnet" title="The following example shows how to use the default constructor."/>
        /// </example> 
        public Vector2D()
            : base(2)
        {
        }


        /// <inheritdoc/>
        /// <param name="x">The X dimension.</param>
        /// <param name="y">The Y dimension.</param>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.cs" region="ConstructorInitValues" lang="cs" title="The following example shows how to use the initialize values constructor."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.vb" region="ConstructorInitValues" lang="vbnet" title="The following example shows how to use the initialize values constructor."/>
        /// </example> 
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y")]
        public Vector2D(double x, double y)
            : base(2)
        {
            X = x;
            Y = y;
        }

        #endregion

        #region Properties

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.cs" region="Index" lang="cs" title="The following example shows how to use the index property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.vb" region="Index" lang="vbnet" title="The following example shows how to use the index property."/>
        /// </example> 
        public override double this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return X;
                    case 1:
                        return Y;
                    default:
                        throw new ArgumentOutOfRangeException("index");
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        X = value;
                        break;
                    case 1:
                        Y = value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("index");
                }
            }
        }


    	/// <summary>
    	/// Gets or sets the x dimension
    	/// </summary>
    	/// <example>
    	/// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.cs" region="NamedDimensions" lang="cs" title="The following example shows how to use the X property."/>
    	/// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.vb" region="NamedDimensions" lang="vbnet" title="The following example shows how to use the X property."/>
    	/// </example> 
    	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "X")]
    	public double X { get; set; }


    	/// <summary>
    	/// Gets or sets the y dimension
    	/// </summary>
    	/// <example>
    	/// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.cs" region="NamedDimensions" lang="cs" title="The following example shows how to use the Y property."/>
    	/// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.vb" region="NamedDimensions" lang="vbnet" title="The following example shows how to use the Y property."/>
    	/// </example> 
    	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Y")]
    	public double Y { get; set; }

    	#endregion

        #region Methods

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.cs" region="AbsoluteMaximum" lang="cs" title="The following example shows how to use the AbsoluteMaximum method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.vb" region="AbsoluteMaximum" lang="vbnet" title="The following example shows how to use the AbsoluteMaximum method."/>
        /// </example> 
        public override double AbsoluteMaximum()
        {
            var absX = Math.Abs(X);
            var absY = Math.Abs(Y);
            return Math.Max(absX, absY);
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.cs" region="AbsoluteMaximumIndex" lang="cs" title="The following example shows how to use the AbsoluteMaximumIndex method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.vb" region="AbsoluteMaximumIndex" lang="vbnet" title="The following example shows how to use the AbsoluteMaximumIndex method."/>
        /// </example> 
        public override int AbsoluteMaximumIndex()
        {
            var absX = Math.Abs(X);
            var absY = Math.Abs(Y);

		    return absX > absY ? 0 : 1;
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.cs" region="AbsoluteMinimum" lang="cs" title="The following example shows how to use the AbsoluteMinimum method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.vb" region="AbsoluteMinimum" lang="vbnet" title="The following example shows how to use the AbsoluteMinimum method."/>
        /// </example> 
        public override double AbsoluteMinimum()
        {

            var absX = Math.Abs(X);
            var absY = Math.Abs(Y);
            return Math.Min(absX, absY);
        }


		/// <inheritdoc />
        public override int AbsoluteMinimumIndex()
        {
            var absX = Math.Abs(X);
            var absY = Math.Abs(Y);

		    return absX < absY ? 0 : 1;
        }




		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.cs" region="AddDouble" lang="cs" title="The following example shows how to use the Add method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.vb" region="AddDouble" lang="vbnet" title="The following example shows how to use the Add method."/>
        /// </example>
        public override void Add(double number)
        {
            AddInternal(this, number);
        }


        /// <summary>
        /// Adds a <see cref="Vector2D"/> to the current <see cref="Vector2D"/>.
        /// </summary>
        /// <param name="vector">The <see cref="Vector2D"/> to add to this <see cref="Vector2D"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="vector"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.cs" region="AddVector" lang="cs" title="The following example shows how to use the Add method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.vb" region="AddVector" lang="vbnet" title="The following example shows how to use the Add method."/>
        /// </example>
        public void Add(Vector2D vector)
        {
            Guard.ArgumentNotNull(vector, "vector");
            AddInternal(this, vector);
        }


        private static void AddInternal(Vector2D left, double right)
        {
            left.X += right;
            left.Y += right;
        }


        private static void AddInternal(Vector2D left, Vector2D right)
        {
            left.X += right.X;
            left.Y += right.Y;
        }


		/// <inheritdoc />
        protected override void AddSafe(IVector<double> vector)
        {
            X += vector[0];
            Y += vector[1];
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.cs" region="Clear" lang="cs" title="The following example shows how to use the Clear method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.vb" region="Clear" lang="vbnet" title="The following example shows how to use the Clear method."/>
        /// </example>
        public override void Clear()
        {

            X = 0;
            Y = 0;
        }


        ///<summary>
        ///Creates a new object that is a copy of the current instance.
        ///</summary>
        ///<returns>
        ///A new object that is a copy of this instance.
        ///</returns>
        internal Vector2D CloneInternal()
        {
            return new Vector2D {X = X, Y = Y};
        }


        /// <summary>
        /// Get the cross product of this <see cref="Vector2D"/> and <paramref name="vector"/>.
        /// </summary>
        /// <param name="vector">The <see cref="Vector3D"/> to calculate the cross product with.</param>
        /// <returns>The cross product of this <see cref="Vector2D"/> and <paramref name="vector"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="vector"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.cs" region="CrossProduct3D" lang="cs" title="The following example shows how to use the CrossProduct method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.vb" region="CrossProduct3D" lang="vbnet" title="The following example shows how to use the CrossProduct method."/>
        /// </example>
        public Vector3D CrossProduct(Vector3D vector)
        {
            Guard.ArgumentNotNull(vector, "vector");
            return new Vector3D(Y * vector.Z,
                                -X * vector.Z,
                                X * vector.Y - Y * vector.X);
        }


        /// <summary>
        /// Get the cross product of this <see cref="Vector2D"/> and <paramref name="vector"/>.
        /// </summary>
        /// <param name="vector">The <see cref="Vector2D"/> to calculate the cross product with.</param>
        /// <returns>The cross product of this <see cref="Vector2D"/> and <paramref name="vector"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="vector"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.cs" region="CrossProduct2D" lang="cs" title="The following example shows how to use the CrossProduct method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.vb" region="CrossProduct2D" lang="vbnet" title="The following example shows how to use the CrossProduct method."/>
        /// </example>
        public Vector3D CrossProduct(Vector2D vector)
        {
            Guard.ArgumentNotNull(vector, "vector");
            return new Vector3D(0, 0, X * vector.Y - Y * vector.Y);
        }


		/// <inheritdoc />
        protected override IVector<double> CrossProductSafe(IVector<double> vector)
		{
		    if (vector.DimensionCount == 2)
		    {
		        return new Vector3D(0, 0, X * vector[1] - Y * vector[1]);
		    }
		    
            return new Vector3D(Y * vector[2], -X * vector[2], X * vector[1] - Y * vector[0]);
		}


        /// <inheritdoc />
        protected override IVector<double> DeepClone()
        {
            return CloneInternal();
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.cs" region="Decrement" lang="cs" title="The following example shows how to use the Decrement method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.vb" region="Decrement" lang="vbnet" title="The following example shows how to use the Decrement method."/>
        /// </example>
        public override void Decrement()
        {
            AddInternal(this, -1);
        }

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.cs" region="DivideDouble" lang="cs" title="The following example shows how to use the Divide method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.vb" region="DivideDouble" lang="vbnet" title="The following example shows how to use the Divide method."/>
        /// </example>
        public override void Divide(double number)
        {
            MultiplyInternal(this, 1 / number);
        }


        /// <summary>
        /// Divide each dimension by a number.
        /// </summary>
        /// <param name="vector">The <see cref="Vector2D"/> to divide by.</param>
        /// <exception cref="ArgumentNullException"><paramref name="vector"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.cs" region="DivideVector" lang="cs" title="The following example shows how to use the Divide method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.vb" region="DivideVector" lang="vbnet" title="The following example shows how to use the Divide method."/>
        /// </example>
        public void Divide(Vector2D vector)
        {
            Guard.ArgumentNotNull(vector, "vector");
            DivideInternal(this, vector);
        }


        private static void DivideInternal(Vector2D left, Vector2D right)
        {

            left.X /= right.X;
            left.X /= right.Y;

            left.Y /= right.X;
            left.Y /= right.Y;
        }


		/// <inheritdoc />
        protected override void DivideSafe(IVector<double> vector)
        {
            X /= vector[0];
            X /= vector[1];

            Y /= vector[0];
            Y /= vector[1];
        }


        /// <summary>
        /// Calculate the dot product.
        /// </summary>
        /// <param name="vector">The <see cref="IVector{T}"/> to calculate the dot product with.</param>
        /// <returns>The dot product of the current instance and <paramref name="vector"/>.</returns>
        ///<exception cref="ArgumentNullException"><paramref name="vector"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.cs" region="DotProduct" lang="cs" title="The following example shows how to use the DotProduct method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.vb" region="DotProduct" lang="vbnet" title="The following example shows how to use the DotProduct method."/>
        /// </example>
        public double DotProduct(Vector2D vector)
        {
            Guard.ArgumentNotNull(vector, "vector");
            return (X * vector.X) + (Y * vector.Y);
        }


		/// <inheritdoc />
        protected override double DotProductSafe(IVector<double> vector)
        {
            return (X * vector[0]) + (Y * vector[1]);
        }


        private static Vector2D FromMatrixInternal(IMatrix<double> matrix)
        {
            if (matrix.Columns != 1)
            {
                throw new InvalidCastException("matrix must have only 1 column");
            }

            if (matrix.Rows > 2)
            {
                throw new InvalidCastException("matrix must at most 2 rows");
            }

            return matrix.Rows == 1 ? new Vector2D(matrix[0, 0], 0) : new Vector2D(matrix[0, 0], matrix[1, 0]);
        }


        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public override IEnumerator<double> GetEnumerator()
        {
            yield return X;
            yield return Y;
        }


        /// <summary>
        /// Creates a unit <see cref="Vector2D"/>.
        /// </summary>
        /// <returns>A unit <see cref="Vector2D"/>.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.cs" region="GetUnitVector" lang="cs" title="The following example shows how to use the UnitVector property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.vb" region="GetUnitVector" lang="vbnet" title="The following example shows how to use the UnitVector property."/>
        /// </example>
        public static Vector2D UnitVector
        {
            get
            {
                return new Vector2D(1, 1);
            }
        }
        /// <summary>
        /// Creates zeroed <see cref="Vector2D"/>.
        /// </summary>
        /// <returns>A zeroed <see cref="Vector2D"/>.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.cs" region="GetZeroVector" lang="cs" title="The following example shows how to use the ZeroVector property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.vb" region="GetZeroVector" lang="vbnet" title="The following example shows how to use the ZeroVector property."/>
        /// </example>
        public static Vector2D ZeroVector
        {
            get { return new Vector2D(); }
        }



		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.cs" region="Increment" lang="cs" title="The following example shows how to use the Increment method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.vb" region="Increment" lang="vbnet" title="The following example shows how to use the Increment method."/>
        /// </example>
        public override void Increment()
        {
            AddInternal(this, 1);
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.cs" region="Magnitude" lang="cs" title="The following example shows how to use the Magnitude method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.vb" region="Magnitude" lang="vbnet" title="The following example shows how to use the Magnitude method."/>
        /// </example>
        public override double Magnitude()
        {
            var squareSum = (X * X) + (Y * Y);
            return Math.Sqrt(squareSum);
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.cs" region="Maximum" lang="cs" title="The following example shows how to use the Maximum method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.vb" region="Maximum" lang="vbnet" title="The following example shows how to use the Maximum method."/>
        /// </example>
        public override double Maximum()
        {
            return Math.Max(X, Y);
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.cs" region="MinimumIndex" lang="cs" title="The following example shows how to use the MinimumIndex method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.vb" region="MinimumIndex" lang="vbnet" title="The following example shows how to use the MinimumIndex method."/>
        /// </example>
        public override int MaximumIndex()
		{
		    return X > Y ? 0 : 1;
		}


        /// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.cs" region="Minimum" lang="cs" title="The following example shows how to use the Minimum method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.vb" region="Minimum" lang="vbnet" title="The following example shows how to use the Minimum method."/>
        /// </example>
        public override double Minimum()
        {
            return Math.Min(X, Y);
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.cs" region="MinimumIndex" lang="cs" title="The following example shows how to use the MinimumIndex method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.vb" region="MinimumIndex" lang="vbnet" title="The following example shows how to use the MinimumIndex method."/>
        /// </example>
        public override int MinimumIndex()
		{
		    return X < Y ? 0 : 1;
		}


        /// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.cs" region="MultiplyDouble" lang="cs" title="The following example shows how to use the Multiply method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.vb" region="MultiplyDouble" lang="vbnet" title="The following example shows how to use the Multiply method."/>
        /// </example>
        public override void Multiply(double number)
        {
            MultiplyInternal(this, number);
        }


        /// <summary>
        /// Multiply the current <see cref="Vector2D"/> with another <see cref="Vector2D"/>.
        /// </summary>
        /// <param name="vector">The <see cref="Vector2D"/> to multiply by.</param>
        /// <returns>The result of the multiply operation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="vector"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.cs" region="MultiplyVector" lang="cs" title="The following example shows how to use the Multiple method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.vb" region="MultiplyVector" lang="vbnet" title="The following example shows how to use the Multiple method."/>
        /// </example>
        public Matrix Multiply(Vector2D vector)
        {
            Guard.ArgumentNotNull(vector, "vector");
            return MultiplyInternal(this, vector);
        }


        private static void MultiplyInternal(Vector2D left, double right)
        {
            left.X *= right;
            left.Y *= right;
        }


        private static Matrix MultiplyInternal(Vector2D left, Vector2D right)
        {
            var matrix = new Matrix(2, 2);
           matrix.SetValue(0, 0, left.X * right.X);
            matrix.SetValue(0, 1, left.X * right.Y);
            matrix.SetValue(1, 0, left.Y * right.X);
            matrix.SetValue(1, 1, left.Y * right.Y);
            return matrix;
        }


		/// <inheritdoc />
        protected override IMatrix<double> MultiplySafe(IVector<double> vector)
        {
            var matrix = new Matrix(2, 2);
            matrix.SetValue(0, 0, X * vector[0]);
            matrix.SetValue(0, 1, X * vector[1]);

            matrix.SetValue(1, 0, Y * vector[0]);
            matrix.SetValue(1, 1, Y * vector[1]);
            return matrix;
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.cs" region="Negate" lang="cs" title="The following example shows how to use the Negate method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.vb" region="Negate" lang="vbnet" title="The following example shows how to use the Negate method."/>
        /// </example>
        public override void Negate()
        {
            X *= -1;
            Y *= -1;
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.cs" region="Normalize" lang="cs" title="The following example shows how to use the Normalize method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.vb" region="Normalize" lang="vbnet" title="The following example shows how to use the Normalize method."/>
        /// </example>
        public override void Normalize()
        {
            var magnitude = Magnitude();
            X /= magnitude;
            Y /= magnitude;
        }


		/// <inheritdoc />
        protected override void SetValuesSafe(double[] values)
        {
            X = values[0];
            Y = values[1];
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.cs" region="Product" lang="cs" title="The following example shows how to use the Product method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.vb" region="Product" lang="vbnet" title="The following example shows how to use the Product method."/>
        /// </example>
        public override double Product()
        {
            return X * Y;
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.cs" region="SubtractDouble" lang="cs" title="The following example shows how to use the Subtract method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.vb" region="SubtractDouble" lang="vbnet" title="The following example shows how to use the Subtract method."/>
        /// </example>
        public override void Subtract(double number)
        {
            AddInternal(this, -number);
        }

		/// <summary>
		/// Subtracts a <see cref="Vector2D"/> from the current instance.
		/// </summary>
		/// <param name="vector">The <see cref="Vector2D"/> to subtract from this <see cref="IVector{T}"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="vector"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.cs" region="SubtractVector" lang="cs" title="The following example shows how to use the Subtract method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.vb" region="SubtractVector" lang="vbnet" title="The following example shows how to use the Subtract method."/>
        /// </example>
        public void Subtract(Vector2D vector)
        {
            Guard.ArgumentNotNull(vector, "vector");
            SubtractInternal(this, vector);
        }


		/// <inheritdoc />
        protected override void SubtractSafe(IVector<double> vector)
        {
            X -= vector[0];
            Y -= vector[1];
        }


        private static void SubtractInternal(Vector2D left, Vector2D right)
        {
            left.X -= right.X;
            left.Y -= right.Y;
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.cs" region="Sum" lang="cs" title="The following example shows how to use the Sum method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.vb" region="Sum" lang="vbnet" title="The following example shows how to use the Sum method."/>
        /// </example>
        public override double Sum()
        {
            return X + Y;
        }

		/// <inheritdoc />
        protected override void SwapSafe(IVector<double> other)
        {
            var tempX = X;
            X = other[0];
            other[0] = tempX;

            var tempY = Y;
            Y = other[1];
            other[1] = tempY;

        }


        /// <summary>
        /// Swap all the values with another <see cref="Vector2D"/>.
        /// </summary>
        /// <param name="other">The <see cref="Vector2D"/> to swap values with.</param>
        /// <exception cref="ArgumentNullException"><paramref name="other"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.cs" region="Swap" lang="cs" title="The following example shows how to use the Swap method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.vb" region="Swap" lang="vbnet" title="The following example shows how to use the Swap method."/>
        /// </example>
        public void Swap(Vector2D other)
        {
            Guard.ArgumentNotNull(other, "other");
            var tempX = X;
            X = other.X;
            other.X = tempX;

            var tempY = Y;
            Y = other.Y;
            other.Y = tempY;

        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.cs" region="ToArray" lang="cs" title="The following example shows how to use the ToArray method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.vb" region="ToArray" lang="vbnet" title="The following example shows how to use the ToArray method."/>
        /// </example>
        public override double[] ToArray()
        {
            return new[] { X, Y };
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.cs" region="ToMatrix" lang="cs" title="The following example shows how to use the ToMatrix method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.vb" region="ToMatrix" lang="vbnet" title="The following example shows how to use the ToMatrix method."/>
        /// </example>
        public override IMatrix<double> ToMatrix()
        {
            return ToMatrixInternal(this);
        }


        private static Matrix ToMatrixInternal(Vector2D vector)
        {
            return new Matrix(2, 1, new[] { vector.X, vector.Y});
        }

     
        #endregion
    }
}