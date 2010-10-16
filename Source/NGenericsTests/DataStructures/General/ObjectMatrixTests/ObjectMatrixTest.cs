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
using NGenerics.Patterns.Visitor;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ObjectMatrixTest
{
   
    public class ObjectMatrixTest
    {  
        #region Private Members

        internal static void TestIfEqual(ObjectMatrix<int> l, ObjectMatrix<int> r)
        {
            Assert.AreEqual(l.Columns, r.Columns);
            Assert.AreEqual(l.Rows, r.Rows);

            for (var i = 0; i < l.Rows; i++)
            {
                for (var j = 0; j < l.Columns; j++)
                {
                    Assert.AreEqual(l[i, j], r[i, j]);
                }
            }
        }

        internal static ObjectMatrix<int> GetTestMatrix()
        {
            var matrix = new ObjectMatrix<int>(10, 15);

            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 15; j++)
                {
                    matrix[i, j] = i + j;
                }
            }

            return matrix;
        }

        #endregion
    }

        #region Tests

        [TestFixture]
        public class Accept:ObjectMatrixTest
        {
            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullVisitor()
            {
                var matrix = GetTestMatrix();
                matrix.AcceptVisitor(null);
            }

            [Test]
			public void Simple()
            {
                var visitor = new TrackingVisitor<int>();

                var matrix = GetTestMatrix();

                matrix.AcceptVisitor(visitor);

                Assert.AreEqual(visitor.TrackingList.Count, matrix.Columns * matrix.Rows);

                for (var i = 0; i < matrix.Rows; i++)
                {
                    for (var j = 0; j < matrix.Columns; j++)
                    {
                        Assert.IsTrue(visitor.TrackingList.Contains(i + j));
                    }
                }
            }
        }

        [TestFixture]
        public class Add:ObjectMatrixTest
        {
            [Test]
            [ExpectedException(typeof(NotSupportedException))]
            public void ExceptionInterface()
            {
                var matrix = GetTestMatrix();
                ((ICollection<int>) matrix).Add(5);
            }
        }

        [TestFixture]
        public class AddColumn:ObjectMatrixTest
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
            public void Values1()
            {
                var matrix = GetTestMatrix();

                var columnCount = matrix.Columns;
                var rowCount = matrix.Rows;

                matrix.AddColumn(0, -1, -2, -3, -4, -5, -6, -7, -8, -9);

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
            public void Values2()
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
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullValues()
            {
                var matrix = GetTestMatrix();
                matrix.AddColumn(null);
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void ExceptionIncorrectNumberOfColumns()
            {
                var matrix = GetTestMatrix();
                matrix.AddColumn(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            }
        }

        [TestFixture]
        public class AddColumns:ObjectMatrixTest
        {
            [Test]
            public void Multiple()
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
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ESimpletionNegativeColumnCount()
            {
                var matrix = GetTestMatrix();
                matrix.AddColumns(-1);
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ExceptionZeroColumnCount()
            {
                var matrix = GetTestMatrix();
                matrix.AddColumns(0);
            }
        }

        [TestFixture]
        public class AddRow:ObjectMatrixTest
        {
            [Test]
            public void Simple()
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
            public void Values1()
            {
                var matrix = GetTestMatrix();

                var columnCount = matrix.Columns;
                var rowCount = matrix.Rows;

                matrix.AddRow(0, -1, -2, -3, -4, -5, -6, -7, -8, -9, -10, -11, -12, -13, -14);

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
            public void Values2()
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
            public void ExceptionNullValues()
            {
                var matrix = GetTestMatrix();
                matrix.AddRow(null);
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void ExceptionIncorrectNumberOfRows()
            {
                var matrix = GetTestMatrix();
                matrix.AddRow(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            }
        }

        [TestFixture]
        public class AddRows:ObjectMatrixTest
        {
            [Test]
            public void Multiple()
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
            public void ExceptionNegativeRowCount()
            {
                var matrix = GetTestMatrix();
                matrix.AddRows(-1);
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionZeroRowCount()
            {
                var matrix = GetTestMatrix();
                matrix.AddRows(0);
            }
        }

        [TestFixture]
        public class Construction:ObjectMatrixTest
        {
            [Test]
            public void Simple()
            {
                var matrix = new ObjectMatrix<int>(10, 15);
                Assert.AreEqual(matrix.Rows, 10);
                Assert.AreEqual(matrix.Columns, 15);

                matrix = new ObjectMatrix<int>(5, 13);
                Assert.AreEqual(matrix.Rows, 5);
                Assert.AreEqual(matrix.Columns, 13);
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void ExceptionNegativeRows()
            {
                new ObjectMatrix<int>(-1, 20);
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void ExceptionZeroRows()
            {
                new ObjectMatrix<int>(0, 20);
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void ExceptionNegativeColomns()
            {
                new ObjectMatrix<int>(50, -1);
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void ExceptionZeroColumns()
            {
                new ObjectMatrix<int>(50, 0);
            }
        }

        [TestFixture]
        public class Clear:ObjectMatrixTest
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
        public class Contains:ObjectMatrixTest
        {
            [Test]
			public void Simple()
            {
                var matrix = new ObjectMatrix<int>(10, 15);

                matrix[5, 5] = 13;

                Assert.IsTrue(matrix.Contains(13));
                Assert.IsFalse(matrix.Contains(15));

                matrix[2, 3] = 15;

                Assert.IsTrue(matrix.Contains(13));
                Assert.IsTrue(matrix.Contains(15));
                Assert.IsFalse(matrix.Contains(17));
            }
        }

        [TestFixture]
        public class CopyTo:ObjectMatrixTest
        {
            [Test]
			public void Simple()
            {
                var matrix = GetTestMatrix();

                var array = new int[matrix.Rows * matrix.Columns];

                matrix.CopyTo(array, 0);

                var list = new List<int>(array);

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
            public void ExceptionIncorrectArrayLength1()
            {
                var matrix = GetTestMatrix();

                var array = new int[matrix.Rows * matrix.Columns];

                matrix.CopyTo(array, 1);
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
			public void ExceptionIncorrectArrayLength2()
            {
                var matrix = GetTestMatrix();

                var array = new int[matrix.Rows * matrix.Columns - 1];

                matrix.CopyTo(array, 0);
            }
        }

        [TestFixture]
        public class Count:ObjectMatrixTest
        {
            [Test]
            public void Simple()
            {
                ICollection<int> matrix = new ObjectMatrix<int>(10, 15);

                Assert.AreEqual(matrix.Count, 150);

                matrix = new ObjectMatrix<int>(3, 3);
                Assert.AreEqual(matrix.Count, 9);
            }
        }

        [TestFixture]
        public class DeleteRow:ObjectMatrixTest
        {
            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionNegativeRow()
            {
                var matrix = GetTestMatrix();
                matrix.DeleteRow(-1);
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ExceptionRowInvalid()
            {
                var matrix = GetTestMatrix();
                matrix.DeleteRow(matrix.Rows);
            }


            [Test]
            public void First()
            {
                var matrix = GetTestMatrix();

                var rows = matrix.Rows;
                var columns = matrix.Columns;

                matrix.DeleteRow(0);

                Assert.AreEqual(matrix.Rows, rows - 1);
                Assert.AreEqual(matrix.Columns, columns);

                for (var i = 1; i <= matrix.Rows; i++)
                {
                    for (var j = 0; j < matrix.Columns; j++)
                    {
                        Assert.AreEqual(matrix[i - 1, j], i + j);
                    }
                }
            }

            [Test]
            public void Arbitrary()
            {
                var matrix = GetTestMatrix();

                var rows = matrix.Rows;
                var columns = matrix.Columns;

                matrix.DeleteRow(2);

                Assert.AreEqual(matrix.Rows, rows - 1);
                Assert.AreEqual(matrix.Columns, columns);

                for (var i = 0; i < 2; i++)
                {
                    for (var j = 0; j < matrix.Columns; j++)
                    {
                        Assert.AreEqual(matrix[i, j], i + j);
                    }
                }

                for (var i = 2; i < matrix.Rows; i++)
                {
                    for (var j = 0; j < matrix.Columns; j++)
                    {
                        Assert.AreEqual(matrix[i, j], i + 1 + j);
                    }
                }
            }

            [Test]
            public void Last()
            {
                var matrix = GetTestMatrix();

                var rows = matrix.Rows;
                var columns = matrix.Columns;

                matrix.DeleteRow(rows - 1);

                Assert.AreEqual(matrix.Rows, rows - 1);
                Assert.AreEqual(matrix.Columns, columns);

                for (var i = 0; i < matrix.Rows - 1; i++)
                {
                    for (var j = 0; j < matrix.Columns; j++)
                    {
                        Assert.AreEqual(matrix[i, j], i + j);
                    }
                }
            }

            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionOnlyRow()
            {
                new ObjectMatrix<int>(1, 4).DeleteRow(0);
            }
        }

        [TestFixture]
        public class DeleteColumn:ObjectMatrixTest
        {
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionOnlyColumn()
            {
                new ObjectMatrix<int>(4, 1).DeleteColumn(0);
            }


            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionNegativeColumn()
            {
                var matrix = GetTestMatrix();
                matrix.DeleteColumn(-1);
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ExceptionColumnInvalid()
            {
                var matrix = GetTestMatrix();
                matrix.DeleteColumn(matrix.Columns);
            }

            [Test]
            public void First()
            {
                var matrix = GetTestMatrix();

                var columnCount = matrix.Columns;
                var rowCount = matrix.Rows;

                matrix.DeleteColumn(0);

                Assert.AreEqual(matrix.Columns, columnCount - 1);
                Assert.AreEqual(matrix.Rows, rowCount);

                for (var i = 0; i < matrix.Rows; i++)
                {
                    for (var j = 0; j < matrix.Columns; j++)
                    {
                        Assert.AreEqual(matrix[i, j], i + j + 1);
                    }
                }
            }

            [Test]
            public void Arbitrary()
            {
                var matrix = GetTestMatrix();

                var columnCount = matrix.Columns;
                var rowCount = matrix.Rows;

                matrix.DeleteColumn(2);

                Assert.AreEqual(matrix.Columns, columnCount - 1);
                Assert.AreEqual(matrix.Rows, rowCount);

                for (var i = 0; i < rowCount; i++)
                {
                    for (var j = 0; j < 2; j++)
                    {
                        Assert.AreEqual(matrix[i, j], i + j);
                    }
                }

                for (var i = 0; i < matrix.Rows; i++)
                {
                    for (var j = 3; j < matrix.Columns; j++)
                    {
                        Assert.AreEqual(matrix[i, j], i + j + 1);
                    }
                }
            }

            [Test]
            public void Last()
            {
                var matrix = GetTestMatrix();

                var columnCount = matrix.Columns;
                var rowCount = matrix.Rows;

                matrix.DeleteColumn(matrix.Columns - 1);

                Assert.AreEqual(matrix.Columns, columnCount - 1);
                Assert.AreEqual(matrix.Rows, rowCount);

                for (var i = 0; i < rowCount; i++)
                {
                    for (var j = 0; j < columnCount - 1; j++)
                    {
                        Assert.AreEqual(matrix[i, j], i + j);
                    }
                }
            }
        }

        [TestFixture]
        public class GetColumn:ObjectMatrixTest
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
            public void ExceptionNegativeColumnIndex()
            {
                var matrix = GetTestMatrix();
                matrix.GetColumn(-1);
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionColumnTooLarge()
            {
                var matrix = GetTestMatrix();
                matrix.GetColumn(matrix.Columns);
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ExceptionColumnTooLarge2()
            {
                var matrix = GetTestMatrix();
                matrix.GetColumn(matrix.Columns + 1);
            }
        }

        [TestFixture]
        public class GetEnumerator:ObjectMatrixTest
        {
            [Test]
            public void Interface()
            {
                var matrix = GetTestMatrix();

                var list = new List<int>();

                var enumerator = ((IEnumerable)matrix).GetEnumerator();
                {
                    while (enumerator.MoveNext())
                    {
                        list.Add((int) enumerator.Current);
                    }
                }

                Assert.AreEqual(list.Count, matrix.Columns * matrix.Rows);

                for (var i = 0; i < matrix.Rows; i++)
                {
                    for (var j = 0; j < matrix.Columns; j++)
                    {
                        Assert.IsTrue(list.Contains(i + j));
                    }
                }
            }

            [Test]
			public void Simple()
            {
                var matrix = GetTestMatrix();

                var list = new List<int>();

                using (var enumerator = matrix.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        list.Add(enumerator.Current);
                    }
                }

                Assert.AreEqual(list.Count, matrix.Columns * matrix.Rows);

                for (var i = 0; i < matrix.Rows; i++)
                {
                    for (var j = 0; j < matrix.Columns; j++)
                    {
                        Assert.IsTrue(list.Contains(i + j));
                    }
                }
            }
        }
                
        [TestFixture]
        public class GetRow:ObjectMatrixTest
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
            public void ExceptionNegativeRowIndex()
            {
                var matrix = GetTestMatrix();
                matrix.GetRow(-1);
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ExceptionRowIndexTooLarge1()
            {
                var matrix = GetTestMatrix();
                matrix.GetRow(matrix.Rows);
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionRowIndexTooLarge2()
            {
                var matrix = GetTestMatrix();
                matrix.GetRow(matrix.Rows + 1);
            }

        }

        [TestFixture]
        public class GetSubMatrix:ObjectMatrixTest
        {
            [Test]
            public void Interface()
            {
                var matrix = GetTestMatrix();

                var result = (ObjectMatrix<int>) ((IMatrix<int>) matrix).GetSubMatrix(0, 0, 3, 3);

                Assert.AreEqual(result.Rows, 3);
                Assert.AreEqual(result.Columns, 3);

                for (var i = 0; i < result.Rows; i++)
                {
                    for (var j = 0; j < result.Columns; j++)
                    {
                        Assert.AreEqual(result[i, j], i + j);
                    }
                }

                result = (ObjectMatrix<int>) ((IMatrix<int>) matrix).GetSubMatrix(1, 2, 3, 3);

                for (var i = 0; i < result.Rows; i++)
                {
                    for (var j = 0; j < result.Columns; j++)
                    {
                        Assert.AreEqual(result[i, j], i + 1 + j + 2);
                    }
                }
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ExcetionInvalid1()
            {
                var matrix = GetTestMatrix();
                matrix.GetSubMatrix(-1, 0, 1, 1);
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExcetionInvalid2()
            {
                var matrix = GetTestMatrix();
                matrix.GetSubMatrix(0, -1, 1, 1);
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExcetionInvalid3()
            {
                var matrix = GetTestMatrix();
                matrix.GetSubMatrix(0, 0, 0, 1);
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExcetionInvalid4()
            {
                var matrix = GetTestMatrix();
                matrix.GetSubMatrix(0, 0, 1, 0);
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExcetionInvalid5()
            {
                var matrix = GetTestMatrix();
                matrix.GetSubMatrix(0, 0, 16, 6);
            }

            [Test]
            public void Simple()
            {
                var matrix = GetTestMatrix();

                var result = matrix.GetSubMatrix(0, 0, 3, 3);

                Assert.AreEqual(result.Rows, 3);
                Assert.AreEqual(result.Columns, 3);

                for (var i = 0; i < result.Rows; i++)
                {
                    for (var j = 0; j < result.Columns; j++)
                    {
                        Assert.AreEqual(result[i, j], i + j);
                    }
                }

                result = matrix.GetSubMatrix(1, 2, 3, 3);

                for (var i = 0; i < result.Rows; i++)
                {
                    for (var j = 0; j < result.Columns; j++)
                    {
                        Assert.AreEqual(result[i, j], i + 1 + j + 2);
                    }
                }
            }
        }

        [TestFixture]
        public class Indexer:ObjectMatrixTest
        {
            [Test]
			public void ExcetionInvalid()
            {
                var matrix = new ObjectMatrix<int>(10, 15);

                matrix[0, 0] = 5;
                Assert.AreEqual(matrix[0, 0], 5);

                matrix[3, 2] = 99;
                Assert.AreEqual(matrix[3, 2], 99);
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void Exception1()
            {
                var matrix = new ObjectMatrix<int>(10, 15);
                matrix[10, 0] = 5;
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void Exception2()
            {
                var matrix = new ObjectMatrix<int>(10, 15);
                matrix[9, 15] = 5;
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void Exception3()
            {
                var matrix = new ObjectMatrix<int>(10, 15);
                var i = matrix[10, 0];
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void Exception4()
            {
                var matrix = new ObjectMatrix<int>(10, 15);
                var i = matrix[9, 15];
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void Exception5()
            {
                var matrix = new ObjectMatrix<int>(10, 15);
                var i = matrix[-1, 0];
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void Exception6()
            {
                var matrix = new ObjectMatrix<int>(10, 15);
                var i = matrix[9, -1];
            }
        }

        [TestFixture]
        public class InterchangeColumns:ObjectMatrixTest
        {
            [Test]
            public void SameColumn()
            {
                var matrix = GetTestMatrix();

                var columnCount = matrix.Columns;
                var rowCount = matrix.Rows;

                matrix.InterchangeColumns(1, 1);

                Assert.AreEqual(matrix.Columns, columnCount);
                Assert.AreEqual(matrix.Rows, rowCount);

                TestIfEqual(GetTestMatrix(), matrix);
            }

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
            public void ExceptionNegativeFirstColumn()
            {
                var matrix = GetTestMatrix();
                matrix.InterchangeColumns(-1, 1);
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ExceptionFirstColumnTooLarge()
            {
                var matrix = GetTestMatrix();
                matrix.InterchangeColumns(matrix.Columns, 1);
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionNegativeSecondColumn()
            {
                var matrix = GetTestMatrix();
                matrix.InterchangeColumns(0, -1);
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionSecondColumnTooLarge()
            {
                var matrix = GetTestMatrix();
                matrix.InterchangeColumns(0, matrix.Columns);
            }
        }

        [TestFixture]
        public class InterchangeRows:ObjectMatrixTest
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
            public void SameRow()
            {
                var matrix = GetTestMatrix();

                var columnCount = matrix.Columns;
                var rowCount = matrix.Rows;

                matrix.InterchangeRows(1, 1);

                Assert.AreEqual(matrix.Columns, columnCount);
                Assert.AreEqual(matrix.Rows, rowCount);

                TestIfEqual(GetTestMatrix(), matrix);
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionNegativeFirstRow()
            {
                var matrix = GetTestMatrix();
                matrix.InterchangeRows(-1, 1);
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ExceptionFirstRowTooLarge()
            {
                var matrix = GetTestMatrix();
                matrix.InterchangeRows(matrix.Rows, 1);
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionNegativeSecondRow()
            {
                var matrix = GetTestMatrix();
                matrix.InterchangeRows(0, -1);
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionSecondRowTooLarge()
            {
                var matrix = GetTestMatrix();
                matrix.InterchangeRows(0, matrix.Rows);
            }
        }

  
        [TestFixture]
        public class IsReadOnly:ObjectMatrixTest
        {
            [Test]
			public void Simple()
            {
                var matrix = new ObjectMatrix<int>(5, 5);
                Assert.IsFalse(matrix.IsReadOnly);

                matrix = GetTestMatrix();
                Assert.IsFalse(matrix.IsReadOnly);
            }
        }

        [TestFixture]
        public class IsSquare:ObjectMatrixTest
        {
            [Test]
			public void Simple()
            {
                var matrix = new ObjectMatrix<int>(10, 15);
                Assert.IsFalse(matrix.IsSquare);

                matrix = new ObjectMatrix<int>(3, 3);
                Assert.IsTrue(matrix.IsSquare);

                matrix = new ObjectMatrix<int>(9, 9);
                Assert.IsTrue(matrix.IsSquare);

                matrix = new ObjectMatrix<int>(2, 3);
                Assert.IsFalse(matrix.IsSquare);
            }
        }

        [TestFixture]
        public class Remove:ObjectMatrixTest
        {
            [Test]
            [ExpectedException(typeof(NotSupportedException))]
            public void ExceptionInterfaceNotSupported()
            {
                var matrix = GetTestMatrix();
                ((ICollection<int>) matrix).Remove(5);
            }
        }

        [TestFixture]
        public class Resize:ObjectMatrixTest
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

                matrix.Resize(20, 20);

                Assert.AreEqual(matrix.Columns, 20);
                Assert.AreEqual(matrix.Rows, 20);

                for (var i = 0; i < rowCount; i++)
                {
                    for (var j = 0; j < columnCount; j++)
                    {
                        Assert.AreEqual(matrix[i, j], i + j);
                    }
                }

                for (var i = rowCount; i < 20; i++)
                {
                    for (var j = columnCount; j < 20; j++)
                    {
                        Assert.AreEqual(matrix[i, j], default(double));
                    }
                }
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void ExceptionNegativeNewNumberOfRows()
            {
                var matrix = GetTestMatrix();
                matrix.Resize(-1, 8);
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
			public void ExceptionNegativeNewNumberOfColumns()
            {
                var matrix = GetTestMatrix();
                matrix.Resize(8, -1);
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
			public void ExceptionZeroNewNumberOfRows()
            {
                var matrix = GetTestMatrix();
                matrix.Resize(8, 0);
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
			public void ExceptionZeroNewNumberOfColumns()
            {
                var matrix = GetTestMatrix();
                matrix.Resize(0, 8);
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void ExceptionNegativeNewNumberOfRowsAndNewNumberOfColumns()
            {
                var matrix = GetTestMatrix();
                matrix.Resize(-1, -1);
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
			public void ExceptionZeroNewNumberOfColumnsAndNewNumberOfRows()
            {
                var matrix = GetTestMatrix();
                matrix.Resize(0, 0);
            }
        }

        [TestFixture]
        public class Serializable:ObjectMatrixTest
        {
            [Test]
            public void Simple()
            {
                var matrix = GetTestMatrix();
                var newMatrix = SerializeUtil.BinarySerializeDeserialize(matrix);

                TestIfEqual(matrix, newMatrix);
            }
        }
        
        #endregion

      
}
