/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using NGenerics.DataStructures.Mathematical;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical
{

	[TestFixture]
	public class Vector2DTest
	{

		[TestFixture]
		public class AbsoluteMaximum
		{
			[Test]
			public void Simple()
			{
				var vector1 = new Vector2D(1, -4);

				Assert.AreEqual(4, vector1.AbsoluteMaximum());

				Assert.AreEqual(1, vector1.X);
				Assert.AreEqual(-4, vector1.Y);


				var vector2 = new Vector2D(5, -4);

				Assert.AreEqual(5, vector2.AbsoluteMaximum());

				Assert.AreEqual(5, vector2.X);
				Assert.AreEqual(-4, vector2.Y);
			}

		}

		[TestFixture]
		public class AbsoluteMaximumIndex
		{
			[Test]
			public void Simple()
			{
				var vector1 = new Vector2D(1, -4);

				Assert.AreEqual(1, vector1.AbsoluteMaximumIndex());

				Assert.AreEqual(1, vector1.X);
				Assert.AreEqual(-4, vector1.Y);

				var vector2 = new Vector2D(5, -4);

				Assert.AreEqual(0, vector2.AbsoluteMaximumIndex());

				Assert.AreEqual(5, vector2.X);
				Assert.AreEqual(-4, vector2.Y);
			}

		}

		[TestFixture]
		public class AbsoluteMinimum
		{

			[Test]
			public void Simple()
			{
				var vector = new Vector2D(1, -4);

				Assert.AreEqual(1, vector.AbsoluteMinimum());

				Assert.AreEqual(1, vector.X);
				Assert.AreEqual(-4, vector.Y);
			}

		}

		[TestFixture]
		public class AbsoluteMinimumIndex
		{

			[Test]
			public void Simple()
			{
				var vector1 = new Vector2D(1, -4);

				Assert.AreEqual(0, vector1.AbsoluteMinimumIndex());

				Assert.AreEqual(1, vector1.X);
				Assert.AreEqual(-4, vector1.Y);


				var vector2 = new Vector2D(-4, 1);

				Assert.AreEqual(1, vector2.AbsoluteMinimumIndex());

				Assert.AreEqual(-4, vector2.X);
				Assert.AreEqual(1, vector2.Y);
			}

		}

		[TestFixture]
		public class Accept
		{

			[Test]
			public void Simple()
			{
				var visitor = new CountingVisitor<double>();
				var vector2D = new Vector2D();
				vector2D.AcceptVisitor(visitor);
				Assert.AreEqual(2, visitor.Count);
			}

			[Test]
			public void HasCompletedPre()
			{
				var visitor = new ComparableFindingVisitor<double>(2);
				visitor.Visit(2);
				var vector2D = new Vector2D();
				vector2D.SetValues(2, 5);
				vector2D.AcceptVisitor(visitor);
				Assert.IsTrue(visitor.Found);
			}

			[Test]
			public void HasCompletedPost()
			{
				var visitor = new ComparableFindingVisitor<double>(2);
				var vector2D = new Vector2D();
				vector2D.SetValues(2, 5);
				vector2D.AcceptVisitor(visitor);
				Assert.IsTrue(visitor.Found);
			}

		}

		[TestFixture]
		public class Add
		{

			[Test]
			public void Double()
			{
				var vector = new Vector2D(4, 7)
				             {
				                 1
				             };

				Assert.AreEqual(5, vector.X);
				Assert.AreEqual(8, vector.Y);
			}

			[Test]
			public void Vector2D()
			{
				var vector1 = new Vector2D(4, 7);

				var vector2 = new Vector2D(3, 4);

				vector1.Add(vector2);

				Assert.AreEqual(7, vector1.X);
				Assert.AreEqual(11, vector1.Y);

				Assert.AreEqual(3, vector2.X);
				Assert.AreEqual(4, vector2.Y);
			}

			[Test]
			public void IVector()
			{
				var vector1 = new Vector2D(4, 7);

				var vector2 = new VectorN(2);
				vector2.SetValues(3, 4);

				vector1.Add(vector2);

				Assert.AreEqual(7, vector1[0]);
				Assert.AreEqual(11, vector1[1]);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullVector()
			{
				new Vector2D
                {
                    null
                };
			}

		}

		[TestFixture]
		public class CLear
		{

			[Test]
			public void Simple()
			{
				var vector = new Vector2D(3, 7);

				vector.Clear();

				Assert.AreEqual(0, vector.X);
				Assert.AreEqual(0, vector.Y);
			}

		}

		[TestFixture]
		public class Clone
		{

			[Test]
			public void Simple()
			{
				var vector = new Vector2D(3, 7);

				var clone = (Vector2D)vector.Clone();

				Assert.AreEqual(3, vector.X);
				Assert.AreEqual(7, vector.Y);

				Assert.AreEqual(3, clone.X);
				Assert.AreEqual(7, clone.Y);

				Assert.AreNotSame(clone, vector);
			}

		}

		[TestFixture]
		public class Contruction
		{

			[Test]
			public void Simple()
			{
				var vector2D = new Vector2D();
				Assert.AreEqual(2, vector2D.DimensionCount);
				Assert.AreEqual(0, vector2D.X);
				Assert.AreEqual(0, vector2D.Y);
			}

		}

		[TestFixture]
		public class CrossProduct
		{

			[Test]
			public void Vector2D2x2()
			{
				var vector1 = new Vector2D(2, 3);

				var vector2 = new Vector2D(4, 5);

				IVector<double> vector = vector1.CrossProduct(vector2);

				Assert.AreEqual(0, vector[0]);
				Assert.AreEqual(0, vector[1]);
				Assert.AreEqual(-5, vector[2]);
			}


			[Test]
			public void Vector2D2x3()
			{
				var vector2D = new Vector2D(4, 5);

				var vector3D = new Vector3D(1, 2, 3);

				IVector<double> vector = vector2D.CrossProduct(vector3D);

				Assert.AreEqual(15, vector[0]);
				Assert.AreEqual(-12, vector[1]);
				Assert.AreEqual(3, vector[2]);
			}

			[Test]
			public void IVector2x2()
			{
				var vector2D = new Vector2D(2, 3);

				var vectorN = new VectorN(2);
				vectorN.SetValues(4, 5);

				var vector = vector2D.CrossProduct(vectorN);

				Assert.AreEqual(0, vector[0]);
				Assert.AreEqual(0, vector[1]);
				Assert.AreEqual(-5, vector[2]);
			}

			[Test]
			public void IVector2x3()
			{
				var vector2D = new Vector2D(4, 5);

				var vectorN = new VectorN(3);
				vectorN.SetValues(1, 2, 3);

				var vector = vector2D.CrossProduct(vectorN);

				Assert.AreEqual(15, vector[0]);
				Assert.AreEqual(-12, vector[1]);
				Assert.AreEqual(3, vector[2]);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExcetionNullVector2D()
			{
				var vector = new Vector2D();
				vector.CrossProduct((Vector2D)null);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExcetionNullVector3D()
			{
				var vector = new Vector2D();
				vector.CrossProduct((Vector3D)null);
			}

		}

		[TestFixture]
		public class Decrement
		{

			[Test]
			public void Simple()
			{
				var vector = new Vector2D(4, 7);

				vector.Decrement();

				Assert.AreEqual(3, vector.X);
				Assert.AreEqual(6, vector.Y);
			}

		}

		[TestFixture]
		public class DimensionCount
		{

			[Test]
			public void Simple()
			{
				var vector = new Vector2D();
				Assert.AreEqual(2, vector.DimensionCount);
			}

		}

		[TestFixture]
		public class Magnitude
		{

			[Test]
			public void Simple()
			{
				var vector = new Vector2D(2, 3);

				Assert.AreEqual(3.6055512754639891d, vector.Magnitude());

				Assert.AreEqual(2, vector.X);
				Assert.AreEqual(3, vector.Y);
			}

		}

		[TestFixture]
		public class Product
		{

			[Test]
			public void Simple()
			{
				var vector = new Vector2D(2, 3);

				Assert.AreEqual(6, vector.Product());

				Assert.AreEqual(2, vector.X);
				Assert.AreEqual(3, vector.Y);
			}

		}

		[TestFixture]
		public class Sum
		{

			[Test]
			public void Simple()
			{
				var vector = new Vector2D(2, 3);

				Assert.AreEqual(5, vector.Sum());

				Assert.AreEqual(2, vector.X);
				Assert.AreEqual(3, vector.Y);
			}

		}

		[TestFixture]
		public class Divide
		{

			[Test]
			public void Double()
			{
				var vector = new Vector2D(9, 3);

				vector.Divide(3);

				Assert.AreEqual(3, vector.X);
				Assert.AreEqual(1, vector.Y);
			}

			[Test]
			public void Vector2D()
			{
				var vector1 = new Vector2D(24, 32);

				var vector2 = new Vector2D(2, 4);

				vector1.Divide(vector2);

				Assert.AreEqual(3, vector1.X);
				Assert.AreEqual(4, vector1.Y);

				Assert.AreEqual(2, vector2.X);
				Assert.AreEqual(4, vector2.Y);
			}

			[Test]
			public void IVector()
			{
				var vector2D = new Vector2D(24, 32);

				var vectorN = new VectorN(2);
				vectorN.SetValues(2, 4);

				vector2D.Divide(vectorN);

				Assert.AreEqual(3, vector2D.X);
				Assert.AreEqual(4, vector2D.Y);

				Assert.AreEqual(2, vectorN[0]);
				Assert.AreEqual(4, vectorN[1]);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullVector()
			{
				var vector = new Vector2D();
				vector.Divide(null);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionDifferentDimensions()
			{
				var vector2D = new Vector2D();
				var vector3D = new Vector3D();
				vector2D.Divide(vector3D);
			}

		}

		[TestFixture]
		public class DotProduct
		{

			[Test]
			public void Vector2D()
			{
				var vector1 = new Vector2D(4, 7);

				var vector2 = new Vector2D(3, 4);

				var dotProduct = vector1.DotProduct(vector2);
				Assert.AreEqual(40, dotProduct);

				Assert.AreEqual(4, vector1.X);
				Assert.AreEqual(7, vector1.Y);

				Assert.AreEqual(3, vector2.X);
				Assert.AreEqual(4, vector2.Y);
			}

			[Test]
			public void IVector()
			{
				var vector2D = new Vector2D(4, 7);

				var vectorN = new VectorN(2);
				vectorN.SetValues(3, 4);

				var dotProduct = vector2D.DotProduct(vectorN);
				Assert.AreEqual(40, dotProduct);

				Assert.AreEqual(4, vector2D.X);
				Assert.AreEqual(7, vector2D.Y);

				Assert.AreEqual(3, vectorN[0]);
				Assert.AreEqual(4, vectorN[1]);

			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionDifferentDimensions()
			{
				var vector = new Vector2D();
				VectorBase<double> vectorBase2 = new VectorN(4);
				vector.DotProduct(vectorBase2);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullVector()
			{
				var vector = new Vector2D();
				vector.DotProduct(null);
			}

		}

		[TestFixture]
		public class EqualsObj
		{

			[Test]
			public void DifferentDimensions()
			{
				var vector2D = new Vector2D();
				var vector3D = new Vector3D();
				Assert.IsFalse(vector2D.Equals(vector3D));
			}

			[Test]
			public void DifferentValues()
			{
				var vector1 = new Vector2D(1, 0);
				var vector2 = new Vector2D(2, 0);

				Assert.IsFalse(vector1.Equals(vector2));

				Assert.AreEqual(1, vector1.X);
				Assert.AreEqual(2, vector2.X);
			}

			[Test]
			public void Null()
			{
				var vector = new Vector2D();
				Assert.IsFalse(vector.Equals(null));
			}

			[Test]
			public void NullVector()
			{
				var vector = new Vector2D();
				const Vector3D nullVector = null;
				Assert.IsFalse(vector.Equals(nullVector));
			}

			[Test]
			public void SameValues()
			{
				var vector1 = new Vector2D(1, 2);

				var vector2 = new Vector2D(1, 2);

				Assert.IsTrue(vector1.Equals(vector2));

				Assert.AreEqual(1, vector1.X);
				Assert.AreEqual(2, vector1.Y);

				Assert.AreEqual(1, vector2.X);
				Assert.AreEqual(2, vector2.Y);
			}

		}

		[TestFixture]
		public class GetHashCodeObj
		{

			[Test]
			public void Simple()
			{
				var vector = new Vector2D { X = 1, Y = 2 };
				Assert.AreNotEqual(0, vector.GetHashCode());
				Assert.AreEqual(1, vector.X);
				Assert.AreEqual(2, vector.Y);
			}

		}

		[TestFixture]
		public class Increment
		{

			[Test]
			public void Simple()
			{
				var vector = new Vector2D(4, 7);
				vector.Increment();
				Assert.AreEqual(5, vector.X);
				Assert.AreEqual(8, vector.Y);
			}

		}

		[TestFixture]
		public class Index
		{

			[Test]
			public void Simple()
			{
				var vector = new Vector2D();
				Assert.AreEqual(2, vector.DimensionCount);

				Assert.AreEqual(0, vector.X);
				Assert.AreEqual(0, vector.Y);
				Assert.AreEqual(0, vector[0]);
				Assert.AreEqual(0, vector[1]);

				vector[0] = 4;
				vector[1] = 5;

				Assert.AreEqual(4, vector.X);
				Assert.AreEqual(5, vector.Y);
				Assert.AreEqual(4, vector[0]);
				Assert.AreEqual(5, vector[1]);
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionGetTooLarge()
			{
				var vector = new Vector2D();
				var d = vector[2];
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionGetTooSmall()
			{
				var vector = new Vector2D();
				var d = vector[-1];
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionSetTooLarge()
			{
				var vector = new Vector2D();
				vector[2] = 8;
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionSetTooSmall()
			{
				var vector = new Vector2D();
				vector[-1] = 8;
			}

		}

		[TestFixture]
		public class Maximum
		{

			[Test]
			public void Simple()
			{
				var vector = new Vector2D(1, -4);

				Assert.AreEqual(1, vector.Maximum());

				Assert.AreEqual(1, vector.X);
				Assert.AreEqual(-4, vector.Y);
			}

		}

		[TestFixture]
		public class MaximumIndex
		{

			[Test]
			public void Simple()
			{
				var vector1 = new Vector2D(1, -4);

				Assert.AreEqual(0, vector1.MaximumIndex());

				Assert.AreEqual(1, vector1.X);
				Assert.AreEqual(-4, vector1.Y);

				var vector2 = new Vector2D(1, 4);

				Assert.AreEqual(1, vector2.MaximumIndex());

				Assert.AreEqual(1, vector2.X);
				Assert.AreEqual(4, vector2.Y);
			}

		}

		[TestFixture]
		public class Minimum
		{

			[Test]
			public void Simple()
			{
				var vector = new Vector2D(1, -4);

				Assert.AreEqual(-4, vector.Minimum());
				Assert.AreEqual(1, vector.X);
				Assert.AreEqual(-4, vector.Y);
			}

		}

		[TestFixture]
		public class MinimumIndex
		{

			[Test]
			public void Simple()
			{
				var vector1 = new Vector2D(1, -4);

				Assert.AreEqual(1, vector1.MinimumIndex());

				Assert.AreEqual(1, vector1.X);
				Assert.AreEqual(-4, vector1.Y);

				var vector2 = new Vector2D(1, 4);

				Assert.AreEqual(0, vector2.MinimumIndex());

				Assert.AreEqual(1, vector2.X);
				Assert.AreEqual(4, vector2.Y);
			}

		}

		[TestFixture]
		public class Multiply
		{

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullVector()
			{
				var vector = new Vector2D();
				vector.Multiply(null);
			}

			[Test]
			public void Double()
			{
				var vector = new Vector2D(1, 2);

				vector.Multiply(2);

				Assert.AreEqual(2, vector.X);
				Assert.AreEqual(4, vector.Y);
			}

			[Test]
			public void Vector2D()
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

				Assert.AreEqual(1, vector1.X);
				Assert.AreEqual(2, vector1.Y);

				Assert.AreEqual(3, vector2.X);
				Assert.AreEqual(4, vector2.Y);
			}

			[Test]
			public void IVector()
			{
				var vector2D = new Vector2D(1, 2);

				var vectorN = new VectorN(2);
				vectorN.SetValues(3, 4);

				var matrix = vector2D.Multiply(vectorN);
				Assert.AreEqual(2, matrix.Columns);
				Assert.AreEqual(2, matrix.Rows);

				Assert.AreEqual(3, matrix[0, 0]);
				Assert.AreEqual(4, matrix[0, 1]);
				Assert.AreEqual(6, matrix[1, 0]);
				Assert.AreEqual(8, matrix[1, 1]);

				Assert.AreEqual(1, vector2D.X);
				Assert.AreEqual(2, vector2D.Y);

				Assert.AreEqual(3, vectorN[0]);
				Assert.AreEqual(4, vectorN[1]);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionDifferentDimensions()
			{
				var vector2D = new Vector2D();
				var vector3D = new Vector3D();
				vector2D.Multiply(vector3D);
			}

		}

		[TestFixture]
		public class Negate
		{

			[Test]
			public void Simple()
			{
				var vector = new Vector2D(1, 2);

				vector.Negate();

				Assert.AreEqual(-1, vector.X);
				Assert.AreEqual(-2, vector.Y);
			}

		}

		[TestFixture]
		public class Normalize
		{

			[Test]
			public void Simple()
			{
				var vector = new Vector2D(23, 21);

				vector.Normalize();

				Assert.AreEqual(1, vector.Magnitude());
			}

		}

		[TestFixture]
		public class SetValues
		{

			[Test]
			public void Simple()
			{
				var vector = new Vector2D { X = 1, Y = 2 };
				vector.SetValues(4, 6);
				Assert.AreEqual(4, vector.X);
				Assert.AreEqual(6, vector.Y);
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionNullValues()
			{
				var vector = new Vector2D();
				vector.SetValues();
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionNotEnoughValues()
			{
				var vector = new Vector2D();
				vector.SetValues(4);
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionTooManyValues()
			{
				var vector = new Vector2D();
				vector.SetValues(4, 6, 3);
			}

		}

		[TestFixture]
		public class Subtract
		{

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullVector()
			{
				var vector = new Vector2D();
				vector.Subtract(null);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionDifferentDimensions()
			{
				var vector2D = new Vector2D();
				var vector3D = new Vector3D();
				vector2D.Subtract(vector3D);
			}

			[Test]
			public void Double()
			{
				var vector = new Vector2D(1, 2);

				vector.Subtract(2);

				Assert.AreEqual(-1, vector.X);
				Assert.AreEqual(0, vector.Y);
			}

			[Test]
			public void Vector2D()
			{
				var vector1 = new Vector2D(1, 2);

				var vector2 = new Vector2D(8, 4);

				vector1.Subtract(vector2);

				Assert.AreEqual(-7, vector1.X);
				Assert.AreEqual(-2, vector1.Y);
				Assert.AreEqual(8, vector2.X);
				Assert.AreEqual(4, vector2.Y);
			}

			[Test]
			public void IVector()
			{
				var vector2D = new Vector2D(1, 2);

				var vectorN = new VectorN(2);
				vectorN.SetValues(8, 4);

				vector2D.Subtract(vectorN);

				Assert.AreEqual(-7, vector2D.X);
				Assert.AreEqual(-2, vector2D.Y);
				Assert.AreEqual(8, vectorN[0]);
				Assert.AreEqual(4, vectorN[1]);
			}

		}

		[TestFixture]
		public class Swap
		{

			[Test]
			public void Vector2D()
			{
				var vector1 = new Vector2D(1, 2);

				var vector2 = new Vector2D(3, 4);

				vector1.Swap(vector2);

				Assert.AreEqual(3, vector1.X);
				Assert.AreEqual(4, vector1.Y);
				Assert.AreEqual(1, vector2.X);
				Assert.AreEqual(2, vector2.Y);
			}

			[Test]
			public void IVector()
			{
				var vector1 = new Vector2D(1, 2);

				var vector2 = new VectorN(2);
				vector2.SetValues(3, 4);

				vector1.Swap(vector2);

				Assert.AreEqual(3, vector1.X);
				Assert.AreEqual(4, vector1.Y);
				Assert.AreEqual(1, vector2[0]);
				Assert.AreEqual(2, vector2[1]);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullVector()
			{
				var vector = new Vector2D();
				vector.Swap(null);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionDifferentDimensions()
			{
				var vector = new Vector2D();
				VectorBase<double> vectorBase = new VectorN(4);
				vector.Swap(vectorBase);
			}

		}

		[TestFixture]
		public class ToArray
		{

			[Test]
			public void Simple()
			{
				var vector = new Vector2D(8, 3);

				var actual = vector.ToArray();

				Assert.AreEqual(2, actual.Length);
				Assert.AreEqual(8, actual[0]);
				Assert.AreEqual(3, actual[1]);
			}

		}

		[TestFixture]
		public class ToMatrix
		{

			[Test]
			public void Simple()
			{
				var vector = new Vector2D(8, 3);

				var actual = vector.ToMatrix();

				Assert.AreEqual(2, actual.Rows);
				Assert.AreEqual(1, actual.Columns);

				Assert.AreEqual(8, actual[0, 0]);
				Assert.AreEqual(3, actual[1, 0]);
			}

		}

		[TestFixture]
		public class ToStringObj
		{

			[Test]
			public void Simple()
			{
				var vector = new Vector2D();
				var actual = vector.ToString();
				Assert.AreEqual("{0,0}", actual);
				vector.X = 1;
				vector.Y = 2;
				actual = vector.ToString();
				Assert.AreEqual("{1,2}", actual);
				Assert.AreEqual(1, vector.X);
				Assert.AreEqual(2, vector.Y);
			}

		}

		[TestFixture]
		public class UnitVector
		{

			[Test]
			public void Simple()
			{
				var vector = Vector2D.UnitVector;
				Assert.AreEqual(1, vector.X);
				Assert.AreEqual(1, vector.Y);
			}

		}

		[TestFixture]
		public class ZeroVector
		{

			[Test]
			public void Simple()
			{
				var vector = Vector2D.ZeroVector;
				Assert.AreEqual(0, vector.X);
				Assert.AreEqual(0, vector.Y);
			}

		}

	}
}