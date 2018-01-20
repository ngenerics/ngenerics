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
    public class MatrixExamples
    {
        #region Constructor

        [Test]
        public void ConstructorExample()
        {
            var matrix = new Matrix(2, 3);
            Assert.AreEqual(2, matrix.Rows);
            Assert.AreEqual(3, matrix.Columns);
        }

        #endregion


        #region Add

        [Test]
        public void AddExample()
        {
            var matrix1 = new Matrix(2, 3);
            matrix1[0, 0] = 1;
            matrix1[0, 1] = 2;
            matrix1[0, 2] = -4;
            matrix1[1, 0] = 0;
            matrix1[1, 1] = 3;
            matrix1[1, 2] = -1;

            var matrix2 = new Matrix(2, 3);
            matrix2[0, 0] = -1;
            matrix2[0, 1] = 0;
            matrix2[0, 2] = 2;
            matrix2[1, 0] = 1;
            matrix2[1, 1] = -5;
            matrix2[1, 2] = 3;

            var expectedMatrix = new Matrix(2, 3);
            expectedMatrix[0, 0] = 0;
            expectedMatrix[0, 1] = 2;
            expectedMatrix[0, 2] = -2;
            expectedMatrix[1, 0] = 1;
            expectedMatrix[1, 1] = -2;
            expectedMatrix[1, 2] = 2;

            var result = matrix1.Add(matrix2);

            Assert.IsTrue(result.Equals(expectedMatrix));
        }

        #endregion


        #region OperatorPlus

        [Test]
        public void OperatorPlusExample()
        {
            var matrix1 = new Matrix(2, 3);
            matrix1[0, 0] = 1;
            matrix1[0, 1] = 2;
            matrix1[0, 2] = -4;
            matrix1[1, 0] = 0;
            matrix1[1, 1] = 3;
            matrix1[1, 2] = -1;

            var matrix2 = new Matrix(2, 3);
            matrix2[0, 0] = -1;
            matrix2[0, 1] = 0;
            matrix2[0, 2] = 2;
            matrix2[1, 0] = 1;
            matrix2[1, 1] = -5;
            matrix2[1, 2] = 3;

            var expectedMatrix = new Matrix(2, 3);
            expectedMatrix[0, 0] = 0;
            expectedMatrix[0, 1] = 2;
            expectedMatrix[0, 2] = -2;
            expectedMatrix[1, 0] = 1;
            expectedMatrix[1, 1] = -2;
            expectedMatrix[1, 2] = 2;

            var result = matrix1 + matrix2;

            Assert.IsTrue(result.Equals(expectedMatrix));
        }

        #endregion


        #region OperatorMinus

        [Test]
        public void OperatorMinusExample()
        {
            var matrix1 = new Matrix(2, 3);
            matrix1[0, 0] = 1;
            matrix1[0, 1] = 2;
            matrix1[0, 2] = -4;
            matrix1[1, 0] = 0;
            matrix1[1, 1] = 3;
            matrix1[1, 2] = -1;

            var matrix2 = new Matrix(2, 3);
            matrix2[0, 0] = -1;
            matrix2[0, 1] = 0;
            matrix2[0, 2] = 2;
            matrix2[1, 0] = 1;
            matrix2[1, 1] = -5;
            matrix2[1, 2] = 3;

            var expectedMatrix = new Matrix(2, 3);
            expectedMatrix[0, 0] = 2;
            expectedMatrix[0, 1] = 2;
            expectedMatrix[0, 2] = -6;
            expectedMatrix[1, 0] = -1;
            expectedMatrix[1, 1] = 8;
            expectedMatrix[1, 2] = -4;

            var result = matrix1 - matrix2;

            Assert.IsTrue(result.Equals(expectedMatrix));
        }

        #endregion


        #region Subtract

        [Test]
        public void SubtractExample()
        {
            var matrix1 = new Matrix(2, 3);
            matrix1[0, 0] = 1;
            matrix1[0, 1] = 2;
            matrix1[0, 2] = -4;
            matrix1[1, 0] = 0;
            matrix1[1, 1] = 3;
            matrix1[1, 2] = -1;

            var matrix2 = new Matrix(2, 3);
            matrix2[0, 0] = -1;
            matrix2[0, 1] = 0;
            matrix2[0, 2] = 2;
            matrix2[1, 0] = 1;
            matrix2[1, 1] = -5;
            matrix2[1, 2] = 3;

            var expectedMatrix = new Matrix(2, 3);
            expectedMatrix[0, 0] = 2;
            expectedMatrix[0, 1] = 2;
            expectedMatrix[0, 2] = -6;
            expectedMatrix[1, 0] = -1;
            expectedMatrix[1, 1] = 8;
            expectedMatrix[1, 2] = -4;

            var result = matrix1.Subtract(matrix2);

            Assert.IsTrue(result.Equals(expectedMatrix));
        }

        #endregion


        #region OperatorMultiplyMatrixMatrix

        [Test]
        public void OperatorMultiplyMatrixMatrixExample()
        {
            var matrix1 = new Matrix(2, 3);
            matrix1[0, 0] = -2;
            matrix1[0, 1] = 3;
            matrix1[0, 2] = 2;
            matrix1[1, 0] = 4;
            matrix1[1, 1] = 6;
            matrix1[1, 2] = -2;

            var matrix2 = new Matrix(3, 4);
            matrix2[0, 0] = 4;
            matrix2[0, 1] = -1;
            matrix2[0, 2] = 2;
            matrix2[0, 3] = 5;
            matrix2[1, 0] = 3;
            matrix2[1, 1] = 0;
            matrix2[1, 2] = 1;
            matrix2[1, 3] = 1;
            matrix2[2, 0] = -2;
            matrix2[2, 1] = 3;
            matrix2[2, 2] = 5;
            matrix2[2, 3] = -3;

            var expectedMatrix = new Matrix(2, 4);
            expectedMatrix[0, 0] = -3;
            expectedMatrix[0, 1] = 8;
            expectedMatrix[0, 2] = 9;
            expectedMatrix[0, 3] = -13;
            expectedMatrix[1, 0] = 38;
            expectedMatrix[1, 1] = -10;
            expectedMatrix[1, 2] = 4;
            expectedMatrix[1, 3] = 32;

            var result = matrix1 * matrix2;

            Assert.IsTrue(result.Equals(expectedMatrix));
        }

        #endregion


        #region MultiplyMatrixMatrix

        [Test]
        public void MultiplyMatrixMatrixExample()
        {
            var matrix1 = new Matrix(2, 3);
            matrix1[0, 0] = -2;
            matrix1[0, 1] = 3;
            matrix1[0, 2] = 2;
            matrix1[1, 0] = 4;
            matrix1[1, 1] = 6;
            matrix1[1, 2] = -2;

            var matrix2 = new Matrix(3, 4);
            matrix2[0, 0] = 4;
            matrix2[0, 1] = -1;
            matrix2[0, 2] = 2;
            matrix2[0, 3] = 5;
            matrix2[1, 0] = 3;
            matrix2[1, 1] = 0;
            matrix2[1, 2] = 1;
            matrix2[1, 3] = 1;
            matrix2[2, 0] = -2;
            matrix2[2, 1] = 3;
            matrix2[2, 2] = 5;
            matrix2[2, 3] = -3;

            var expectedMatrix = new Matrix(2, 4);
            expectedMatrix[0, 0] = -3;
            expectedMatrix[0, 1] = 8;
            expectedMatrix[0, 2] = 9;
            expectedMatrix[0, 3] = -13;
            expectedMatrix[1, 0] = 38;
            expectedMatrix[1, 1] = -10;
            expectedMatrix[1, 2] = 4;
            expectedMatrix[1, 3] = 32;

            var result = matrix1.Multiply(matrix2);

            Assert.IsTrue(result.Equals(expectedMatrix));
        }

        #endregion


        #region Equals

        [Test]
        public void EqualsExample()
        {
            var matrix1 = new Matrix(2, 2);
            matrix1[0, 0] = 1;
            matrix1[0, 1] = 2;
            matrix1[1, 1] = 3;
            matrix1[1, 0] = 4;


            var matrix2 = new Matrix(2, 2);
            matrix2[0, 0] = 1;
            matrix2[0, 1] = 2;
            matrix2[1, 1] = 3;
            matrix2[1, 0] = 4;

            Assert.IsTrue(matrix1.Equals(matrix2));

            var matrix3 = new Matrix(2, 2);
            matrix3[0, 0] = 1;
            matrix3[0, 1] = 2;
            matrix3[1, 1] = 3;
            matrix3[1, 0] = 5;

            Assert.IsFalse(matrix1.Equals(matrix3));
        }

        #endregion


        #region Transpose

        [Test]
        public void TransposeExample()
        {
            var matrix1 = new Matrix(2, 3);
            matrix1[0, 0] = 1;
            matrix1[0, 1] = 4;
            matrix1[0, 2] = 5;
            matrix1[1, 0] = -3;
            matrix1[1, 1] = 2;
            matrix1[1, 2] = 7;

            //            T			[ 1, -3]
            // [ 1, 4,  5]    =		[ 4,  2]
            // [-3, 2,  7]			[ 5,  7]

            var expectedMatrix = new Matrix(3, 2);
            expectedMatrix[0, 0] = 1;
            expectedMatrix[0, 1] = -3;
            expectedMatrix[1, 0] = 4;
            expectedMatrix[1, 1] = 2;
            expectedMatrix[2, 0] = 5;
            expectedMatrix[2, 1] = 7;

            var result = matrix1.Transpose();

            Assert.IsTrue(result.Equals(expectedMatrix));
        }

        #endregion


        #region OperatorMultiplyMatrixDouble

        [Test]
        public void OperatorMultiplyMatrixDoubleExample()
        {
            var matrix1 = new Matrix(2, 3);
            matrix1[0, 0] = 1;
            matrix1[0, 1] = 4;
            matrix1[0, 2] = 5;
            matrix1[1, 0] = -3;
            matrix1[1, 1] = 2;
            matrix1[1, 2] = 7;

            var expectedMatrix = new Matrix(2, 3);
            expectedMatrix[0, 0] = 2;
            expectedMatrix[0, 1] = 8;
            expectedMatrix[0, 2] = 10;
            expectedMatrix[1, 0] = -6;
            expectedMatrix[1, 1] = 4;
            expectedMatrix[1, 2] = 14;

            var result = matrix1*2;
            Assert.IsTrue(result.Equals(expectedMatrix));

            result = 2*matrix1;
            Assert.IsTrue(result.Equals(expectedMatrix));
        }

        #endregion


        #region MultiplyMatrixDouble

        [Test]
        public void MultiplyMatrixDoubleExample()
        {
            var matrix1 = new Matrix(2, 3);
            matrix1[0, 0] = 1;
            matrix1[0, 1] = 4;
            matrix1[0, 2] = 5;
            matrix1[1, 0] = -3;
            matrix1[1, 1] = 2;
            matrix1[1, 2] = 7;

            var expectedMatrix = new Matrix(2, 3);
            expectedMatrix[0, 0] = 2;
            expectedMatrix[0, 1] = 8;
            expectedMatrix[0, 2] = 10;
            expectedMatrix[1, 0] = -6;
            expectedMatrix[1, 1] = 4;
            expectedMatrix[1, 2] = 14;

            var result = matrix1.Multiply(2);
            Assert.IsTrue(result.Equals(expectedMatrix));
        }

        #endregion


        #region IsSymmetric

        [Test]
        public void IsSymmetricExample()
        {
            // Columns != Rows
            var matrix1 = new Matrix(2, 3);
            matrix1[0, 0] = -2;
            matrix1[0, 1] = 3;
            matrix1[0, 2] = 2;
            matrix1[1, 0] = 4;
            matrix1[1, 1] = 6;
            matrix1[1, 2] = -2;

            Assert.IsFalse(matrix1.IsSymmetric);

            // Not symmetric because of values
            var matrix2 = new Matrix(2, 2);
            matrix2[0, 0] = -2;
            matrix2[0, 1] = 3;
            matrix2[1, 0] = 4;
            matrix2[1, 1] = 6;

            Assert.IsFalse(matrix2.IsSymmetric);

            // Symmetric
            var matrix3 = new Matrix(2, 2);
            matrix3[0, 0] = 1;
            matrix3[0, 1] = 1;
            matrix3[1, 0] = 1;
            matrix3[1, 1] = 1;

            Assert.IsTrue(matrix3.IsSymmetric);

            // Symmetric
            var matrix4 = new Matrix(3, 3);
            matrix4[0, 0] = 1;
            matrix4[0, 1] = 2;
            matrix4[0, 2] = 3;
            matrix4[1, 0] = 2;
            matrix4[1, 1] = -4;
            matrix4[1, 2] = 5;
            matrix4[2, 0] = 3;
            matrix4[2, 1] = 5;
            matrix4[2, 2] = 6;

            Assert.IsTrue(matrix4.IsSymmetric);
        }

        #endregion


        #region Negate

        [Test]
        public void NegateExample()
        {
            var matrix1 = new Matrix(2, 3);
            matrix1[0, 0] = 1;
            matrix1[0, 1] = 4;
            matrix1[0, 2] = 5;
            matrix1[1, 0] = -3;
            matrix1[1, 1] = 2;
            matrix1[1, 2] = 7;

            var expectedMatrix = new Matrix(2, 3);
            expectedMatrix[0, 0] = -1;
            expectedMatrix[0, 1] = -4;
            expectedMatrix[0, 2] = -5;
            expectedMatrix[1, 0] = 3;
            expectedMatrix[1, 1] = -2;
            expectedMatrix[1, 2] = -7;

            var result = matrix1.Negate();

            Assert.IsTrue(result.Equals(expectedMatrix));
        }

        #endregion


        #region GetSubMatrix

        [Test]
        public void GetSubMatrixExample()
        {
            var matrix = new Matrix(3, 3);
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[0, 2] = 3;
            matrix[1, 0] = 4;
            matrix[1, 1] = 5;
            matrix[1, 2] = 6;
            matrix[2, 0] = 7;
            matrix[2, 1] = 8;
            matrix[2, 2] = 9;


            var result1 = matrix.GetSubMatrix(0, 0, 1, 1);

            Assert.AreEqual(1, result1.Rows);
            Assert.AreEqual(1, result1.Columns);

            var result2 = matrix.GetSubMatrix(1, 2, 2, 1);

            Assert.AreEqual(2, result2.Rows);
            Assert.AreEqual(1, result2.Columns);
        }

        #endregion


        #region Clone

        [Test]
        public void CloneExample()
        {
            var matrix = new Matrix(2, 2);
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[1, 0] = 3;
            matrix[1, 1] = 4;
            var clone = matrix.Clone();


            Assert.AreEqual(matrix.Rows, clone.Rows);
            Assert.AreEqual(matrix.Columns, clone.Columns);

            Assert.IsTrue(matrix.Equals(clone));
        }

        #endregion


        #region Minor
        [Test]
        public void MinorExample()
        {
            var matrix = new Matrix(4, 5);
            var minor = matrix.Minor(2, 3);

            // The resulting matrix will have one less column,
            // and one less row.
            Assert.AreEqual(minor.Columns, 4);
            Assert.AreEqual(minor.Rows, 3);
        }
        #endregion


        #region Adjoint
        [Test]
        public void AdjointExample()
        {
            //A = [ a, b ]
            //    [ c, d ]
            var matrix = new Matrix(2, 2);
            matrix[0, 0] = 2;
            matrix[0, 1] = 4;
            matrix[1, 0] = 1;
            matrix[1, 1] = 3;

            var a = matrix.Adjoint();

            // Adj(A) = [ d, -b]
            //          [ -c, a]
            Assert.AreEqual(a[0, 0], 3);
            Assert.AreEqual(a[0, 1], -4);
            Assert.AreEqual(a[1, 0], -1);
            Assert.AreEqual(a[1, 1], 2);
        }
        #endregion

        #region Inverse
        [Test]
        public void InverseExample()
        {
            // [  1, -1,  3 ] -1
            // [  2,  1,  2 ]
            // [ -2, -2,  1 ]

            // Set up the matrix to look like the above sample.
            var matrix = new Matrix(3, 3);
            matrix[0, 0] = 1;
            matrix[0, 1] = -1;
            matrix[0, 2] = 3;

            matrix[1, 0] = 2;
            matrix[1, 1] = 1;
            matrix[1, 2] = 2;

            matrix[2, 0] = -2;
            matrix[2, 1] = -2;
            matrix[2, 2] = 1;

            // Calculate the inverse of the matrix
            var a = matrix.Inverse();

            // The Inverse should be the following :
            // [  1,        -1,   -1 ]
            // [  -(6/5),  7/5,  4/5 ]
            // [  -(2/5),  4/5,  3/5 ]
            var delta = 0.0000001;

            Assert.AreEqual(1, a[0, 0]);
            Assert.AreEqual(-1, a[0, 1], delta);
            Assert.AreEqual(-1, a[0, 2]);

            Assert.AreEqual((6F / 5F) * -1F, a[1, 0], delta);
            Assert.AreEqual(7F / 5F, a[1, 1], delta);
            Assert.AreEqual(4F / 5F, a[1, 2], delta);

            Assert.AreEqual((2F / 5F) * -1F, a[2, 0], delta);
            Assert.AreEqual(4F / 5F, a[2, 1], delta);
            Assert.AreEqual(3F / 5F, a[2, 2], delta);
        }
        #endregion

        #region Concatenate
        [Test]
        public void ConcatenateExample()
        {
            var matrix1 = new Matrix(2, 2);

            // Set up the matrix to look like the following :
            // [1, 2]
            // [3, 4]
            matrix1[0, 0] = 1;
            matrix1[0, 1] = 2;
            matrix1[0, 1] = 3;
            matrix1[0, 1] = 4;

            // Set up the second matrix to look like the following :
            // [5, 6]
            // [7, 8]
            var matrix2 = new Matrix(2, 2);
            matrix1[0, 0] = 5;
            matrix1[0, 1] = 6;
            matrix1[0, 1] = 7;
            matrix1[0, 1] = 8;

            // Concatenate the two matrices
            var concat = matrix1.Concatenate(matrix2);

            // The result looks like this :
            // [1, 2, 5, 6]
            // [3, 4, 7, 8]
            //
            // And the columns have increased to 4, while the rows 
            // stayed the same...
            Assert.AreEqual(4, concat.Columns);
            Assert.AreEqual(2, concat.Rows);
        }
        #endregion

        #region MultiplyColumn
        [Test]
        public void MultiplyColumnExample()
        {
            // Set up a sample matrix to look like this :
            // [1, 2]
            // [3, 4]
            var matrix = new Matrix(2, 2);

            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[1, 0] = 3;
            matrix[1, 1] = 4;
            
            // Multiply the second column by 3
            matrix.MultiplyColumn(1, 3);

            // Now the matrix looks like this :
            // [1,  6]
            // [3, 12]
            Assert.AreEqual(matrix[0, 0], 1);
            Assert.AreEqual(matrix[0, 1], 6);
            Assert.AreEqual(matrix[1, 0], 3);
            Assert.AreEqual(matrix[1, 1], 12);
        }
        #endregion


        #region MultiplyRow
        [Test]
        public void MultiplyRowExample()
        {
            // Set up a sample matrix to look like this :
            // [1, 2]
            // [3, 4]
            var matrix = new Matrix(2, 2);

            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[1, 0] = 3;
            matrix[1, 1] = 4;

            // Multiply the second row by 3
            matrix.MultiplyRow(1, 3);

            // Now the matrix looks like this :
            // [1,  2]
            // [9, 12]
            Assert.AreEqual(matrix[0, 0], 1);
            Assert.AreEqual(matrix[0, 1], 2);
            Assert.AreEqual(matrix[1, 0], 9);
            Assert.AreEqual(matrix[1, 1], 12);
        }
        #endregion

        #region Determinant
        [Test]
        public void DeterminantExample()
        {
            // Set up a sample matrix
            var matrix = new Matrix(3, 3);

            // [ 3,  1,  8 ]
            // [ 2, -5,  4 ]
            // [-1,  6, -2 ]
            // Determinant = 14

            matrix[0, 0] = 3;
            matrix[0, 1] = 1;
            matrix[0, 2] = 8;

            matrix[1, 0] = 2;
            matrix[1, 1] = -5;
            matrix[1, 2] = 4;

            matrix[2, 0] = -1;
            matrix[2, 1] = 6;
            matrix[2, 2] = -2;
            
            // Calculate the determinant - the answer is 14.
            Assert.AreEqual(matrix.Determinant(), 14, 0.000000001);
        }
        #endregion

        #region IsSingular
        [Test]
        public void IsSingularExample()
        {
            // Set up a sample matrix.
            var matrix = new Matrix(3, 3);

            // [ 4,  4,  4 ]
            // [ 4,  4,  4 ]
            // [ 4,  4,  4 ]
            // Determinant = 0

            matrix[0, 0] = 4;
            matrix[0, 1] = 4;
            matrix[0, 2] = 4;

            matrix[1, 0] = 4;
            matrix[1, 1] = 4;
            matrix[1, 2] = 4;

            // The determinant is equal to 0, so the matrix
            // is singular.
            Assert.AreEqual(matrix.IsSingular, true);
        }
        #endregion
    }
}