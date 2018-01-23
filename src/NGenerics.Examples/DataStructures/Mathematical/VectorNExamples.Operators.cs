/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/



using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Examples.DataStructures.Mathematical
{
    public partial class VectorNExamples
    {
        #region OperatorGreaterThan

        [Test]
        public void OperatorGreaterThanExample()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(2, 2);

            var vector2 = new VectorN(2);
            vector2.SetValues(1, 1);

            var vector3 = new VectorN(2);
            vector3.SetValues(2, 2);

            var vector4 = new VectorN(2);
            vector4.SetValues(3, 3);

            Assert.IsTrue(vector1 > vector2);

            Assert.IsFalse(vector1 > vector3);

            Assert.IsFalse(vector1 > vector4);
        }

        #endregion


        #region OperatorGreaterThanOrEqualTo

        [Test]
        public void OperatorGreaterThanOrEqualToExample()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(2, 2);

            var vector2 = new VectorN(2);
            vector2.SetValues(1, 1);

            var vector3 = new VectorN(2);
            vector3.SetValues(2, 2);

            var vector4 = new VectorN(2);
            vector4.SetValues(3, 3);

            Assert.IsTrue(vector1 >= vector2);

            Assert.IsTrue(vector1 >= vector3);

            Assert.IsFalse(vector1 >= vector4);
        }

        #endregion


        #region OperatorLessThan

        [Test]
        public void OperatorLessThanExample()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(2, 2);

            var vector2 = new VectorN(2);
            vector2.SetValues(1, 1);

            var vector3 = new VectorN(2);
            vector3.SetValues(2, 2);

            var vector4 = new VectorN(2);
            vector4.SetValues(3, 3);

            Assert.IsFalse(vector1 < vector2);

            Assert.IsFalse(vector1 < vector3);

            Assert.IsTrue(vector1 < vector4);
        }

        #endregion


        #region OperatorLessThanOrEqualTo

        [Test]
        public void OperatorLessThanOrEqualToExample()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(2, 2);

            var vector2 = new VectorN(2);
            vector2.SetValues(1, 1);

            var vector3 = new VectorN(2);
            vector3.SetValues(2, 2);

            var vector4 = new VectorN(2);
            vector4.SetValues(3, 3);

            Assert.IsFalse(vector1 <= vector2);

            Assert.IsTrue(vector1 <= vector3);

            Assert.IsTrue(vector1 <= vector4);
        }

        #endregion


        #region OperatorDecrement

        [Test]
        public void OperatorDecrementExample()
        {
            VectorBase<double> vector1 = new VectorN(2);
            vector1.SetValues(4, 7);

            vector1--;

            Assert.AreEqual(3, vector1[0]);
            Assert.AreEqual(6, vector1[1]);
        }

        #endregion


        #region OperatorDivideDouble

        [Test]
        public void OperatorDivideDoubleExample()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(4, 12);
            IVector<double> vector = vector1/2;
            Assert.AreEqual(2, vector[0]);
            Assert.AreEqual(6, vector[1]);
            Assert.AreEqual(4, vector1[0]);
            Assert.AreEqual(12, vector1[1]);
            Assert.AreNotSame(vector1, vector);
        }

        #endregion


        #region OperatorDivideVector

        [Test]
        public void OperatorDivideVectorExample()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(4, 8);
            var vector2 = new VectorN(2);
            vector2.SetValues(2, 2);
            IVector<double> vector = vector1/vector2;
            Assert.AreEqual(2, vector[0]);
            Assert.AreEqual(4, vector[1]);
            Assert.AreEqual(4, vector1[0]);
            Assert.AreEqual(8, vector1[1]);
            Assert.AreEqual(2, vector2[0]);
            Assert.AreEqual(2, vector2[1]);
            Assert.AreNotSame(vector1, vector);
            Assert.AreNotSame(vector2, vector);
        }

        #endregion


        #region OperatorEquals

        [Test]
        public void OperatorEqualsExample()
        {
            var vector1 = new VectorN(2);
            vector1[0] = 1;
            vector1[1] = 2;
            var vector2 = new VectorN(2);
            vector2[0] = 1;
            vector2[1] = 2;
            Assert.IsTrue(vector1 == vector2);
        }

        #endregion


        #region OperatorIncrement

        [Test]
        public void OperatorIncrementExample()
        {
            VectorBase<double> vector1 = new VectorN(2);
            vector1.SetValues(4, 7);

            vector1++;

            Assert.AreEqual(5, vector1[0]);
            Assert.AreEqual(8, vector1[1]);
        }

        #endregion


        #region OperatorMultiplyDouble

        [Test]
        public void OperatorMultiplyDoubleExample()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(4, 7);

            var vector = vector1*2;

            Assert.AreEqual(8, vector[0]);
            Assert.AreEqual(14, vector[1]);

            Assert.AreEqual(4, vector1[0]);
            Assert.AreEqual(7, vector1[1]);

            Assert.AreNotSame(vector1, vector);
        }

        #endregion


        #region OperatorMultiplyVector

        [Test]
        public void OperatorMultiplyVectorExample()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(4, 7);
            var vector2 = new VectorN(2);
            vector2.SetValues(3, 4);

            var matrix = vector1*vector2;

            Assert.AreEqual(2, matrix.Columns);
            Assert.AreEqual(2, matrix.Rows);

            Assert.AreEqual(12, matrix[0, 0]);
            Assert.AreEqual(16, matrix[0, 1]);
            Assert.AreEqual(21, matrix[1, 0]);
            Assert.AreEqual(28, matrix[1, 1]);
        }

        #endregion


        #region OperatorNegate

        [Test]
        public void OperatorNegateExample()
        {
            var vector1 = new VectorN(2);
            vector1[0] = 1;
            vector1[1] = 2;

            IVector<double> vector = -vector1;

            Assert.AreEqual(-1, vector[0]);
            Assert.AreEqual(-2, vector[1]);

            Assert.AreEqual(1, vector1[0]);
            Assert.AreEqual(2, vector1[1]);

            Assert.AreNotSame(vector1, vector);
        }

        #endregion


        #region OperatorNotEquals

        [Test]
        public void OperatorNotEqualsExample()
        {
            var vector1 = new VectorN(2);
            vector1[0] = 1;
            vector1[1] = 2;

            var vector2 = new VectorN(2);
            vector2[0] = 1;
            vector2[1] = 2;

            Assert.IsFalse(vector1 != vector2);
        }

        #endregion


        #region OperatorPlusDouble

        [Test]
        public void OperatorPlusDoubleExample()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(4, 7);

            IVector<double> vector = vector1 + 2;

            Assert.AreEqual(6, vector[0]);
            Assert.AreEqual(9, vector[1]);

            Assert.AreEqual(4, vector1[0]);
            Assert.AreEqual(7, vector1[1]);

            Assert.AreNotSame(vector1, vector);
        }

        #endregion


        #region OperatorPlusVector

        [Test]
        public void OperatorPlusVectorExample()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(4, 7);

            var vector2 = new VectorN(2);
            vector2.SetValues(3, 4);

            IVector<double> vector = vector1 + vector2;

            Assert.AreEqual(7, vector[0]);
            Assert.AreEqual(11, vector[1]);

            Assert.AreEqual(4, vector1[0]);
            Assert.AreEqual(7, vector1[1]);
            Assert.AreEqual(3, vector2[0]);
            Assert.AreEqual(4, vector2[1]);

            Assert.AreNotSame(vector1, vector);
            Assert.AreNotSame(vector2, vector);
        }

        #endregion


        #region OperatorSubtractDouble

        [Test]
        public void OperatorSubtractDoubleExample()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(4, 7);

            IVector<double> vector = vector1 - 2;

            Assert.AreEqual(2, vector[0]);
            Assert.AreEqual(5, vector[1]);

            Assert.AreEqual(4, vector1[0]);
            Assert.AreEqual(7, vector1[1]);

            Assert.AreNotSame(vector1, vector);
        }

        #endregion


        #region OperatorSubtractVector

        [Test]
        public void OperatorSubtractVectorExample()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(4, 7);

            var vector2 = new VectorN(2);
            vector2.SetValues(3, 4);

            IVector<double> vector = vector1 - vector2;
            Assert.AreEqual(1, vector[0]);
            Assert.AreEqual(3, vector[1]);

            Assert.AreEqual(4, vector1[0]);
            Assert.AreEqual(7, vector1[1]);
            Assert.AreEqual(3, vector2[0]);
            Assert.AreEqual(4, vector2[1]);

            Assert.AreNotSame(vector1, vector);
            Assert.AreNotSame(vector2, vector);
        }

        #endregion


        #region OperatorToMatrix

        [Test]
        public void OperatorToMatrixExample()
        {
            var vector = new VectorN(2);
            vector.SetValues(8, 3);

            Matrix actual = vector;

            Assert.AreEqual(2, actual.Rows);
            Assert.AreEqual(1, actual.Columns);

            Assert.AreEqual(8, actual[0, 0]);
            Assert.AreEqual(3, actual[1, 0]);
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

            var actual = (VectorN)matrix;

            Assert.AreEqual(7, actual[0]);
            Assert.AreEqual(4, actual[1]);
            Assert.AreEqual(8, actual[2]);
        }

        #endregion
    }
}