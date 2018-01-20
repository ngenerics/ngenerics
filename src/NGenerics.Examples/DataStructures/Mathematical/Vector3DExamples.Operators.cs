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
    public partial class Vector3DExamples
    {
        #region OperatorDecrement

        [Test]
        public void OperatorDecrementExample()
        {
            var vector3D = new Vector3D(4, 7, 8);

            vector3D--;

            Assert.AreEqual(3, vector3D.X);
            Assert.AreEqual(6, vector3D.Y);
            Assert.AreEqual(7, vector3D.Z);
        }

        #endregion


        #region OperatorDivideDouble

        [Test]
        public void OperatorDivideDoubleExample()
        {
            var vector3D1 = new Vector3D(4, 12, 8);

            var vector = vector3D1/2;

            Assert.AreEqual(2, vector.X);
            Assert.AreEqual(6, vector.Y);
            Assert.AreEqual(4, vector.Z);

        }

        #endregion


        #region OperatorDivideVector

        [Test]
        public void OperatorDivideVectorExample()
        {
            var vector3D1 = new Vector3D(24, 48, 72);

            var vector3D2 = new Vector3D(2, 3, 4);

            var vector = vector3D1/vector3D2;

            Assert.AreEqual(1, vector.X);
            Assert.AreEqual(2, vector.Y);
            Assert.AreEqual(3, vector.Z);

        }

        #endregion


        #region OperatorEquals

        [Test]
        public void OperatorEqualsExample()
        {
            var vector3D1 = new Vector3D(1, 2, 6);
            var vector3D2 = new Vector3D(1, 2, 6);
            Assert.IsTrue(vector3D1 == vector3D2);
        }

        #endregion


        #region OperatorGreaterThan

        [Test]
        public void OperatorGreaterThanExample()
        {
            var vector1 = new Vector2D(2, 2);
            var vector2 = new Vector2D(1, 1);
            var vector3 = new Vector2D(2, 2);
            var vector4 = new Vector2D(3, 3);

            Assert.IsTrue(vector1 > vector2);

            Assert.IsFalse(vector1 > vector3);

            Assert.IsFalse(vector1 > vector4);
        }

        #endregion


        #region OperatorGreaterThanOrEqualTo

        [Test]
        public void OperatorGreaterThanOrEqualToExample()
        {
            var vector1 = new Vector2D(2, 2);
            var vector2 = new Vector2D(1, 1);
            var vector3 = new Vector2D(2, 2);
            var vector4 = new Vector2D(3, 3);

            Assert.IsTrue(vector1 >= vector2);

            Assert.IsTrue(vector1 >= vector3);

            Assert.IsFalse(vector1 >= vector4);
        }

        #endregion


        #region OperatorLessThan

        [Test]
        public void OperatorLessThanExample()
        {
            var vector1 = new Vector2D(2, 2);
            var vector2 = new Vector2D(1, 1);
            var vector3 = new Vector2D(2, 2);
            var vector4 = new Vector2D(3, 3);

            Assert.IsFalse(vector1 < vector2);

            Assert.IsFalse(vector1 < vector3);

            Assert.IsTrue(vector1 < vector4);
        }

        #endregion


        #region OperatorLessThanOrEqualTo

        [Test]
        public void OperatorLessThanOrEqualToExample()
        {
            var vector1 = new Vector2D(2, 2);
            var vector2 = new Vector2D(1, 1);
            var vector3 = new Vector2D(2, 2);
            var vector4 = new Vector2D(3, 3);

            Assert.IsFalse(vector1 <= vector2);

            Assert.IsTrue(vector1 <= vector3);

            Assert.IsTrue(vector1 <= vector4);
        }

        #endregion


        #region OperatorIncrement

        [Test]
        public void OperatorIncrementExample()
        {
            var vector3D = new Vector3D(4, 7, 8);

            vector3D++;

            Assert.AreEqual(5, vector3D.X);
            Assert.AreEqual(8, vector3D.Y);
            Assert.AreEqual(9, vector3D.Z);
        }

        #endregion


        #region OperatorMultiplyDouble

        [Test]
        public void OperatorMultiplyDoubleExample()
        {
            var vector3D1 = new Vector3D(4, 7, 8);
            var vector = vector3D1*2;
            Assert.AreEqual(8, vector.X);
            Assert.AreEqual(14, vector.Y);
            Assert.AreEqual(16, vector.Z);
        }

        #endregion


        #region OperatorMultiplyVector

        [Test]
        public void OperatorMultiplyVectorExample()
        {
            var vector3D1 = new Vector3D(4, 7, 2);

            var vector3D2 = new Vector3D(3, 4, 9);

            var matrix = vector3D1*vector3D2;
            Assert.AreEqual(3, matrix.Columns);
            Assert.AreEqual(3, matrix.Rows);

            Assert.AreEqual(12, matrix[0, 0]);
            Assert.AreEqual(16, matrix[0, 1]);
            Assert.AreEqual(36, matrix[0, 2]);

            Assert.AreEqual(21, matrix[1, 0]);
            Assert.AreEqual(28, matrix[1, 1]);
            Assert.AreEqual(63, matrix[1, 2]);

            Assert.AreEqual(6, matrix[2, 0]);
            Assert.AreEqual(8, matrix[2, 1]);
            Assert.AreEqual(18, matrix[2, 2]);
        }

        #endregion


        #region OperatorNegate

        [Test]
        public void OperatorNegateExample()
        {
            var vector3D1 = new Vector3D(1, 2, 3);
            var vector = -vector3D1;
            Assert.AreEqual(-1, vector.X);
            Assert.AreEqual(-2, vector.Y);
            Assert.AreEqual(-3, vector.Z);
        }

        #endregion


        #region OperatorNotEquals

        [Test]
        public void OperatorNotEqualsExample()
        {
            var vector3D1 = new Vector3D(1, 2, 5);
            var vector3D2 = new Vector3D(1, 2, 5);
            Assert.IsFalse(vector3D1 != vector3D2);
        }

        #endregion


        #region OperatorPlusDouble

        [Test]
        public void OperatorPlusDoubleExample()
        {
            var vector3D1 = new Vector3D(4, 7, 8);
            var vector = vector3D1 + 2;
            Assert.AreEqual(6, vector.X);
            Assert.AreEqual(9, vector.Y);
            Assert.AreEqual(10, vector.Z);
        }

        #endregion


        #region OperatorPlusVector

        [Test]
        public void OperatorPlusVectorExample()
        {
            var vector3D1 = new Vector3D(4, 7, 9);
            var vector3D2 = new Vector3D(3, 4, 1);
            var vector = vector3D1 + vector3D2;
            Assert.AreEqual(7, vector.X);
            Assert.AreEqual(11, vector.Y);
            Assert.AreEqual(10, vector.Z);
        }

        #endregion


        #region OperatorSubtractDouble

        [Test]
        public void OperatorSubtractDoubleExample()
        {
            var vector3D = new Vector3D(4, 7, 6);
            var vector = vector3D - 2;

            Assert.AreEqual(2, vector.X);
            Assert.AreEqual(5, vector.Y);
            Assert.AreEqual(4, vector.Z);

        }

        #endregion


        #region OperatorSubtractVector

        [Test]
        public void OperatorSubtractVectorExample()
        {
            var vector3D1 = new Vector3D(4, 7, 8);
            var vector3D2 = new Vector3D(3, 4, 2);
            var vector = vector3D1 - vector3D2;

            Assert.AreEqual(1, vector.X);
            Assert.AreEqual(3, vector.Y);
            Assert.AreEqual(6, vector.Z);
        }

        #endregion


        #region OperatorToMatrix

        [Test]
        public void OperatorToMatrixExample()
        {
            var vector = new Vector3D(8, 3, 7);

            Matrix actual = vector;

            Assert.AreEqual(3, actual.Rows);
            Assert.AreEqual(1, actual.Columns);

            Assert.AreEqual(8, actual[0, 0]);
            Assert.AreEqual(3, actual[1, 0]);
            Assert.AreEqual(7, actual[2, 0]);
        }

        #endregion


        #region OperatorFromMatrix

        [Test]
        public void OperatorFromMatrixExample()
        {
            var matrix = new Matrix(3, 1);
            matrix[0, 0] = 7;
            matrix[1, 0] = 4;
            matrix[2, 0] = 8;

            var actual = (Vector3D) matrix;

            Assert.AreEqual(7, actual.X);
            Assert.AreEqual(4, actual.Y);
            Assert.AreEqual(8, actual.Z);
        }

        #endregion

    }
}