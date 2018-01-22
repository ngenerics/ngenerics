/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/



using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace ExampleLibraryCSharp.DataStructures.Mathematical
{


    [TestFixture]
    public partial class Vector2DExamples
    {
        #region AbsoluteMaximum
        [Test]
        public void AbsoluteMaximumExample()
        {

            var vector1 = new Vector2D(1, -4);
            Assert.AreEqual(4, vector1.AbsoluteMaximum());


            var vector2 = new Vector2D(5, -4);
             Assert.AreEqual(5, vector2.AbsoluteMaximum());

        }

        #endregion

        #region AbsoluteMaximumIndex

        [Test]
        public void AbsoluteMaximumIndexExample()
        {

            var vector1 = new Vector2D(1, -4);
            Assert.AreEqual(1, vector1.AbsoluteMaximumIndex());

            var vector2 = new Vector2D(5, -4);
            Assert.AreEqual(0, vector2.AbsoluteMaximumIndex());
        }

        #endregion

        #region AbsoluteMinimum
        [Test]
        public void AbsoluteMinimumExample()
        {

            var vector = new Vector2D(1, -4);

            Assert.AreEqual(1, vector.AbsoluteMinimum());

        }


        #endregion

        #region AbsoluteMinimumIndex
        [Test]
        public void AbsoluteMinimumIndexExample()
        {

            var vector1 = new Vector2D(1, -4);
            Assert.AreEqual(0, vector1.AbsoluteMinimumIndex());

            var vector2 = new Vector2D(-4, 1);
            Assert.AreEqual(1, vector2.AbsoluteMinimumIndex());

        }

        #endregion

        #region AddDouble

        [Test]
        public void AddDoubleExample()
        {

            var vector = new Vector2D(4, 7);

            vector.Add(1);

            Assert.AreEqual(5, vector.X);
            Assert.AreEqual(8, vector.Y);

        }


        #endregion

        #region AddVector
        [Test]
        public void AddVectorExample()
        {

            var vector1 = new Vector2D(4, 7);

            var vector2 = new Vector2D(3, 4);

            vector1.Add(vector2);

            Assert.AreEqual(7, vector1.X);
            Assert.AreEqual(11, vector1.Y);

        }

        #endregion

        #region Clear


        [Test]
        public void ClearExample()
        {

            var vector = new Vector2D(3, 7);

            vector.Clear();

            Assert.AreEqual(0, vector.X);
            Assert.AreEqual(0, vector.Y);

        }

        #endregion


        #region Constructor

        [Test]
        public void ConstructorExample()
        {

            var vector = new Vector2D();
            Assert.AreEqual(2, vector.DimensionCount);
            Assert.AreEqual(0, vector.X);
            Assert.AreEqual(0, vector.Y);

        }


        #endregion

        #region ConstructorInitValues

        [Test]
        public void ConstructorInitValuesExample()
        {
            var vector = new Vector2D(2, 5);
            Assert.AreEqual(2, vector.DimensionCount);
            Assert.AreEqual(2, vector.X);
            Assert.AreEqual(5, vector.Y);
        }


        #endregion

        #region CrossProduct2D

        [Test]
        public void CrossProduct2DExample()
        {
            var vector1 = new Vector2D(6, 3);
            var vector2 = new Vector2D(4, 5);

            IVector<double> vector = vector1.CrossProduct(vector2);

            Assert.AreEqual(0, vector[0]);
            Assert.AreEqual(0, vector[1]);
            Assert.AreEqual(18, vector[2]);
        }

        #endregion

        #region CrossProduct3D

        [Test]
        public void CrossProduct3DExample()
        {

            var vector2D = new Vector2D(4, 5);

            var vector3D = new Vector3D(1, 2, 3);

            IVector<double> vector = vector2D.CrossProduct(vector3D);

            Assert.AreEqual(15, vector[0]);
            Assert.AreEqual(-12, vector[1]);
            Assert.AreEqual(3, vector[2]);

        }


        #endregion

        #region Decrement


        [Test]
        public void DecrementExample()
        {

            var vector = new Vector2D(4, 7);

            vector.Decrement();

            Assert.AreEqual(3, vector.X);
            Assert.AreEqual(6, vector.Y);

        }
        #endregion

        #region DimensionCount
        [Test]
        public void DimensionCountExample()
        {

            var vector = new Vector2D();
            Assert.AreEqual(2, vector.DimensionCount);

        }

        #endregion

        #region DivideDouble


        [Test]
        public void DivideDoubleExample()
        {
            var vector = new Vector2D(9, 3);

            vector.Divide(3);

            Assert.AreEqual(3, vector.X);
            Assert.AreEqual(1, vector.Y);
        }

        #endregion

        #region DivideVector2D

        [Test]
        public void DivideVector2DExample()
        {
            var vector1 = new Vector2D(24, 32);

            var vector2 = new Vector2D(2, 4);

            vector1.Divide(vector2);

            Assert.AreEqual(3, vector1.X);
            Assert.AreEqual(4, vector1.Y);

        }

        #endregion

        #region DotProduct

        [Test]
        public void DotProductExample()
        {
            var vector1 = new Vector2D(4, 7);

            var vector2 = new Vector2D(3, 4);

            var dotProduct = vector1.DotProduct(vector2);
            Assert.AreEqual(40, dotProduct);

        }
        #endregion

        #region GetUnitVector

        [Test]
        public void GetUnitVectorExample()
        {
            var vector = Vector2D.UnitVector;
            Assert.AreEqual(1, vector.X);
            Assert.AreEqual(1, vector.Y);
        }

        #endregion

        #region GetZeroVector

        [Test]
        public void GetZeroVectorExample()
        {
            var vector = Vector2D.ZeroVector;
            Assert.AreEqual(0, vector.X);
            Assert.AreEqual(0, vector.Y);
        }

        #endregion

        #region Increment
        [Test]
        public void IncrementExample()
        {
            var vector = new Vector2D(4, 7);
            vector.Increment();
            Assert.AreEqual(5, vector.X);
            Assert.AreEqual(8, vector.Y);
        }
        #endregion

        #region Index
        [Test]
        public void IndexExample()
        {
            var vector = new Vector2D();

            vector[0] = 4;
            vector[1] = 5;

            Assert.AreEqual(4, vector[0]);
            Assert.AreEqual(5, vector[1]);
        }

        #endregion

        #region Magnitude

        [Test]
        public void MagnitudeExample()
        {
            var vector = new Vector2D(2, 3);

            Assert.AreEqual(3.6055512754639891d, vector.Magnitude());
        }
        #endregion

        #region Maximum




        [Test]
        public void MaximumExample()
        {
            var vector = new Vector2D(1, -4);

            Assert.AreEqual(1, vector.Maximum());
        }
        #endregion

        #region MaximumIndex

        [Test]
        public void MaximumIndexExample()
        {
            var vector1 = new Vector2D(1, -4);
            Assert.AreEqual(0, vector1.MaximumIndex());

            var vector2 = new Vector2D(1, 4);
            Assert.AreEqual(1, vector2.MaximumIndex());
        }
        #endregion

        #region Minimum

        [Test]
        public void MinimumExample()
        {
            var vector = new Vector2D(1, -4);

            Assert.AreEqual(-4, vector.Minimum());
        }

        #endregion

        #region MinimumIndex

        [Test]
        public void MinimumIndexExample()
        {
            var vector1 = new Vector2D(1, -4);
            Assert.AreEqual(1, vector1.MinimumIndex());

            var vector2 = new Vector2D(1, 4);
            Assert.AreEqual(0, vector2.MinimumIndex());
        }
        #endregion

        #region MultiplyDouble


        [Test]
        public void MultiplyDoubleExample()
        {
            var vector = new Vector2D(1, 2);

            vector.Multiply(2);

            Assert.AreEqual(2, vector.X);
            Assert.AreEqual(4, vector.Y);
        }

        #endregion

        #region MultiplyVector
        [Test]
        public void MultiplyVectorExample()
        {
            var vector1 = new Vector2D(1, 2);

            var vector2 = new Vector2D(3, 4);

            var matrix = vector1.Multiply(vector2);
            Assert.AreEqual(2, matrix.Columns);
            Assert.AreEqual(2, matrix.Rows);

            Assert.AreEqual(3, matrix[0, 0]);
            Assert.AreEqual(4, matrix[0, 1]);
            Assert.AreEqual(6, matrix[1, 0]);
            Assert.AreEqual(8, matrix[1, 1]);
        }

        #endregion

        #region NamedDimensions

        [Test]
        public void NamedDimensionsExample()
        {
            var vector = new Vector2D();

            vector.X = 1;
            vector.Y = 2;
            Assert.AreEqual(1, vector.X);
            Assert.AreEqual(2, vector.Y);
        }


        #endregion

        #region Negate

        [Test]
        public void NegateExample()
        {
            var vector = new Vector2D(1, 2);

            vector.Negate();

            Assert.AreEqual(-1, vector.X);
            Assert.AreEqual(-2, vector.Y);
        }

        #endregion

        #region Normalize
        [Test]
        public void NormalizeExample()
        {
            var vector = new Vector2D(23, 21);

            vector.Normalize();

            Assert.AreEqual(1, vector.Magnitude());
        }


        #endregion

        #region Product

        [Test]
        public void ProductExample()
        {
            var vector = new Vector2D(2, 3);

            Assert.AreEqual(6, vector.Product());
        }
        #endregion

        #region SetValues


        [Test]
        public void SetValuesExample()
        {
            var vector = new Vector2D();
            vector.SetValues(4, 6);
            Assert.AreEqual(4, vector.X);
            Assert.AreEqual(6, vector.Y);
        }


        #endregion

        #region SubtractDouble

        [Test]
        public void SubtractDoubleExample()
        {
            var vector = new Vector2D(1, 2);

            vector.Subtract(2);

            Assert.AreEqual(-1, vector.X);
            Assert.AreEqual(0, vector.Y);
        }


        #endregion

        #region SubtractVector
        [Test]
        public void SubtractVectorExample()
        {
            var vector1 = new Vector2D(1, 2);

            var vector2 = new Vector2D(8, 4);

            vector1.Subtract(vector2);

            Assert.AreEqual(-7, vector1.X);
            Assert.AreEqual(-2, vector1.Y);
        }

        #endregion

        #region Sum

        [Test]
        public void SumExample()
        {
            var vector = new Vector2D(2, 3);

            Assert.AreEqual(5, vector.Sum());

        }
        #endregion

        #region Swap

        [Test]
        public void SwapExample()
        {
            var vector1 = new Vector2D(1, 2);

            var vector2 = new Vector2D(3, 4);

            vector1.Swap(vector2);

            Assert.AreEqual(3, vector1.X);
            Assert.AreEqual(4, vector1.Y);
            Assert.AreEqual(1, vector2.X);
            Assert.AreEqual(2, vector2.Y);
        }
        #endregion

        #region ToArray


        [Test]
        public void ToArrayExample()
        {
            var vector = new Vector2D(8, 3);

            var actual = vector.ToArray();

            Assert.AreEqual(2, actual.Length);
            Assert.AreEqual(8, actual[0]);
            Assert.AreEqual(3, actual[1]);
        }
        #endregion

        #region ToMatrix


        [Test]
        public void ToMatrixExample()
        {
            var vector = new Vector2D(8, 3);

            var actual = vector.ToMatrix();

            Assert.AreEqual(2, actual.Rows);
            Assert.AreEqual(1, actual.Columns);

            Assert.AreEqual(8, actual[0, 0]);
            Assert.AreEqual(3, actual[1, 0]);
        }

        #endregion

        #region ToString

        [Test]
        public void ToStringExample()
        {
            var vector = new Vector2D();
            var actual = vector.ToString();
            Assert.AreEqual("{0,0}", actual);
            vector.X = 1;
            vector.Y = 2;
            actual = vector.ToString();
            Assert.AreEqual("{1,2}", actual);
        }
        #endregion

    }
}