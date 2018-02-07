/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/


using System;
using NGenerics.DataStructures.General;
using NGenerics.Util;

namespace NGenerics.DataStructures.Mathematical
{
    /// <summary>
    /// A Vector data structure.
    /// </summary>
    public partial class VectorN : VectorBase<double>
    {
        #region Globals

        private double[] _dimensions;

        #endregion

        #region Constructors

        /// <inheritdoc/>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorNExamples.cs" region="Constructor" lang="cs" title="The following example shows how to use the default constructor."/>
        /// </example> 
        public VectorN(int dimensionCount)
            : base(dimensionCount)
        {
            if (dimensionCount < 1)
            {
                throw new ArgumentOutOfRangeException("dimensionCount");
            }
            _dimensions = new double[dimensionCount];
        }

        #endregion

        #region Properties


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorNExamples.cs" region="Index" lang="cs" title="The following example shows how to use the index property."/>
        /// </example> 
        public override double this[int index]
        {
            get => _dimensions[index];
		    set => _dimensions[index] = value;
		}

        #endregion

        #region Methods


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorNExamples.cs" region="AbsoluteMaximum" lang="cs" title="The following example shows how to use the AbsoluteMaximum method."/>
        /// </example> 
        public override double AbsoluteMaximum()
        {
            var absoluteMaximumIndex = AbsoluteMaximumIndex();
            return Math.Abs(this[absoluteMaximumIndex]);
        }



		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorNExamples.cs" region="AbsoluteMaximumIndex" lang="cs" title="The following example shows how to use the AbsoluteMaximumIndex method."/>
        /// </example> 
        public override int AbsoluteMaximumIndex()
        {
            var index = 0;
            var max = Math.Abs(this[0]);
            for (var i = 1; i < DimensionCount; i++)
            {
                var test = Math.Abs(this[i]);
                if (test > max)
                {
                    index = i;
                    max = test;
                }
            }
            return index;
        }



		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorNExamples.cs" region="AbsoluteMinimum" lang="cs" title="The following example shows how to use the AbsoluteMinimum method."/>
        /// </example> 
        public override double AbsoluteMinimum()
        {
            var absoluteMinimumIndex = AbsoluteMinimumIndex();
            return Math.Abs(this[absoluteMinimumIndex]);
        }



		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorNExamples.cs" region="AbsoluteMinimumIndex" lang="cs" title="The following example shows how to use the AbsoluteMinimumIndex method."/>
        /// </example> 
        public override int AbsoluteMinimumIndex()
        {
            var index = 0;
            var min = Math.Abs(this[0]);
            for (var dimensionIndex = 1; dimensionIndex < DimensionCount; dimensionIndex++)
            {
                var test = Math.Abs(this[dimensionIndex]);
                if (test < min)
                {
                    index = dimensionIndex;
                    min = test;
                }
            }
            return index;
        }


        private static void AddInternal(IVector<double> left, IVector<double> right)
        {
            for (var index = 0; index < left.DimensionCount; index++)
            {
                left[index] += right[index];
            }
        }


        private static void AddInternal(IVector<double> left, double number)
        {
            for (var index = 0; index < left.DimensionCount; index++)
            {
                left[index] += number;
            }
        }



		/// <inheritdoc />
        protected override void AddSafe(IVector<double> vector)
        {
            CheckDimensionsEqual(this, vector);
            AddInternal(this, vector);
        }



		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorNExamples.cs" region="AddDouble" lang="cs" title="The following example shows how to use the Add method."/>
        /// </example>
        public override void Add(double number)
        {
            AddInternal(this, number);
        }



		/// <inheritdoc />
        protected override IVector<double> CrossProductSafe(IVector<double> vector)
        {
            double x1;
            double y1;
            double z1;
            double x2;
            double y2;
            double z2;
            if (DimensionCount == 3)
            {
                x1 = this[0];
                y1 = this[1];
                z1 = this[2];
            }
            else 
            {
                x1 = this[0];
                y1 = this[1];
                z1 = 0;
            }
            if (vector.DimensionCount == 3)
            {
                x2 = vector[0];
                y2 = vector[1];
                z2 = vector[2];
            }
            else 
            {
                x2 = vector[0];
                y2 = vector[1];
                z2 = 0;
            }

            return new Vector3D(y1*z2 - z1*y2,
                                z1*x2 - x1*z2,
                                x1*y2 - y1*x2);
        }



		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorNExamples.cs" region="Decrement" lang="cs" title="The following example shows how to use the Decrement method."/>
        /// </example>
        public override void Decrement()
        {
            AddInternal(this, -1);
        }



		/// <inheritdoc />
        protected override IVector<double> DeepClone()
        {
            return new VectorN(DimensionCount) {_dimensions = ((double[]) _dimensions.Clone())};
        }



		/// <inheritdoc />
        protected override void DivideSafe(IVector<double> vector)
        {
            DivideInternal(this, vector);
        }



		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorNExamples.cs" region="DivideDouble" lang="cs" title="The following example shows how to use the Divide method."/>
        /// </example>
        public override void Divide(double number)
        {
            MultiplyInternal(this, 1/number);
        }


        private static void DivideInternal(IVector<double> left, IVector<double> right)
        {
            for (var index = 0; index < left.DimensionCount; index++)
            {
                left[index] /= right[index];
            }
        }



		/// <inheritdoc />
        protected override double DotProductSafe(IVector<double> vector)
        {
            double dotProduct = 0;
            for (var index = 0; index < DimensionCount; index++)
            {
                dotProduct += this[index]*vector[index];
            }
            return dotProduct;
        }


        private static VectorN FromMatrixInternal(ObjectMatrix<double> matrix)
        {
            if (matrix.Columns != 1)
            {
                throw new InvalidCastException("matrix must have only 1 column");
            }
            var vector = new VectorN(matrix.Rows);
            for (var index = 0; index < matrix.Rows; index++)
            {
                vector[index] = matrix.GetValue(index, 0);
            }
            return vector;
        }


        /// <summary>
        /// Creates zeroed <see cref="VectorN"/>.
        /// </summary>
        /// <param name="dimensionCount">The number of dimensions.</param>
        /// <returns>A zeroed <see cref="VectorN"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="dimensionCount"/> is less than 0.</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorNExamples.cs" region="GetUnitVector" lang="cs" title="The following example shows how to use the GetZeroVector method."/>
        /// </example>
        public static VectorN GetUnitVector(int dimensionCount)
        {
            var vector = new VectorN(dimensionCount);
            for (var index = 0; index < dimensionCount; index++)
            {
                vector[index] = 1;
            }
            return vector;
        }


        /// <summary>
        /// Creates zeroed <see cref="VectorN"/>.
        /// </summary>
        /// <param name="dimensionCount">The number of dimensions.</param>
        /// <returns>A zeroed <see cref="VectorN"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="dimensionCount"/> is less than 0.</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorNExamples.cs" region="GetZeroVector" lang="cs" title="The following example shows how to use the GetZeroVector method."/>
        /// </example>
        public static VectorN GetZeroVector(int dimensionCount)
        {
            return new VectorN(dimensionCount);
        }



		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorNExamples.cs" region="Increment" lang="cs" title="The following example shows how to use the Increment method."/>
        /// </example>
        public override void Increment()
        {
            AddInternal(this, 1);
        }



		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorNExamples.cs" region="Magnitude" lang="cs" title="The following example shows how to use the Magnitude method."/>
        /// </example>
        public override double Magnitude()
        {
            double squareSum = 0;
            for (var index = 0; index < DimensionCount; index++)
            {
                var dimension = this[index];
                squareSum += dimension*dimension;
            }
            return Math.Sqrt(squareSum);
        }



		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorNExamples.cs" region="Maximum" lang="cs" title="The following example shows how to use the Maximum method."/>
        /// </example>
        public override int MaximumIndex()
        {
            var index = 0;
            var max = this[0];
            for (var dimensionIndex = 1; dimensionIndex < DimensionCount; dimensionIndex++)
            {
                var dimension = this[dimensionIndex];
                if (max < dimension)
                {
                    index = dimensionIndex;
                    max = dimension;
                }
            }
            return index;
        }



		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorNExamples.cs" region="MinimumIndex" lang="cs" title="The following example shows how to use the MinimumIndex method."/>
        /// </example>
        public override int MinimumIndex()
        {
            var index = 0;
            var min = this[0];
            for (var dimensionIndex = 1; dimensionIndex < DimensionCount; dimensionIndex++)
            {
                var dimension = this[dimensionIndex];
                if (min > dimension)
                {
                    index = dimensionIndex;
                    min = dimension;
                }
            }
            return index;
        }



		/// <inheritdoc />
        protected override IMatrix<double> MultiplySafe(IVector<double> vector)
        {
            return MultiplyInternal(this, vector);
        }



		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorNExamples.cs" region="MultiplyDouble" lang="cs" title="The following example shows how to use the Multiply method."/>
        /// </example>
        public override void Multiply(double number)
        {
            MultiplyInternal(this, number);
        }


        private static Matrix MultiplyInternal(IVector<double> left, IVector<double> right)
        {
            var matrix = new Matrix(left.DimensionCount, right.DimensionCount);

            for (var leftIndex = 0; leftIndex < left.DimensionCount; leftIndex++)
            {
                for (var rightIndex = 0; rightIndex < right.DimensionCount; rightIndex++)
                {
                    matrix.SetValue(leftIndex, rightIndex, left[leftIndex]*right[rightIndex]);
                }
            }
            return matrix;
        }


        private static void MultiplyInternal(IVector<double> left, double right)
        {
            for (var index = 0; index < left.DimensionCount; index++)
            {
                left[index] *= right;
            }
        }



		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorNExamples.cs" region="Negate" lang="cs" title="The following example shows how to use the Negate method."/>
        /// </example>
        public override void Negate()
        {
            for (var index = 0; index < DimensionCount; index++)
            {
                this[index] *= -1;
            }
        }



		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorNExamples.cs" region="Normalize" lang="cs" title="The following example shows how to use the Normalize method."/>
        /// </example>
        public override void Normalize()
        {
            var magnitude = Magnitude();
            for (var index = 0; index < DimensionCount; index++)
            {
                this[index] /= magnitude;
            }
        }



		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorNExamples.cs" region="Product" lang="cs" title="The following example shows how to use the Product method."/>
        /// </example>
        public override double Product()
        {
            double product = 1;
            for (var index = 0; index < DimensionCount; index++)
            {
                product *= this[index];
            }
            return product;
        }



		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorNExamples.cs" region="Sum" lang="cs" title="The following example shows how to use the Sum method."/>
        /// </example>
        public override double Sum()
        {
            double sum = 0;
            for (var index = 0; index < DimensionCount; index++)
            {
                sum += this[index];
            }
            return sum;
        }



		/// <inheritdoc />
        protected override void SubtractSafe(IVector<double> vector)
        {
            SubtractInternal(this, vector);
        }



		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorNExamples.cs" region="SubtractDouble" lang="cs" title="The following example shows how to use the Subtract method."/>
        /// </example>
        public override void Subtract(double number)
        {
            AddInternal(this, -number);
        }


        private static void SubtractInternal(IVector<double> left, IVector<double> right)
        {
            for (var index = 0; index < left.DimensionCount; index++)
            {
                left[index] -= right[index];
            }
        }


        /// <summary>
        /// Swap all the values with another <see cref="IVector{T}"/>.
        /// </summary>
        /// <param name="vector">The <see cref="IVector{T}"/> to swap value with.</param>
        /// <exception cref="ArgumentNullException"><paramref name="vector"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentException">The <see cref="IVector{T}.DimensionCount"/> of <paramref name="vector"/> does not equal the <see cref="IVector{T}.DimensionCount"/> of the current instance.</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorNExamples.cs" region="Swap" lang="cs" title="The following example shows how to use the Swap method."/>
        /// </example>
        public void Swap(VectorN vector)
        {
            Guard.ArgumentNotNull(vector, "vector");
            CheckDimensionsEqual(this, vector);
            var temp = _dimensions;
            _dimensions = vector._dimensions;
            vector._dimensions = temp;
        }



		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorNExamples.cs" region="ToArray" lang="cs" title="The following example shows how to use the ToArray method."/>
        /// </example>
        public override double[] ToArray()
        {
            return (double[]) _dimensions.Clone();
        }



		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorNExamples.cs" region="ToMatrix" lang="cs" title="The following example shows how to use the ToMatrix method."/>
        /// </example>
        public override IMatrix<double> ToMatrix()
        {
            return ToMatrixInternal(this);
        }


        private static Matrix ToMatrixInternal(IVector<double> vector)
        {
            var matrix = new Matrix(vector.DimensionCount, 1);
            for (var index = 0; index < vector.DimensionCount; index++)
            {
                matrix.SetValue(index, 0, vector[index]);
            }
            return matrix;
        }

        #endregion
    }
}