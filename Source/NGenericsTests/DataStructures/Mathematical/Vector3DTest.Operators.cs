/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical
{

	[TestFixture]
	public class Vector3DTestOperator
	{
		[TestFixture]
		public class DecrementOperator
		{
			[Test]
			public void Simple()
			{
				var vector3D = new Vector3D(4, 7, 8);

				vector3D--;

				Assert.AreEqual(3, vector3D.X);
				Assert.AreEqual(6, vector3D.Y);
				Assert.AreEqual(7, vector3D.Z);
			}
		}

		[TestFixture]
		public class DivideOperator
		{
			[Test]
			public void Double()
			{
				var vector3D1 = new Vector3D(4, 12, 8);

				var vector = vector3D1 / 2;

				Assert.AreEqual(2, vector.X);
				Assert.AreEqual(6, vector.Y);
				Assert.AreEqual(4, vector.Z);

				Assert.AreNotSame(vector3D1, vector);

				Assert.AreEqual(4, vector3D1.X);
				Assert.AreEqual(12, vector3D1.Y);
				Assert.AreEqual(8, vector3D1.Z);
			}


			[Test]
			public void Vector()
			{
				var vector1 = new Vector3D(24, 48, 72);

				var vector2 = new Vector3D(2, 3, 4);

				var vector = vector1 / vector2;

				Assert.AreEqual(1, vector.X);
				Assert.AreEqual(2, vector.Y);
				Assert.AreEqual(3, vector.Z);

				Assert.AreNotSame(vector1, vector);
				Assert.AreNotSame(vector2, vector);

				Assert.AreEqual(24, vector1.X);
				Assert.AreEqual(48, vector1.Y);
				Assert.AreEqual(72, vector1.Z);

				Assert.AreEqual(2, vector2.X);
				Assert.AreEqual(3, vector2.Y);
				Assert.AreEqual(4, vector2.Z);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionDifferentDimensions()
			{
				var vector3D1 = new Vector3D();
				VectorBase<double> vectorBase = new VectorN(4);
				IVector<double> vector = vector3D1 / vectorBase;
			}


			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullLeft()
			{
				var vector3D1 = new Vector3D();
				var vector = null / vector3D1;
			}


			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullRight()
			{
				var vector3D1 = new Vector3D();
				var vector = vector3D1 / null;
			}
		}

		[TestFixture]
		public class EqualsOperator
		{
			[Test]
			public void Simple()
			{
				var vector3D1 = new Vector3D(1, 2, 6);
				var vector3D2 = new Vector3D(1, 2, 6);
				Assert.IsTrue(vector3D1 == vector3D2);
				Assert.AreEqual(1, vector3D1.X);
				Assert.AreEqual(2, vector3D1.Y);
				Assert.AreEqual(6, vector3D1.Z);
				Assert.AreEqual(1, vector3D2.X);
				Assert.AreEqual(2, vector3D2.Y);
				Assert.AreEqual(6, vector3D2.Z);
			}


			[Test]
			public void LeftNull()
			{
				var vector3D1 = new Vector3D();
				const Vector3D vector3D2 = null;
				Assert.IsFalse(vector3D2 == vector3D1);
			}


			[Test]
			public void ReferenceEquals()
			{
				var vector3D1 = new Vector3D();
				var vector3D2 = vector3D1;
				Assert.IsTrue(vector3D1 == vector3D2);
			}


			[Test]
			public void RightNull()
			{
				var vector3D1 = new Vector3D();
				const Vector3D vector3D2 = null;
				Assert.IsFalse(vector3D1 == vector3D2);
			}
		}

		[TestFixture]
		public class FromMatrixOperator
		{
			[Test]
			public void Simple3D()
			{

				var matrix = new Matrix(3, 1);
				matrix[0, 0] = 7;
				matrix[1, 0] = 4;
				matrix[2, 0] = 8;

				var actual = (Vector3D)matrix;

				Assert.AreEqual(7, actual.X);
				Assert.AreEqual(4, actual.Y);
				Assert.AreEqual(8, actual.Z);
			}

			[Test]
			public void Simple2D()
			{

				var matrix = new Matrix(2, 1);
				matrix[0, 0] = 7;
				matrix[1, 0] = 4;

				var actual = (Vector3D)matrix;

				Assert.AreEqual(7, actual.X);
				Assert.AreEqual(4, actual.Y);
				Assert.AreEqual(0, actual.Z);
			}

			[Test]
			public void Simple1D()
			{

				var matrix = new Matrix(1, 1);
				matrix[0, 0] = 7;

				var actual = (Vector3D)matrix;

				Assert.AreEqual(7, actual.X);
				Assert.AreEqual(0, actual.Y);
				Assert.AreEqual(0, actual.Z);
			}


			[Test]
			[ExpectedException(typeof(InvalidCastException))]
			public void ExceptionInvalidColumns()
			{

				var matrix = new Matrix(2, 2);
				var actual = (Vector3D)matrix;

			}


			[Test]
			[ExpectedException(typeof(InvalidCastException))]
			public void ExceptionInvalidRows()
			{

				var matrix = new Matrix(4, 1);
				var actual = (Vector3D)matrix;
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullMatrix()
			{
				const Matrix matrix = null;
				var actual = (Vector3D)matrix;
			}
		}

		[TestFixture]
		public class GreaterThanOperator
		{
			[Test]
			public void Simple()
			{
				var vector1 = new Vector3D(1, 1, 1);
				var vector2 = new Vector3D(2, 2, 2);
				var vector3 = new Vector3D(2, 2, 2);

				Assert.IsFalse(vector1 > vector2);
				Assert.IsTrue(vector2 > vector1);
				Assert.IsFalse(vector2 > vector3);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionLeftNull()
			{
				const Vector3D vector1 = null;
				var vector2 = new Vector3D(2, 2, 2);

				var condition = vector1 > vector2;
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionRightNull()
			{
				var vector1 = new Vector3D(2, 2, 2);
				const Vector3D vector2 = null;

				var condition = vector1 > vector2;
			}
		}

		[TestFixture]
		public class GreaterThanEqualToOperator
		{
			[Test]
			public void Simple()
			{
				var vector1 = new Vector3D(1, 1, 1);
				var vector2 = new Vector3D(2, 2, 2);
				var vector3 = new Vector3D(2, 2, 2);

				Assert.IsFalse(vector1 >= vector2);
				Assert.IsTrue(vector2 >= vector1);
				Assert.IsTrue(vector2 >= vector3);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionLeftNull()
			{
				const Vector3D vector1 = null;
				var vector2 = new Vector3D(2, 2, 2);

				var condition = vector1 >= vector2;
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionRightNull()
			{
				var vector1 = new Vector3D(2, 2, 2);
				const Vector3D vector2 = null;

				var condition = vector1 >= vector2;
			}
		}

		[TestFixture]
		public class IncrementOperator
		{
			[Test]
			public void Simple()
			{
				var vector3D = new Vector3D(4, 7, 8);

				vector3D++;

				Assert.AreEqual(5, vector3D.X);
				Assert.AreEqual(8, vector3D.Y);
				Assert.AreEqual(9, vector3D.Z);
			}
		}

		[TestFixture]
		public class LessThanOperator
		{
			[Test]
			public void Simple()
			{
				var vector1 = new Vector3D(1, 1, 1);
				var vector2 = new Vector3D(2, 2, 2);
				var vector3 = new Vector3D(2, 2, 2);

				Assert.IsTrue(vector1 < vector2);
				Assert.IsFalse(vector2 < vector1);
				Assert.IsFalse(vector2 < vector3);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionLeftNull()
			{
				const Vector3D vector1 = null;
				var vector2 = new Vector3D(2, 2, 2);

				var condition = vector1 < vector2;
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionRightNull()
			{
				var vector1 = new Vector3D(2, 2, 2);
				const Vector3D vector2 = null;

				var condition = vector1 < vector2;
			}
		}

		[TestFixture]
		public class LessThanEqualToOperator
		{
			[Test]
			public void Simple()
			{
				var vector1 = new Vector3D(1, 1, 1);
				var vector2 = new Vector3D(2, 2, 2);
				var vector3 = new Vector3D(2, 2, 2);

				Assert.IsTrue(vector1 <= vector2);
				Assert.IsFalse(vector2 <= vector1);
				Assert.IsTrue(vector2 <= vector3);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionLeftNull()
			{
				const Vector3D vector1 = null;
				var vector2 = new Vector3D(2, 2, 2);

				var condition = vector1 <= vector2;
			}
			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionRightNull()
			{
				var vector1 = new Vector3D(2, 2, 2);
				const Vector3D vector2 = null;

				var condition = vector1 <= vector2;
			}
		}

		[TestFixture]
		public class MultiplyOperator
		{
			[Test]
			public void Simple()
			{
				var vector3D1 = new Vector3D(4, 7, 8);
				var vector = vector3D1 * 2;
				Assert.AreEqual(8, vector.X);
				Assert.AreEqual(14, vector.Y);
				Assert.AreEqual(16, vector.Z);
				Assert.AreNotSame(vector3D1, vector);
				Assert.AreEqual(4, vector3D1.X);
				Assert.AreEqual(7, vector3D1.Y);
				Assert.AreEqual(8, vector3D1.Z);
			}


			[Test]
			public void Vector()
			{
				var vector3D1 = new Vector3D(4, 7, 2);

				var vector3D2 = new Vector3D(3, 4, 9);

				var matrix = vector3D1 * vector3D2;
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

				Assert.AreEqual(4, vector3D1.X);
				Assert.AreEqual(7, vector3D1.Y);
				Assert.AreEqual(2, vector3D1.Z);

				Assert.AreEqual(3, vector3D2.X);
				Assert.AreEqual(4, vector3D2.Y);
				Assert.AreEqual(9, vector3D2.Z);
			}


			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionDifferentDimensions()
			{
				var vector3D = new Vector3D();
				VectorBase<double> vectorBase = new VectorN(2);
				var matrix = vector3D * vectorBase;
			}


			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionLeftNull()
			{
				var vector3D1 = new Vector3D();
				var matrix = null * vector3D1;
			}


			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionRightNull()
			{
				var vector3D1 = new Vector3D();
				var matrix = vector3D1 * null;
			}
		}

		[TestFixture]
		public class NegateOperator
		{
			[Test]
			public void Simple()
			{
				var vector3D1 = new Vector3D(1, 2, 3);
				var vector = -vector3D1;
				Assert.AreEqual(-1, vector.X);
				Assert.AreEqual(-2, vector.Y);
				Assert.AreEqual(-3, vector.Z);
				Assert.AreNotSame(vector3D1, vector);
				Assert.AreEqual(1, vector3D1.X);
				Assert.AreEqual(2, vector3D1.Y);
				Assert.AreEqual(3, vector3D1.Z);
			}
		}

		[TestFixture]
		public class NotEqualsOperator
		{
			[Test]
			public void Simple()
			{
				var vector3D1 = new Vector3D(1, 2, 5);
				var vector3D2 = new Vector3D(1, 2, 5);
				Assert.IsFalse(vector3D1 != vector3D2);
				Assert.AreEqual(1, vector3D1.X);
				Assert.AreEqual(2, vector3D1.Y);
				Assert.AreEqual(5, vector3D1.Z);
				Assert.AreEqual(1, vector3D2.X);
				Assert.AreEqual(2, vector3D2.Y);
				Assert.AreEqual(5, vector3D2.Z);
			}
		}

		[TestFixture]
		public class PlusOperator
		{
			[Test]
			public void Simple()
			{
				var vector3D1 = new Vector3D(4, 7, 8);
				var vector = vector3D1 + 2;
				Assert.AreEqual(6, vector.X);
				Assert.AreEqual(9, vector.Y);
				Assert.AreEqual(10, vector.Z);
				Assert.AreNotSame(vector3D1, vector);
			}


			[Test]
			public void Vector()
			{
				var vector3D1 = new Vector3D(4, 7, 9);
				var vector3D2 = new Vector3D(3, 4, 1);
				var vector = vector3D1 + vector3D2;
				Assert.AreEqual(7, vector.X);
				Assert.AreEqual(11, vector.Y);
				Assert.AreEqual(10, vector.Z);
				Assert.AreNotSame(vector3D1, vector);
				Assert.AreNotSame(vector3D2, vector);
				Assert.AreEqual(4, vector3D1.X);
				Assert.AreEqual(7, vector3D1.Y);
				Assert.AreEqual(9, vector3D1.Z);
				Assert.AreEqual(3, vector3D2.X);
				Assert.AreEqual(4, vector3D2.Y);
				Assert.AreEqual(1, vector3D2.Z);
			}


			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionDifferentDimensions()
			{
				var vector3D = new Vector3D();
				VectorBase<double> vectorBase = new VectorN(4);
				IVector<double> vector = vector3D + vectorBase;
			}


			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionLeftNull()
			{
				var vector3D1 = new Vector3D();
				var vector = null + vector3D1;
			}


			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionRightNull()
			{
				var vector3D1 = new Vector3D();
				var vector = vector3D1 + null;
			}

		}

		[TestFixture]
		public class SubtractOperator
		{
			[Test]
			public void Simple()
			{
				var vector3D = new Vector3D(4, 7, 6);
				var vector = vector3D - 2;

				Assert.AreEqual(2, vector.X);
				Assert.AreEqual(5, vector.Y);
				Assert.AreEqual(4, vector.Z);

				Assert.AreNotSame(vector3D, vector);

				Assert.AreEqual(4, vector3D.X);
				Assert.AreEqual(7, vector3D.Y);
				Assert.AreEqual(6, vector3D.Z);
			}


			[Test]
			public void Vector()
			{
				var vector3D1 = new Vector3D(4, 7, 8);
				var vector3D2 = new Vector3D(3, 4, 2);
				var vector = vector3D1 - vector3D2;

				Assert.AreEqual(1, vector.X);
				Assert.AreEqual(3, vector.Y);
				Assert.AreEqual(6, vector.Z);

				Assert.AreNotSame(vector3D1, vector);
				Assert.AreNotSame(vector3D2, vector);

				Assert.AreEqual(4, vector3D1.X);
				Assert.AreEqual(7, vector3D1.Y);
				Assert.AreEqual(8, vector3D1.Z);

				Assert.AreEqual(3, vector3D2.X);
				Assert.AreEqual(4, vector3D2.Y);
				Assert.AreEqual(2, vector3D2.Z);
			}


			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionDifferentDimensions()
			{
				var vector3D = new Vector3D();
				VectorBase<double> vectorBase = new VectorN(4);
				IVector<double> vector = vector3D - vectorBase;
			}


			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionLeftNull()
			{
				var vector3D1 = new Vector3D();
				var vector = null - vector3D1;
			}


			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionRightNull()
			{
				var vector3D1 = new Vector3D();
				var vector = vector3D1 - null;
			}

		}

		[TestFixture]
		public class ToMatrixOperator
		{
			[Test]
			public void Simple()
			{
				var vector = new Vector3D(8, 3, 7);

				Matrix actual = vector;

				Assert.AreEqual(3, actual.Rows);
				Assert.AreEqual(1, actual.Columns);

				Assert.AreEqual(8, actual[0, 0]);
				Assert.AreEqual(3, actual[1, 0]);
				Assert.AreEqual(7, actual[2, 0]);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullVector()
			{
				const Vector3D vector = null;
				Matrix actual = vector;
			}
		}
	}
}