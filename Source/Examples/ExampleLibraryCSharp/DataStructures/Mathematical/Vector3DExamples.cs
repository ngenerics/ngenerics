/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using NGenerics.DataStructures.Mathematical;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace ExampleLibraryCSharp.DataStructures.Mathematical
{
    [TestFixture]
    public partial class Vector3DExamples
    {
        #region AbsoluteMaximum

        [Test]
        public void AbsoluteMaximumExample()
        {
            var vector = new Vector3D(1, -4, 3);
            Assert.AreEqual(4, vector.AbsoluteMaximum());
        }

        #endregion


        #region AbsoluteMaximumIndex

        [Test]
        public void AbsoluteMaximumIndexExample()
        {
            var vector1 = new Vector3D(1, -4, 3);
            Assert.AreEqual(1, vector1.AbsoluteMaximumIndex());


            var vector2 = new Vector3D(1, -4, 5);
            Assert.AreEqual(2, vector2.AbsoluteMaximumIndex());


            var vector3 = new Vector3D(7, -4, 3);
            Assert.AreEqual(0, vector3.AbsoluteMaximumIndex());


            var vector4 = new Vector3D(7, -4, 8);
            Assert.AreEqual(2, vector4.AbsoluteMaximumIndex());
        }

        #endregion


        #region AbsoluteMinimum

        [Test]
        public void AbsoluteMinimumExample()
        {
            var vector = new Vector3D(1, -4, 3);
            Assert.AreEqual(1, vector.AbsoluteMinimum());
        }

        #endregion


        #region AbsoluteMinimumIndex

        [Test]
        public void AbsoluteMinimumIndexExample()
        {
            var vector1 = new Vector3D(1, -4, 3);
            Assert.AreEqual(0, vector1.AbsoluteMinimumIndex());

            var vector2 = new Vector3D(7, -4, 3);
            Assert.AreEqual(2, vector2.AbsoluteMinimumIndex());

            var vector3 = new Vector3D(7, -4, 8);
            Assert.AreEqual(1, vector3.AbsoluteMinimumIndex());

            var vector4 = new Vector3D(-8, 9, -7);
            Assert.AreEqual(2, vector4.AbsoluteMinimumIndex());
        }

        #endregion


        #region Accept

        [Test]
        public void AcceptExample()
        {
            var visitor = new CountingVisitor<double>();
            var vector3D = new Vector3D();
            vector3D.AcceptVisitor(visitor);
            Assert.AreEqual(3, visitor.Count);
        }

        #endregion


        #region AddDouble

        [Test]
        public void AddDoubleExample()
        {
            var vector = new Vector3D(4, 7, 3);
            vector.Add(1);
            Assert.AreEqual(5, vector.X);
            Assert.AreEqual(8, vector.Y);
            Assert.AreEqual(4, vector.Z);
        }

        #endregion


        #region AddVector3D

        [Test]
        public void AddVector3DExample()
        {
            var vector1 = new Vector3D(4, 7, -1);

            var vector2 = new Vector3D(3, 4, 2);

            vector1.Add(vector2);

            Assert.AreEqual(7, vector1.X);
            Assert.AreEqual(11, vector1.Y);
            Assert.AreEqual(1, vector1.Z);
        }

        #endregion


        #region Clear

        [Test]
        public void ClearExample()
        {
            var vector = new Vector3D(3, 7, 8);

            vector.Clear();

            Assert.AreEqual(0, vector.X);
            Assert.AreEqual(0, vector.Y);
            Assert.AreEqual(0, vector.Z);
        }

        #endregion


        #region Clone

        [Test]
        public void CloneExample()
        {
            var vector = new Vector3D(3, 7, 9);

            var clone = (Vector3D) vector.Clone();

            Assert.AreEqual(3, clone.X);
            Assert.AreEqual(7, clone.Y);
            Assert.AreEqual(9, clone.Z);
        }

        #endregion


        #region Constructor

        [Test]
        public void ConstructorExample()
        {
            var vector = new Vector3D();
            Assert.AreEqual(0, vector.X);
            Assert.AreEqual(0, vector.Y);
            Assert.AreEqual(0, vector.Z);
        }

        #endregion


        #region ConstructorInitValues

        [Test]
        public void ConstructorInitValuesExample()
        {
            var vector = new Vector3D(2, 7, 4);
            Assert.AreEqual(2, vector.X);
            Assert.AreEqual(7, vector.Y);
            Assert.AreEqual(4, vector.Z);
        }

        #endregion
        

        #region CrossProduct3D

        [Test]
        public void CrossProduct3DExample()
        {
            var vector1 = new Vector3D(1, 2, 3);

            var vector2 = new Vector3D(4, 5, 6);

            var vector = vector1.CrossProduct(vector2);

            Assert.AreEqual(-3, vector.X);
            Assert.AreEqual(6, vector.Y);
            Assert.AreEqual(-3, vector.Z);
        }

        #endregion


        #region CrossProduct2D

        [Test]
        public void CrossProduct2DExample()
        {
            var vector3D = new Vector3D(1, 2, 3);

            var vector2D = new Vector2D(4, 5);

            var vector = vector3D.CrossProduct(vector2D);

            Assert.AreEqual(-15, vector.X);
            Assert.AreEqual(12, vector.Y);
            Assert.AreEqual(-3, vector.Z);
        }

        #endregion


        #region Decrement

        [Test]
        public void DecrementExample()
        {
            var vector = new Vector3D(4, 7, 9);

            vector.Decrement();

            Assert.AreEqual(3, vector.X);
            Assert.AreEqual(6, vector.Y);
            Assert.AreEqual(8, vector.Z);
        }

        #endregion


        #region DimensionCount

        [Test]
        public void DimensionCountExample()
        {
            var vector3D = new Vector3D();
            Assert.AreEqual(3, vector3D.DimensionCount);
        }

        #endregion


        #region Magnitude

        [Test]
        public void MagnitudeExample()
        {
            var vector3D = new Vector3D(4, 3, 12);

            Assert.AreEqual(13, vector3D.Magnitude());
        }

        #endregion


        #region Product

        [Test]
        public void ProductExample()
        {
            var vector3D = new Vector3D();
            vector3D.SetValues(2, 3, 5);

            Assert.AreEqual(30, vector3D.Product());
        }

        #endregion


        #region Sum

        [Test]
        public void SumExample()
        {
            var vector = new Vector3D(2, 3, 5);

            Assert.AreEqual(10, vector.Sum());

        }

        #endregion


        #region DivideDouble

        [Test]
        public void DivideDoubleExample()
        {
            var vector = new Vector3D(9, 3, 18);

            vector.Divide(3);

            Assert.AreEqual(3, vector.X);
            Assert.AreEqual(1, vector.Y);
            Assert.AreEqual(6, vector.Z);
        }

        #endregion


        #region DivideVector3D

        [Test]
        public void DivideVector3DExample()
        {
            var vector1 = new Vector3D(24, 48, 72);

            var vector2 = new Vector3D(2, 3, 4);

            vector1.Divide(vector2);

            Assert.AreEqual(1, vector1.X);
            Assert.AreEqual(2, vector1.Y);
            Assert.AreEqual(3, vector1.Z);

            Assert.AreEqual(2, vector2.X);
            Assert.AreEqual(3, vector2.Y);
            Assert.AreEqual(4, vector2.Z);
        }

        #endregion


        #region DotProduct
        [Test]
        public void DotProductExample()
        {
            var vector1 = new Vector3D(4, 7, 4);

            var vector2 = new Vector3D(3, 4, 8);

            var dotProduct = vector1.DotProduct(vector2);
            Assert.AreEqual(72, dotProduct);

        }

        #endregion


        #region GetHashCode

        [Test]
        public void GetHashCodeExample()
        {
            var vector = new Vector3D(1, 2, 3);

            Assert.AreNotEqual(0, vector.GetHashCode());

        }

        #endregion


        #region GetUnitVector

        [Test]
        public void GetUnitVectorExample()
        {
            var vector = Vector3D.UnitVector;
            Assert.AreEqual(1, vector.X);
            Assert.AreEqual(1, vector.Y);
            Assert.AreEqual(1, vector.Z);
        }

        #endregion


        #region GetZeroVector

        [Test]
        public void GetZeroVectorExample()
        {
            var vector = Vector3D.ZeroVector;
            Assert.AreEqual(0, vector.X);
            Assert.AreEqual(0, vector.Y);
            Assert.AreEqual(0, vector.Z);
        }

        #endregion


        #region Increment

        [Test]
        public void IncrementExample()
        {
            var vector = new Vector3D(4, 7, 9);

            vector.Increment();

            Assert.AreEqual(5, vector.X);
            Assert.AreEqual(8, vector.Y);
            Assert.AreEqual(10, vector.Z);
        }

        #endregion


        #region Index

        [Test]
        public void IndexExample()
        {
            var vector = new Vector3D();
            Assert.AreEqual(3, vector.DimensionCount);

            Assert.AreEqual(0, vector.X);
            Assert.AreEqual(0, vector.Y);
            Assert.AreEqual(0, vector.Z);

            Assert.AreEqual(0, vector[0]);
            Assert.AreEqual(0, vector[1]);
            Assert.AreEqual(0, vector[2]);


            vector[0] = 4;
            vector[1] = 5;
            vector[2] = -2;

            Assert.AreEqual(4, vector.X);
            Assert.AreEqual(5, vector.Y);
            Assert.AreEqual(-2, vector.Z);

            Assert.AreEqual(4, vector[0]);
            Assert.AreEqual(5, vector[1]);
            Assert.AreEqual(-2, vector[2]);
        }

        #endregion


        #region Maximum

        [Test]
        public void MaximumExample()
        {
            var vector = new Vector3D(1, -4, 3);

            Assert.AreEqual(3, vector.Maximum());
        }

        #endregion


        #region MaximumIndex

        [Test]
        public void MaximumIndexExample()
        {
            var vector1 = new Vector3D(1, -4, 3);
            Assert.AreEqual(2, vector1.MaximumIndex());

            var vector2 = new Vector3D(4, -4, 3);
            Assert.AreEqual(0, vector2.MaximumIndex());

            var vector3 = new Vector3D(1, 4, 3);
            Assert.AreEqual(1, vector3.MaximumIndex());


            var vector4 = new Vector3D(3, 4, 9);
            Assert.AreEqual(2, vector4.MaximumIndex());
        }

        #endregion


        #region Minimum

        [Test]
        public void MinimumExample()
        {
            var vector = new Vector3D(1, -4, 3);

            Assert.AreEqual(-4, vector.Minimum());
        }

        #endregion


        #region MinimumIndex

        [Test]
        public void MinimumIndexExample()
        {
            var vector1 = new Vector3D(1, -4, 3);
            Assert.AreEqual(1, vector1.MinimumIndex());

            var vector2 = new Vector3D(1, 4, 3);
            Assert.AreEqual(0, vector2.MinimumIndex());

            var vector3 = new Vector3D(1, 4, -3);
            Assert.AreEqual(2, vector3.MinimumIndex());

            var vector4 = new Vector3D(6, 4, -3);
            Assert.AreEqual(2, vector4.MinimumIndex());

        }

        #endregion


        #region MultiplyDouble

        [Test]
        public void MultiplyDoubleExample()
        {
            var vector = new Vector3D(1, 2, 9);

            vector.Multiply(2);

            Assert.AreEqual(2, vector.X);
            Assert.AreEqual(4, vector.Y);
            Assert.AreEqual(18, vector.Z);
        }

        #endregion


        #region MultiplyVector

        [Test]
        public void MultiplyVectorExample()
        {
            var vector1 = new Vector3D(1, 2, 8);

            var vector2 = new Vector3D(3, 4, 2);

            var matrix = vector1.Multiply(vector2);

            Assert.AreEqual(3, matrix.Columns);
            Assert.AreEqual(3, matrix.Rows);

            Assert.AreEqual(3, matrix[0, 0]);
            Assert.AreEqual(4, matrix[0, 1]);
            Assert.AreEqual(2, matrix[0, 2]);

            Assert.AreEqual(6, matrix[1, 0]);
            Assert.AreEqual(8, matrix[1, 1]);
            Assert.AreEqual(4, matrix[1, 2]);

            Assert.AreEqual(24, matrix[2, 0]);
            Assert.AreEqual(32, matrix[2, 1]);
            Assert.AreEqual(16, matrix[2, 2]);

        }

        #endregion


        #region NamedDimensions

        [Test]
        public void NamedDimensionsExample()
        {
            var vector = new Vector3D();

            vector.X = 1;
            vector.Y = 2;
            vector.Z = 3;
            Assert.AreEqual(1, vector.X);
            Assert.AreEqual(2, vector.Y);
            Assert.AreEqual(3, vector.Z);
        }

        #endregion


        #region Negate

        [Test]
        public void NegateExample()
        {
            var vector = new Vector3D(1, 2, -5);

            vector.Negate();

            Assert.AreEqual(-1, vector.X);
            Assert.AreEqual(-2, vector.Y);
            Assert.AreEqual(5, vector.Z);
        }

        #endregion


        #region Normalize

        [Test]
        public void NormalizeExample()
        {
            var vector = new Vector3D(23, -21, 4);

            vector.Normalize();
            Assert.AreEqual(1, vector.Magnitude());
        }

        #endregion


        #region SetValues

        [Test]
        public void SetValuesExample()
        {
            var vector = new Vector3D(4, 6, 8);

            Assert.AreEqual(4, vector.X);
            Assert.AreEqual(6, vector.Y);
            Assert.AreEqual(8, vector.Z);
        }

        #endregion


        #region SubtractDouble

        [Test]
        public void SubtractDoubleExample()
        {
            var vector = new Vector3D(1, 2, -2);

            vector.Subtract(2);

            Assert.AreEqual(-1, vector.X);
            Assert.AreEqual(0, vector.Y);
            Assert.AreEqual(-4, vector.Z);
        }

        #endregion


        #region SubtractVector

        [Test]
        public void SubtractVectorExample()
        {
            var vector1 = new Vector3D(1, 2, 9);

            var vector2 = new Vector3D(8, 4, 2);

            vector1.Subtract(vector2);

            Assert.AreEqual(-7, vector1.X);
            Assert.AreEqual(-2, vector1.Y);
            Assert.AreEqual(7, vector1.Z);

        }

        #endregion


        #region Swap

        [Test]
        public void SwapExample()
        {
            var vector1 = new Vector3D(1, 2, 3);

            var vector2 = new Vector3D(3, 4, 6);

            vector1.Swap(vector2);

            Assert.AreEqual(3, vector1.X);
            Assert.AreEqual(4, vector1.Y);
            Assert.AreEqual(6, vector1.Z);

            Assert.AreEqual(1, vector2.X);
            Assert.AreEqual(2, vector2.Y);
            Assert.AreEqual(3, vector2.Z);
        }

        #endregion


        #region ToArray

        [Test]
        public void ToArrayExample()
        {
            var vector = new Vector3D(8, 3, 6);

            var actual = vector.ToArray();

            Assert.AreEqual(3, actual.Length);

        }

        #endregion


        #region ToMatrix

        [Test]
        public void ToMatrixExample()
        {
            var vector = new Vector3D(8, 3, 7);

            var actual = vector.ToMatrix();

            Assert.AreEqual(3, actual.Rows);
            Assert.AreEqual(1, actual.Columns);

            Assert.AreEqual(8, actual[0, 0]);
            Assert.AreEqual(3, actual[1, 0]);
            Assert.AreEqual(7, actual[2, 0]);
        }

        #endregion


        #region ToString

        [Test]
        public void ToStringExample()
        {
            var vector = new Vector3D();
            var actual = vector.ToString();
            Assert.AreEqual("{0,0,0}", actual);
            vector.X = 1;
            vector.Y = 2;
            vector.Z = 7;
            actual = vector.ToString();
            Assert.AreEqual("{1,2,7}", actual);
        }

        #endregion

    }
}