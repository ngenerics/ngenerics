/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
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
    public partial class Vector3D
    {
        #region Globals

    	#endregion

        #region Constructors

        /// <inheritdoc/>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="Constructor" lang="cs" title="The following example shows how to use the default constructor."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="Constructor" lang="vbnet" title="The following example shows how to use the default constructor."/>
        /// </example> 
        public Vector3D()
            : base(3)
        {
        }

        /// <inheritdoc/>
        /// <param name="x">The X dimension.</param>
        /// <param name="y">The Y dimension.</param>
        /// <param name="z">The Z dimension.</param>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="ConstructorInitValues" lang="cs" title="The following example shows how to use the initialize values constructor."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="ConstructorInitValues" lang="vbnet" title="The following example shows how to use the initialize values constructor."/>
        /// </example> 
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "z")]
        public Vector3D(double x, double y, double z)
            : base(3)
        {
            X = x;
            Y = y;
            Z = z;
        }

        #endregion

        #region Properties

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="Index" lang="cs" title="The following example shows how to use the index property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="Index" lang="vbnet" title="The following example shows how to use the index property."/>
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
                    case 2:
                        return Z;
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
                    case 2:
                        Z = value;
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
    	/// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="NamedDimensions" lang="cs" title="The following example shows how to use the X property."/>
    	/// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="NamedDimensions" lang="vbnet" title="The following example shows how to use the X property."/>
    	/// </example> 
    	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "X")]
    	public double X { get; set; }

    	/// <summary>
    	/// Gets or sets the y dimension
    	/// </summary>
    	/// <example>
    	/// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="NamedDimensions" lang="cs" title="The following example shows how to use the Y property."/>
    	/// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="NamedDimensions" lang="vbnet" title="The following example shows how to use the Y property."/>
    	/// </example> 
    	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Y")]
    	public double Y { get; set; }


    	/// <summary>
    	/// Gets or sets the z dimension
    	/// </summary>
    	/// <example>
    	/// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="NamedDimensions" lang="cs" title="The following example shows how to use the Z property."/>
    	/// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="NamedDimensions" lang="vbnet" title="The following example shows how to use the Z property."/>
    	/// </example> 
    	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Z")]
    	public double Z { get; set; }

    	#endregion

        #region Methods

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="AbsoluteMaximum" lang="cs" title="The following example shows how to use the AbsoluteMaximum method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="AbsoluteMaximum" lang="vbnet" title="The following example shows how to use the AbsoluteMaximum method."/>
        /// </example> 
        public override double AbsoluteMaximum()
        {
            var absX = Math.Abs(X);
            var absY = Math.Abs(Y);
            var absZ = Math.Abs(Z);
            return Math.Max(absX, Math.Max(absY, absZ));
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="AbsoluteMaximumIndex" lang="cs" title="The following example shows how to use the AbsoluteMaximumIndex method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="AbsoluteMaximumIndex" lang="vbnet" title="The following example shows how to use the AbsoluteMaximumIndex method."/>
        /// </example> 
        public override int AbsoluteMaximumIndex()
        {
            var absX = Math.Abs(X);
            var absY = Math.Abs(Y);
            var absZ = Math.Abs(Z);

            if (absX > absY)
            {
            	if (absX > absZ)
                {
                    return 0;
                }
            	return 2;
            }

			if (absY > absZ)
		    {
		        return 1;
		    }
			return 2;
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="AbsoluteMinimum" lang="cs" title="The following example shows how to use the AbsoluteMinimum method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="AbsoluteMinimum" lang="vbnet" title="The following example shows how to use the AbsoluteMinimum method."/>
        /// </example> 
        public override double AbsoluteMinimum()
        {

            var absX = Math.Abs(X);
            var absY = Math.Abs(Y);
            var absZ = Math.Abs(Z);
            return Math.Min(absX, Math.Min(absY, absZ));
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="AbsoluteMinimumIndex" lang="cs" title="The following example shows how to use the AbsoluteMinimumIndex method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="AbsoluteMinimumIndex" lang="vbnet" title="The following example shows how to use the AbsoluteMinimumIndex method."/>
        /// </example> 
        public override int AbsoluteMinimumIndex()
        {
            var absX = Math.Abs(X);
            var absY = Math.Abs(Y);
            var absZ = Math.Abs(Z);
            if (absX < absY)
            {
            	if (absX < absZ)
                {
                    return 0;
                }
            	return 2;
            }

			if (absY < absZ)
		    {
		        return 1;
		    }
			return 2;
        }




		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="AddDouble" lang="cs" title="The following example shows how to use the Add method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="AddDouble" lang="vbnet" title="The following example shows how to use the Add method."/>
        /// </example>
        public override void Add(double number)
        {
            AddInternal(this, number);
        }


        /// <summary>
        /// Adds a <see cref="Vector3D"/> to the current <see cref="Vector3D"/>.
        /// </summary>
        /// <param name="vector">The <see cref="Vector3D"/> to add to this <see cref="Vector3D"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="vector"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="AddVector" lang="cs" title="The following example shows how to use the Add method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="AddVector" lang="vbnet" title="The following example shows how to use the Add method."/>
        /// </example>
        public void Add(Vector3D vector)
        {
            Guard.ArgumentNotNull(vector, "vector");
            AddInternal(this, vector);
        }


        private static void AddInternal(Vector3D left, double right)
        {
            left.X += right;
            left.Y += right;
            left.Z += right;
        }


        private static void AddInternal(Vector3D left, Vector3D right)
        {
            left.X += right.X;
            left.Y += right.Y;
            left.Z += right.Z;
        }


		/// <inheritdoc />
        protected override void AddSafe(IVector<double> vector)
        {
            X += vector[0];
            Y += vector[1];
            Z += vector[2];
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="Clear" lang="cs" title="The following example shows how to use the Clear method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="Clear" lang="vbnet" title="The following example shows how to use the Clear method."/>
        /// </example>
        public override void Clear()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }


        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        internal Vector3D CloneInternal()
        {
            return new Vector3D {X = X, Y = Y, Z = Z};
        }


        /// <summary>
        /// Get the cross product of this <see cref="Vector3D"/> and <paramref name="vector"/>.
        /// </summary>
        /// <param name="vector">The <see cref="Vector3D"/> to calculate the cross product with.</param>
        /// <returns>The cross product of this <see cref="Vector3D"/> and <paramref name="vector"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="vector"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="CrossProduct3D" lang="cs" title="The following example shows how to use the CrossProduct method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="CrossProduct3D" lang="vbnet" title="The following example shows how to use the CrossProduct method."/>
        /// </example>
        public Vector3D CrossProduct(Vector2D vector)
        {
            Guard.ArgumentNotNull(vector, "vector");
            return new Vector3D(-Z * vector.Y,
                                Z * vector.X,
                                X * vector.Y - Y * vector.X);
        }


        /// <summary>
        /// Get the cross product of this <see cref="Vector3D"/> and <paramref name="vector"/>.
        /// </summary>
        /// <param name="vector">The <see cref="Vector3D"/> to calculate the cross product with.</param>
        /// <returns>The cross product of this <see cref="Vector3D"/> and <paramref name="vector"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="vector"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="CrossProduct3D" lang="cs" title="The following example shows how to use the CrossProduct method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="CrossProduct3D" lang="vbnet" title="The following example shows how to use the CrossProduct method."/>
        /// </example>
        public Vector3D CrossProduct(Vector3D vector)
        {
            Guard.ArgumentNotNull(vector, "vector");
            return new Vector3D(Y * vector.Z - Z * vector.Y,
                                Z * vector.X - X * vector.Z,
                                X * vector.Y - Y * vector.X);
        }


		/// <inheritdoc />
        protected override IVector<double> CrossProductSafe(IVector<double> vector)
		{
			if (vector.DimensionCount == 2)
		    {
		        return new Vector3D(-Z * vector[1],
		                            Z * vector[0],
		                            X * vector[1] - Y * vector[0]);
		    }
			return new Vector3D(Y * vector[2] - Z * vector[1],
			                    Z * vector[0] - X * vector[2],
			                    X * vector[1] - Y * vector[0]);
		}


    	/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="Decrement" lang="cs" title="The following example shows how to use the Decrement method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="Decrement" lang="vbnet" title="The following example shows how to use the Decrement method."/>
        /// </example>
        public override void Decrement()
        {
            AddInternal(this, -1);
        }


		/// <inheritdoc />
        protected override IVector<double> DeepClone()
        {
            return CloneInternal();
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="DivideDouble" lang="cs" title="The following example shows how to use the Divide method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="DivideDouble" lang="vbnet" title="The following example shows how to use the Divide method."/>
        /// </example>
        public override void Divide(double number)
        {
            MultiplyInternal(this, 1 / number);
        }


        /// <summary>
        /// Divide each dimension by a number.
        /// </summary>
        /// <param name="vector">The <see cref="Vector3D"/> to divide by.</param>
        /// <exception cref="ArgumentNullException"><paramref name="vector"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="DivideVector" lang="cs" title="The following example shows how to use the Divide method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="DivideVector" lang="vbnet" title="The following example shows how to use the Divide method."/>
        /// </example>
        public void Divide(Vector3D vector)
        {
            Guard.ArgumentNotNull(vector, "vector");
            DivideInternal(this, vector);
        }


        private static void DivideInternal(Vector3D left, Vector3D right)
        {

            left.X /= right.X;
            left.X /= right.Y;
            left.X /= right.Z;

            left.Y /= right.X;
            left.Y /= right.Y;
            left.Y /= right.Z;

            left.Z /= right.X;
            left.Z /= right.Y;
            left.Z /= right.Z;
        }


		/// <inheritdoc />
        protected override void DivideSafe(IVector<double> vector)
        {
            X /= vector[0];
            X /= vector[1];
            X /= vector[2];

            Y /= vector[0];
            Y /= vector[1];
            Y /= vector[2];

            Z /= vector[0];
            Z /= vector[1];
            Z /= vector[2];
        }


        /// <summary>
        /// Calculate the dot product.
        /// </summary>
        /// <param name="vector">The <see cref="Vector3D"/> to calculate the dot product with.</param>
        /// <returns>The dot product of the current instance and <paramref name="vector"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="vector"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="DotProduct" lang="cs" title="The following example shows how to use the DotProduct method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="DotProduct" lang="vbnet" title="The following example shows how to use the DotProduct method."/>
        /// </example>
        public double DotProduct(Vector3D vector)
        {
            Guard.ArgumentNotNull(vector, "vector");
            return (X * vector.X) + (Y * vector.Y) + (Z * vector.Z);
        }


		/// <inheritdoc />
        protected override double DotProductSafe(IVector<double> vector)
        {
            return (X * vector[0]) + (Y * vector[1]) + (Z * vector[2]);
        }


        private static Vector3D FromMatrixInternal(IMatrix<double> matrix)
        {
            if (matrix.Columns != 1)
            {
                throw new InvalidCastException("matrix must have only 1 column");
            }

            if (matrix.Rows > 3)
            {
                throw new InvalidCastException("matrix must at most 3 rows");
            }
            
            switch (matrix.Rows)
            {
                case 1:
                    return new Vector3D(matrix[0, 0], 0, 0);
                case 2:
                    return new Vector3D(matrix[0, 0], matrix[1, 0], 0);
                default:
                    return new Vector3D(matrix[0, 0], matrix[1, 0], matrix[2, 0]);
            }
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
            yield return Z;
        }

        /// <summary>
        /// Creates zeroed <see cref="Vector3D"/>.
        /// </summary>
        /// <returns>A zeroed <see cref="Vector3D"/>.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="GetZeroVector" lang="cs" title="The following example shows how to use the ZeroVector property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="GetZeroVector" lang="vbnet" title="The following example shows how to use the ZeroVector property."/>
        /// </example>
        public static Vector3D ZeroVector
        {
            get { return new Vector3D(); }
        }


        /// <summary>
        /// Creates unit <see cref="Vector3D"/>.
        /// </summary>
        /// <returns>A unit <see cref="Vector3D"/>.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="GetUnitVector" lang="cs" title="The following example shows how to use the ZeroVector property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="GetUnitVector" lang="vbnet" title="The following example shows how to use the ZeroVector property."/>
        /// </example>
        public static Vector3D UnitVector
        {
            get { return new Vector3D(1, 1, 1); }
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="Increment" lang="cs" title="The following example shows how to use the Increment method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="Increment" lang="vbnet" title="The following example shows how to use the Increment method."/>
        /// </example>
        public override void Increment()
        {
            AddInternal(this, 1);
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="Magnitude" lang="cs" title="The following example shows how to use the Increment method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="Magnitude" lang="vbnet" title="The following example shows how to use the Increment method."/>
        /// </example>
        public override double Magnitude()
        {
            var squareSum = (X * X) + (Y * Y) + (Z * Z);
            return Math.Sqrt(squareSum);
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="Maximum" lang="cs" title="The following example shows how to use the Maximum method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="Maximum" lang="vbnet" title="The following example shows how to use the Maximum method."/>
        /// </example>
        public override double Maximum()
        {
            return Math.Max(X, Math.Max(Y, Z));
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="MinimumIndex" lang="cs" title="The following example shows how to use the MinimumIndex method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="MinimumIndex" lang="vbnet" title="The following example shows how to use the MinimumIndex method."/>
        /// </example>
        public override int MaximumIndex()
		{
		    if (X > Y)
            {
                return X > Z ? 0 : 2;
            }
		    
            return Y > Z ? 1 : 2;
		}

        /// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="Minimum" lang="cs" title="The following example shows how to use the Minimum method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="Minimum" lang="vbnet" title="The following example shows how to use the Minimum method."/>
        /// </example>
        public override double Minimum()
        {
            return Math.Min(X, Math.Min(Y, Z));
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="MinimumIndex" lang="cs" title="The following example shows how to use the MinimumIndex method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="MinimumIndex" lang="vbnet" title="The following example shows how to use the MinimumIndex method."/>
        /// </example>
        public override int MinimumIndex()
		{
		    if (X < Y)
            {
                return X < Z ? 0 : 2;
            }

		    return Y < Z ? 1 : 2;
		}


        /// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="MultiplyDouble" lang="cs" title="The following example shows how to use the Multiply method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="MultiplyDouble" lang="vbnet" title="The following example shows how to use the Multiply method."/>
        /// </example>
        public override void Multiply(double number)
        {
            MultiplyInternal(this, number);
        }


        /// <summary>
        /// Multiply the current <see cref="Vector3D"/> with another <see cref="Vector3D"/>
        /// </summary>
        /// <param name="vector">The <see cref="Vector3D"/> to multiply by.</param>
        /// <returns>The result of the multiplication.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="vector"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// 	<code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="MultiplyVector" lang="cs" title="The following example shows how to use the Multiply method."/>
        /// 	<code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="MultiplyVector" lang="vbnet" title="The following example shows how to use the Multiply method."/>
        /// </example>
        public Matrix Multiply(Vector3D vector)
        {
            Guard.ArgumentNotNull(vector, "vector");
            return MultiplyInternal(this, vector);
        }


        private static void MultiplyInternal(Vector3D left, double right)
        {
            left.X *= right;
            left.Y *= right;
            left.Z *= right;
        }


        private static Matrix MultiplyInternal(Vector3D left, Vector3D right)
        {

            var matrix = new Matrix(3, 3);
            matrix.SetValue(0, 0, left.X * right.X);
           matrix.SetValue(0, 1, left.X * right.Y);
             matrix.SetValue(0, 2, left.X * right.Z);

             matrix.SetValue(1, 0, left.Y * right.X);
             matrix.SetValue(1, 1, left.Y * right.Y);
             matrix.SetValue(1, 2, left.Y * right.Z);

            matrix.SetValue(2, 0, left.Z * right.X);
             matrix.SetValue(2, 1, left.Z * right.Y);
             matrix.SetValue(2, 2, left.Z * right.Z);

            return matrix;
        }


		/// <inheritdoc />
        protected override IMatrix<double> MultiplySafe(IVector<double> vector)
        {

            var matrix = new Matrix(3, 3);
            matrix.SetValue(0, 0, X * vector[0]);
            matrix.SetValue(0, 1, X * vector[1]);
            matrix.SetValue(0, 2, X * vector[2]);

            matrix.SetValue(1, 0, Y * vector[0]);
            matrix.SetValue(1, 1, Y * vector[1]);
            matrix.SetValue(1, 2, Y * vector[2]);

            matrix.SetValue(2, 0, Z * vector[0]);
            matrix.SetValue(2, 1, Z * vector[1]);
            matrix.SetValue(2, 2, Z * vector[2]);
            return matrix;
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="Negate" lang="cs" title="The following example shows how to use the Negate method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="Negate" lang="vbnet" title="The following example shows how to use the Negate method."/>
        /// </example>
        public override void Negate()
        {
            X *= -1;
            Y *= -1;
            Z *= -1;
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="Normalize" lang="cs" title="The following example shows how to use the Normalize method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="Normalize" lang="vbnet" title="The following example shows how to use the Normalize method."/>
        /// </example>
        public override void Normalize()
        {
            var magnitude = Magnitude();
            X /= magnitude;
            Y /= magnitude;
            Z /= magnitude;
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="Product" lang="cs" title="The following example shows how to use the Product method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="Product" lang="vbnet" title="The following example shows how to use the Product method."/>
        /// </example>
        public override double Product()
        {
            return X * Y * Z;
        }


		/// <inheritdoc />
        protected override void SubtractSafe(IVector<double> vector)
        {
            X -= vector[0];
            Y -= vector[1];
            Z -= vector[2];
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="Sum" lang="cs" title="The following example shows how to use the Sum method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="Sum" lang="vbnet" title="The following example shows how to use the Sum method."/>
        /// </example>
        public override double Sum()
        {
            return X + Y + Z;
        }


		/// <inheritdoc />
        protected override void SetValuesSafe(double[] values)
        {
            X = values[0];
            Y = values[1];
            Z = values[2];
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="SubtractDouble" lang="cs" title="The following example shows how to use the Subtract method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="SubtractDouble" lang="vbnet" title="The following example shows how to use the Subtract method."/>
        /// </example>
        public override void Subtract(double number)
        {
            AddInternal(this, -number);
        }


        /// <summary>
        /// Subtracts a <see cref="Vector3D"/> from the current instance.
        /// </summary>
        /// <param name="vector">The <see cref="Vector3D"/> to subtract from this <see cref="Vector3D"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="vector"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="SubtractVector" lang="cs" title="The following example shows how to use the Subtract method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="SubtractVector" lang="vbnet" title="The following example shows how to use the Subtract method."/>
        /// </example>
        public void Subtract(Vector3D vector)
        {
            Guard.ArgumentNotNull(vector, "vector");
            SubtractInternal(this, vector);
        }


        private static void SubtractInternal(Vector3D left, Vector3D right)
        {
            left.X -= right.X;
            left.Y -= right.Y;
            left.Z -= right.Z;
        }


        /// <summary>
        /// Swap all the values with another <see cref="Vector3D"/>.
        /// </summary>
        /// <param name="other">The <see cref="Vector3D"/> to swap values with.</param>
        /// <exception cref="ArgumentNullException"><paramref name="other"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="Swap" lang="cs" title="The following example shows how to use the Swap method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="Swap" lang="vbnet" title="The following example shows how to use the Swap method."/>
        /// </example>
        public void Swap(Vector3D other)
        {
            Guard.ArgumentNotNull(other, "other");
            var tempX = X;
            X = other.X;
            other.X = tempX;

            var tempY = Y;
            Y = other.Y;
            other.Y = tempY;

            var tempZ = Z;
            Z = other.Z;
            other.Z = tempZ;
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

            var tempZ = Z;
            Z = other[2];
            other[2] = tempZ;
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="ToArray" lang="cs" title="The following example shows how to use the ToArray method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="ToArray" lang="vbnet" title="The following example shows how to use the ToArray method."/>
        /// </example>
        public override double[] ToArray()
        {
            return new[] { X, Y, Z };
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector3DExamples.cs" region="ToMatrix" lang="cs" title="The following example shows how to use the ToMatrix method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector3DExamples.vb" region="ToMatrix" lang="vbnet" title="The following example shows how to use the ToMatrix method."/>
        /// </example>
        public override IMatrix<double> ToMatrix()
        {
            return ToMatrixInternal(this);
        }


        private static Matrix ToMatrixInternal(Vector3D vector)
        {
            return new Matrix(3, 1, new[] { vector.X, vector.Y, vector.Z });
        }


        #endregion
    }
}