/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace ExampleLibraryCSharp.DataStructures.General
{
    [TestFixture]
    public class ObjectMatrixExamples
    {

        #region Constructor
        [Test]
        public void ConstructorExample()
        {
            var matrix = new ObjectMatrix<double>(2, 3);
            Assert.AreEqual(2, matrix.Rows);
            Assert.AreEqual(3, matrix.Columns);
        }
        #endregion

        #region Rows
        [Test]
        public void RowsExample()
        {
            var matrix = new ObjectMatrix<double>(2, 3);
            Assert.AreEqual(2, matrix.Rows);
        }
        #endregion

        #region Columns
        [Test]
        public void ColumnsExample()
        {
            var matrix = new ObjectMatrix<double>(2, 3);
            Assert.AreEqual(3, matrix.Columns);
        }
        #endregion

        #region IsSquare
        [Test]
        public void IsSquareExample()
        {
            var matrix = new ObjectMatrix<double>(10, 10);

            Assert.IsTrue(matrix.IsSquare);

            matrix = new ObjectMatrix<double>(3, 4);
            Assert.IsFalse(matrix.IsSquare);

            matrix = new ObjectMatrix<double>(35, 35);
            Assert.IsTrue(matrix.IsSquare);

            matrix = new ObjectMatrix<double>(45, 44);
            Assert.IsFalse(matrix.IsSquare);
        }
        #endregion

        #region Index
        [Test]
        public void IndexExample()
        {
            var matrix = new ObjectMatrix<double>(4, 5);

            // Set the item
            matrix[2, 3] = 5;

            // Item is 5
            Assert.AreEqual(5, matrix[2, 3]);
        }
        #endregion

        #region Clear
        [Test]
        public void ClearExample()
        {
            var matrix = new ObjectMatrix<double>(4, 5);

            // Set the item
            matrix[2, 3] = 5;

            // Item is 5
            Assert.AreEqual(5, matrix[2, 3]);

            // Clear the matrix
            matrix.Clear();

            // Item is now 0
            Assert.AreEqual(0, matrix[2, 3]);

        }
        #endregion

       
        #region IsReadOnly
        [Test]
        public void IsReadOnlyExample()
        {
            var matrix = new ObjectMatrix<double>(4, 5);

            //IsReadOnly is always false for ObjectMatrix<double> 
            Assert.IsFalse(matrix.IsReadOnly);
            matrix[2, 3] = 5;
            Assert.IsFalse(matrix.IsReadOnly);
        }
        #endregion

        #region GetEnumerator
        [Test]
        public void GetEnumeratorExample()
        {
            var matrix = new ObjectMatrix<double>(2, 2);
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[1, 1] = 3;
            matrix[1, 0] = 4;

            var enumerator = matrix.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }
        #endregion

        #region Count
        [Test]
        public void CountExample()
        {
            var matrix = new ObjectMatrix<double>(2, 2);
            ICollection<double> collection = matrix;
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[1, 1] = 3;
            matrix[1, 0] = 4;
            Assert.AreEqual(4, ((ICollection<double>)matrix).Count);
        }
        #endregion

//#region Equals
//        [Test]
//        public void EqualsExample()
//        {

//            ObjectMatrix<double> matrix1 = new ObjectMatrix<double>(2, 2);
//            matrix1[0, 0] = 1;
//            matrix1[0, 1] = 2;
//            matrix1[1, 1] = 3;
//            matrix1[1, 0] = 4;


//            ObjectMatrix<double> matrix2 = new ObjectMatrix<double>(2, 2);
//            matrix2[0, 0] = 1;
//            matrix2[0, 1] = 2;
//            matrix2[1, 1] = 3;
//            matrix2[1, 0] = 4;

//            Assert.IsTrue(matrix1.Equals(matrix2));

//            ObjectMatrix<double> matrix3 = new ObjectMatrix<double>(2, 2);
//            matrix3[0, 0] = 1;
//            matrix3[0, 1] = 2;
//            matrix3[1, 1] = 3;
//            matrix3[1, 0] = 5;

//            Assert.IsFalse(matrix1.Equals(matrix3));
//        }
//        #endregion


        #region Accept
        [Test]
        public void AcceptExample()
        {

            var matrix = new ObjectMatrix<double>(2, 2);
            matrix[0, 0] = -2;
            matrix[0, 1] = 3;
            matrix[1, 0] = 4;
            matrix[1, 1] = 6;
            var visitor = new CountingVisitor<double>();

            matrix.AcceptVisitor(visitor);

            Assert.AreEqual(4, visitor.Count);
        }
        #endregion

        #region Contains
        [Test]
        public void ContainsExample()
        {

            var matrix = new ObjectMatrix<double>(2, 2);
            matrix[0, 0] = -2;
            matrix[0, 1] = 3;
            matrix[1, 0] = 4;
            matrix[1, 1] = 6;

            Assert.IsTrue(matrix.Contains(-2));
            Assert.IsTrue(matrix.Contains(3));
            Assert.IsFalse(matrix.Contains(-5));
        }
        #endregion

        #region CopyTo
        [Test]
        public void CopyToExample()
        {
            var matrix = new ObjectMatrix<double>(2, 2);
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[1, 0] = 3;
            matrix[1, 1] = 4;

            var array = new double[matrix.Rows * matrix.Columns];

            matrix.CopyTo(array, 0);

            Assert.AreEqual(1, array[0]);
            Assert.AreEqual(4, array[3]);
        }
        #endregion

        #region GetSubMatrix
        [Test]
        public void GetSubMatrixExample()
        {

            var matrix = new ObjectMatrix<double>(3, 3);
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[0, 2] = 3;
            matrix[1, 0] = 4;
            matrix[1, 1] = 5;
            matrix[1, 2] = 6;
            matrix[2, 0] = 7;
            matrix[2, 1] = 8;
            matrix[2, 2] = 9;


            var result1 = matrix.GetSubMatrix(0, 0, 1, 1);

            Assert.AreEqual(1, result1.Rows);
            Assert.AreEqual(1, result1.Columns);

            var result2 = matrix.GetSubMatrix(1, 2, 2, 1);

            Assert.AreEqual(2, result2.Rows);
            Assert.AreEqual(1, result2.Columns);

        }

        #endregion
      
        #region InterchangeRows
        [Test]
        public void InterchangeRowsExample()
        {
            var matrix = new ObjectMatrix<double>(2, 2);
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[1, 0] = 3;
            matrix[1, 1] = 4;

            matrix.InterchangeRows(0, 1);

            Assert.AreEqual(3, matrix[0, 0]);
            Assert.AreEqual(4, matrix[0, 1]);
            Assert.AreEqual(1, matrix[1, 0]);
            Assert.AreEqual(2, matrix[1, 1]);
        }
        #endregion

        #region InterchangeColumns
        [Test]
        public void InterchangeColumnsExample()
        {
            var matrix = new ObjectMatrix<double>(2, 2);
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[1, 0] = 3;
            matrix[1, 1] = 4;


            matrix.InterchangeColumns(0, 1);


            Assert.AreEqual(2, matrix[0, 0]);
            Assert.AreEqual(1, matrix[0, 1]);
            Assert.AreEqual(4, matrix[1, 0]);
            Assert.AreEqual(3, matrix[1, 1]);
        }
        #endregion

        #region GetRow
        [Test]
        public void GetRowExample()
        {
            var matrix = new ObjectMatrix<double>(2, 2);
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[1, 0] = 3;
            matrix[1, 1] = 4;

            var row1 = matrix.GetRow(0);

            Assert.AreEqual(1, row1[0]);
            Assert.AreEqual(2, row1[1]);

            var row2 = matrix.GetRow(1);

            Assert.AreEqual(3, row2[0]);
            Assert.AreEqual(4, row2[1]);
        }
        #endregion

        #region GetColumn
        [Test]
        public void GetColumnExample()
        {
            var matrix = new ObjectMatrix<double>(2, 2);
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[1, 0] = 3;
            matrix[1, 1] = 4;

            var column1 = matrix.GetColumn(0);

            Assert.AreEqual(1, column1[0]);
            Assert.AreEqual(3, column1[1]);

            var column2 = matrix.GetColumn(1);

            Assert.AreEqual(2, column2[0]);
            Assert.AreEqual(4, column2[1]);
        }
        #endregion

        #region AddRow
        [Test]
        public void AddRowExample()
        {
            var matrix = new ObjectMatrix<double>(2, 2);
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[1, 0] = 3;
            matrix[1, 1] = 4;


            Assert.AreEqual(2, matrix.Columns);
            Assert.AreEqual(2, matrix.Rows);

            matrix.AddRow();

            Assert.AreEqual(2, matrix.Columns);
            Assert.AreEqual(3, matrix.Rows);
        }
        #endregion

        #region AddRows
        [Test]
        public void AddRowsExample()
        {
            var matrix = new ObjectMatrix<double>(2, 2);
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[1, 0] = 3;
            matrix[1, 1] = 4;


            Assert.AreEqual(2, matrix.Columns);
            Assert.AreEqual(2, matrix.Rows);

            matrix.AddRows(2);

            Assert.AreEqual(2, matrix.Columns);
            Assert.AreEqual(4, matrix.Rows);
        }
        #endregion

        #region AddRowValues
        [Test]
        public void AddRowValuesExample()
        {
            var matrix = new ObjectMatrix<double>(2, 2);
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[1, 0] = 3;
            matrix[1, 1] = 4;

            Assert.AreEqual(2, matrix.Columns);
            Assert.AreEqual(2, matrix.Rows);

            matrix.AddRow(5, 6);

            Assert.AreEqual(2, matrix.Columns);
            Assert.AreEqual(3, matrix.Rows);
            Assert.AreEqual(5, matrix[2, 0]);
            Assert.AreEqual(6, matrix[2, 1]);
        }
        #endregion

        #region AddColumn
        [Test]
        public void AddColumnExample()
        {
            var matrix = new ObjectMatrix<double>(2, 2);
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[1, 0] = 3;
            matrix[1, 1] = 4;

            Assert.AreEqual(2, matrix.Columns);
            Assert.AreEqual(2, matrix.Rows);

            matrix.AddColumn();

            Assert.AreEqual(3, matrix.Columns);
            Assert.AreEqual(2, matrix.Rows);

        }
        #endregion

        #region AddColumns
        [Test]
        public void AddColumnsExample()
        {
            var matrix = new ObjectMatrix<double>(2, 2);
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[1, 0] = 3;
            matrix[1, 1] = 4;

            Assert.AreEqual(2, matrix.Columns);
            Assert.AreEqual(2, matrix.Rows);

            matrix.AddColumns(2);

            Assert.AreEqual(4, matrix.Columns);
            Assert.AreEqual(2, matrix.Rows);

        }
        #endregion

        #region AddColumnValues
        [Test]
        public void AddColumnValuesExample()
        {
            var matrix = new ObjectMatrix<double>(2, 2);
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[1, 0] = 3;
            matrix[1, 1] = 4;

            Assert.AreEqual(2, matrix.Columns);
            Assert.AreEqual(2, matrix.Rows);

            matrix.AddColumn(5, 6);

            Assert.AreEqual(3, matrix.Columns);
            Assert.AreEqual(2, matrix.Rows);

            Assert.AreEqual(5, matrix[0, 2]);
            Assert.AreEqual(6, matrix[1, 2]);
        }
        #endregion

        #region Resize

        [Test]
        public void ResizeExample()
        {
            var matrix = new ObjectMatrix<double>(3, 3);
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[0, 2] = 3;
            matrix[1, 0] = 4;
            matrix[1, 1] = 5;
            matrix[1, 2] = 6;
            matrix[2, 0] = 7;
            matrix[2, 1] = 8;
            matrix[2, 2] = 9;

            matrix.Resize(2, 2);

            Assert.AreEqual(matrix.Columns, 2);
            Assert.AreEqual(matrix.Rows, 2);

            Assert.AreEqual(1, matrix[0, 0]);
            Assert.AreEqual(2, matrix[0, 1]);
            Assert.AreEqual(4, matrix[1, 0]);
            Assert.AreEqual(5, matrix[1, 1]);
        }

        #endregion

        #region DeleteColumn
                
        public void DeleteColumnExample()
        {
            var matrix = new ObjectMatrix<int>(4, 5);
            
            // Delete the second row from the matrix
            matrix.DeleteRow(2);

            // Only 3 rows left...
            Assert.AreEqual(matrix.Rows, 3);
        }

        #endregion

        #region DeleteRow
                
        [Test]
        public void DeleteRowExample()
        {
            var matrix = new ObjectMatrix<int>(4, 5);

            // Delete the second column from the matrix
            matrix.DeleteColumn(2);

            // Only 4 columns left...
            Assert.AreEqual(matrix.Columns, 4);
        }

        #endregion
    }
}