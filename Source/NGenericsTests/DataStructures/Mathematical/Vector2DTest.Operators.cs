/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/


using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical
{
    public partial class Vector2DTest
    {
        [TestFixture]
        public class DecrementOperator
        {
            [Test]
            public void Simple()
            {
                var vector2D = new Vector2D(4, 7);

                vector2D--;

                Assert.AreEqual(3, vector2D.X);
                Assert.AreEqual(6, vector2D.Y);
            }
        }

        [TestFixture]
        public class DivideOperator
        {
            [Test]
            public void Double()
            {
                var vector2D = new Vector2D(4, 12);
                var vector = vector2D / 2;
                Assert.AreEqual(2, vector.X);
                Assert.AreEqual(6, vector.Y);
                Assert.AreEqual(4, vector2D.X);
                Assert.AreEqual(12, vector2D.Y);
                Assert.AreNotSame(vector2D, vector);
            }

            [Test]
            public void Vector()
            {
                var vector1 = new Vector2D(4, 8);
                var vector2 = new Vector2D(2, 2);
                var vector = vector1 / vector2;
                Assert.AreEqual(1, vector.X);
                Assert.AreEqual(2, vector.Y);
                Assert.AreEqual(4, vector1.X);
                Assert.AreEqual(8, vector1.Y);
                Assert.AreEqual(2, vector2.X);
                Assert.AreEqual(2, vector2.Y);
                Assert.AreNotSame(vector1, vector);
                Assert.AreNotSame(vector2, vector);
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void ExceptionDifferentDimensions()
            {
                var vector2D1 = new Vector2D();
                VectorBase<double> vectorBase = new VectorN(4);
                IVector<double> vector = vector2D1 / vectorBase;
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullLeft()
            {
                var vector2D1 = new Vector2D();
                var vector = null / vector2D1;
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullRight()
            {
                var vector2D1 = new Vector2D();
                var vector = vector2D1 / null;
            }
        }

        [TestFixture]
        public class EqualsOperator
        {
            [Test]
			public void Simple()
            {
                var vector2D1 = new Vector2D {X = 1, Y = 2};
                var vector2D2 = new Vector2D {X = 1, Y = 2};
                Assert.IsTrue(vector2D1 == vector2D2);
                Assert.AreEqual(1, vector2D1.X);
                Assert.AreEqual(2, vector2D1.Y);
                Assert.AreEqual(1, vector2D2.X);
                Assert.AreEqual(2, vector2D2.Y);
            }


            [Test]
            public void LeftNull()
            {
                var vector2D1 = new Vector2D();
                const Vector2D vector2D2 = null;
                Assert.IsFalse(vector2D2 == vector2D1);
            }


            [Test]
            public void ReferenceEquals()
            {
                var vector2D1 = new Vector2D();
                var vector2D2 = vector2D1;
                Assert.IsTrue(vector2D1 == vector2D2);
            }


            [Test]
            public void RightNull()
            {
                var vector1 = new Vector2D();
                const Vector2D vector2 = null;
                Assert.IsFalse(vector1 == vector2);
            }
        }

        [TestFixture]
        public class FromMatrixOperator
        {
            [Test]
            public void Simple2()
            {

                var matrix = new Matrix(2, 1);
                matrix[0, 0] = 7;
                matrix[1, 0] = 4;

                var actual = (Vector2D) matrix;

                Assert.AreEqual(7, actual.X);
                Assert.AreEqual(4, actual.Y);
            }

            [Test]
            public void Simple1()
            {

                var matrix = new Matrix(1, 1);
                matrix[0, 0] = 7;

                var actual = (Vector2D) matrix;

                Assert.AreEqual(7, actual.X);
                Assert.AreEqual(0, actual.Y);
            }


            [Test]
            [ExpectedException(typeof(InvalidCastException))]
            public void ExceptionInvalidColumns()
            {

                var matrix = new Matrix(2, 2);
                var actual = (Vector2D) matrix;

            }

            [Test]
            [ExpectedException(typeof(InvalidCastException))]
            public void ExceptionInvalidRows()
            {

                var matrix = new Matrix(3, 1);
                var actual = (Vector2D) matrix;

            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullMatrix()
            {
                const Matrix matrix = null;
                var actual = (Vector2D) matrix;
            }
        }

        [TestFixture]
        public class GreaterThanOperator
        {
            [Test]
			public void Simple()
            {
                var vector1 = new Vector2D(1, 1);
                var vector2 = new Vector2D(2, 2);
                var vector3 = new Vector2D(2, 2);

                Assert.IsFalse(vector1 > vector2);
                Assert.IsTrue(vector2 > vector1);
                Assert.IsFalse(vector2 > vector3);
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionLeftNull()
            {
                const Vector2D vector1 = null;
                var vector2 = new Vector2D(2, 2);

                var condition = vector1 > vector2;
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionRightNull()
            {
                var vector1 = new Vector2D(2, 2);
                const Vector2D vector2 = null;

                var condition = vector1 > vector2;
            }
        }

        [TestFixture]
        public class GreaterThanEqualToOperator
        {
            [Test]
            public void Simple()
            {
                var vector1 = new Vector2D(1, 1);
                var vector2 = new Vector2D(2, 2);
                var vector3 = new Vector2D(2, 2);

                Assert.IsFalse(vector1 >= vector2);
                Assert.IsTrue(vector2 >= vector1);
                Assert.IsTrue(vector2 >= vector3);
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionLeftNull()
            {
                const Vector2D vector1 = null;
                var vector2 = new Vector2D(2, 2);

                var condition = vector1 >= vector2;
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionRightNull()
            {
                var vector1 = new Vector2D(2, 2);
                const Vector2D vector2 = null;

                var condition = vector1 >= vector2;
            }
        }

        [TestFixture]
        public class IncrementOperator
        {
            [Test]
            public void Simple()
            {
                var vector = new Vector2D(4, 7);

                vector++;

                Assert.AreEqual(5, vector.X);
                Assert.AreEqual(8, vector.Y);
            }
        }

        [TestFixture]
        public class LessThanOperator
        {
            [Test]
			public void Simple()
            {
                var vector1 = new Vector2D(1, 1);
                var vector2 = new Vector2D(2, 2);
                var vector3 = new Vector2D(2, 2);

                Assert.IsTrue(vector1 < vector2);
                Assert.IsFalse(vector2 < vector1);
                Assert.IsFalse(vector2 < vector3);
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionLeftNull()
            {
                const Vector2D vector1 = null;
                var vector2 = new Vector2D(2, 2);

                var condition = vector1 < vector2;
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionRightNull()
            {
                var vector1 = new Vector2D(2, 2);
                const Vector2D vector2 = null;

                var condition = vector1 < vector2;
            }
        }

        [TestFixture]
        public class LessThanEqualToOperator
        {
            [Test]
            public void Simple()
            {
                var vector1 = new Vector2D(1, 1);
                var vector2 = new Vector2D(2, 2);
                var vector3 = new Vector2D(2, 2);

                Assert.IsTrue(vector1 <= vector2);
                Assert.IsFalse(vector2 <= vector1);
                Assert.IsTrue(vector2 <= vector3);
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionLeftNull()
            {
                const Vector2D vector1 = null;
                var vector2 = new Vector2D(2, 2);

                var condition = vector1 <= vector2;
            }
            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionRightNull()
            {
                var vector1 = new Vector2D(2, 2);
                const Vector2D vector2 = null;

                var condition = vector1 <= vector2;
            }
        }

        [TestFixture]
        public class MultiplyOperator
        {
            [Test]
            public void Double()
            {
                var vector2D = new Vector2D(4, 7);
                var vector = vector2D * 2;
                Assert.AreEqual(8, vector.X);
                Assert.AreEqual(14, vector.Y);
                Assert.AreEqual(4, vector2D.X);
                Assert.AreEqual(7, vector2D.Y);
                Assert.AreNotSame(vector2D, vector);
            }


            [Test]
            public void Vector()
            {
                var vector2D1 = new Vector2D(4, 7);
                var vector2D2 = new Vector2D(3, 4);
                var matrix = vector2D1 * vector2D2;
                Assert.AreEqual(2, matrix.Columns);
                Assert.AreEqual(2, matrix.Rows);

                Assert.AreEqual(12, matrix[0, 0]);
                Assert.AreEqual(16, matrix[0, 1]);
                Assert.AreEqual(21, matrix[1, 0]);
                Assert.AreEqual(28, matrix[1, 1]);

                Assert.AreEqual(4, vector2D1.X);
                Assert.AreEqual(7, vector2D1.Y);
                Assert.AreEqual(3, vector2D2.X);
                Assert.AreEqual(4, vector2D2.Y);
            }


            [Test]
            [ExpectedException(typeof(ArgumentException))]
			public void ExceptionDifferentDimensions()
            {
                var vector2D1 = new Vector2D();
                VectorBase<double> vectorBase = new VectorN(4);
                var matrix = vector2D1 * vectorBase;
            }


            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionLeftNull()
            {
                var vector2D1 = new Vector2D();
                var matrix = null * vector2D1;
            }


            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionRightNull()
            {
                var vector2D1 = new Vector2D();
                var matrix = vector2D1 * null;
            }
        }

        [TestFixture]
        public class NegateOperator
        {
            [Test]
			public void Simple()
            {
                var vector2D = new Vector2D {X = 1, Y = 2};
                var vector = -vector2D;
                Assert.AreEqual(-1, vector.X);
                Assert.AreEqual(-2, vector.Y);
                Assert.AreEqual(1, vector2D.X);
                Assert.AreEqual(2, vector2D.Y);
                Assert.AreNotSame(vector2D, vector);
            }

        }

        [TestFixture]
        public class NotEqualsOperator
        {
            [Test]
			public void Simple()
            {
                var vector2D1 = new Vector2D(1, 2);
                var vector2D2 = new Vector2D(1, 2);
                Assert.IsFalse(vector2D1 != vector2D2);
                Assert.AreEqual(1, vector2D1.X);
                Assert.AreEqual(2, vector2D1.Y);
                Assert.AreEqual(1, vector2D2.X);
                Assert.AreEqual(2, vector2D2.Y);
            }
        }

        [TestFixture]
        public class PlusOperator
        {
            [Test]
            public void Double()
            {
                var vector2D = new Vector2D(4, 7);
                var vector = vector2D + 2;
                Assert.AreEqual(6, vector.X);
                Assert.AreEqual(9, vector.Y);
                Assert.AreEqual(4, vector2D.X);
                Assert.AreEqual(7, vector2D.Y);
                Assert.AreNotSame(vector2D, vector);
            }


            [Test]
            public void Vector()
            {
                var vector1 = new Vector2D(4, 7);
                var vector2 = new Vector2D(3, 4);
                var vector = vector1 + vector2;
                Assert.AreEqual(7, vector.X);
                Assert.AreEqual(11, vector.Y);
                Assert.AreEqual(4, vector1.X);
                Assert.AreEqual(7, vector1.Y);
                Assert.AreEqual(3, vector2.X);
                Assert.AreEqual(4, vector2.Y);
                Assert.AreNotSame(vector1, vector);
                Assert.AreNotSame(vector2, vector);
            }


            [Test]
            [ExpectedException(typeof(ArgumentException))]
			public void ExceptionDifferentDimensions()
            {
                var vector2D = new Vector2D();
                var vector3D = new Vector3D();
                IVector<double> vector = vector2D + vector3D;
            }


            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionLeftNull()
            {
                var vector2D1 = new Vector2D();
                var vector = null + vector2D1;
            }


            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionRightNull()
            {
                var vector2D1 = new Vector2D();
                var vector = vector2D1 + null;
            }
        }

        [TestFixture]
        public class SubtractOperator
        {
            [Test]
            public void Double()
            {
                var vector2D = new Vector2D(4, 7);
                var vector = vector2D - 2;
                Assert.AreEqual(2, vector.X);
                Assert.AreEqual(5, vector.Y);
                Assert.AreEqual(4, vector2D.X);
                Assert.AreEqual(7, vector2D.Y);
                Assert.AreNotSame(vector2D, vector);
            }


            [Test]
            public void Vector()
            {
                var vector2D1 = new Vector2D(4, 7);
                var vector2D2 = new Vector2D(3, 4);
                var vector = vector2D1 - vector2D2;
                Assert.AreEqual(1, vector.X);
                Assert.AreEqual(3, vector.Y);
                Assert.AreEqual(4, vector2D1.X);
                Assert.AreEqual(7, vector2D1.Y);
                Assert.AreEqual(3, vector2D2.X);
                Assert.AreEqual(4, vector2D2.Y);
                Assert.AreNotSame(vector2D1, vector);
                Assert.AreNotSame(vector2D2, vector);
            }


            [Test]
            [ExpectedException(typeof(ArgumentException))]
			public void ExceptionDifferentDimensions()
            {
                var vector2D = new Vector2D();
                var vector3D = new Vector3D();
                IVector<double> vector = vector2D - vector3D;
            }


            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionLeftNull()
            {
                var vector2D1 = new Vector2D();
                var vector = null - vector2D1;
            }


            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionRightNull()
            {
                var vector2D1 = new Vector2D();
                var vector = vector2D1 - null;
            }
        }
                
        [TestFixture]
        public class ToMatrixOperator
        {
            [Test]
			public void Simple()
            {
                var vector = new Vector2D(8, 3);

                Matrix actual = vector;

                Assert.AreEqual(2, actual.Rows);
                Assert.AreEqual(1, actual.Columns);

                Assert.AreEqual(8, actual[0, 0]);
                Assert.AreEqual(3, actual[1, 0]);
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullVector()
            {
                const Vector2D vector = null;
                Matrix actual = vector;
            }
        }

    }
}