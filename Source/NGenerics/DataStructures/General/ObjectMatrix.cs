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
using System.Text;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using NGenerics.Util;

namespace NGenerics.DataStructures.General
{
    /// <summary>
    /// A data structure representing a matrix of objects.
	/// </summary>
    /// <typeparam name="T">The type of elements in the object matrix.</typeparam>
#if (!SILVERLIGHT)
    [Serializable]
#endif
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
    public class ObjectMatrix<T> : IMatrix<T>, ICollection<T>
    {
        #region Globals

        const string rowsOrColumnsInvalid = "Rows and columns must be nonnegative values.";
        /// <summary>
        /// The number of columns in the matrix.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        protected int noOfColumns;

        /// <summary>
        /// The number of rows in the matrix.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        protected int noOfRows;

        /// <summary>
        /// The data matrix.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        protected T[] data;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectMatrix&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        /// <exception cref="ArgumentException"><paramref name="columns"/> is less than 0.</exception>
        /// <exception cref="ArgumentException"><paramref name="rows"/> is less than 0.</exception>
        /// <example>
        /// 	<code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\ObjectMatrixExamples.cs" region="Constructor" lang="cs" title="The following example shows how to use the default constructor."/>
        /// 	<code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\ObjectMatrixExamples.vb" region="Constructor" lang="vbnet" title="The following example shows how to use the default constructor."/>
        /// </example>
        public ObjectMatrix(int rows, int columns) 
        {
            #region Validation

            if (rows <= 0)
            {
                throw new ArgumentException(rowsOrColumnsInvalid, "rows");
            }

            if (columns <= 0)
            {
                throw new ArgumentException(rowsOrColumnsInvalid, "columns");
            }

            #endregion

            noOfColumns = columns;
            noOfRows = rows;

            data = new T[noOfRows * noOfColumns];
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectMatrix&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="pData">The data.</param>
        /// <exception cref="ArgumentException"><paramref name="columns"/> is less than 0.</exception>
        /// <exception cref="ArgumentException"><paramref name="rows"/> is less than 0.</exception>
        /// <example>
        /// </example>
        internal ObjectMatrix(int rows, int columns, T[] pData)
        {
            #region Validation

            Debug.Assert(rows > 0);
            Debug.Assert(columns > 0);

            #endregion

            noOfColumns = columns;
            noOfRows = rows;

            data = pData;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectMatrix&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="data">The data.</param>
        /// <exception cref="ArgumentException"><paramref name="columns"/> is less than 0.</exception>
        /// <exception cref="ArgumentException"><paramref name="rows"/> is less than 0.</exception>
        /// <example>
        /// </example>
        internal ObjectMatrix(int rows, int columns, T[,] data) : this(rows,columns)
        {
           for (var i = 0; i < rows; i++)
           {
              for (var j = 0; j < columns; j++)
              {
                 this.data[i*columns+j] = data[i,j];
              }  
           }
        }
        #endregion

        #region IMatrix<T> Members

		/// <inheritdoc />  
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\ObjectMatrixExamples.cs" region="IsSquare" lang="cs" title="The following example shows how to use the IsSquare property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\ObjectMatrixExamples.vb" region="IsSquare" lang="vbnet" title="The following example shows how to use the IsSquare property."/>
        /// </example>
        public bool IsSquare
        {
            get
            {
                return noOfRows == noOfColumns;
            }
        }

		/// <inheritdoc />  
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\ObjectMatrixExamples.cs" region="Index" lang="cs" title="The following example shows how to use the Index property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\ObjectMatrixExamples.vb" region="Index" lang="vbnet" title="The following example shows how to use the Index property."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1023:IndexersShouldNotBeMultidimensional")]
        public T this[int row, int column]
        {
            get
            {
                #region Validation

                CheckIndexValid(row, column);
                
                #endregion

                return data[GetOffset(row, column)];
            }
            set
            {
                #region Validation

                CheckIndexValid(row, column);
                
                #endregion

                data[GetOffset(row, column)] = value;
            }
        }


		/// <inheritdoc />  
        IMatrix<T> IMatrix<T>.GetSubMatrix(int rowStart, int noOfColumnStart, int rowCount, int columnCount)
        {
            return GetSubMatrix(rowStart, noOfColumnStart, rowCount, columnCount);
        }

        #endregion

        #region ICollection<T> Members

		/// <inheritdoc />  
        /// <exception cref="NotSupportedException">Always.</exception>
        [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void ICollection<T>.Add(T item)
        {
            throw new NotSupportedException();
        }

		/// <inheritdoc />  
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\ObjectMatrixExamples.cs" region="Clear" lang="cs" title="The following example shows how to use the Clear method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\ObjectMatrixExamples.vb" region="Clear" lang="vbnet" title="The following example shows how to use the Clear method."/>
        /// </example>
        public void Clear()
        {
            data = new T[data.Length];
        }

		/// <inheritdoc />  
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\ObjectMatrixExamples.cs" region="Contains" lang="cs" title="The following example shows how to use the Contains method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\ObjectMatrixExamples.vb" region="Contains" lang="vbnet" title="The following example shows how to use the Contains method."/>
        /// </example>
        public bool Contains(T item)
        {
            for (var i = 0; i < data.Length; i++)
            {
                if (data[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

		/// <inheritdoc />  
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\ObjectMatrixExamples.cs" region="CopyTo" lang="cs" title="The following example shows how to use the CopyTo method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\ObjectMatrixExamples.vb" region="CopyTo" lang="vbnet" title="The following example shows how to use the CopyTo method."/>
        /// </example>
        public void CopyTo(T[] array, int arrayIndex)
        {
            #region Validation

            Guard.ArgumentNotNull(array, "array");

            if ((array.Length - arrayIndex) < data.Length)
            {
                throw new ArgumentException(Constants.NotEnoughSpaceInTheTargetArray, "array");
            }
                        
            #endregion

            Array.Copy(data, 0, array, arrayIndex, data.Length);
        }

		/// <inheritdoc />  
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\ObjectMatrixExamples.cs" region="Count" lang="cs" title="The following example shows how to use the Count property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\ObjectMatrixExamples.vb" region="Count" lang="vbnet" title="The following example shows how to use the Count property."/>
        /// </example>
        int ICollection<T>.Count
        {
            get
            {
                return data.Length;
            }
        }

		/// <inheritdoc />  
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\ObjectMatrixExamples.cs" region="IsReadOnly" lang="cs" title="The following example shows how to use the IsReadOnly property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\ObjectMatrixExamples.vb" region="IsReadOnly" lang="vbnet" title="The following example shows how to use the IsReadOnly property."/>
        /// </example>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

		/// <inheritdoc />  
        /// <exception cref="NotSupportedException">Always.</exception>
        [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        bool ICollection<T>.Remove(T item)
        {
            throw new NotSupportedException();
        }

        #endregion

        #region IEnumerable<T> Members

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        /// <example>
        /// 	<code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\ObjectMatrixExamples.cs" region="GetEnumerator" lang="cs" title="The following example shows how to use the GetEnumerator method."/>
        /// 	<code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\ObjectMatrixExamples.vb" region="GetEnumerator" lang="vbnet" title="The following example shows how to use the GetEnumerator method."/>
        /// </example>
        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < data.Length; i++)
            {
                yield return data[i];
            }
        }

        #endregion

        #region IEnumerable Members

		/// <inheritdoc />  
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Public Members


        /// <summary>
        /// Validate that <see cref="ObjectMatrix{T}.IsSquare"/> is <c>true</c>.
        /// </summary>
        /// <exception cref="InvalidOperationException"><see cref="ObjectMatrix{T}.IsSquare"/> is <c>false</c>.</exception>
        public void ValidateIsSquare()
        {
            if (!IsSquare)
            {
                throw new InvalidOperationException("The operation is only valid on a square matrix.");
            }
        }

        /// <summary>
        /// Copies the elements of the Matrix to a new array
        /// </summary>
        /// <returns>An [n,m] array containing copies of the elements of the Matrix. </returns>
        [SuppressMessage("Microsoft.Performance", "CA1814:PreferJaggedArraysOverMultidimensional", MessageId = "Body")]
        [SuppressMessage("Microsoft.Performance", "CA1814:PreferJaggedArraysOverMultidimensional", MessageId = "Return")]
        public T[,] ToArray()
        {
           var res = new T[Rows, Columns];
           for (var i = 0; i < Rows; i++)
           {
              for (var j = 0; j < Columns; j++)
              {
                 res[i, j] = GetValue(i, j);
              }
           }
           return res;
        }

		/// <inheritdoc />  
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\ObjectMatrixExamples.cs" region="Columns" lang="cs" title="The following example shows how to use the Columns property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\ObjectMatrixExamples.vb" region="Columns" lang="vbnet" title="The following example shows how to use the Columns property."/>
        /// </example>
        public int Columns
        {
            get
            {
                return noOfColumns;
            }
        }

		/// <inheritdoc />  
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\ObjectMatrixExamples.cs" region="Rows" lang="cs" title="The following example shows how to use the Rows property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\ObjectMatrixExamples.vb" region="Rows" lang="vbnet" title="The following example shows how to use the Rows property."/>
        /// </example>
        public int Rows
        {
            get
            {
                return noOfRows;
            }
        }


        /// <summary>
        /// Gets the sub matrix.
        /// </summary>
        /// <param name="rowStart">The row start.</param>
        /// <param name="columnStart">The column start.</param>
        /// <param name="rowCount">The row count.</param>
        /// <param name="columnCount">The column count.</param>
        /// <returns>The sub matrix of the current matrix.</returns>
        /// <exception cref="ArgumentException"><paramref name="rowCount"/> is less than or equal to 0.</exception>
        /// <exception cref="ArgumentException"><paramref name="columnCount"/> is less than or equal to 0.</exception>
        /// <exception cref="ArgumentException"><paramref name="rowStart"/> is less than 0.</exception>
        /// <exception cref="ArgumentException"><paramref name="columnStart"/> is less than 0.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="rowStart"/> plus <paramref name="rowCount"/> is greater that <see cref="Rows"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="columnStart"/> plus <paramref name="columnCount"/> is greater that <see cref="Columns"/>.</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\ObjectMatrixExamples.cs" region="GetSubMatrix" lang="cs" title="The following example shows how to use the GetSubMatrix method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\ObjectMatrixExamples.vb" region="GetSubMatrix" lang="vbnet" title="The following example shows how to use the GetSubMatrix method."/>
        /// </example>
        public ObjectMatrix<T> GetSubMatrix(int rowStart, int columnStart, int rowCount, int columnCount)
        {            
            #region Validation

            const string message = "Column and row count must be larger than 0.";
            if (rowCount <= 0)
            {
                throw new ArgumentOutOfRangeException("rowCount", message);
            }

            if (columnCount <= 0)
            {
                throw new ArgumentOutOfRangeException("columnCount", message);
            }

            if (rowStart < 0)
            {
                throw new ArgumentOutOfRangeException("rowStart", "The row index to start from can not be smaller than 0.");
            }
            
            if (columnStart < 0)
            {
                throw new ArgumentOutOfRangeException("columnCount", "The column index to start from can not be smaller than 0.");
            }

            if (((rowStart + rowCount) > Rows) || ((columnStart + columnCount) > Columns))
            {
                throw new ArgumentOutOfRangeException("rowStart", "More rows or columns have been specified than is present in the matrix.");
            }
                     
            #endregion

            var ret = new ObjectMatrix<T>(rowCount, columnCount);

            for (var i = rowStart; i < rowStart + rowCount; i++)
            {
                for (var j = columnStart; j < columnStart + columnCount; j++)
                {
                    ret.SetValue(i - rowStart, j - columnStart, GetValue(i, j));
                }
            }

            return ret;
        }

		/// <inheritdoc />  
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\ObjectMatrixExamples.cs" region="InterchangeRows" lang="cs" title="The following example shows how to use the InterchangeRows method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\ObjectMatrixExamples.vb" region="InterchangeRows" lang="vbnet" title="The following example shows how to use the InterchangeRows method."/>
        /// </example>
        public void InterchangeRows(int firstRow, int secondRow)
        {
            #region Validation
                        
            if ((firstRow < 0) || (firstRow > noOfRows - 1))
            {
                throw new ArgumentOutOfRangeException("firstRow");
            }

            if ((secondRow < 0) || (secondRow > noOfRows - 1))
            {
                throw new ArgumentOutOfRangeException("secondRow");
            }
                        
            #endregion

            // Nothing to do
            if (firstRow == secondRow)
            {
                return;
            }

            for (var i = 0; i < noOfColumns; i++)
            {
                var temp = GetValue(firstRow, i);
                SetValue(firstRow, i, GetValue(secondRow, i));
                SetValue(secondRow, i, temp);
            }
        }

		/// <inheritdoc />  
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\ObjectMatrixExamples.cs" region="InterchangeColumns" lang="cs" title="The following example shows how to use the InterchangeColumns method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\ObjectMatrixExamples.vb" region="InterchangeColumns" lang="vbnet" title="The following example shows how to use the InterchangeColumns method."/>
        /// </example>
        public void InterchangeColumns(int firstColumn, int secondColumn)
        {            
            #region Validation

            if ((firstColumn < 0) || (firstColumn > noOfColumns - 1))
            {
                throw new ArgumentOutOfRangeException("firstColumn");
            }

            if ((secondColumn < 0) || (secondColumn > noOfColumns - 1))
            {
                throw new ArgumentOutOfRangeException("secondColumn");
            }
                     
            #endregion


            // Nothing to do
            if (firstColumn == secondColumn)
            {
                return;
            }

            for (var i = 0; i < noOfRows; i++)
            {
                var temp = GetValue(i, firstColumn);
                SetValue(i, firstColumn, GetValue(i, secondColumn));
                SetValue(i, secondColumn, temp);
            }
        }

		/// <inheritdoc />   
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\ObjectMatrixExamples.cs" region="GetRow" lang="cs" title="The following example shows how to use the GetRow method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\ObjectMatrixExamples.vb" region="GetRow" lang="vbnet" title="The following example shows how to use the GetRow method."/>
        /// </example>
        public T[] GetRow(int rowIndex)
        {
            #region Validation

            if ((rowIndex < 0) || (rowIndex > noOfRows - 1))
            {
                throw new ArgumentOutOfRangeException("rowIndex");
            }
            
            #endregion

            var ret = new T[noOfColumns];

            for (var i = 0; i < noOfColumns; i++)
            {
                ret[i] = GetValue(rowIndex, i);
            }

            return ret;
        }

		/// <inheritdoc />   
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\ObjectMatrixExamples.cs" region="GetColumn" lang="cs" title="The following example shows how to use the GetColumn method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\ObjectMatrixExamples.vb" region="GetColumn" lang="vbnet" title="The following example shows how to use the GetColumn method."/>
        /// </example>
        public T[] GetColumn(int columnIndex)
        {
            #region Validation

            if ((columnIndex < 0) || (columnIndex > noOfColumns - 1))
            {
                throw new ArgumentOutOfRangeException("columnIndex");
            }
                        
            #endregion

            var ret = new T[noOfRows];

            for (var i = 0; i < noOfRows; i++)
            {
                ret[i] = GetValue(i, columnIndex);
            }

            return ret;
        }

		/// <inheritdoc />    
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\ObjectMatrixExamples.cs" region="AddRows" lang="cs" title="The following example shows how to use the AddRows method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\ObjectMatrixExamples.vb" region="AddRows" lang="vbnet" title="The following example shows how to use the AddRows method."/>
        /// </example>  
        public void AddRows(int rowCount)
        {
            #region Validation
                        
            if (rowCount <= 0)
            {
                throw new ArgumentOutOfRangeException("rowCount");
            }
                        
            #endregion

            var newRowCount = noOfRows + rowCount;

            // Create a new matrix of the specified size
            var newData = new T[newRowCount * noOfColumns];

            CopyData(newData, noOfColumns);

            noOfRows = newRowCount;
            data = newData;
        }

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\ObjectMatrixExamples.cs" region="AddRow" lang="cs" title="The following example shows how to use the AddRow method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\ObjectMatrixExamples.vb" region="AddRow" lang="vbnet" title="The following example shows how to use the AddRow method."/>
        /// </example>  
        public void AddRow()
        {
            AddRows(1);
        }

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\ObjectMatrixExamples.cs" region="AddColumnValues" lang="cs" title="The following example shows how to use the AddColumn method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\ObjectMatrixExamples.vb" region="AddColumnValues" lang="vbnet" title="The following example shows how to use the AddColumn method."/>
        /// </example>  
        public void AddColumn(params T[] values)
        {
            #region Validation

            Guard.ArgumentNotNull(values, "values");

            if (values.Length > noOfRows)
            {
                throw new ArgumentException("The number of values can not be greater than the number of rows.", "values");
            }
                        
            #endregion

            AddColumn();

            for (var i = 0; i < values.Length; i++)
            {
                SetValue(i, noOfColumns - 1, values[i]);
            }
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\ObjectMatrixExamples.cs" region="AddColumns" lang="cs" title="The following example shows how to use the AddColumns method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\ObjectMatrixExamples.vb" region="AddColumns" lang="vbnet" title="The following example shows how to use the AddColumns method."/>
        /// </example>      
        public void AddColumns(int columnCount)
        {
            #region Validation

            if (columnCount <= 0)
            {
                throw new ArgumentOutOfRangeException("columnCount");
            }

            #endregion

            var newColumnCount = noOfColumns + columnCount;

            // Create a new matrix of the specified size
            var newData = new T[noOfRows * newColumnCount];

            CopyData(newData, newColumnCount);

            noOfColumns = newColumnCount;
            data = newData;
        }

		/// <inheritdoc /> 
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\ObjectMatrixExamples.cs" region="AddColumn" lang="cs" title="The following example shows how to use the AddColumn method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\ObjectMatrixExamples.vb" region="AddColumn" lang="vbnet" title="The following example shows how to use the AddColumn method."/>
        /// </example>      
        public void AddColumn()
        {
            AddColumns(1);
        }

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\ObjectMatrixExamples.cs" region="AddRowValues" lang="cs" title="The following example shows how to use the AddRow method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\ObjectMatrixExamples.vb" region="AddRowValues" lang="vbnet" title="The following example shows how to use the AddRow method."/>
        /// </example> 
        public void AddRow(params T[] values)
        {            
            #region Validation

            Guard.ArgumentNotNull(values, "values");

            if (values.Length > noOfColumns)
            {
                throw new ArgumentException("The number of values can not be greater than the number of columns.", "values");
            }
                        
            #endregion

            AddRow();

            for (var i = 0; i < values.Length; i++)
            {
                SetValue(noOfRows - 1, i, values[i]);
            }
        }

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\ObjectMatrixExamples.cs" region="Resize" lang="cs" title="The following example shows how to use the Resize method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\ObjectMatrixExamples.vb" region="Resize" lang="vbnet" title="The following example shows how to use the Resize method."/>
        /// </example> 
        public void Resize(int newNumberOfRows, int newNumberOfColumns)
        {
            #region Validation

            if (newNumberOfRows <= 0) 
            {
                throw new ArgumentException(rowsOrColumnsInvalid, "newNumberOfRows");
            }
		    
            if (newNumberOfColumns <= 0)
		    {
                throw new ArgumentException(rowsOrColumnsInvalid, "newNumberOfColumns");
		    }

		    #endregion

            var newData = new T[newNumberOfRows * newNumberOfColumns];

            // Find the minimum of the rows and the columns.
            // Case 1 : Target array is smaller than original - don't cross boundaries of target.
            // Case 2 : Original is smaller than target - don't cross boundaries of original.
            var minRows = Math.Min(noOfRows, newNumberOfRows);
            var minColumns = Math.Min(noOfColumns, newNumberOfColumns);

            for (var i = 0; i < minRows; i++)
            {
                for (var j = 0; j < minColumns; j++)
                {
                    newData[newNumberOfRows * i + j] = GetValue(i, j);
                }
            }

            data = newData;

            noOfRows = newNumberOfRows;
            noOfColumns = newNumberOfColumns;
        }

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\ObjectMatrixExamples.cs" region="DeleteRow" lang="cs" title="The following example shows how to use the DeleteRow method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\ObjectMatrixExamples.vb" region="DeleteRow" lang="vbnet" title="The following example shows how to use the DeleteRow method."/>
        /// </example>
        public void DeleteRow(int row)
        {
            #region Validation

            if (noOfRows == 1)
            {
                throw new InvalidOperationException("The matrix has only one row left, which can not be deleted.");
            }

            var newRows = noOfRows - 1;

            if ((row > newRows) || (row < 0))
            {
                throw new ArgumentOutOfRangeException("row");
            }

            #endregion

            var newData = new T[newRows * Columns];

            // Copy the data before the row
            Array.Copy(data, 0, newData, 0, row * Columns);

            // Copy the data after the row
            Array.Copy(data, ((row + 1) * Columns), newData, row * Columns, Columns * (newRows - row));

            data = newData;

            noOfRows--;
        }

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\ObjectMatrixExamples.cs" region="DeleteColumn" lang="cs" title="The following example shows how to use the DeleteColumn method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\ObjectMatrixExamples.vb" region="DeleteColumn" lang="vbnet" title="The following example shows how to use the DeleteColumn method."/>
        /// </example>
        public void DeleteColumn(int column)
        {
            #region Validation

            if (noOfColumns == 1)
            {
                throw new InvalidOperationException("The matrix has only one column left, which can not be deleted.");
            }

            if ((column > noOfColumns - 1) || (column < 0))
            {
                throw new ArgumentOutOfRangeException("column");
            }

            #endregion

            var newData = new T[noOfRows * (noOfColumns - 1)];

            // We use an exclusion strategy here
            for (var i = 0; i < noOfRows; i++)
            {
                var columnIndex = 0;

                for (var j = 0; j < noOfColumns; j++)
                {
                    if (j != column)
                    {
                        newData[i * (noOfColumns - 1) + columnIndex] = GetValue(i, j);
                        columnIndex++;
                    }
                }
            }

            data = newData;

            noOfColumns--;
        }
		/// <inheritdoc />
       public override string ToString()
       {
          var sb = new StringBuilder(noOfRows*noOfColumns*2);

          for (var i = 0; i < noOfRows; i++)
          {
             for (var j = 0; j < noOfColumns; j++)
             {
                sb.Append(GetValue(i, j)).Append("\t");
             }

             sb.AppendLine();
          }

          return sb.ToString();
       } 


        #endregion

        #region Internal Members

        /// <summary>
        /// Gets the value at the specified indexes.
        /// </summary>
        /// <param name="row">The row index.</param>
        /// <param name="column">The column index.</param>
        internal T GetValue(int row, int column)
        {
            return data[GetOffset(row, column)];
        }

        /// <summary>
        /// Gets the value at the specified indexes.
        /// </summary>
        /// <param name="row">The row index.</param>
        /// <param name="column">The column index.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        internal void SetValue(int row, int column, T value)
        {
            data[GetOffset(row, column)] = value;
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>The data.</value>
        internal T[] Data
        {
            get
            {
                return data;
            }
        }

        #endregion

        #region Protected Members
               
        /// <summary>
        /// Gets the offset.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        /// <returns>The offset of <paramref name="row"/> and <paramref name="row"/>.</returns>
        protected int GetOffset(int row, int column)
        {
            #region Asserts

            Debug.Assert(row >= 0);
            Debug.Assert(row <= noOfRows - 1);

            Debug.Assert(column >= 0);
            Debug.Assert(column <= noOfColumns - 1);

            #endregion

            return row * noOfColumns + column;
        } 

        #endregion

        #region Private Members

        /// <summary>
        /// Checks whether the index supplied is valid.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="i"/> is less than 0.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="i"/> is greater than <see cref="Rows"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="j"/> is less than 0.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="j"/> is greater than <see cref="Columns"/>.</exception>
        private void CheckIndexValid(int i, int j)
        {
            if ((i < 0) || (i > noOfRows - 1))
            {
                throw new ArgumentOutOfRangeException("i");
            }

            if ((j < 0) || (j > noOfColumns - 1))
            {
                throw new ArgumentOutOfRangeException("j");
            }
        }        

        /// <summary>
        /// Copies the data.
        /// </summary>
        /// <param name="newData">The new data.</param>
        /// <param name="newColumnCount">The new column count.</param>
        private void CopyData(T[] newData, int newColumnCount)
        {
            #region Asserts

            Debug.Assert(newColumnCount > 0);

            #endregion

            // Copy the smaller of the sizes
            int copyBlockSize;
            if (noOfColumns < newColumnCount)
            {
                copyBlockSize = noOfColumns;
            }
            else
            {
                copyBlockSize = newColumnCount;
            }

            // Copy in blocks row by row
            for (var row = 0; row < noOfRows; row++)
            {
                Array.Copy(
                    data, 
                    row * noOfColumns, 
                    newData, 
                    row * newColumnCount,
                    copyBlockSize
                 );
            }            
        }

        #endregion
    }
}
