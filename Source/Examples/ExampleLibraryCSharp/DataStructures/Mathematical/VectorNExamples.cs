/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/


using NGenerics.DataStructures.Mathematical;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace ExampleLibraryCSharp.DataStructures.Mathematical
{
    [TestFixture]
    public partial class VectorNExamples
    {
        #region AbsoluteMaximum

        [Test]
        public void AbsoluteMaximumExample()
        {
            var vector1 = new VectorN(4);
            vector1[0] = 1;
            vector1[1] = -4;
            vector1[2] = 3;
            vector1[3] = 2;
            Assert.AreEqual(4, vector1.AbsoluteMaximum());
        }

        #endregion


        #region AbsoluteMaximumIndex

        [Test]
        public void AbsoluteMaximumIndexExample()
        {
            var vector1 = new VectorN(4);
            vector1[0] = 1;
            vector1[1] = -4;
            vector1[2] = 3;
            vector1[3] = 2;
            Assert.AreEqual(1, vector1.AbsoluteMaximumIndex());
        }

        #endregion


        #region AbsoluteMinimum

        [Test]
        public void AbsoluteMinimumExample()
        {
            var vector1 = new VectorN(4);
            vector1[0] = 1;
            vector1[1] = -4;
            vector1[2] = 3;
            vector1[3] = 2;
            Assert.AreEqual(1, vector1.AbsoluteMinimum());
        }

        #endregion


        #region AbsoluteMinimumIndex

        [Test]
        public void AbsoluteMinimumIndexExample()
        {
            var vector1 = new VectorN(5);
            vector1[0] = 7;
            vector1[1] = -4;
            vector1[2] = 3;
            vector1[3] = 5;
            vector1[4] = 1;

            Assert.AreEqual(4, vector1.AbsoluteMinimumIndex());
        }

        #endregion


        #region Accept

        [Test]
        public void AcceptExample()
        {
            var visitor = new CountingVisitor<double>();
            var vector = new VectorN(2);
            vector.AcceptVisitor(visitor);
            Assert.AreEqual(2, visitor.Count);
        }

        #endregion


        #region AddDouble

        [Test]
        public void AddDoubleExample()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(4, 7);
            vector1.Add(1);
            Assert.AreEqual(5, vector1[0]);
            Assert.AreEqual(8, vector1[1]);
        }

        #endregion


        #region AddVector

        [Test]
        public void AddVectorExample()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(4, 7);
            var vector2 = new VectorN(2);
            vector2.SetValues(3, 4);
            vector1.Add(vector2);
            Assert.AreEqual(7, vector1[0]);
            Assert.AreEqual(11, vector1[1]);
        }

        #endregion


        #region Clear

        [Test]
        public void ClearExample()
        {
            var vector = new VectorN(2);
            vector.SetValues(3, 7);
            vector.Clear();
            Assert.AreEqual(0, vector[0]);
            Assert.AreEqual(0, vector[1]);
        }

        #endregion


        #region Clone

        [Test]
        public void CloneExample()
        {
            var vector = new VectorN(3);
            vector.SetValues(3, 7, 9);

            var clone = (VectorN) vector.Clone();

            Assert.AreEqual(3, vector[0]);
            Assert.AreEqual(7, vector[1]);
            Assert.AreEqual(9, vector[2]);

            Assert.AreEqual(3, clone[0]);
            Assert.AreEqual(7, clone[1]);
            Assert.AreEqual(9, clone[2]);

            Assert.AreNotSame(clone, vector);
        }

        #endregion


        #region Constructor

        [Test]
        public void ConstructorExample()
        {
            var vector = new VectorN(2);
            Assert.AreEqual(2, vector.DimensionCount);
            Assert.AreEqual(0, vector[0]);
            Assert.AreEqual(0, vector[1]);
        }

        #endregion


        #region Decrement

        [Test]
        public void DecrementExample()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(4, 7);
            vector1.Decrement();
            Assert.AreEqual(3, vector1[0]);
            Assert.AreEqual(6, vector1[1]);
        }

        #endregion


        #region DimensionCount

        [Test]
        public void DimensionCountExample()
        {
            var vector = new VectorN(2);
            Assert.AreEqual(2, vector.DimensionCount);
        }

        #endregion


        #region Magnitude

        [Test]
        public void MagnitudeExample()
        {
            var vector = new VectorN(3);
            vector.SetValues(4, 3, 12);
            Assert.AreEqual(13, vector.Magnitude());

            Assert.AreEqual(4, vector[0]);
            Assert.AreEqual(3, vector[1]);
            Assert.AreEqual(12, vector[2]);
        }

        #endregion


        #region Product

        [Test]
        public void ProductExample()
        {
            var vector = new VectorN(2);
            vector.SetValues(2, 3);
            Assert.AreEqual(6, vector.Product());
        }

        #endregion


        #region Sum

        [Test]
        public void SumExample()
        {
            var vector = new VectorN(2);
            vector.SetValues(2, 3);
            Assert.AreEqual(5, vector.Sum());
        }

        #endregion


        #region DivideDouble

        [Test]
        public void DivideDoubleExample()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(9, 3);
            vector1.Divide(3);
            Assert.AreEqual(3, vector1[0]);
            Assert.AreEqual(1, vector1[1]);
        }

        #endregion


        #region DivideVector

        [Test]
        public void DivideVectorExample()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(6, 16);
            var vector2 = new VectorN(2);
            vector2.SetValues(2, 4);
            vector1.Divide(vector2);
            Assert.AreEqual(3, vector1[0]);
            Assert.AreEqual(4, vector1[1]);
        }

        #endregion


        #region DotProductVector

        [Test]
        public void DotProductVectorExample()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(4, 7);

            var vector2 = new VectorN(2);
            vector2.SetValues(3, 4);

            var dotProduct = vector1.DotProduct(vector2);
            Assert.AreEqual(40, dotProduct);


            Assert.AreEqual(4, vector1[0]);
            Assert.AreEqual(7, vector1[1]);

            Assert.AreEqual(3, vector2[0]);
            Assert.AreEqual(4, vector2[1]);
        }

        #endregion



        #region GetHashCode

        [Test]
        public void GetHashCodeExample()
        {
            var vector1 = new VectorN(2);
            vector1[0] = 1;
            vector1[1] = 2;
            Assert.AreNotEqual(0, vector1.GetHashCode());
        }

        #endregion


        #region Increment

        [Test]
        public void IncrementExample()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(4, 7);
            vector1.Increment();
            Assert.AreEqual(5, vector1[0]);
            Assert.AreEqual(8, vector1[1]);
        }

        #endregion


        #region Index

        [Test]
        public void IndexExample()
        {
            var vector = new VectorN(2);
            Assert.AreEqual(2, vector.DimensionCount);

            Assert.AreEqual(0, vector[0]);
            Assert.AreEqual(0, vector[1]);

            vector[0] = 4;
            vector[1] = 5;

            Assert.AreEqual(4, vector[0]);
            Assert.AreEqual(5, vector[1]);
        }

        #endregion


        #region Maximum

        [Test]
        public void MaximumExample()
        {
            var vector1 = new VectorN(4);
            vector1[0] = 1;
            vector1[1] = -4;
            vector1[2] = 3;
            vector1[3] = 2;
            Assert.AreEqual(3, vector1.Maximum());
        }

        #endregion


        #region MaximumIndex

        [Test]
        public void MaximumIndexExample()
        {
            var vector1 = new VectorN(4);
            vector1[0] = 1;
            vector1[1] = -4;
            vector1[2] = 3;
            vector1[3] = 2;
            Assert.AreEqual(2, vector1.MaximumIndex());
        }

        #endregion


        #region Minimum

        [Test]
        public void MinimumExample()
        {
            var vector1 = new VectorN(4);
            vector1[0] = 1;
            vector1[1] = -4;
            vector1[2] = 3;
            vector1[3] = 2;
            Assert.AreEqual(-4, vector1.Minimum());
        }

        #endregion


        #region MinimumIndex

        [Test]
        public void MinimumIndexExample()
        {
            var vector1 = new VectorN(4);
            vector1[0] = 1;
            vector1[1] = -4;
            vector1[2] = 3;
            vector1[3] = 2;
            Assert.AreEqual(1, vector1.MinimumIndex());
        }

        #endregion


        #region MultiplyDouble

        [Test]
        public void MultiplyDoubleExample()
        {
            var vector1 = new VectorN(2);
            vector1[0] = 1;
            vector1[1] = 2;
            vector1.Multiply(2);
            Assert.AreEqual(2, vector1[0]);
            Assert.AreEqual(4, vector1[1]);
        }

        #endregion


        #region MultiplyVector

        [Test]
        public void MultiplyVectorExample()
        {
            var vector1 = new VectorN(2);
            vector1[0] = 1;
            vector1[1] = 2;
            var vector2 = new VectorN(2);
            vector2[0] = 3;
            vector2[1] = 4;
            var matrix = vector1.Multiply(vector2);
            Assert.AreEqual(2, matrix.Columns);
            Assert.AreEqual(2, matrix.Rows);
            Assert.AreEqual(3, matrix[0, 0]);
            Assert.AreEqual(4, matrix[0, 1]);
            Assert.AreEqual(6, matrix[1, 0]);
            Assert.AreEqual(8, matrix[1, 1]);
        }

        #endregion


        #region Negate

        [Test]
        public void NegateExample()
        {
            var vector1 = new VectorN(2);
            vector1[0] = 1;
            vector1[1] = 2;
            vector1.Negate();
            Assert.AreEqual(-1, vector1[0]);
            Assert.AreEqual(-2, vector1[1]);
        }

        #endregion


        #region Normalize

        [Test]
        public void NormalizeExample()
        {
            var vector = new VectorN(3);
            vector[0] = 23;
            vector[1] = -21;
            vector[2] = 4;
            vector.Normalize();
            Assert.AreEqual(1, vector.Magnitude());
        }

        #endregion


        #region SetValues

        [Test]
        public void SetValuesExample()
        {
            var vector1 = new VectorN(2);

            vector1.SetValues(4, 6);

            Assert.AreEqual(4, vector1[0]);
            Assert.AreEqual(6, vector1[1]);
        }

        #endregion


        #region SubtractDouble

        [Test]
        public void SubtractDoubleExample()
        {
            var vector1 = new VectorN(2);
            vector1[0] = 1;
            vector1[1] = 2;

            vector1.Subtract(2);

            Assert.AreEqual(-1, vector1[0]);
            Assert.AreEqual(0, vector1[1]);
        }

        #endregion


        #region SubtractVector

        [Test]
        public void SubtractVectorExample()
        {
            var vector1 = new VectorN(2);
            vector1[0] = 1;
            vector1[1] = 2;

            var vector2 = new VectorN(2);
            vector2[0] = 8;
            vector2[1] = 4;

            vector1.Subtract(vector2);

            Assert.AreEqual(-7, vector1[0]);
            Assert.AreEqual(-2, vector1[1]);
        }

        #endregion


        #region Swap

        [Test]
        public void SwapExample()
        {
            var vector1 = new VectorN(2);
            vector1[0] = 1;
            vector1[1] = 2;

            var vector2 = new VectorN(2);
            vector2[0] = 3;
            vector2[1] = 4;

            vector1.Swap(vector2);

            Assert.AreEqual(3, vector1[0]);
            Assert.AreEqual(4, vector1[1]);
            Assert.AreEqual(1, vector2[0]);
            Assert.AreEqual(2, vector2[1]);
        }

        #endregion


        #region ToString

        [Test]
        public void ToStringExample()
        {
            var vector1 = new VectorN(2);
            var actual = vector1.ToString();

            Assert.AreEqual("{0,0}", actual);
            vector1[0] = 1;
            vector1[1] = 2;

            actual = vector1.ToString();
            Assert.AreEqual("{1,2}", actual);
        }

        #endregion


        #region ToArray

        [Test]
        public void ToArrayExample()
        {
            var vector = new VectorN(2);
            vector.SetValues(8, 3);

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
            var vector = new VectorN(2);
            vector.SetValues(8, 3);

            var actual = vector.ToMatrix();

            Assert.AreEqual(2, actual.Rows);
            Assert.AreEqual(1, actual.Columns);

            Assert.AreEqual(8, actual[0, 0]);
            Assert.AreEqual(3, actual[1, 0]);
        }

        #endregion


        #region GetZeroVector

        [Test]
        public void GetZeroVectorExample()
        {
            var vector = VectorN.GetZeroVector(3);
            Assert.AreEqual(3, vector.DimensionCount);
            Assert.AreEqual(0, vector[0]);
            Assert.AreEqual(0, vector[1]);
            Assert.AreEqual(0, vector[2]);
        }

        #endregion


        #region GetUnitVector

        [Test]
        public void GetUnitVectorExample()
        {
            var vector = VectorN.GetUnitVector(3);

            Assert.AreEqual(3, vector.DimensionCount);
            Assert.AreEqual(1, vector[0]);
            Assert.AreEqual(1, vector[1]);
            Assert.AreEqual(1, vector[2]);
        }

        #endregion
    }
}