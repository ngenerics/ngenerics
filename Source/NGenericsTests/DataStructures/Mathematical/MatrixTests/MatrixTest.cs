/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using System.Collections;
using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NGenerics.DataStructures.Mathematical;
using NGenerics.Patterns.Visitor;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical
{
	public class MatrixTest
    {
        #region Tests

        [TestFixture]
        public class Construction
        {
            [Test]
            public void Should_Copy_Multi_Dimensional_Array_For_Data()
            {
                var values = new double[4,3];
                
                for (var i = 0; i< 4; i++)
                {
                    for (var j = 2; j>= 0; j--)
                    {
                        values[i, j] = i + j;
                    }
                }
                
                var m = new Matrix(4, 3, values);

                for (var i = 0; i < 4; i++)
                {
                    for (var j = 2; j >= 0; j--)
                    {
                        Assert.AreEqual(m[i, j], i + j);
                    }
                }
                
            }
        }

        [TestFixture]
		public class Add
		{

			[Test]
			[ExpectedException(typeof(NotSupportedException))]
			public void ExceptionInterfaceAdd()
			{
				ICollection<double> matrix = GetTestMatrix();
				matrix.Add(5);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullMatrix()
			{
				var matrix = GetTestMatrix();
				matrix.Add(null);
			}

		}


		[TestFixture]
		public class Adjoint
		{

			[Test]
			public void TwoByTwo()
			{
				//A = [ a, b ]
				//    [ c, d ]
				//
				// AdjA = [ d, -b]
				//        [ -c, a]

				var matrix = new Matrix(2, 2);
				matrix[0, 0] = 2;
				matrix[0, 1] = 4;
				matrix[1, 0] = 1;
				matrix[1, 1] = 3;

				var a = matrix.Adjoint();

				Assert.AreEqual(a[0, 0], 3);
				Assert.AreEqual(a[0, 1], -4);
				Assert.AreEqual(a[1, 0], -1);
				Assert.AreEqual(a[1, 1], 2);
			}

			[Test]
			public void ThreeByThree()
			{
				//A = [ 3, 0,  2 ]
				//    [ 0, 1, -1 ]
				//    [ 0, 4,  5 ]
				//
				// AdjA = [ 9,   8, -2 ]
				//        [ 0,  15,  3 ]
				//        [ 0, -12,  3 ]


				var matrix = new Matrix(3, 3);
				matrix[0, 0] = 3;
				matrix[0, 1] = 0;
				matrix[0, 2] = 2;

				matrix[1, 0] = 0;
				matrix[1, 1] = 1;
				matrix[1, 2] = -1;

				matrix[2, 0] = 0;
				matrix[2, 1] = 4;
				matrix[2, 2] = 5;

				var a = matrix.Adjoint();

				Assert.AreEqual(a[0, 0], 9);
				Assert.AreEqual(a[0, 1], 8);
				Assert.AreEqual(a[0, 2], -2);

				Assert.AreEqual(a[1, 0], 0);
				Assert.AreEqual(a[1, 1], 15);
				Assert.AreEqual(a[1, 2], 3);

				Assert.AreEqual(a[2, 0], 0);
				Assert.AreEqual(a[2, 1], -12);
				Assert.AreEqual(a[2, 2], 3);
			}

			[Test]
			public void AdjointInterface()
			{
				//A = [ 3, 0,  2 ]
				//    [ 0, 1, -1 ]
				//    [ 0, 4,  5 ]
				//
				// AdjA = [ 9,   8, -2 ]
				//        [ 0,  15,  3 ]
				//        [ 0, -12,  3 ]


				IMathematicalMatrix matrix = new Matrix(3, 3);
				matrix[0, 0] = 3;
				matrix[0, 1] = 0;
				matrix[0, 2] = 2;

				matrix[1, 0] = 0;
				matrix[1, 1] = 1;
				matrix[1, 2] = -1;

				matrix[2, 0] = 0;
				matrix[2, 1] = 4;
				matrix[2, 2] = 5;

				var a = matrix.Adjoint();

				Assert.AreEqual(a[0, 0], 9);
				Assert.AreEqual(a[0, 1], 8);
				Assert.AreEqual(a[0, 2], -2);

				Assert.AreEqual(a[1, 0], 0);
				Assert.AreEqual(a[1, 1], 15);
				Assert.AreEqual(a[1, 2], 3);

				Assert.AreEqual(a[2, 0], 0);
				Assert.AreEqual(a[2, 1], -12);
				Assert.AreEqual(a[2, 2], 3);
			}

			[Test]
			[ExpectedException(typeof(InvalidOperationException))]
			public void ExceptionNonSquare()
			{
				var matrix = new Matrix(3, 2);
				matrix.Adjoint();
			}

		}


		[TestFixture]
		public class Accept
		{

			[Test]
			public void Simple()
			{
				var visitor = new TrackingVisitor<double>();
				var matrix = GetTestMatrix();

				matrix.AcceptVisitor(visitor);

				Assert.AreEqual(visitor.TrackingList.Count, matrix.Rows * matrix.Columns);

				for (var i = 0; i < matrix.Rows; i++)
				{
					for (var j = 0; j < matrix.Columns; j++)
					{
						Assert.IsTrue(visitor.TrackingList.Contains(i + j));
					}
				}
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void NullVisitor()
			{
				var matrix = GetTestMatrix();
				matrix.AcceptVisitor(null);
			}

		}


		[TestFixture]
		public class AddRow
		{

			[Test]
			public void Simple1()
			{
				var matrix = GetTestMatrix();

				var columnCount = matrix.Columns;
				var rowCount = matrix.Rows;

				matrix.AddRow();

				Assert.AreEqual(matrix.Columns, columnCount);
				Assert.AreEqual(matrix.Rows, rowCount + 1);

				for (var i = 0; i < rowCount; i++)
				{
					for (var j = 0; j < columnCount; j++)
					{
						Assert.AreEqual(matrix[i, j], i + j);
					}
				}

				for (var i = 0; i < columnCount; i++)
				{
					Assert.AreEqual(matrix[rowCount, i], default(double));
				}
			}

			[Test]
			public void Simple2()
			{
				var matrix = GetTestMatrix();

				var columnCount = matrix.Columns;
				var rowCount = matrix.Rows;

				matrix.AddRow(0, -1, -2, -3, -4);

				Assert.AreEqual(matrix.Columns, columnCount);
				Assert.AreEqual(matrix.Rows, rowCount + 1);

				for (var i = 0; i < rowCount; i++)
				{
					for (var j = 0; j < columnCount; j++)
					{
						Assert.AreEqual(matrix[i, j], i + j);
					}
				}

				for (var i = 0; i < columnCount; i++)
				{
					Assert.AreEqual(matrix[rowCount, i], -1 * i);
				}
			}

			[Test]
			public void Simple3()
			{
				var matrix = GetTestMatrix();

				var columnCount = matrix.Columns;
				var rowCount = matrix.Rows;

				matrix.AddRow(0, -1, -2);

				Assert.AreEqual(matrix.Columns, columnCount);
				Assert.AreEqual(matrix.Rows, rowCount + 1);

				for (var i = 0; i < rowCount; i++)
				{
					for (var j = 0; j < columnCount; j++)
					{
						Assert.AreEqual(matrix[i, j], i + j);
					}
				}

				Assert.AreEqual(matrix[rowCount, 0], 0);
				Assert.AreEqual(matrix[rowCount, 1], -1);
				Assert.AreEqual(matrix[rowCount, 2], -2);
				Assert.AreEqual(matrix[rowCount, 3], 0);
				Assert.AreEqual(matrix[rowCount, 4], 0);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNull1()
			{
				var matrix = GetTestMatrix();
				matrix.AddRow(null);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void Exception1()
			{
				var matrix = GetTestMatrix();
				matrix.AddRow(1, 2, 3, 4, 5, 6);
			}

			[Test]
			public void MultipleRows()
			{
				var matrix = GetTestMatrix();

				var columnCount = matrix.Columns;
				var rowCount = matrix.Rows;

				matrix.AddRows(3);

				Assert.AreEqual(matrix.Columns, columnCount);
				Assert.AreEqual(matrix.Rows, rowCount + 3);

				for (var i = 0; i < rowCount; i++)
				{
					for (var j = 0; j < columnCount; j++)
					{
						Assert.AreEqual(matrix[i, j], i + j);
					}
				}

				for (var i = 0; i < columnCount; i++)
				{
					for (var j = 0; j < 3; j++)
					{
						Assert.AreEqual(matrix[rowCount + j, i], default(double));
					}
				}
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionNegativeRows()
			{
				var matrix = GetTestMatrix();
				matrix.AddRows(-1);
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionZeroRows()
			{
				var matrix = GetTestMatrix();
				matrix.AddRows(0);
			}

		}


		[TestFixture]
		public class AddColumn
		{

			[Test]
			public void Simple()
			{
				var matrix = GetTestMatrix();

				var columnCount = matrix.Columns;
				var rowCount = matrix.Rows;

				matrix.AddColumn();

				Assert.AreEqual(matrix.Columns, columnCount + 1);
				Assert.AreEqual(matrix.Rows, rowCount);

				for (var i = 0; i < rowCount; i++)
				{
					for (var j = 0; j < columnCount; j++)
					{
						Assert.AreEqual(matrix[i, j], i + j);
					}
				}

				for (var i = 0; i < rowCount; i++)
				{
					Assert.AreEqual(matrix[i, columnCount], default(double));
				}
			}

			[Test]
			public void Simple2()
			{
				var matrix = GetTestMatrix();

				var columnCount = matrix.Columns;
				var rowCount = matrix.Rows;

				matrix.AddColumn(0, -1, -2, -3);

				Assert.AreEqual(matrix.Columns, columnCount + 1);
				Assert.AreEqual(matrix.Rows, rowCount);

				for (var i = 0; i < rowCount; i++)
				{
					for (var j = 0; j < columnCount; j++)
					{
						Assert.AreEqual(matrix[i, j], i + j);
					}
				}

				for (var i = 0; i < rowCount; i++)
				{
					Assert.AreEqual(matrix[i, columnCount], -1 * i);
				}
			}

			[Test]
			public void Simple3()
			{
				var matrix = GetTestMatrix();

				var columnCount = matrix.Columns;
				var rowCount = matrix.Rows;

				matrix.AddColumn(0, -1, -2);

				Assert.AreEqual(matrix.Columns, columnCount + 1);
				Assert.AreEqual(matrix.Rows, rowCount);

				for (var i = 0; i < rowCount; i++)
				{
					for (var j = 0; j < columnCount; j++)
					{
						Assert.AreEqual(matrix[i, j], i + j);
					}
				}

				Assert.AreEqual(matrix[0, columnCount], 0);
				Assert.AreEqual(matrix[1, columnCount], -1);
				Assert.AreEqual(matrix[2, columnCount], -2);
				Assert.AreEqual(matrix[3, columnCount], 0);
			}


			[Test]
			public void MultipleColumns()
			{
				var matrix = GetTestMatrix();

				var columnCount = matrix.Columns;
				var rowCount = matrix.Rows;

				matrix.AddColumns(3);

				Assert.AreEqual(matrix.Columns, columnCount + 3);
				Assert.AreEqual(matrix.Rows, rowCount);

				for (var i = 0; i < rowCount; i++)
				{
					for (var j = 0; j < columnCount; j++)
					{
						Assert.AreEqual(matrix[i, j], i + j);
					}
				}

				for (var i = 0; i < rowCount; i++)
				{
					for (var j = 0; j < 3; j++)
					{
						Assert.AreEqual(matrix[i, matrix.Columns - j - 1], default(double));
					}
				}
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullColumn()
			{
				var matrix = GetTestMatrix();
				matrix.AddColumn(null);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionTooManyValues()
			{
				var matrix = GetTestMatrix();
				matrix.AddColumn(1, 2, 3, 4, 5);
			}
			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionNegativeColumns()
			{
				var matrix = GetTestMatrix();
				matrix.AddColumns(-1);
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionZeroColumns()
			{
				var matrix = GetTestMatrix();
				matrix.AddColumns(0);
			}

		}


		[TestFixture]
		public class ChangeSignColumn
		{

			[Test]
			public void Simple()
			{
				var matrix = new Matrix(3, 3);

				// [ 1,  4,  7 ]
				// [ 2,  5,  8 ]
				// [ 3,  6,  9 ]


				matrix[0, 0] = 1;
				matrix[0, 1] = 4;
				matrix[0, 2] = 7;

				matrix[1, 0] = 2;
				matrix[1, 1] = 5;
				matrix[1, 2] = 8;

				matrix[2, 0] = 3;
				matrix[2, 1] = 6;
				matrix[2, 2] = 9;

				matrix.ChangeSignColumn(1);

				Assert.AreEqual(matrix[0, 1], -4);
				Assert.AreEqual(matrix[1, 1], -5);
				Assert.AreEqual(matrix[2, 1], -6);
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionColumnIndexLessThan0()
			{
				var matrix = new Matrix(3, 3);
				matrix.ChangeSignColumn(-1);
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionColumnIndexGreaterThanColumnCount()
			{
				var matrix = new Matrix(3, 3);
				matrix.ChangeSignColumn(3);
			}

		}


		[TestFixture]
		public class ChangeSignRow
		{

			[Test]
			public void Simple()
			{
				var matrix = new Matrix(3, 3);

				// [ 1,  4,  7 ]
				// [ 2,  5,  8 ]
				// [ 3,  6,  9 ]


				matrix[0, 0] = 1;
				matrix[0, 1] = 4;
				matrix[0, 2] = 7;

				matrix[1, 0] = 2;
				matrix[1, 1] = 5;
				matrix[1, 2] = 8;

				matrix[2, 0] = 3;
				matrix[2, 1] = 6;
				matrix[2, 2] = 9;

				matrix.ChangeSignRow(1);

				Assert.AreEqual(matrix[1, 0], -2);
				Assert.AreEqual(matrix[1, 1], -5);
				Assert.AreEqual(matrix[1, 2], -8);
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionRowIndexLessThan0()
			{
				var matrix = new Matrix(3, 3);
				matrix.ChangeSignRow(-1);
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionRowIndexGreaterThanRowCount()
			{
				var matrix = new Matrix(3, 3);
				matrix.ChangeSignRow(3);
			}

		}


		[TestFixture]
		public class Clear
		{

			[Test]
			public void Simple()
			{
				var matrix = GetTestMatrix();

				matrix.Clear();

				for (var i = 0; i < matrix.Rows; i++)
				{
					for (var j = 0; j < matrix.Columns; j++)
					{
						Assert.AreEqual(matrix[i, j], 0);
					}
				}
			}

		}


		[TestFixture]
		public class Contruction
		{

			[Test]
			public void Simple()
			{
				var matrix = new Matrix(2, 3);
				Assert.AreEqual(matrix.Rows, 2);
				Assert.AreEqual(matrix.Columns, 3);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void UnsuccessfulRowNegative()
			{
				new Matrix(-1, 2);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionRowZero()
			{
				new Matrix(0, 2);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionColumnNegative()
			{
				new Matrix(2, -1);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionColumnZero()
			{
				new Matrix(2, 0);
			}

		}


		[TestFixture]
		public class Contains
		{

			[Test]
			public void Simple()
			{
				var matrix = GetTestMatrix();

				for (var i = 0; i < matrix.Rows; i++)
				{
					for (var j = 0; j < matrix.Columns; j++)
					{
						Assert.IsTrue(matrix.Contains(i + j));
					}
				}

				Assert.IsFalse(matrix.Contains(-5));
			}

		}


		[TestFixture]
		public class CopyTo
		{

			[Test]
			public void Simple()
			{
				var matrix = GetTestMatrix();

				var array = new double[matrix.Rows * matrix.Columns];

				matrix.CopyTo(array, 0);

				var list = new List<double>(array);

				for (var i = 0; i < matrix.Rows; i++)
				{
					for (var j = 0; j < matrix.Columns; j++)
					{
						Assert.IsTrue(list.Contains(i + j));
					}
				}
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullArray()
			{
				var matrix = GetTestMatrix();
				matrix.CopyTo(null, 0);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionInvalidArrayLength12()
			{
				var matrix = GetTestMatrix();

				var array = new double[matrix.Rows * matrix.Columns];

				matrix.CopyTo(array, 1);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionInvalidArrayLength1()
			{
				var matrix = GetTestMatrix();

				var array = new double[matrix.Rows * matrix.Columns - 1];

				matrix.CopyTo(array, 0);
			}

		}


		[TestFixture]
		public class Clone
		{

			[Test]
			public void Simple()
			{
				var matrix = GetTestMatrix();
				var clone = matrix.Clone();


				Assert.AreEqual(matrix.Rows, clone.Rows);
				Assert.AreEqual(matrix.Columns, clone.Columns);

				for (var i = 0; i < matrix.Rows; i++)
				{
					for (var j = 0; j < matrix.Columns; j++)
					{
						Assert.AreEqual(matrix[i, j], clone[i, j]);
					}
				}
			}

			[Test]
			public void InterfaceClone()
			{
				var matrix = GetTestMatrix();
				var clone = (Matrix)((ICloneable)matrix).Clone();


				Assert.AreEqual(matrix.Rows, clone.Rows);
				Assert.AreEqual(matrix.Columns, clone.Columns);

				for (var i = 0; i < matrix.Rows; i++)
				{
					for (var j = 0; j < matrix.Columns; j++)
					{
						Assert.AreEqual(matrix[i, j], clone[i, j]);
					}
				}
			}

		}


		[TestFixture]
		public class Concatenate
		{

			[Test]
			public void Simple()
			{
				var matrix1 = GetTestMatrix();
				var matrix2 = GetTestMinusMatrix();

				var concat = matrix1.Concatenate(matrix2);

				Assert.AreEqual(concat.Rows, matrix1.Rows);
				Assert.AreEqual(concat.Columns, matrix1.Columns + matrix2.Columns);

				for (var i = 0; i < matrix1.Rows; i++)
				{
					for (var j = 0; j < matrix1.Columns; j++)
					{
						Assert.AreEqual(concat[i, j], matrix1[i, j]);
					}
				}

				for (var i = 0; i < matrix2.Rows; i++)
				{
					for (var j = 0; j < matrix2.Columns; j++)
					{
						Assert.AreEqual(concat[i, j + matrix1.Columns], matrix2[i, j]);
					}
				}
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullMatrix()
			{
				var matrix1 = GetTestMatrix();
				matrix1.Concatenate(null);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionDifferentRowSizesLarger()
			{
				var matrix1 = GetTestMatrix();
				var matrix2 = GetTestMinusMatrix();

				// Add a row to make the row sizes different
				matrix2.AddRow();

				matrix1.Concatenate(matrix2);
			}
			private static Matrix GetTestMinusMatrix()
			{
				var matrix = new Matrix(4, 5);

				for (var i = 0; i < matrix.Rows; i++)
				{
					for (var j = 0; j < matrix.Columns; j++)
					{
						matrix[i, j] = i - j;
					}
				}

				return matrix;
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionDifferentRowSizesSmaller()
			{
				var matrix1 = GetTestMatrix();
				var matrix2 = GetTestMinusMatrix();

				// Add a row to make the row sizes different
				matrix2.DeleteRow(0);

				matrix1.Concatenate(matrix2);
			}

			[Test]
			public void ConcatenateInterface()
			{
				IMathematicalMatrix matrix1 = GetTestMatrix();
				IMathematicalMatrix matrix2 = GetTestMinusMatrix();

				var concat = matrix1.Concatenate(matrix2);

				Assert.AreEqual(concat.Rows, matrix1.Rows);
				Assert.AreEqual(concat.Columns, matrix1.Columns + matrix2.Columns);

				for (var i = 0; i < matrix1.Rows; i++)
				{
					for (var j = 0; j < matrix1.Columns; j++)
					{
						Assert.AreEqual(concat[i, j], matrix1[i, j]);
					}
				}

				for (var i = 0; i < matrix2.Rows; i++)
				{
					for (var j = 0; j < matrix2.Columns; j++)
					{
						Assert.AreEqual(concat[i, j + matrix1.Columns], matrix2[i, j]);
					}
				}
			}

		}

          [TestFixture]
          public class Rank
          {

             [Test]
             public void Simple()
             {
                var matrix = new Matrix(4, 4);

                // [ 2,  4,  1,  3 ]
                // [-1, -2,  1,  0 ]
                // [ 0,  0,  2,  2 ]
                // [ 3,  6,  2,  5 ]
                // rank 2

                matrix[0, 0] = 2;
                matrix[0, 1] = 4;
                matrix[0, 2] = 1;
                matrix[0, 3] = 3;

                matrix[1, 0] = -1;
                matrix[1, 1] = -2;
                matrix[1, 2] = 1;
                matrix[1, 3] = 0;

                matrix[2, 0] =  0;
                matrix[2, 1] = 0;
                matrix[2, 2] =  2;
                matrix[2, 3] =  2;

                matrix[3, 0] = 3;
                matrix[3, 1] =  6;
                matrix[3, 2] = 2;
                matrix[3, 3] = 5;

                Assert.AreEqual(2, matrix.Rank());
             }
          }


		[TestFixture]
		public class Determinant
		{

			[Test]
			public void Simple()
			{
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

                Assert.AreEqual(14, matrix.Determinant(), 0.000000001);
			}

			[Test]
			public void Simple2()
			{
				var matrix = new Matrix(4, 4);

				// [ 1,  2,  3,  4 ]
				// [ 5,  6,  7,  8 ]
				// [ 2,  6,  4,  8 ]
				// [ 3,  1,  1,  2 ]
				// Determinant = 72

				matrix[0, 0] = 1;
				matrix[0, 1] = 2;
				matrix[0, 2] = 3;
				matrix[0, 3] = 4;

				matrix[1, 0] = 5;
				matrix[1, 1] = 6;
				matrix[1, 2] = 7;
				matrix[1, 3] = 8;

				matrix[2, 0] = 2;
				matrix[2, 1] = 6;
				matrix[2, 2] = 4;
				matrix[2, 3] = 8;

				matrix[3, 0] = 3;
				matrix[3, 1] = 1;
				matrix[3, 2] = 1;
				matrix[3, 3] = 2;

				Assert.AreEqual(matrix.Determinant(), 72, 0.000000001);
			}

			[Test]
            [ExpectedException(typeof(InvalidOperationException))]
			public void ExceptionNotSquare()
			{
				var matrix = new Matrix(2, 3);
				matrix.Determinant();
			}

		}
		
		[TestFixture]
		public class Diagonal
		{

			[Test]
			public void Simple()
			{
				var matrix = Matrix.Diagonal(10, 10, 5);
				TestDiagonalValues(matrix, 10, 10, 5);

				matrix = Matrix.Diagonal(4, 7, 9);
				TestDiagonalValues(matrix, 4, 7, 9);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionInvalidRow1()
			{
				Matrix.Diagonal(-1, 10, 4);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionInvalidColumn1()
			{
				Matrix.Diagonal(10, -1, 4);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionInvalidRow2()
			{
				Matrix.Diagonal(0, 10, 4);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionInvalidColumn2()
			{
				Matrix.Diagonal(10, 0, 4);
			}

		}


		[TestFixture]
		public class Equality
		{

			[Test]
			public void Simple()
			{
				var matrix1 = new Matrix(5, 6);
				var matrix2 = new Matrix(5, 6);

				Assert.IsTrue(matrix1.Equals(matrix2));

				for (var i = 0; i < matrix1.Rows; i++)
				{
					for (var j = 0; j < matrix1.Columns; j++)
					{
						matrix1[i, j] = i + j;
						matrix2[i, j] = i + j;
					}
				}

				Assert.IsTrue(matrix1.Equals(matrix2));
				Assert.IsFalse(matrix1.Equals(null));
			}

			[Test]
			public void NotEquals()
			{
				var matrix1 = new Matrix(5, 6);
				var matrix2 = new Matrix(5, 7);
				var matrix3 = new Matrix(5, 6);
				var matrix4 = new Matrix(6, 6);

				// Columns are not the same
				Assert.IsFalse(matrix1.Equals(matrix2));

				// Rows are not the same
				Assert.IsFalse(matrix1.Equals(matrix4));

				for (var i = 0; i < matrix1.Rows; i++)
				{
					for (var j = 0; j < matrix1.Columns; j++)
					{
						matrix1[i, j] = i + j;
						matrix3[i, j] = i + j;
					}
				}

				// One value is different
				matrix3[4, 4] = 0;

				Assert.IsFalse(matrix1.Equals(matrix3));

			}

			[Test]
			public void NotEqualsOperator()
			{
				var matrix1 = new Matrix(5, 6);
				var matrix2 = new Matrix(5, 7);
				var matrix3 = new Matrix(5, 6);
				var matrix4 = new Matrix(6, 6);

				// Columns are not the same
				Assert.IsTrue(matrix1 != (matrix2));

				// Rows are not the same
				Assert.IsTrue(matrix1 != matrix4);

				for (var i = 0; i < matrix1.Rows; i++)
				{
					for (var j = 0; j < matrix1.Columns; j++)
					{
						matrix1[i, j] = i + j;
						matrix3[i, j] = i + j;
					}
				}

				// One value is different
				matrix3[4, 4] = 0;

				Assert.IsTrue(matrix1 != matrix3);

				// Disable warning C1718 : Testing equality of same variable
#pragma warning disable 1718

				Assert.IsFalse(matrix1 != matrix1);
				Assert.IsFalse(matrix2 != matrix2);

#pragma warning restore 1718
			}

		}


		[TestFixture]
		public class FrobeniusNorm
		{

			[Test]
			public void Simple()
			{
				var matrix = new Matrix(1, 2);
				matrix[0, 0] = 3;
				matrix[0, 1] = 4;

				Assert.AreEqual(matrix.FrobeniusNorm, 5);
			}

		}


		[TestFixture]
		public class GetEnumerator
		{

			[Test]
			public void InterfaceEnumerator()
			{
				var matrix = GetTestMatrix();

				var enumerator = ((IEnumerable)matrix).GetEnumerator();

				var moved = false;

				var i = 0;
				var j = 0;

				var totalCount = 0;

				while (enumerator.MoveNext())
				{
					moved = true;
					totalCount++;

					Assert.AreEqual((double)enumerator.Current, matrix[i, j]);

					j++;

					if (j > matrix.Columns - 1)
					{
						j = 0;
						i++;
					}
				}

				Assert.AreEqual(totalCount, matrix.Columns * matrix.Rows);
				Assert.AreEqual(i, matrix.Columns - 1);
				Assert.AreEqual(j, 0);

				// Test that we did indeed move through the enumerator
				Assert.IsTrue(moved);
			}

			[Test]
			public void Simple()
			{
				var matrix = GetTestMatrix();

				var enumerator = matrix.GetEnumerator();

				var moved = false;

				var i = 0;
				var j = 0;

				var totalCount = 0;

				while (enumerator.MoveNext())
				{
					moved = true;
					totalCount++;

					Assert.AreEqual(enumerator.Current, matrix[i, j]);

					j++;

					if (j > matrix.Columns - 1)
					{
						j = 0;
						i++;
					}
				}

				Assert.AreEqual(totalCount, matrix.Columns * matrix.Rows);
				Assert.AreEqual(i, matrix.Columns - 1);
				Assert.AreEqual(j, 0);

				// Test that we did indeed move through the enumerator
				Assert.IsTrue(moved);
			}

		}


		[TestFixture]
		public class GetHashcode
		{

			[Test]
			public void Simple()
			{
				var d = new Dictionary<Matrix, string>();

				for (var i = 0; i < 10; i++)
				{
					var test = GetTestMatrix();
					Assert.IsFalse(d.ContainsKey(test));
					d.Add(test, null);
				}
			}

		}


		[TestFixture]
		public class GetSubMatrix
		{

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionInvalidGetSubMatrix1()
			{
				var matrix = GetTestMatrix();
				matrix.GetSubMatrix(-1, 0, 1, 1);
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionInvalidGetSubMatrix2()
			{
				var matrix = GetTestMatrix();
				matrix.GetSubMatrix(0, -1, 1, 1);
			}

			[Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionInvalidGetSubMatrix3()
			{
				var matrix = GetTestMatrix();
				matrix.GetSubMatrix(0, 0, 0, 1);
			}

			[Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionInvalidGetSubMatrix4()
			{
				var matrix = GetTestMatrix();
				matrix.GetSubMatrix(0, 0, 1, 0);
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionInvalidGetSubMatrix5()
			{
				var matrix = GetTestMatrix();
				matrix.GetSubMatrix(0, 0, 6, 6);
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionInvalidGetSubMatrix6()
			{
				var matrix = GetTestMatrix();
				matrix.GetSubMatrix(0, 0, 4, 7);
			}

			[Test]
			public void Simple()
			{
				var matrix = GetTestMatrix();

				var subMatrix = matrix.GetSubMatrix(0, 0, 3, 3);

				Assert.AreEqual(subMatrix.Rows, 3);
				Assert.AreEqual(subMatrix.Columns, 3);

				for (var i = 0; i < subMatrix.Rows; i++)
				{
					for (var j = 0; j < subMatrix.Columns; j++)
					{
						Assert.AreEqual(subMatrix[i, j], i + j);
					}
				}

				subMatrix = matrix.GetSubMatrix(1, 2, 3, 3);

				for (var i = 0; i < subMatrix.Rows; i++)
				{
					for (var j = 0; j < subMatrix.Columns; j++)
					{
						Assert.AreEqual(subMatrix[i, j], i + 1 + j + 2);
					}
				}
			}

			[Test]
			public void InterfaceGetSubMatrix()
			{
				var matrix = GetTestMatrix();

                var subMatrix = matrix.GetSubMatrix(0, 0, 3, 3);

				Assert.AreEqual(subMatrix.Rows, 3);
				Assert.AreEqual(subMatrix.Columns, 3);

				for (var i = 0; i < subMatrix.Rows; i++)
				{
					for (var j = 0; j < subMatrix.Columns; j++)
					{
						Assert.AreEqual(subMatrix[i, j], i + j);
					}
				}

				subMatrix = (Matrix)((IMatrix<double>)matrix).GetSubMatrix(1, 2, 3, 3);

				for (var i = 0; i < subMatrix.Rows; i++)
				{
					for (var j = 0; j < subMatrix.Columns; j++)
					{
						Assert.AreEqual(subMatrix[i, j], i + 1 + j + 2);
					}
				}
			}

		}


		[TestFixture]
		public class GetRow
		{

			[Test]
			public void Simple()
			{
				var matrix = GetTestMatrix();

				var columnCount = matrix.Columns;
				var rowCount = matrix.Rows;

				var row = matrix.GetRow(0);

				Assert.AreEqual(matrix.Columns, columnCount);
				Assert.AreEqual(matrix.Rows, rowCount);

				Assert.AreEqual(row.Length, matrix.Columns);

				for (var i = 0; i < row.Length; i++)
				{
					Assert.AreEqual(row[i], i);
				}

				row = matrix.GetRow(1);

				Assert.AreEqual(row.Length, matrix.Columns);

				for (var i = 0; i < row.Length; i++)
				{
					Assert.AreEqual(row[i], i + 1);
				}
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionInvalidGetRow1()
			{
				var matrix = GetTestMatrix();
				matrix.GetRow(-1);
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionInvalidGetRow2()
			{
				var matrix = GetTestMatrix();
				matrix.GetRow(matrix.Rows);
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionInvalidGetRow3()
			{
				var matrix = GetTestMatrix();
				matrix.GetRow(matrix.Rows + 1);
			}

		}


		[TestFixture]
		public class GetColumn
		{

			[Test]
			public void Simple()
			{
				var matrix = GetTestMatrix();

				var columnCount = matrix.Columns;
				var rowCount = matrix.Rows;

				var column = matrix.GetColumn(0);

				Assert.AreEqual(matrix.Columns, columnCount);
				Assert.AreEqual(matrix.Rows, rowCount);

				Assert.AreEqual(column.Length, matrix.Rows);

				for (var i = 0; i < column.Length; i++)
				{
					Assert.AreEqual(column[i], i);
				}

				column = matrix.GetColumn(1);

				Assert.AreEqual(column.Length, matrix.Rows);

				for (var i = 0; i < column.Length; i++)
				{
					Assert.AreEqual(column[i], i + 1);
				}
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionInvalidGetColumn1()
			{
				var matrix = GetTestMatrix();
				matrix.GetColumn(-1);
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionInvalidGetColumn2()
			{
				var matrix = GetTestMatrix();
				matrix.GetColumn(matrix.Columns);
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionInvalidGetColumn3()
			{
				var matrix = GetTestMatrix();
				matrix.GetColumn(matrix.Columns + 1);
			}

		}


		[TestFixture]
		public class IdentityMatrix
		{

			[Test]
			public void Simple()
			{
				var matrix = Matrix.IdentityMatrix(10, 10);
				TestDiagonalValues(matrix, 10, 10, 1);

				matrix = Matrix.IdentityMatrix(4, 7);
				TestDiagonalValues(matrix, 4, 7, 1);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionInvalidRow1()
			{
				Matrix.IdentityMatrix(-1, 10);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionInvalidColumn1()
			{
				Matrix.IdentityMatrix(10, -1);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionInvalidRow2()
			{
				Matrix.IdentityMatrix(0, 10);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionInvalidColumn2()
			{
				Matrix.IdentityMatrix(10, 0);
			}

		}


		[TestFixture]
		public class Indexes
		{

			[Test]
			public void Simple()
			{
				var matrix = new Matrix(4, 5);

				for (var i = 0; i < matrix.Rows; i++)
				{
					for (var j = 0; j < matrix.Columns; j++)
					{
						matrix[i, j] = i + j;
					}
				}

				for (var i = 0; i < matrix.Rows; i++)
				{
					for (var j = 0; j < matrix.Columns; j++)
					{
						Assert.AreEqual(matrix[i, j], i + j);
					}
				}
			}

		}


		[TestFixture]
		public class IsDiagonal
		{

			[Test]
			public void DifferentNumberOfRowsAndColumns()
			{
				var matrix = new Matrix(5, 2);
				Assert.IsFalse(matrix.IsDiagonal);
			}

			[Test]
			public void True()
			{
				var matrix = new Matrix(2, 2);

				matrix[0, 0] = 1;
				matrix[0, 1] = 0;
				matrix[1, 0] = 0;
				matrix[1, 1] = 1;
				Assert.IsTrue(matrix.IsDiagonal);
			}

			[Test]
			public void False()
			{
				var matrix = new Matrix(2, 2);
				matrix[0, 0] = 1;
				matrix[0, 1] = 0;
				matrix[1, 0] = 1;
				matrix[1, 1] = 1;
				Assert.IsFalse(matrix.IsDiagonal);
			}
		}


	

	

		


		[TestFixture]
		public class IsReadOnly
		{

			[Test]
			public void Simple()
			{
				var matrix = new Matrix(5, 5);
				Assert.IsFalse(matrix.IsReadOnly);

				matrix = GetTestMatrix();
				Assert.IsFalse(matrix.IsReadOnly);
			}

		}


		[TestFixture]
		public class IsSquare
		{

			[Test]
			public void Simple()
			{
				var matrix = new Matrix(10, 10);

				Assert.IsTrue(matrix.IsSquare);

				matrix = new Matrix(3, 4);
				Assert.IsFalse(matrix.IsSquare);

				matrix = new Matrix(35, 35);
				Assert.IsTrue(matrix.IsSquare);

				matrix = new Matrix(45, 44);
				Assert.IsFalse(matrix.IsSquare);
			}

		}

		[TestFixture]
		public class IsSymmetric
		{

			[Test]
			public void Simple()
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

		}


		[TestFixture]
		public class InterchangeRows
		{

			[Test]
			public void Simple()
			{
				var matrix = GetTestMatrix();

				var columnCount = matrix.Columns;
				var rowCount = matrix.Rows;

				matrix.InterchangeRows(0, 1);

				Assert.AreEqual(matrix.Columns, columnCount);
				Assert.AreEqual(matrix.Rows, rowCount);

				for (var i = 0; i < matrix.Rows; i++)
				{
					for (var j = 0; j < matrix.Columns; j++)
					{
						if (i == 0)
						{
							Assert.AreEqual(matrix[i, j], (i + 1) + (j));
						}
						else if (i == 1)
						{
							Assert.AreEqual(matrix[i, j], (i - 1) + (j));
						}
						else
						{
							Assert.AreEqual(matrix[i, j], i + j);
						}
					}
				}
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionInvalidRow1()
			{
				var matrix = GetTestMatrix();
				matrix.InterchangeRows(-1, 1);
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionInvalidRow2()
			{
				var matrix = GetTestMatrix();
				matrix.InterchangeRows(matrix.Rows, 1);
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionInvalidRow3()
			{
				var matrix = GetTestMatrix();
				matrix.InterchangeRows(0, -1);
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionInvalidRow4()
			{
				var matrix = GetTestMatrix();
				matrix.InterchangeRows(0, matrix.Rows);
			}

		}


		[TestFixture]
		public class InterchangeColumns
		{

			[Test]
			public void Simple()
			{
				var matrix = GetTestMatrix();

				var columnCount = matrix.Columns;
				var rowCount = matrix.Rows;

				matrix.InterchangeColumns(0, 1);

				Assert.AreEqual(matrix.Columns, columnCount);
				Assert.AreEqual(matrix.Rows, rowCount);

				for (var i = 0; i < matrix.Rows; i++)
				{
					for (var j = 0; j < matrix.Columns; j++)
					{
						if (j == 0)
						{
							Assert.AreEqual(matrix[i, j], (i) + (j + 1));
						}
						else if (j == 1)
						{
							Assert.AreEqual(matrix[i, j], (i) + (j - 1));
						}
						else
						{
							Assert.AreEqual(matrix[i, j], i + j);
						}
					}
				}
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionInvalidColumn1()
			{
				var matrix = GetTestMatrix();
				matrix.InterchangeColumns(-1, 1);
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionInvalidColumn2()
			{
				var matrix = GetTestMatrix();
				matrix.InterchangeColumns(matrix.Columns, 1);
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionInvalidColumn3()
			{
				var matrix = GetTestMatrix();
				matrix.InterchangeColumns(0, -1);
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionInvalidColumn4()
			{
				var matrix = GetTestMatrix();
				matrix.InterchangeColumns(0, matrix.Columns);
			}

		}


		[TestFixture]
		public class InfinityNorm
		{

			[Test]
			public void Simple()
			{
				var matrix = new Matrix(2, 2);
				matrix[0, 0] = 1;
				matrix[0, 1] = 2;
				matrix[1, 0] = 3;
				matrix[1, 1] = 4;

				Assert.AreEqual(matrix.InfinityNorm, 7);
			}

		}


		[TestFixture]
		public class IsSingular
		{

			[Test]
			public void True()
			{
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

				Assert.AreEqual(matrix.IsSingular, true);
			}

				[Test]
				public void False()
				{
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

					Assert.AreEqual(matrix.IsSingular, false);
				}

				[Test]
				public void InterfaceIsSingular()
				{
					IMathematicalMatrix matrix = new Matrix(3, 3);

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

					Assert.AreEqual(matrix.IsSingular, true);
				}
			
		}


		[TestFixture]
		public class IsTriangular
		{

			[Test]
			public void Simple()
			{
				var matrix = new Matrix(3, 3);

				// [ 1,  4,  7 ]
				// [ 2,  5,  8 ]
				// [ 3,  6,  9 ]


				matrix[0, 0] = 1;
				matrix[0, 1] = 4;
				matrix[0, 2] = 7;

				matrix[1, 0] = 0;
				matrix[1, 1] = 5;
				matrix[1, 2] = 8;

				matrix[2, 0] = 0;
				matrix[2, 1] = 0;
				matrix[2, 2] = 0;


				Console.WriteLine(matrix);
				Assert.AreEqual(matrix.IsTriangular, TriangularMatrixType.Upper);
				matrix = matrix.Transpose();
				Console.WriteLine(matrix);
				Assert.AreEqual(matrix.IsTriangular, TriangularMatrixType.Lower);
			}

			[Test]
			public void DifferingNumberOfColumnsAndRows()
			{
				var matrix = new Matrix(3, 4);
				Assert.AreEqual(TriangularMatrixType.None, matrix.IsTriangular);
			}

		}


		[TestFixture]
		public class Inverse
		{

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionZeroDeterminant()
			{
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

				matrix.Inverse();
			}

         [Test]
         public void Simple2()
         {
            // [  19.6, 24.974999999999998,  36.999999999999993 ] -1
            // [  24.974999999999998,  52.125000000000014,  67.5 ]
            // [  36.999999999999993, 67.5,  100.0 ]
            //
            // = 
            //
            // [  1,        -1,   -1 ]
            // [  -(6/5),  7/5,  4/5 ]
            // [  -(2/5),  4/5,  3/5 ]



            var matrix = new Matrix(3, 3);
            matrix[0, 0] = 19.6;
            matrix[0, 1] = 24.974999999999998;
            matrix[0, 2] = 36.999999999999993;

            matrix[1, 0] = 24.974999999999998;
            matrix[1, 1] = 52.125000000000014;
            matrix[1, 2] = 67.5;

            matrix[2, 0] = 36.999999999999993;
            matrix[2, 1] = 67.5;
            matrix[2, 2] = 100.0;

            var inv = matrix.Inverse();



            Assert.AreEqual(inv[0, 0], 0.169204737732656, 0.000000001);
            Assert.AreEqual(inv[0, 1], -1.44028932924345E-16, 0.000000001);
            Assert.AreEqual(inv[0, 2], -0.0626057529610827, 0.000000001);

            Assert.AreEqual(inv[1, 0], -7.20806576118106E-17, 0.00001);
            Assert.AreEqual(inv[1, 1], 0.152380952380952, 0.00001);
            Assert.AreEqual(inv[1, 2], -0.102857142857143, 0.00001);

            Assert.AreEqual(inv[2, 0], -0.0626057529610828, 0.00001);
            Assert.AreEqual(inv[2, 1], -0.102857142857142, 0.00001);
            Assert.AreEqual(inv[2, 2], 0.102592700024172, 0.00001);
         }

			[Test]
			public void Simple()
			{
				// [  1, -1,  3 ] -1
				// [  2,  1,  2 ]
				// [ -2, -2,  1 ]
				//
				// = 
				//
				// [  1,        -1,   -1 ]
				// [  -(6/5),  7/5,  4/5 ]
				// [  -(2/5),  4/5,  3/5 ]


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

				var a = matrix.Inverse();

                Assert.AreEqual(a[0, 0], 1, 0.000000001);
                Assert.AreEqual(a[0, 1], -1, 0.000000001);
                Assert.AreEqual(a[0, 2], -1, 0.000000001);

                Assert.AreEqual(a[1, 0], (6F / 5F) * -1F, 0.00001);
                Assert.AreEqual(a[1, 1], 7F / 5F, 0.00001);
                Assert.AreEqual(a[1, 2], 4F / 5F, 0.00001);

                Assert.AreEqual(a[2, 0], (2F / 5F) * -1F, 0.00001);
                Assert.AreEqual(a[2, 1], 4F / 5F, 0.00001);
                Assert.AreEqual(a[2, 2], 3F / 5F, 0.00001);
			}

			[Test]
			public void InverseInterface()
			{
				// [  1, -1,  3 ] -1
				// [  2,  1,  2 ]
				// [ -2, -2,  1 ]
				//
				// = 
				//
				// [  1,        -1,   -1 ]
				// [  -(6/5),  7/5,  4/5 ]
				// [  -(2/5),  4/5,  3/5 ]


				IMathematicalMatrix matrix = new Matrix(3, 3);
				matrix[0, 0] = 1;
				matrix[0, 1] = -1;
				matrix[0, 2] = 3;

				matrix[1, 0] = 2;
				matrix[1, 1] = 1;
				matrix[1, 2] = 2;

				matrix[2, 0] = -2;
				matrix[2, 1] = -2;
				matrix[2, 2] = 1;

				var a = matrix.Inverse();

                Assert.AreEqual(a[0, 0], 1, 0.000000001);
                Assert.AreEqual(a[0, 1], -1, 0.000000001);
                Assert.AreEqual(a[0, 2], -1, 0.000000001);

                Assert.AreEqual(a[1, 0], (6F / 5F) * -1F, 0.00001);
                Assert.AreEqual(a[1, 1], 7F / 5F, 0.00001);
                Assert.AreEqual(a[1, 2], 4F / 5F, 0.00001);

                Assert.AreEqual(a[2, 0], (2F / 5F) * -1F, 0.00001);
                Assert.AreEqual(a[2, 1], 4F / 5F, 0.00001);
                Assert.AreEqual(a[2, 2], 3F / 5F, 0.00001);
			}

		}


		[TestFixture]
		public class LinearSolve
		{
		
			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullLeft()
			{
				Matrix.LinearSolve(null, new Matrix(3, 3));
			}

		}


		[TestFixture]
		public class Minor
		{

			[Test]
			public void TopLeft()
			{
				var matrix = GetTestMatrix();

				var rows = matrix.Rows;
				var columns = matrix.Columns;

				var minor = matrix.Minor(0, 0);

				Assert.AreEqual(minor.Columns, columns - 1);
				Assert.AreEqual(minor.Rows, rows - 1);

				for (var i = 0; i < minor.Rows; i++)
				{
					for (var j = 0; j < minor.Columns; j++)
					{
						Assert.AreEqual(minor[i, j], i + j + 2);
					}
				}

				Assert.IsTrue(IsOriginalTestMatrix(matrix));
			}

			[Test]
			public void TopRight()
			{
				var matrix = GetTestMatrix();

				var rows = matrix.Rows;
				var columns = matrix.Columns;

				var minor = matrix.Minor(0, matrix.Columns - 1);

				Assert.AreEqual(minor.Columns, columns - 1);
				Assert.AreEqual(minor.Rows, rows - 1);

				for (var i = 0; i < minor.Rows; i++)
				{
					for (var j = 0; j < minor.Columns; j++)
					{
						Assert.AreEqual(minor[i, j], i + j + 1);
					}
				}

				Assert.IsTrue(IsOriginalTestMatrix(matrix));
			}

			[Test]
			public void BottomLeft()
			{
				var matrix = GetTestMatrix();

				var rows = matrix.Rows;
				var columns = matrix.Columns;

				var minor = matrix.Minor(matrix.Rows - 1, 0);

				Assert.AreEqual(minor.Columns, columns - 1);
				Assert.AreEqual(minor.Rows, rows - 1);

				for (var i = 0; i < minor.Rows; i++)
				{
					for (var j = 0; j < minor.Columns; j++)
					{
						Assert.AreEqual(minor[i, j], i + j + 1);
					}
				}

				Assert.IsTrue(IsOriginalTestMatrix(matrix));
			}

			[Test]
			public void BottomRight()
			{
				var matrix = GetTestMatrix();

				var rows = matrix.Rows;
				var columns = matrix.Columns;

				var minor = matrix.Minor(matrix.Rows - 1, matrix.Columns - 1);

				Assert.AreEqual(minor.Columns, columns - 1);
				Assert.AreEqual(minor.Rows, rows - 1);

				for (var i = 0; i < minor.Rows; i++)
				{
					for (var j = 0; j < minor.Columns; j++)
					{
						Assert.AreEqual(minor[i, j], i + j);
					}
				}

				Assert.IsTrue(IsOriginalTestMatrix(matrix));
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionColumnNegative()
			{
				var matrix = GetTestMatrix();
				matrix.Minor(2, -1);
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionColumnOutOfRange()
			{
				var matrix = GetTestMatrix();
				matrix.Minor(2, matrix.Columns);
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionRowNegative()
			{
				var matrix = GetTestMatrix();
				matrix.Minor(-1, 2);
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionRowOutOfRange()
			{
				var matrix = GetTestMatrix();
				matrix.Minor(matrix.Rows, 2);
			}

			[Test]
			public void MinorArbitrary()
			{
				var matrix = GetTestMatrix();

				var rows = matrix.Rows;
				var columns = matrix.Columns;

				var minor = matrix.Minor(2, 3);

				Assert.AreEqual(minor.Columns, columns - 1);
				Assert.AreEqual(minor.Rows, rows - 1);

				for (var i = 0; i < minor.Rows; i++)
				{
					for (var j = 0; j < minor.Columns; j++)
					{
						var addAmount = 0;

						if (i >= 2)
						{
							addAmount++;
						}

						if (j >= 3)
						{
							addAmount++;
						}

						Assert.AreEqual(minor[i, j], i + j + addAmount);
					}
				}

				Assert.IsTrue(IsOriginalTestMatrix(matrix));
			}

			[Test]
			public void MinorTopLeftInterface()
			{
				IMathematicalMatrix matrix = GetTestMatrix();

				var rows = matrix.Rows;
				var columns = matrix.Columns;

				var minor = matrix.Minor(0, 0);

				Assert.AreEqual(minor.Columns, columns - 1);
				Assert.AreEqual(minor.Rows, rows - 1);

				for (var i = 0; i < minor.Rows; i++)
				{
					for (var j = 0; j < minor.Columns; j++)
					{
						Assert.AreEqual(minor[i, j], i + j + 2);
					}
				}

				Assert.IsTrue(IsOriginalTestMatrix(matrix));
			}

			[Test]
			public void MinorTopRightInterface()
			{
				IMathematicalMatrix matrix = GetTestMatrix();

				var rows = matrix.Rows;
				var columns = matrix.Columns;

				var minor = matrix.Minor(0, matrix.Columns - 1);

				Assert.AreEqual(minor.Columns, columns - 1);
				Assert.AreEqual(minor.Rows, rows - 1);

				for (var i = 0; i < minor.Rows; i++)
				{
					for (var j = 0; j < minor.Columns; j++)
					{
						Assert.AreEqual(minor[i, j], i + j + 1);
					}
				}

				Assert.IsTrue(IsOriginalTestMatrix(matrix));
			}

			[Test]
			public void MinorBottomLeftInterface()
			{
				IMathematicalMatrix matrix = GetTestMatrix();

				var rows = matrix.Rows;
				var columns = matrix.Columns;

				var minor = matrix.Minor(matrix.Rows - 1, 0);

				Assert.AreEqual(minor.Columns, columns - 1);
				Assert.AreEqual(minor.Rows, rows - 1);

				for (var i = 0; i < minor.Rows; i++)
				{
					for (var j = 0; j < minor.Columns; j++)
					{
						Assert.AreEqual(minor[i, j], i + j + 1);
					}
				}

				Assert.IsTrue(IsOriginalTestMatrix(matrix));
			}

			[Test]
			public void MinorBottomRightInterface()
			{
				IMathematicalMatrix matrix = GetTestMatrix();

				var rows = matrix.Rows;
				var columns = matrix.Columns;

				var minor = matrix.Minor(matrix.Rows - 1, matrix.Columns - 1);

				Assert.AreEqual(minor.Columns, columns - 1);
				Assert.AreEqual(minor.Rows, rows - 1);

				for (var i = 0; i < minor.Rows; i++)
				{
					for (var j = 0; j < minor.Columns; j++)
					{
						Assert.AreEqual(minor[i, j], i + j);
					}
				}

				Assert.IsTrue(IsOriginalTestMatrix(matrix));
			}

			[Test]
			public void MinorArbitraryInterface()
			{
				IMathematicalMatrix matrix = GetTestMatrix();

				var rows = matrix.Rows;
				var columns = matrix.Columns;

				var minor = matrix.Minor(2, 3);

				Assert.AreEqual(minor.Columns, columns - 1);
				Assert.AreEqual(minor.Rows, rows - 1);

				for (var i = 0; i < minor.Rows; i++)
				{
					for (var j = 0; j < minor.Columns; j++)
					{
						var addAmount = 0;

						if (i >= 2)
						{
							addAmount++;
						}

						if (j >= 3)
						{
							addAmount++;
						}

						Assert.AreEqual(minor[i, j], i + j + addAmount);
					}
				}

				Assert.IsTrue(IsOriginalTestMatrix(matrix));
			}
		}


		[TestFixture]
		public class Minus
		{

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionIncompatibleMatrices()
			{
				var matrix1 = new Matrix(2, 3);
				matrix1[0, 0] = 1;
				matrix1[0, 1] = 2;
				matrix1[0, 2] = -4;
				matrix1[1, 0] = 0;
				matrix1[1, 1] = 3;
				matrix1[1, 2] = -1;

				var matrix2 = GetTestMatrix();

				matrix1.Subtract(matrix2);
			}

			[Test]
			public void Simple()
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

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionIncompatibleMatrices2()
			{
				IMathematicalMatrix matrix1 = new Matrix(2, 3);
				matrix1[0, 0] = 1;
				matrix1[0, 1] = 2;
				matrix1[0, 2] = -4;
				matrix1[1, 0] = 0;
				matrix1[1, 1] = 3;
				matrix1[1, 2] = -1;

				IMathematicalMatrix matrix2 = GetTestMatrix();

				matrix1.Subtract(matrix2);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionInterfaceMinusNull()
			{
				IMathematicalMatrix matrix = GetTestMatrix();
				matrix.Subtract(null);
			}


			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionSubtractNull()
			{
				var matrix = GetTestMatrix();
				matrix.Subtract(null);
			}

			[Test]
			public void InterfaceMinus()
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

				var result = (Matrix)((IMathematicalMatrix)matrix1).Subtract(matrix2);

				Assert.IsTrue(result.Equals(expectedMatrix));
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullMinus1()
			{
				var matrix1 = new Matrix(2, 3);
				var result = matrix1 - null;
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullMinus2()
			{
				var matrix1 = new Matrix(2, 3);
				var result = null - matrix1;
			}

		}


		[TestFixture]
		public class Multiply
		{

			[Test]
			public void TimesDouble()
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

				var result = matrix1 * 2;
				Assert.IsTrue(result.Equals(expectedMatrix));

				result = 2 * matrix1;
				Assert.IsTrue(result.Equals(expectedMatrix));
			}
			[Test]
			public void Multiplication()
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


			[Test]
			public void InterfaceTimesDouble()
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

				var result = (Matrix)((IMathematicalMatrix)matrix1).Multiply(2);
				Assert.IsTrue(result.Equals(expectedMatrix));
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionInterfaceIncompatibleMatrices()
			{
				IMathematicalMatrix matrix1 = new Matrix(2, 3);
				matrix1[0, 0] = 1;
				matrix1[0, 1] = 2;
				matrix1[0, 2] = -4;
				matrix1[1, 0] = 0;
				matrix1[1, 1] = 3;
				matrix1[1, 2] = -1;

				IMathematicalMatrix matrix2 = GetTestMatrix();

				matrix1.Multiply(matrix2);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionInterfaceTimesNull()
			{
				IMathematicalMatrix matrix = GetTestMatrix();
				matrix.Multiply(null);
			}

			[Test]
			public void InterfaceMultiplication()
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

				var result = (Matrix)((IMathematicalMatrix)matrix1).Multiply(matrix2);

				Assert.IsTrue(result.Equals(expectedMatrix));
			}


			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void IncompatibleSizes()
			{
				var matrix1 = new Matrix(2, 3);
				var matrix2 = new Matrix(4, 2);
				var result = matrix1 * matrix2;							// Should throw an ArgumentException since the matrices are of incompatible sizes
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionMultiplicationNull1()
			{
				var matrix = new Matrix(2, 3);
				var result = matrix * null;
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNull2()
			{
				var matrix = new Matrix(2, 3);
				var result = null * matrix;
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNull3()
			{
				var result = ((Matrix)null) * 3;
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNull4()
			{
				var result = 3 * ((Matrix)null);
			}
		}


		[TestFixture]
		public class MultiplyRow
		{

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionIndexNegative()
			{
				var matrix = GetTestMatrix();
				matrix.MultiplyRow(-1, 2);
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionRowGreaterThanRows()
			{
				var matrix = GetTestMatrix();
				matrix.MultiplyRow(matrix.Rows, 2);
			}

			[Test]
			public void RowFirst()
			{
				var matrix = GetTestMatrix();
				matrix.MultiplyRow(0, 2);

				for (var i = 0; i < matrix.Rows; i++)
				{
					for (var j = 0; j < matrix.Columns; j++)
					{
						if (i == 0)
						{
							Assert.AreEqual(matrix[i, j], 2 * (i + j));
						}
						else
						{
							Assert.AreEqual(matrix[i, j], i + j);
						}
					}
				}
			}

			[Test]
			public void RowLast()
			{
				var matrix = GetTestMatrix();
				matrix.MultiplyRow(matrix.Rows - 1, 2);

				for (var i = 0; i < matrix.Rows; i++)
				{
					for (var j = 0; j < matrix.Columns; j++)
					{
						if (i == matrix.Rows - 1)
						{
							Assert.AreEqual(matrix[i, j], 2 * (i + j));
						}
						else
						{
							Assert.AreEqual(matrix[i, j], i + j);
						}
					}
				}
			}

			[Test]
			public void RowArbitrary()
			{
				var matrix = GetTestMatrix();
				matrix.MultiplyRow(3, 2);

				for (var i = 0; i < matrix.Rows; i++)
				{
					for (var j = 0; j < matrix.Columns; j++)
					{
						if (i == 3)
						{
							Assert.AreEqual(matrix[i, j], 2 * (i + j));
						}
						else
						{
							Assert.AreEqual(matrix[i, j], i + j);
						}
					}
				}
			}

			[Test]
			public void RowArbitraryInterface()
			{
				IMathematicalMatrix matrix = GetTestMatrix();
				matrix.MultiplyRow(3, 2);

				for (var i = 0; i < matrix.Rows; i++)
				{
					for (var j = 0; j < matrix.Columns; j++)
					{
						if (i == 3)
						{
							Assert.AreEqual(matrix[i, j], 2 * (i + j));
						}
						else
						{
							Assert.AreEqual(matrix[i, j], i + j);
						}
					}
				}
			}

		}


		[TestFixture]
		public class MultiplyColumn
		{

			[Test]
			public void ColumnFirst()
			{
				var matrix = GetTestMatrix();
				matrix.MultiplyColumn(0, 2);

				for (var i = 0; i < matrix.Rows; i++)
				{
					for (var j = 0; j < matrix.Columns; j++)
					{
						if (j == 0)
						{
							Assert.AreEqual(matrix[i, j], 2 * (i + j));
						}
						else
						{
							Assert.AreEqual(matrix[i, j], i + j);
						}
					}
				}
			}

			[Test]
			public void ColumnLast()
			{
				var matrix = GetTestMatrix();
				matrix.MultiplyColumn(matrix.Columns - 1, 2);

				for (var i = 0; i < matrix.Rows; i++)
				{
					for (var j = 0; j < matrix.Columns; j++)
					{
						if (j == matrix.Columns - 1)
						{
							Assert.AreEqual(matrix[i, j], 2 * (i + j));
						}
						else
						{
							Assert.AreEqual(matrix[i, j], i + j);
						}
					}
				}
			}

			[Test]
			public void ColumnArbitrary()
			{
				var matrix = GetTestMatrix();
				matrix.MultiplyColumn(3, 2);

				for (var i = 0; i < matrix.Rows; i++)
				{
					for (var j = 0; j < matrix.Columns; j++)
					{
						if (j == 3)
						{
							Assert.AreEqual(matrix[i, j], 2 * (i + j));
						}
						else
						{
							Assert.AreEqual(matrix[i, j], i + j);
						}
					}
				}
			}

			[Test]
			public void ColumnArbitraryInterface()
			{
				IMathematicalMatrix matrix = GetTestMatrix();
				matrix.MultiplyColumn(3, 3);

				for (var i = 0; i < matrix.Rows; i++)
				{
					for (var j = 0; j < matrix.Columns; j++)
					{
						if (j == 3)
						{
							Assert.AreEqual(matrix[i, j], 3 * (i + j));
						}
						else
						{
							Assert.AreEqual(matrix[i, j], i + j);
						}
					}
				}
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionIndexNegative()
			{
				var matrix = GetTestMatrix();
				matrix.MultiplyColumn(-1, 2);
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionInvalidIndex()
			{
				var matrix = GetTestMatrix();
				matrix.MultiplyColumn(matrix.Columns, 2);
			}

		}


		[TestFixture]
		public class Negate
		{

			[Test]
			public void Simple()
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

			[Test]
			public void InterfaceNegate()
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

				var result = (Matrix)((IMathematicalMatrix)matrix1).Negate();

				Assert.IsTrue(result.Equals(expectedMatrix));
			}

		}


		[TestFixture]
		public class OneNorm
		{

			[Test]
			public void Simple()
			{
				var matrix = new Matrix(2, 2);
				matrix[0, 0] = 1;
				matrix[0, 1] = 2;
				matrix[1, 0] = 3;
				matrix[1, 1] = 4;

				Assert.AreEqual(matrix.OneNorm, 6);
			}

		}


		[TestFixture]
		public class Plus
		{

			[Test]
			public void Simple()
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

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullOperatorPlus1()
			{
				var matrix = GetTestMatrix();
				var newMatrix = null + matrix;
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullOperatorPlus2()
			{
				var matrix = GetTestMatrix();
				var newMatrix = matrix + null;
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionIncompatibleMatrices()
			{
				IMathematicalMatrix matrix1 = new Matrix(2, 3);
				matrix1[0, 0] = 1;
				matrix1[0, 1] = 2;
				matrix1[0, 2] = -4;
				matrix1[1, 0] = 0;
				matrix1[1, 1] = 3;
				matrix1[1, 2] = -1;

				IMathematicalMatrix matrix2 = GetTestMatrix();

				matrix1.Add(matrix2);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionPlusNull()
			{
				IMathematicalMatrix matrix = GetTestMatrix();
				matrix.Add(null);
			}

			[Test]
			public void ExceptionInterfacePlus()
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

				var result = (Matrix)((IMathematicalMatrix)matrix1).Add(matrix2);

				Assert.IsTrue(result.Equals(expectedMatrix));
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionDifferentSizes()
			{
				var matrix1 = new Matrix(2, 3);
				var matrix2 = new Matrix(3, 2);

				// Should throw an ArgumentException since the matrices are of different sizes
				var result = matrix1 + matrix2;
			}
		}


		[TestFixture]
		public class Remove
		{

			[Test]
			[ExpectedException(typeof(NotSupportedException))]
			public void InterfaceRemove()
			{
				ICollection<double> matrix = GetTestMatrix();
				matrix.Remove(5);
			}

		}

		[TestFixture]
		public class Resize
		{

			[Test]
			public void Smaller()
			{
				var matrix = GetTestMatrix();

				matrix.Resize(2, 2);

				Assert.AreEqual(matrix.Columns, 2);
				Assert.AreEqual(matrix.Rows, 2);

				for (var i = 0; i < 2; i++)
				{
					for (var j = 0; j < 2; j++)
					{
						Assert.AreEqual(matrix[i, j], i + j);
					}
				}
			}

			[Test]
			public void Larger()
			{
				var matrix = GetTestMatrix();

				var columnCount = matrix.Columns;
				var rowCount = matrix.Rows;

				matrix.Resize(8, 8);

				Assert.AreEqual(matrix.Columns, 8);
				Assert.AreEqual(matrix.Rows, 8);

				for (var i = 0; i < rowCount; i++)
				{
					for (var j = 0; j < columnCount; j++)
					{
						Assert.AreEqual(matrix[i, j], i + j);
					}
				}

				for (var i = rowCount; i < 8; i++)
				{
					for (var j = columnCount; j < 8; j++)
					{
						Assert.AreEqual(matrix[i, j], default(double));
					}
				}
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionNewRowsNegative()
			{
				var matrix = GetTestMatrix();
				matrix.Resize(-1, 8);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionNewColumnsNegative()
			{
				var matrix = GetTestMatrix();
				matrix.Resize(8, -1);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionNewRowsZero()
			{
				var matrix = GetTestMatrix();
				matrix.Resize(8, 0);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionNewColumnsZero()
			{
				var matrix = GetTestMatrix();
				matrix.Resize(0, 8);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionInvalidSize5()
			{
				var matrix = GetTestMatrix();
				matrix.Resize(-1, -1);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionNewColumnsAndNewRowsTooSmall()
			{
				var matrix = GetTestMatrix();
				matrix.Resize(0, 0);
			}

		}


		[TestFixture]
		public class Solve
		{

			[Test]
			public void Square()
			{
				// A: [2,2]((0,1),(2,0))
				// > B: [2,2]((1,0),(0,-1))
				// > X: [2,2]((0,-0.5),(1,0))

				var matrixA = new Matrix(2, 2);

				matrixA[0, 0] = 0;
				matrixA[0, 1] = 1;

				matrixA[1, 0] = 2;
				matrixA[1, 1] = 0;

				var matrixB = new Matrix(2, 2);

				matrixB[0, 0] = 1;
				matrixB[0, 1] = 0;

				matrixB[1, 0] = 0;
				matrixB[1, 1] = -1;

                var solveMatrix = matrixA.Solve(matrixB);

				Assert.AreEqual(solveMatrix.Rows, 2);
				Assert.AreEqual(solveMatrix.Columns, 2);

				Assert.AreEqual(solveMatrix[0, 0], 0);
				Assert.AreEqual(solveMatrix[0, 1], -0.5);

				Assert.AreEqual(solveMatrix[1, 0], 1);
				Assert.AreEqual(solveMatrix[1, 1], 0);
			}

			[Test]
			public void Rectangular()
			{
				var matrixA = new Matrix(3, 2);

				matrixA[0, 0] = 1;
				matrixA[0, 1] = 2;

				matrixA[1, 0] = 3;
				matrixA[1, 1] = 4;

				matrixA[2, 0] = 4;
				matrixA[2, 1] = 2;

				var matrixB = new Matrix(3, 2);

				matrixB[0, 0] = 3;
				matrixB[0, 1] = 4;

				matrixB[1, 0] = 4;
				matrixB[1, 1] = 2;

				matrixB[2, 0] = 1;
				matrixB[2, 1] = 2;

				var solveMatrix = matrixA.Solve(matrixB);

				Assert.AreEqual(solveMatrix.Rows, 2);
				Assert.AreEqual(solveMatrix.Columns, 2);

				Assert.AreEqual(solveMatrix[0, 0], -0.514285714, 0.00000001);
				Assert.AreEqual(solveMatrix[0, 1], -0.057142857, 0.00000001);

				Assert.AreEqual(solveMatrix[1, 0], 1.4714285714, 0.00000001);
				Assert.AreEqual(solveMatrix[1, 1], 0.8857142857, 0.00000001);
			}

		}

		
		[TestFixture]
		public class Serializability
		{

			[Test]
			public void Simple()
			{
				var matrix = GetTestMatrix();
				var newMatrix = SerializeUtil.BinarySerializeDeserialize(matrix);

				Assert.AreNotSame(matrix, newMatrix);
				Assert.AreEqual(matrix.Rows, newMatrix.Rows);
				Assert.AreEqual(matrix.Columns, newMatrix.Columns);

				Assert.IsTrue(matrix.Equals(newMatrix));
			}

		}


		[TestFixture]
		public class Trace
		{

			[Test]
			public void Simple()
			{
				var matrix = new Matrix(10, 10);
				Assert.AreEqual(matrix.Trace, 0);

				matrix[0, 0] = 5;

				Assert.AreEqual(matrix.Trace, 5);

				matrix = Matrix.Diagonal(5, 5, 5);
				Assert.AreEqual(matrix.Trace, 25);

				matrix = Matrix.IdentityMatrix(6, 7);
				Assert.AreEqual(matrix.Trace, 6);
			}

		}


		[TestFixture]
		public class ToArray
		{

			[Test]
			public void Simple()
			{
				var matrix = new Matrix(3, 2);

				// [ 1,  4,  7 ]
				// [ 2,  5,  8 ]
				// [ 3,  6,  9 ]


				matrix[0, 0] = 1;
				matrix[0, 1] = 4;

				matrix[1, 0] = 2;
				matrix[1, 1] = 5;

				matrix[2, 0] = 3;
				matrix[2, 1] = 6;

				var array = matrix.ToArray();

				Assert.AreEqual(1, array[0,0]);
				Assert.AreEqual(4, array[0,1]);
				Assert.AreEqual(2, array[1,0]);
				Assert.AreEqual(5, array[1,1]);
				Assert.AreEqual(3, array[2,0]);
				Assert.AreEqual(6, array[2,1]);
			}

		}


		[TestFixture]
		public class Transpose
		{

			[Test]
			public void Simple()
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

			[Test]
			public void InterfaceTranspose()
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

				var result = (Matrix)((IMathematicalMatrix)matrix1).Transpose();

				Assert.IsTrue(result.Equals(expectedMatrix));
			}

        }

        #endregion

        #region Private Members

        private static void TestDiagonalValues(Matrix matrix, int rows, int columns, int value)
		{
			Assert.AreEqual(matrix.Rows, rows);
			Assert.AreEqual(matrix.Columns, columns);

			for (var i = 0; i < rows; i++)
			{
				for (var j = 0; j < columns; j++)
				{
					if (i == j)
					{
						Assert.AreEqual(matrix[i, j], value);
					}
					else
					{
						Assert.AreEqual(matrix[i, j], 0);
					}
				}
			}
		}

		private static Matrix GetTestMatrix()
		{
			var matrix = new Matrix(4, 5);

			for (var i = 0; i < matrix.Rows; i++)
			{
				for (var j = 0; j < matrix.Columns; j++)
				{
					matrix[i, j] = i + j;
				}
			}

			return matrix;
		}

		private static bool IsOriginalTestMatrix(IMathematicalMatrix matrix)
		{
			for (var i = 0; i < matrix.Rows; i++)
			{
				for (var j = 0; j < matrix.Columns; j++)
				{
					if (matrix[i, j] != i + j)
					{
						return false;
					}
				}
			}

			return true;
		}



		#endregion
	}
}