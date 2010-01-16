/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace ExampleLibraryCSharp.DataStructures.Mathematical
{
    public partial class Vector2DExamples
    {


        #region OperatorDecrement

        [Test]
        public void OperatorDecrementExample()
        {
            var vector2D = new Vector2D(4, 7);

            vector2D--;

            Assert.AreEqual(3, vector2D.X);
            Assert.AreEqual(6, vector2D.Y);
        }

        #endregion


        #region OperatorDivideDouble

        [Test]
        public void OperatorDivideDoubleExample()
        {
            var vector2D = new Vector2D(4, 12);
            var vector = vector2D/2;
            Assert.AreEqual(2, vector.X);
            Assert.AreEqual(6, vector.Y);
        }

        #endregion


        #region OperatorDivideVector

        [Test]
        public void OperatorDivideVectorExample()
        {
            var vector2D1 = new Vector2D(4, 8);
            var vector2D2 = new Vector2D(2, 2);
            var vector = vector2D1/vector2D2;
            Assert.AreEqual(1, vector.X);
            Assert.AreEqual(2, vector.Y);
        }

        #endregion


        #region OperatorEquals

        [Test]
        public void OperatorEqualsExample()
        {
            var vector2D1 = new Vector2D {X = 1, Y = 2};
            var vector2D2 = new Vector2D {X = 1, Y = 2};
            Assert.IsTrue(vector2D1 == vector2D2);
        }

        #endregion


        #region OperatorGreaterThan

        [Test]
        public void OperatorGreaterThanExample()
        {
            var vector1 = new Vector2D(2,2);
            var vector2 = new Vector2D(1,1);
            var vector3 = new Vector2D(2,2);
            var vector4 = new Vector2D(3,3);

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
            var vector2D = new Vector2D(4, 7);

            vector2D++;

            Assert.AreEqual(5, vector2D.X);
            Assert.AreEqual(8, vector2D.Y);
        }

        #endregion


        #region OperatorMultiplyDouble

        [Test]
        public void OperatorMultiplyDoubleExample()
        {
            var vector2D = new Vector2D(4, 7);
            var vector = vector2D*2;
            Assert.AreEqual(8, vector.X);
            Assert.AreEqual(14, vector.Y);
        }

        #endregion


        #region OperatorMultiplyVector

        [Test]
        public void OperatorMultiplyVectorExample()
        {
            var vector2D1 = new Vector2D(4, 7);
            var vector2D2 = new Vector2D(3, 4);
            var matrix = vector2D1*vector2D2;
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
            var vector2D = new Vector2D {X = 1, Y = 2};
            var vector = -vector2D;
            Assert.AreEqual(-1, vector.X);
            Assert.AreEqual(-2, vector.Y);
        }

        #endregion


        #region OperatorNotEquals

        [Test]
        public void OperatorNotEqualsExample()
        {
            var vector2D1 = new Vector2D {X = 1, Y = 2};
            var vector2D2 = new Vector2D {X = 1, Y = 2};
            Assert.IsFalse(vector2D1 != vector2D2);
        }

        #endregion


        #region OperatorPlusDouble

        [Test]
        public void OperatorPlusDoubleExample()
        {
            var vector2D = new Vector2D(4, 7);
            var vector = vector2D + 2;
            Assert.AreEqual(6, vector.X);
            Assert.AreEqual(9, vector.Y);
        }

        #endregion


        #region OperatorPlusVector

        [Test]
        public void OperatorPlusVectorExample()
        {
            var vector2D1 = new Vector2D(4, 7);
            var vector2D2 = new Vector2D(3, 4);
            var vector = vector2D1 + vector2D2;
            Assert.AreEqual(7, vector.X);
            Assert.AreEqual(11, vector.Y);
        }

        #endregion


        #region OperatorSubtractDouble

        [Test]
        public void OperatorSubtractDoubleExample()
        {
            var vector2D = new Vector2D(4, 7);
            var vector = vector2D - 2;
            Assert.AreEqual(2, vector.X);
            Assert.AreEqual(5, vector.Y);
        }

        #endregion


        #region OperatorSubtractVector

        [Test]
        public void OperatorSubtractVectorExample()
        {
            var vector2D1 = new Vector2D(4, 7);
            var vector2D2 = new Vector2D(3, 4);
            var vector = vector2D1 - vector2D2;
            Assert.AreEqual(1, vector.X);
            Assert.AreEqual(3, vector.Y);
        }

        #endregion


        #region OperatorToMatrix

        [Test]
        public void OperatorToMatrixExample()
        {
            var vector = new Vector2D(8, 3);

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
            var matrix = new Matrix(2, 1);
            matrix[0, 0] = 7;
            matrix[1, 0] = 4;

            var actual = (Vector2D) matrix;

            Assert.AreEqual(7, actual.X);
            Assert.AreEqual(4, actual.Y);
        }

        #endregion


    }
}