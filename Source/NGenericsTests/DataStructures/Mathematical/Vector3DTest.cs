/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/


using System;
using NGenerics.DataStructures.Mathematical;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical
{

	[TestFixture]
	public partial class Vector3DTest
	{

		[TestFixture]
		public class AbsoluteMaximum
		{

			[Test]
			public void Simple()
			{
				var vector = new Vector3D(1, -4, 3);
				Assert.AreEqual(4, vector.AbsoluteMaximum());
				Assert.AreEqual(1, vector.X);
				Assert.AreEqual(-4, vector.Y);
				Assert.AreEqual(3, vector.Z);
			}

		}

		[TestFixture]
		public class AbsoluteMaximumIndex
		{

			[Test]
			public void Simple()
			{
				var vector1 = new Vector3D(1, -4, 3);
				Assert.AreEqual(1, vector1.AbsoluteMaximumIndex());
				Assert.AreEqual(1, vector1.X);
				Assert.AreEqual(-4, vector1.Y);
				Assert.AreEqual(3, vector1.Z);


				var vector2 = new Vector3D(1, -4, 5);
				Assert.AreEqual(2, vector2.AbsoluteMaximumIndex());
				Assert.AreEqual(1, vector2.X);
				Assert.AreEqual(-4, vector2.Y);
				Assert.AreEqual(5, vector2.Z);


				var vector3 = new Vector3D(7, -4, 3);
				Assert.AreEqual(0, vector3.AbsoluteMaximumIndex());
				Assert.AreEqual(7, vector3.X);
				Assert.AreEqual(-4, vector3.Y);
				Assert.AreEqual(3, vector3.Z);


				var vector4 = new Vector3D(7, -4, 8);
				Assert.AreEqual(2, vector4.AbsoluteMaximumIndex());
				Assert.AreEqual(7, vector4.X);
				Assert.AreEqual(-4, vector4.Y);
				Assert.AreEqual(8, vector4.Z);
			}

		}

		[TestFixture]
		public class AbsoluteMinimum
		{

			[Test]
			public void Simple()
			{
				var vector = new Vector3D {X = 1, Y = (-4), Z = 3};
			    Assert.AreEqual(1, vector.AbsoluteMinimum());
				Assert.AreEqual(1, vector.X);
				Assert.AreEqual(-4, vector.Y);
				Assert.AreEqual(3, vector.Z);
			}

		}

		[TestFixture]
		public class AbsoluteMinimumIndex
		{

			[Test]
			public void Simple()
			{
				var vector1 = new Vector3D(1, -4, 3);
				Assert.AreEqual(0, vector1.AbsoluteMinimumIndex());
				Assert.AreEqual(1, vector1.X);
				Assert.AreEqual(-4, vector1.Y);
				Assert.AreEqual(3, vector1.Z);

				var vector2 = new Vector3D(7, -4, 3);
				Assert.AreEqual(2, vector2.AbsoluteMinimumIndex());
				Assert.AreEqual(7, vector2.X);
				Assert.AreEqual(-4, vector2.Y);
				Assert.AreEqual(3, vector2.Z);

				var vector3 = new Vector3D(7, -4, 8);
				Assert.AreEqual(1, vector3.AbsoluteMinimumIndex());
				Assert.AreEqual(7, vector3.X);
				Assert.AreEqual(-4, vector3.Y);
				Assert.AreEqual(8, vector3.Z);

				var vector4 = new Vector3D(-8, 9, -7);
				Assert.AreEqual(2, vector4.AbsoluteMinimumIndex());
				Assert.AreEqual(-8, vector4.X);
				Assert.AreEqual(9, vector4.Y);
				Assert.AreEqual(-7, vector4.Z);
			}

		}

		[TestFixture]
		public class Accept
		{

			[Test]
			public void Simple()
			{
				var visitor = new CountingVisitor<double>();
				var vector3D = new Vector3D();
				vector3D.AcceptVisitor(visitor);
				Assert.AreEqual(3, visitor.Count);

			}

			[Test]
			public void HasCompletedPre()
			{
				var visitor = new ComparableFindingVisitor<double>(5);
				visitor.Visit(5);
				var vector = new Vector3D();
				vector.SetValues(2, 5, 9);
				vector.AcceptVisitor(visitor);
				Assert.IsTrue(visitor.Found);
			}

			[Test]
			public void HasCompletedPost()
			{
				var visitor = new ComparableFindingVisitor<double>(5);
				var vector = new Vector3D();
				vector.SetValues(2, 5, 9);
				vector.AcceptVisitor(visitor);
				Assert.IsTrue(visitor.Found);
			}

			[Test]
			public void HasCompletedX()
			{
				var visitor = new ComparableFindingVisitor<double>(2);
				var vector = new Vector3D();
				vector.SetValues(2, 5, 9);
				vector.AcceptVisitor(visitor);
				Assert.IsTrue(visitor.Found);
			}
		}

		[TestFixture]
		public class Add
		{

			[Test]
			public void Double()
			{
				var vector = new Vector3D(4, 7, 3);
				vector.Add(1);
				Assert.AreEqual(5, vector.X);
				Assert.AreEqual(8, vector.Y);
				Assert.AreEqual(4, vector.Z);
			}

			[Test]
			public void Vector3D()
			{
				var vector1 = new Vector3D(4, 7, -1);

				var vector2 = new Vector3D(3, 4, 2);

				vector1.Add(vector2);

				Assert.AreEqual(7, vector1.X);
				Assert.AreEqual(11, vector1.Y);
				Assert.AreEqual(1, vector1.Z);

				Assert.AreEqual(3, vector2.X);
				Assert.AreEqual(4, vector2.Y);
				Assert.AreEqual(2, vector2.Z);
			}

			[Test]
			public void IVector()
			{
				var vector1 = new Vector3D(4, 7, -1);

				var vector2 = new VectorN(3);
				vector2.SetValues(3, 4, 2);

				vector1.Add(vector2);

				Assert.AreEqual(7, vector1.X);
				Assert.AreEqual(11, vector1.Y);
				Assert.AreEqual(1, vector1.Z);

				Assert.AreEqual(3, vector2[0]);
				Assert.AreEqual(4, vector2[1]);
				Assert.AreEqual(2, vector2[2]);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullVector()
			{
				var vector = new Vector3D();
				vector.Add(null);
			}

		}

		[TestFixture]
		public class Clear
		{

			[Test]
			public void Simple()
			{
				var vector = new Vector3D(3, 7, 8);

				vector.Clear();

				Assert.AreEqual(0, vector.X);
				Assert.AreEqual(0, vector.Y);
				Assert.AreEqual(0, vector.Z);
			}

		}

		[TestFixture]
		public class Clone
		{

			[Test]
			public void Simple()
			{
				var vector = new Vector3D(3, 7, 9);

				var clone = (Vector3D)vector.Clone();

				Assert.AreEqual(3, vector.X);
				Assert.AreEqual(7, vector.Y);
				Assert.AreEqual(9, vector.Z);

				Assert.AreEqual(3, clone.X);
				Assert.AreEqual(7, clone.Y);
				Assert.AreEqual(9, clone.Z);

				Assert.AreNotSame(clone, vector);
			}

		}

		[TestFixture]
		public class Construction
		{

			[Test]
			public void Simple()
			{
				var vector = new Vector3D();
				Assert.AreEqual(3, vector.DimensionCount);
				Assert.AreEqual(0, vector.X);
				Assert.AreEqual(0, vector.Y);
				Assert.AreEqual(0, vector.Z);
			}

		}

		[TestFixture]
		public class CrossProduct
		{

			[Test]
			public void IVector3x3()
			{
				var vector3D = new Vector3D(1, 2, 3);

				var vectorN = new VectorN(3);
				vectorN.SetValues(4, 5, 6);

				var vector = vector3D.CrossProduct(vectorN);

				Assert.AreEqual(-3, vector[0]);
				Assert.AreEqual(6, vector[1]);
				Assert.AreEqual(-3, vector[2]);
			}

			[Test]
			public void IVector3x2()
			{
				var vector3D = new Vector3D(1, 2, 3);

				var vectorN = new VectorN(2);
				vectorN.SetValues(4, 5);

				var vector = vector3D.CrossProduct(vectorN);

				Assert.AreEqual(-15, vector[0]);
				Assert.AreEqual(12, vector[1]);
				Assert.AreEqual(-3, vector[2]);
			}

			[Test]
			public void Vector3D3x3()
			{
				var vector1 = new Vector3D(1, 2, 3);

				var vector2 = new Vector3D(4, 5, 6);

				var vector = vector1.CrossProduct(vector2);

				Assert.AreEqual(-3, vector.X);
				Assert.AreEqual(6, vector.Y);
				Assert.AreEqual(-3, vector.Z);
			}

			[Test]
			public void Vector3D3x2()
			{
				var vector3D = new Vector3D(1, 2, 3);

				var vector2D = new Vector2D(4, 5);

				var vector = vector3D.CrossProduct(vector2D);

				Assert.AreEqual(-15, vector.X);
				Assert.AreEqual(12, vector.Y);
				Assert.AreEqual(-3, vector.Z);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullVector3D()
			{
				var vector = new Vector3D();
				vector.CrossProduct((Vector3D)null);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullVector2D()
			{
				var vector = new Vector3D();
				vector.CrossProduct((Vector2D)null);
			}

		}

		[TestFixture]
		public class Decrement
		{

			[Test]
			public void Simple()
			{
				var vector = new Vector3D(4, 7, 9);

				vector.Decrement();

				Assert.AreEqual(3, vector.X);
				Assert.AreEqual(6, vector.Y);
				Assert.AreEqual(8, vector.Z);
			}

		}

		[TestFixture]
		public class DimensionCount
		{

			[Test]
			public void Simple()
			{
				var vector3D = new Vector3D();
				Assert.AreEqual(3, vector3D.DimensionCount);
				Assert.AreEqual(0, vector3D.X);
				Assert.AreEqual(0, vector3D.Y);
				Assert.AreEqual(0, vector3D.Z);
			}

		}

		[TestFixture]
		public class Magnitude
		{

			[Test]
			public void Simple()
			{
				var vector3D = new Vector3D(4, 3, 12);

				Assert.AreEqual(13, vector3D.Magnitude());
				Assert.AreEqual(4, vector3D.X);
				Assert.AreEqual(3, vector3D.Y);
				Assert.AreEqual(12, vector3D.Z);
			}

		}

		[TestFixture]
		public class Product
		{

			[Test]
			public void Simple()
			{
				var vector3D = new Vector3D(2, 3, 5);

				Assert.AreEqual(30, vector3D.Product());
				Assert.AreEqual(2, vector3D.X);
				Assert.AreEqual(3, vector3D.Y);
				Assert.AreEqual(5, vector3D.Z);
			}

		}

		[TestFixture]
		public class Sum
		{

			[Test]
			public void Simple()
			{
				var vector = new Vector3D(2, 3, 5);

				Assert.AreEqual(10, vector.Sum());

				Assert.AreEqual(2, vector.X);
				Assert.AreEqual(3, vector.Y);
				Assert.AreEqual(5, vector.Z);
			}

		}

		[TestFixture]
		public class Divide
		{

			[Test]
			public void Double()
			{
				var vector = new Vector3D(9, 3, 18);

				vector.Divide(3);

				Assert.AreEqual(3, vector.X);
				Assert.AreEqual(1, vector.Y);
				Assert.AreEqual(6, vector.Z);
			}

			[Test]
			public void Vector3D()
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

			[Test]
			public void IVector()
			{
				var vector3D = new Vector3D(24, 48, 72);

				var vectorN = new VectorN(3);
				vectorN.SetValues(2, 3, 4);

				vector3D.Divide(vectorN);

				Assert.AreEqual(1, vector3D.X);
				Assert.AreEqual(2, vector3D.Y);
				Assert.AreEqual(3, vector3D.Z);

				Assert.AreEqual(2, vectorN[0]);
				Assert.AreEqual(3, vectorN[1]);
				Assert.AreEqual(4, vectorN[2]);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExcetionNullVector()
			{
				var vector = new Vector3D();
				vector.Divide(null);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionDifferentDimensions()
			{
				var vector = new Vector3D();
				VectorBase<double> vectorBase = new VectorN(4);
				vector.Divide(vectorBase);
			}

		}

		[TestFixture]
		public class DotProduct
		{

			[Test]
			public void Vector3D()
			{
				var vector1 = new Vector3D(4, 7, 4);

				var vector2 = new Vector3D(3, 4, 8);

				var dotProduct = vector1.DotProduct(vector2);
				Assert.AreEqual(72, dotProduct);

				Assert.AreEqual(4, vector1.X);
				Assert.AreEqual(7, vector1.Y);
				Assert.AreEqual(4, vector1.Z);

				Assert.AreEqual(3, vector2.X);
				Assert.AreEqual(4, vector2.Y);
				Assert.AreEqual(8, vector2.Z);
			}

			[Test]
			public void IVector()
			{
				var vector3D = new Vector3D(4, 7, 4);

				var vectorN = new VectorN(3);
				vectorN.SetValues(3, 4, 8);

				var dotProduct = vector3D.DotProduct(vectorN);
				Assert.AreEqual(72, dotProduct);

				Assert.AreEqual(4, vector3D.X);
				Assert.AreEqual(7, vector3D.Y);
				Assert.AreEqual(4, vector3D.Z);

				Assert.AreEqual(3, vectorN[0]);
				Assert.AreEqual(4, vectorN[1]);
				Assert.AreEqual(8, vectorN[2]);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionDifferentDimensions()
			{
				var vector = new Vector3D();
				VectorBase<double> vectorBase = new VectorN(4);
				vector.DotProduct(vectorBase);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExcetionNullVector()
			{
				var vector = new Vector3D();
				vector.DotProduct(null);
			}

		}

		[TestFixture]
		public class EqualsObj
		{

			[Test]
			public void DifferentDimensions()
			{
				var vector3D = new Vector3D();
				var vectorN = new VectorN(4);
				Assert.IsFalse(vector3D.Equals(vectorN));
			}

			[Test]
			public void DifferentValues()
			{
				var vector1 = new Vector3D {X = 1};

			    var vector2 = new Vector3D {X = 2};

			    Assert.IsFalse(vector1.Equals(vector2));

				Assert.AreEqual(1, vector1.X);
				Assert.AreEqual(2, vector2.X);
			}

			[Test]
			public void Null()
			{
				var vector = new Vector3D();
				Assert.IsFalse(vector.Equals(null));
			}

			[Test]
			public void NullVector()
			{
				var vector3D1 = new Vector3D();
				const Vector3D nullVector = null;
				Assert.IsFalse(vector3D1.Equals(nullVector));
			}

			[Test]
			public void SameValues()
			{
				var vector1 = new Vector3D(1, 2, 5);

				var vector2 = new Vector3D(1, 2, 5);

				Assert.IsTrue(vector1.Equals(vector2));

				Assert.AreEqual(1, vector1.X);
				Assert.AreEqual(2, vector1.Y);
				Assert.AreEqual(5, vector1.Z);

				Assert.AreEqual(1, vector2.X);
				Assert.AreEqual(2, vector2.Y);
				Assert.AreEqual(5, vector2.Z);
			}

		}

		[TestFixture]
		public class GetHashCodeObj
		{

			[Test]
			public void Simple()
			{
				var vector = new Vector3D(1, 2, 3);

				Assert.AreNotEqual(0, vector.GetHashCode());

				Assert.AreEqual(1, vector.X);
				Assert.AreEqual(2, vector.Y);
				Assert.AreEqual(3, vector.Z);
			}

		}

		[TestFixture]
		public class Increment
		{

			[Test]
			public void Simple()
			{
				var vector = new Vector3D(4, 7, 9);

				vector.Increment();

				Assert.AreEqual(5, vector.X);
				Assert.AreEqual(8, vector.Y);
				Assert.AreEqual(10, vector.Z);
			}

		}

		[TestFixture]
		public class Index
		{

			[Test]
			public void Simple()
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

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionGetTooLarge()
			{
				var vector = new Vector3D();
				var d = vector[3];
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionGetTooSmall()
			{
				var vector = new Vector3D();
				var d = vector[-1];
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionSetTooLarge()
			{
				var vector = new Vector3D();
				vector[3] = 9;
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionSetTooSmall()
			{
				var vector = new Vector3D();
				vector[-1] = 9;
			}

		}

		[TestFixture]
		public class Maximim
		{

			[Test]
			public void Simple()
			{
				var vector = new Vector3D(1, -4, 3);

				Assert.AreEqual(3, vector.Maximum());

				Assert.AreEqual(1, vector.X);
				Assert.AreEqual(-4, vector.Y);
				Assert.AreEqual(3, vector.Z);
			}

		}

		[TestFixture]
		public class MaximumIndex
		{

			[Test]
			public void Simple()
			{
				var vector1 = new Vector3D(1, -4, 3);

				Assert.AreEqual(2, vector1.MaximumIndex());

				Assert.AreEqual(1, vector1.X);
				Assert.AreEqual(-4, vector1.Y);
				Assert.AreEqual(3, vector1.Z);

				var vector2 = new Vector3D(4, -4, 3);

				Assert.AreEqual(0, vector2.MaximumIndex());

				Assert.AreEqual(4, vector2.X);
				Assert.AreEqual(-4, vector2.Y);
				Assert.AreEqual(3, vector2.Z);

				var vector3 = new Vector3D(1, 4, 3);

				Assert.AreEqual(1, vector3.MaximumIndex());

				Assert.AreEqual(1, vector3.X);
				Assert.AreEqual(4, vector3.Y);
				Assert.AreEqual(3, vector3.Z);



				var vector4 = new Vector3D(3, 4, 9);

				Assert.AreEqual(2, vector4.MaximumIndex());

				Assert.AreEqual(3, vector4.X);
				Assert.AreEqual(4, vector4.Y);
				Assert.AreEqual(9, vector4.Z);
			}

		}

		[TestFixture]
		public class Minimum
		{

			[Test]
			public void Simple()
			{
				var vector = new Vector3D(1, -4, 3);

				Assert.AreEqual(-4, vector.Minimum());
				Assert.AreEqual(1, vector.X);
				Assert.AreEqual(-4, vector.Y);
				Assert.AreEqual(3, vector.Z);
			}

		}

		[TestFixture]
		public class MinimumIndex
		{

			[Test]
			public void Simple()
			{
				var vector1 = new Vector3D(1, -4, 3);

				Assert.AreEqual(1, vector1.MinimumIndex());

				Assert.AreEqual(1, vector1.X);
				Assert.AreEqual(-4, vector1.Y);
				Assert.AreEqual(3, vector1.Z);


				var vector2 = new Vector3D(1, 4, 3);

				Assert.AreEqual(0, vector2.MinimumIndex());

				Assert.AreEqual(1, vector2.X);
				Assert.AreEqual(4, vector2.Y);
				Assert.AreEqual(3, vector2.Z);


				var vector3 = new Vector3D(1, 4, -3);

				Assert.AreEqual(2, vector3.MinimumIndex());

				Assert.AreEqual(1, vector3.X);
				Assert.AreEqual(4, vector3.Y);
				Assert.AreEqual(-3, vector3.Z);


				var vector4 = new Vector3D(6, 4, -3);

				Assert.AreEqual(2, vector4.MinimumIndex());

				Assert.AreEqual(6, vector4.X);
				Assert.AreEqual(4, vector4.Y);
				Assert.AreEqual(-3, vector4.Z);
			}

		}

		[TestFixture]
		public class Multimply
		{

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullVector()
			{
				var vector = new Vector3D();
				vector.Multiply(null);
			}

			[Test]
			public void Double()
			{
				var vector = new Vector3D(1, 2, 9);

				vector.Multiply(2);

				Assert.AreEqual(2, vector.X);
				Assert.AreEqual(4, vector.Y);
				Assert.AreEqual(18, vector.Z);
			}

			[Test]
			public void Vector3D()
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

				Assert.AreEqual(1, vector1.X);
				Assert.AreEqual(2, vector1.Y);
				Assert.AreEqual(8, vector1.Z);

				Assert.AreEqual(3, vector2.X);
				Assert.AreEqual(4, vector2.Y);
				Assert.AreEqual(2, vector2.Z);
			}

			[Test]
			public void IVector()
			{
				var vector3D = new Vector3D(1, 2, 8);

				var vectorN = new VectorN(3);
				vectorN.SetValues(3, 4, 2);

				var matrix = vector3D.Multiply(vectorN);

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

				Assert.AreEqual(1, vector3D.X);
				Assert.AreEqual(2, vector3D.Y);
				Assert.AreEqual(8, vector3D.Z);

				Assert.AreEqual(3, vectorN[0]);
				Assert.AreEqual(4, vectorN[1]);
				Assert.AreEqual(2, vectorN[2]);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionDifferentDimensions()
			{
				var vector = new Vector3D();
				VectorBase<double> vectorBase = new VectorN(2);
				vector.Multiply(vectorBase);
			}

		}

		[TestFixture]
		public class Negate
		{

			[Test]
			public void Simple()
			{
				var vector = new Vector3D(1, 2, -5);

				vector.Negate();

				Assert.AreEqual(-1, vector.X);
				Assert.AreEqual(-2, vector.Y);
				Assert.AreEqual(5, vector.Z);
			}

		}

		[TestFixture]
		public class Normalize
		{

			[Test]
			public void Simple()
			{
				var vector = new Vector3D(23, -21, 4);

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
				var vector = new Vector3D(1, 2, 34);

				vector.SetValues(4, 6, 8);

				Assert.AreEqual(4, vector.X);
				Assert.AreEqual(6, vector.Y);
				Assert.AreEqual(8, vector.Z);
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionNoValues()
			{
				var vector = new Vector3D();
				vector.SetValues();
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExcepionNotEnoughValues()
			{
				var vector = new Vector3D();
				vector.SetValues(4);
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionTooManyValues()
			{
				var vector = new Vector3D();
				vector.SetValues(4, 6, 3, 7);
			}

		}

		[TestFixture]
		public class Subtract
		{

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullVector()
			{
				var vector = new Vector3D();
				vector.Subtract(null);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionDifferentDimensions()
			{
				var vector3D = new Vector3D();
				VectorBase<double> vectorBase = new VectorN(4);
				vector3D.Subtract(vectorBase);
			}

			[Test]
			public void Double()
			{
				var vector = new Vector3D(1, 2, -2);

				vector.Subtract(2);

				Assert.AreEqual(-1, vector.X);
				Assert.AreEqual(0, vector.Y);
				Assert.AreEqual(-4, vector.Z);
			}

			[Test]
			public void Vector3D()
			{
				var vector1 = new Vector3D(1, 2, 9);

				var vector2 = new Vector3D(8, 4, 2);

				vector1.Subtract(vector2);

				Assert.AreEqual(-7, vector1.X);
				Assert.AreEqual(-2, vector1.Y);
				Assert.AreEqual(7, vector1.Z);

				Assert.AreEqual(8, vector2.X);
				Assert.AreEqual(4, vector2.Y);
				Assert.AreEqual(2, vector2.Z);
			}

			[Test]
			public void IVector()
			{
				var vector3D = new Vector3D(1, 2, 9);

				var vectorN = new VectorN(3);
				vectorN.SetValues(8, 4, 2);

				vector3D.Subtract(vectorN);

				Assert.AreEqual(-7, vector3D.X);
				Assert.AreEqual(-2, vector3D.Y);
				Assert.AreEqual(7, vector3D.Z);

				Assert.AreEqual(8, vectorN[0]);
				Assert.AreEqual(4, vectorN[1]);
				Assert.AreEqual(2, vectorN[2]);
			}

		}

		[TestFixture]
		public class Swap
		{

			[Test]
			public void Vector3d()
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

			[Test]
			public void IVector()
			{
				var vector3D = new Vector3D(1, 2, 3);

				var vectorN = new VectorN(3);
				vectorN.SetValues(3, 4, 6);

				vector3D.Swap(vectorN);

				Assert.AreEqual(3, vector3D.X);
				Assert.AreEqual(4, vector3D.Y);
				Assert.AreEqual(6, vector3D.Z);

				Assert.AreEqual(1, vectorN[0]);
				Assert.AreEqual(2, vectorN[1]);
				Assert.AreEqual(3, vectorN[2]);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullOther()
			{
				var vector = new Vector3D();
				vector.Swap(null);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionDifferentDimensions()
			{
				var vector = new Vector3D();
				VectorBase<double> vectorBase = new VectorN(4);
				vector.Swap(vectorBase);
			}

		}

		[TestFixture]
		public class ToStringObj
		{

			[Test]
			public void Simple()
			{
				var vector = new Vector3D();
				var actual = vector.ToString();
				Assert.AreEqual("{0,0,0}", actual);
				vector.X = 1;
				vector.Y = 2;
				vector.Z = 7;
				actual = vector.ToString();
				Assert.AreEqual("{1,2,7}", actual);
				Assert.AreEqual(1, vector.X);
				Assert.AreEqual(2, vector.Y);
				Assert.AreEqual(7, vector.Z);
			}

		}

		[TestFixture]
		public class ToArray
		{

			[Test]
			public void Simple()
			{
				var vector = new Vector3D(8, 3, 6);

				var actual = vector.ToArray();

				Assert.AreEqual(3, actual.Length);

				Assert.AreEqual(8, actual[0]);
				Assert.AreEqual(3, actual[1]);
				Assert.AreEqual(6, actual[2]);
			}

		}

		[TestFixture]
		public class ToMatrix
		{

			[Test]
			public void Simple()
			{
				var vector = new Vector3D(8, 3, 7);

				var actual = vector.ToMatrix();

				Assert.AreEqual(3, actual.Rows);
				Assert.AreEqual(1, actual.Columns);

				Assert.AreEqual(8, actual[0, 0]);
				Assert.AreEqual(3, actual[1, 0]);
				Assert.AreEqual(7, actual[2, 0]);
			}

		}

		[TestFixture]
		public class UnitVector
		{

			[Test]
			public void Simple()
			{
				var vector = Vector3D.UnitVector;
				Assert.AreEqual(1, vector.X);
				Assert.AreEqual(1, vector.Y);
				Assert.AreEqual(1, vector.Z);
			}

		}

		[TestFixture]
		public class ZeroVector
		{

			[Test]
			public void Simple()
			{
				var vector = Vector3D.ZeroVector;
				Assert.AreEqual(0, vector.X);
				Assert.AreEqual(0, vector.Y);
				Assert.AreEqual(0, vector.Z);
			}

		}

	}
}