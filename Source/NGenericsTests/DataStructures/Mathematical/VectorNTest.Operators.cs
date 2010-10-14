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
	public class VectorNTestOperator
	{
		[TestFixture]
		public class DecrementOperator
		{
			[Test]
			public void Simple()
			{
				VectorBase<double> vector1 = new VectorN(2);
				vector1.SetValues(4, 7);

				vector1--;

				Assert.AreEqual(3, vector1[0]);
				Assert.AreEqual(6, vector1[1]);
			}
		}

		[TestFixture]
		public class DivideOperator
		{
			[Test]
			public void DivideDouble()
			{
				var vector1 = new VectorN(2);
				vector1.SetValues(4, 12);
				IVector<double> vector = vector1 / 2;
				Assert.AreEqual(2, vector[0]);
				Assert.AreEqual(6, vector[1]);
				Assert.AreEqual(4, vector1[0]);
				Assert.AreEqual(12, vector1[1]);
				Assert.AreNotSame(vector1, vector);
			}


			[Test]
			public void DivideVector()
			{
				var vector1 = new VectorN(2);
				vector1.SetValues(4, 8);
				var vector2 = new VectorN(2);
				vector2.SetValues(2, 2);
				IVector<double> vector = vector1 / vector2;
				Assert.AreEqual(2, vector[0]);
				Assert.AreEqual(4, vector[1]);
				Assert.AreEqual(4, vector1[0]);
				Assert.AreEqual(8, vector1[1]);
				Assert.AreEqual(2, vector2[0]);
				Assert.AreEqual(2, vector2[1]);
				Assert.AreNotSame(vector1, vector);
				Assert.AreNotSame(vector2, vector);
			}


			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionDifferentDimensions()
			{
				var vector1 = new VectorN(2);
				var vector2 = new VectorN(4);
				IVector<double> vector = vector1 / vector2;
			}


			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionLeftNull()
			{
				var vector1 = new VectorN(2);
				IVector<double> vector = null / vector1;
			}


			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionRightNull()
			{
				var vector1 = new VectorN(2);
				IVector<double> vector = vector1 / null;
			}
		}

		[TestFixture]
		public class EqualsOperator
		{
			[Test]
			public void Simple()
			{
				var vector1 = new VectorN(2);
				vector1[0] = 1;
				vector1[1] = 2;
				var vector2 = new VectorN(2);
				vector2[0] = 1;
				vector2[1] = 2;
				Assert.IsTrue(vector1 == vector2);
			}


			[Test]
			public void LeftNull()
			{
				var vector1 = new VectorN(2);
				const VectorN vector2 = null;
				Assert.IsFalse(vector2 == vector1);
			}


			[Test]
			public void ReferenceEquals()
			{
				var vector1 = new VectorN(2);
				var vector2 = vector1;
				Assert.IsTrue(vector1 == vector2);
			}


			[Test]
			public void RightNull()
			{
				var vector1 = new VectorN(2);
				const VectorN vector2 = null;
				Assert.IsFalse(vector1 == vector2);
			}
		}

		[TestFixture]
		public class FromMatrixOperator
		{
			[Test]
			public void Simple()
			{

				var matrix = new Matrix(2, 1);
				matrix[0, 0] = 4;
				matrix[1, 0] = 7;
				var actual = (VectorN)matrix;

				Assert.AreEqual(2, actual.DimensionCount);

				Assert.AreEqual(4, actual[0]);
				Assert.AreEqual(7, actual[1]);
			}

			[Test]
			[ExpectedException(typeof(InvalidCastException))]
			public void ExceptionInvalidColumns()
			{

				var matrix = new Matrix(2, 2);
				var actual = (VectorN)matrix;

			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionMatrixNull()
			{
				const Matrix matrix = null;
				var actual = (VectorN)matrix;
			}
		}

		[TestFixture]
		public class GreaterThanOperator
		{
			[Test]
			public void Simple2()
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

			[Test]
			public void Simple1()
			{
				var vector1 = new VectorN(3);
				vector1.SetValues(1, 1, 1);
				var vector2 = new VectorN(3);
				vector2.SetValues(2, 2, 2);
				var vector3 = new VectorN(3);
				vector3.SetValues(2, 2, 2);

				Assert.IsFalse(vector1 > vector2);
				Assert.IsTrue(vector2 > vector1);
				Assert.IsFalse(vector2 > vector3);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionLeftNull()
			{
				const VectorN vector1 = null;
				var vector2 = new VectorN(3);
				vector2.SetValues(2, 2, 2);

				var condition = vector1 > vector2;
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionRightNull()
			{
				var vector1 = new VectorN(3);
				vector1.SetValues(1, 1, 1);
				const VectorN vector2 = null;

				var condition = vector1 > vector2;
			}
		}

		[TestFixture]
		public class GreaterThanOrEqualToOperator
		{
			[Test]
			public void Simple1()
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

			[Test]
			public void Simple2()
			{
				var vector1 = new VectorN(3);
				vector1.SetValues(1, 1, 1);
				var vector2 = new VectorN(3);
				vector2.SetValues(2, 2, 2);
				var vector3 = new VectorN(3);
				vector3.SetValues(2, 2, 2);

				Assert.IsFalse(vector1 >= vector2);
				Assert.IsTrue(vector2 >= vector1);
				Assert.IsTrue(vector2 >= vector3);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionLeftNull()
			{
				const VectorN vector1 = null;
				var vector2 = new VectorN(3);
				vector2.SetValues(2, 2, 2);

				var condition = vector1 >= vector2;
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionRightNull()
			{
				var vector1 = new VectorN(3);
				vector1.SetValues(1, 1, 1);
				const VectorN vector2 = null;

				var condition = vector1 >= vector2;
			}
		}

		[TestFixture]
		public class IncrementOperator
		{
			[Test]
			public void Simple()
			{
				VectorBase<double> vector1 = new VectorN(2);
				vector1.SetValues(4, 7);

				vector1++;

				Assert.AreEqual(5, vector1[0]);
				Assert.AreEqual(8, vector1[1]);
			}
		}

		[TestFixture]
		public class LessThanOperator
		{
			[Test]
			public void Simpel()
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

			[Test]
			public void Simple2()
			{
				var vector1 = new VectorN(3);
				vector1.SetValues(1, 1, 1);
				var vector2 = new VectorN(3);
				vector2.SetValues(2, 2, 2);
				var vector3 = new VectorN(3);
				vector3.SetValues(2, 2, 2);

				Assert.IsTrue(vector1 < vector2);
				Assert.IsFalse(vector2 < vector1);
				Assert.IsFalse(vector2 < vector3);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionLeftNull()
			{
				const VectorN vector1 = null;
				var vector2 = new VectorN(3);
				vector2.SetValues(2, 2, 2);

				var condition = vector1 < vector2;
			}
			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionRightNull()
			{
				var vector1 = new VectorN(3);
				vector1.SetValues(1, 1, 1);
				const VectorN vector2 = null;

				var condition = vector1 < vector2;
			}
		}

		[TestFixture]
		public class LessThanOrEqualToOperator
		{
			[Test]
			public void Simple1()
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

			[Test]
			public void Simple2()
			{
				var vector1 = new VectorN(3);
				vector1.SetValues(1, 1, 1);
				var vector2 = new VectorN(3);
				vector2.SetValues(2, 2, 2);
				var vector3 = new VectorN(3);
				vector3.SetValues(2, 2, 2);

				Assert.IsTrue(vector1 <= vector2);
				Assert.IsFalse(vector2 <= vector1);
				Assert.IsTrue(vector2 <= vector3);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionLeftNull()
			{
				const VectorN vector1 = null;
				var vector2 = new VectorN(3);
				vector2.SetValues(2, 2, 2);

				var condition = vector1 <= vector2;
			}
			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionRightNull()
			{
				var vector1 = new VectorN(3);
				vector1.SetValues(1, 1, 1);
				const VectorN vector2 = null;

				var condition = vector1 <= vector2;
			}
		}

		[TestFixture]
		public class MultiplyOperator
		{
			[Test]
			public void Double()
			{
				var vector1 = new VectorN(2);
				vector1.SetValues(4, 7);

				var vector = vector1 * 2;

				Assert.AreEqual(8, vector[0]);
				Assert.AreEqual(14, vector[1]);

				Assert.AreEqual(4, vector1[0]);
				Assert.AreEqual(7, vector1[1]);

				Assert.AreNotSame(vector1, vector);
			}


			[Test]
			public void Vector()
			{
				var vector1 = new VectorN(2);
				vector1.SetValues(4, 7);
				var vector2 = new VectorN(2);
				vector2.SetValues(3, 4);

				var matrix = vector1 * vector2;

				Assert.AreEqual(2, matrix.Columns);
				Assert.AreEqual(2, matrix.Rows);

				Assert.AreEqual(12, matrix[0, 0]);
				Assert.AreEqual(16, matrix[0, 1]);
				Assert.AreEqual(21, matrix[1, 0]);
				Assert.AreEqual(28, matrix[1, 1]);

				Assert.AreEqual(4, vector1[0]);
				Assert.AreEqual(7, vector1[1]);
				Assert.AreEqual(3, vector2[0]);
				Assert.AreEqual(4, vector2[1]);
			}


			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionDifferentDimensions()
			{
				var vector1 = new VectorN(2);
				var vector2 = new VectorN(4);

				var matrix = vector1 * vector2;
			}


			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionLeftNull()
			{
				var vector1 = new VectorN(2);
				var matrix = null * vector1;
			}


			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionRightNull()
			{
				var vector1 = new VectorN(2);
				var matrix = vector1 * null;
			}

		}

		[TestFixture]
		public class NegateOperator
		{
			[Test]
			public void Simple()
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
		}

		[TestFixture]
		public class NotEqualsOperator
		{
			[Test]
			public void Simple()
			{
				var vector1 = new VectorN(2);
				vector1[0] = 1;
				vector1[1] = 2;

				var vector2 = new VectorN(2);
				vector2[0] = 1;
				vector2[1] = 2;

				Assert.IsFalse(vector1 != vector2);
			}
		}

		[TestFixture]
		public class PlusOperator
		{
			[Test]
			public void Double()
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


			[Test]
			public void Vector()
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


			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionDifferentDimensions()
			{
				var vector1 = new VectorN(2);
				var vector2 = new VectorN(4);
				IVector<double> vector = vector1 + vector2;
			}


			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionLeftNull()
			{
				var vector1 = new VectorN(2);
				IVector<double> vector = null + vector1;
			}


			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionRightNull()
			{
				var vector1 = new VectorN(2);
				IVector<double> vector = vector1 + null;
			}
		}

		[TestFixture]
		public class SubtractOperator
		{
			[Test]
			public void Double()
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


			[Test]
			public void Vector()
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


			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionDifferentDimensions()
			{
				var vector1 = new VectorN(2);
				var vector2 = new VectorN(4);
				IVector<double> vector = vector1 - vector2;
			}


			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionLeftNull()
			{
				var vector1 = new VectorN(2);
				IVector<double> vector = null - vector1;
			}


			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionRightNull()
			{
				var vector1 = new VectorN(2);
				IVector<double> vector = vector1 - null;
			}
		}

		[TestFixture]
		public class ToMatrixOperator
		{
			[Test]
			public void Simple()
			{
				var vector = new VectorN(2);
				vector.SetValues(8, 3);

				Matrix actual = vector;

				Assert.AreEqual(2, actual.Rows);
				Assert.AreEqual(1, actual.Columns);

				Assert.AreEqual(8, actual[0, 0]);
				Assert.AreEqual(3, actual[1, 0]);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionMatrixNull()
			{
				const VectorN vector = null;
				Matrix actual = vector;
			}
		}
	}
}