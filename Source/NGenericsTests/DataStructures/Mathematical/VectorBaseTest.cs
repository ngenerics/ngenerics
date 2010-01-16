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
    public class VectorBaseTest
    {

		[TestFixture]
		public class Accept
		{

			[Test]
			public void Simple()
			{
				var visitor = new CountingVisitor<double>();
				var vector = new VectorN(2);
				vector.AcceptVisitor(visitor);
				Assert.AreEqual(2, visitor.Count);
			}

			[Test]
			public void Completed()
			{
				var visitor = new ComparableFindingVisitor<double>(5);
				var vector = new VectorN(3);
				vector.SetValues(2, 5, 9);
				vector.AcceptVisitor(visitor);
				Assert.IsTrue(visitor.Found);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullVisitor()
			{
				var vector = new VectorBaseTestObject(2);
				vector.AcceptVisitor(null);
			}

		}

		[TestFixture]
		public class Add
		{
			[Test]
			[ExpectedException(typeof(NotImplementedException), ExpectedMessage = "AddSafe")]
			public void Exception1()
			{
				var vector1 = new VectorBaseTestObject(2);
				var vector2 = new VectorBaseTestObject(2);
				vector1.Add(vector2);
			}


			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionDifferentDimensions()
			{
				var vector1 = new VectorBaseTestObject(2);
				var vector2 = new VectorBaseTestObject(4);
				vector1.Add(vector2);
			}

						[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullVector()
			{
				var vector1 = new VectorBaseTestObject(2);
				vector1.Add(null);
			}

		}

		[TestFixture]
		public class Clear
		{
			[Test]
			public void Simple()
			{
				var vector = new VectorN(3);
				vector.SetValues(3, 7, 8);

				vector.Clear();

				Assert.AreEqual(0, vector[0]);
				Assert.AreEqual(0, vector[1]);
				Assert.AreEqual(0, vector[0]);
			}
		}

		[TestFixture]
		public class Contruction
		{

			[Test]
			public void Simple()
			{
				var vector = new VectorBaseTestObject(2);
				Assert.AreEqual(2, vector.DimensionCount);
			}

		}

		[TestFixture]
		public class CrossProduct
		{
			
			[Test]
			[ExpectedException(typeof(NotImplementedException), ExpectedMessage = "CrossProductSafe")]
			public void Exception3x3()
			{
				var vector1 = new VectorBaseTestObject(3);
				var vector2 = new VectorBaseTestObject(3);
				vector1.CrossProduct(vector2);
			}
			
			[Test]
			[ExpectedException(typeof(NotImplementedException), ExpectedMessage = "CrossProductSafe")]
			public void Exception2x3()
			{
				var vector1 = new VectorBaseTestObject(2);
				var vector2 = new VectorBaseTestObject(3);
				vector1.CrossProduct(vector2);
			}
			
			[Test]
			[ExpectedException(typeof(NotImplementedException), ExpectedMessage = "CrossProductSafe")]
			public void Exception3x2()
			{
				var vector1 = new VectorBaseTestObject(3);
				var vector2 = new VectorBaseTestObject(2);
				vector1.CrossProduct(vector2);
			}
			
			[Test]
			[ExpectedException(typeof(NotImplementedException), ExpectedMessage = "CrossProductSafe")]
			public void Exception2x2()
			{
				var vector1 = new VectorBaseTestObject(2);
				var vector2 = new VectorBaseTestObject(2);
				vector1.CrossProduct(vector2);
			}

						[Test]
			[ExpectedException(typeof(InvalidOperationException))]
			public void Exception1x2()
			{
				var vector1 = new VectorBaseTestObject(1);
				var vector2 = new VectorBaseTestObject(2);
				vector1.CrossProduct(vector2);
			}
			
			[Test]
			[ExpectedException(typeof(InvalidOperationException))]
			public void Exception4x2()
			{
				var vector1 = new VectorBaseTestObject(4);
				var vector2 = new VectorBaseTestObject(2);
				vector1.CrossProduct(vector2);
			}
			
			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void Exception2x1()
			{
				var vector1 = new VectorBaseTestObject(2);
				var vector2 = new VectorBaseTestObject(1);
				vector1.CrossProduct(vector2);
			}
			
			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionDifferentDimensions1()
			{
				var vector1 = new VectorBaseTestObject(2);
				var vector2 = new VectorBaseTestObject(4);
				vector1.CrossProduct(vector2);
			}
			
			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullVector()
			{
				var vector1 = new VectorBaseTestObject(2);
				vector1.CrossProduct(null);
			}

		}

		[TestFixture]
		public class DimensionCount
		{
			[Test]
			public void Simple()
			{
				var vector = new VectorBaseTestObject(2);
				Assert.AreEqual(2, vector.DimensionCount);
			}

		}

		[TestFixture]
		public class Divide
		{
			[Test]
			[ExpectedException(typeof(NotImplementedException), ExpectedMessage = "DivideSafe")]
			public void Exception()
			{
				var vector1 = new VectorBaseTestObject(2);
				var vector2 = new VectorBaseTestObject(2);
				vector1.Divide(vector2);
			}


			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullVector()
			{
				var vector1 = new VectorBaseTestObject(2);
				vector1.Divide(null);
			}


			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionDifferentDimensions()
			{
				var vector1 = new VectorBaseTestObject(2);
				var vector2 = new VectorBaseTestObject(3);
				vector1.Divide(vector2);
			}

		}

		[TestFixture]
		public class DotProduct
		{

			[Test]
			[ExpectedException(typeof(NotImplementedException), ExpectedMessage = "DotProductSafe")]
			public void Exception1()
			{
				var vector1 = new VectorBaseTestObject(2);
				var vector2 = new VectorBaseTestObject(2);
				vector1.DotProduct(vector2);
			}


			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullVector()
			{
				var vector1 = new VectorBaseTestObject(2);
				vector1.DotProduct(null);
			}


			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void EceptionDifferentDimensions()
			{
				var vector1 = new VectorBaseTestObject(2);
				var vector2 = new VectorBaseTestObject(3);
				vector1.DotProduct(vector2);
			}

		}

		[TestFixture]
		public class EqualsObj
		{

			[Test]
			public void SameValues()
			{
				var vector1 = new VectorN(3);
				vector1.SetValues(1, 2, 5);
				var vector2 = new VectorN(3);
				vector2.SetValues(1, 2, 5);

				Assert.IsTrue(vector1.Equals(vector2));

				Assert.AreEqual(1, vector1[0]);
				Assert.AreEqual(2, vector1[1]);
				Assert.AreEqual(5, vector1[2]);

				Assert.AreEqual(1, vector2[0]);
				Assert.AreEqual(2, vector2[1]);
				Assert.AreEqual(5, vector2[2]);
			}
			[Test]
			public void SameValuesObject()
			{
				var vector1 = new VectorN(3);
				vector1.SetValues(1, 2, 5);
				var vector2 = new VectorN(3);
				vector2.SetValues(1, 2, 5);

				Assert.IsTrue(vector1.Equals((object)vector2));

				Assert.AreEqual(1, vector1[0]);
				Assert.AreEqual(2, vector1[1]);
				Assert.AreEqual(5, vector1[2]);

				Assert.AreEqual(1, vector2[0]);
				Assert.AreEqual(2, vector2[1]);
				Assert.AreEqual(5, vector2[2]);
			}


			[Test]
			public void DifferentDimensions()
			{
				var vector1 = new VectorN(3);
				vector1.SetValues(1, 2, 5);
				var vector2 = new VectorN(4);
				vector2.SetValues(1, 2, 5, 6);

				Assert.IsFalse(vector1.Equals(vector2));

				Assert.AreEqual(1, vector1[0]);
				Assert.AreEqual(2, vector1[1]);
				Assert.AreEqual(5, vector1[2]);

				Assert.AreEqual(1, vector2[0]);
				Assert.AreEqual(2, vector2[1]);
				Assert.AreEqual(5, vector2[2]);
				Assert.AreEqual(6, vector2[3]);
			}


			[Test]
			public void Null()
			{
				var vector1 = new VectorN(3);
				vector1.SetValues(1, 2, 5);

				Assert.IsFalse(vector1.Equals(null));

				Assert.AreEqual(1, vector1[0]);
				Assert.AreEqual(2, vector1[1]);
				Assert.AreEqual(5, vector1[2]);

			}

			[Test]
			public void NullObject()
			{
				var vector1 = new VectorN(3);
				vector1.SetValues(1, 2, 5);

				Assert.IsFalse(vector1.Equals((object)null));

				Assert.AreEqual(1, vector1[0]);
				Assert.AreEqual(2, vector1[1]);
				Assert.AreEqual(5, vector1[2]);

			}
		}

		[TestFixture]
		public class Maximum
		{
			[Test]
			public void Simple()
			{
				var vector = new VectorN(3);
				vector.SetValues(1, -4, 3);

				Assert.AreEqual(3, vector.Maximum());
				Assert.AreEqual(1, vector[0]);
				Assert.AreEqual(-4, vector[1]);
				Assert.AreEqual(3, vector[2]);
			}
		}

		[TestFixture]
		public class Minimum
		{

			[Test]
			public void Simple()
			{
				var vector = new VectorN(3);
				vector.SetValues(1, -4, 3);

				Assert.AreEqual(-4, vector.Minimum());
				Assert.AreEqual(1, vector[0]);
				Assert.AreEqual(-4, vector[1]);
				Assert.AreEqual(3, vector[2]);
			}

		}

		[TestFixture]
		public class Multiply
		{

			[Test]
			[ExpectedException(typeof(NotImplementedException), ExpectedMessage = "MultiplySafe")]
			public void Exception()
			{
				var vector1 = new VectorBaseTestObject(2);
				var vector2 = new VectorBaseTestObject(2);
				vector1.Multiply(vector2);
			}
			
			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullVector()
			{
				var vector1 = new VectorBaseTestObject(2);
				vector1.Multiply(null);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionDifferentDimensions()
			{
				var vector1 = new VectorBaseTestObject(2);
				var vector2 = new VectorBaseTestObject(3);
				vector1.Multiply(vector2);
			}

		}

		[TestFixture]
		public class Subtract
		{

			[Test]
			[ExpectedException(typeof(NotImplementedException), ExpectedMessage = "SubtractSafe")]
			public void Exception()
			{
				var vector1 = new VectorBaseTestObject(2);
				var vector2 = new VectorBaseTestObject(2);
				vector1.Subtract(vector2);
			}
			
			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionVectorNull()
			{
				var vector1 = new VectorBaseTestObject(2);
				vector1.Subtract(null);
			}


			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionDifferentDimensions()
			{
				var vector1 = new VectorBaseTestObject(2);
				var vector2 = new VectorBaseTestObject(3);
				vector1.Subtract(vector2);
			}

		}

		[TestFixture]
		public class Swap
		{

			[Test]
			public void Simple()
			{
				var vector1 = new VectorN(2);
				vector1[0] = 1;
				vector1[1] = 2;

				var vector2 = new VectorN(2);
				vector2[0] = 3;
				vector2[1] = 4;

				vector1.Swap((IVector<double>)vector2);

				Assert.AreEqual(3, vector1[0]);
				Assert.AreEqual(4, vector1[1]);
				Assert.AreEqual(1, vector2[0]);
				Assert.AreEqual(2, vector2[1]);
			}
			
			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExcpetionNullOther()
			{
				var vector1 = new VectorBaseTestObject(2);
				vector1.Swap(null);
			}


			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionDifferentDimensions()
			{
				var vector1 = new VectorBaseTestObject(2);
				var vector2 = new VectorBaseTestObject(3);
				vector1.Swap(vector2);
			}

		}

    }
}