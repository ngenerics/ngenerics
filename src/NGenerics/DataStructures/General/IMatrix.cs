/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/


using System;
using System.Diagnostics.CodeAnalysis;

namespace NGenerics.DataStructures.General
{
    /// <summary>
    /// An interface for a general matrix-type data structure.
	/// </summary>
	/// <typeparam name="T">The type of elements in the matrix.</typeparam>
	public interface IMatrix<T>
	{
		/// <summary>
		/// Gets the number of columns in this <see cref="IMatrix{T}"/>.
		/// </summary>
		/// <value>The columns.</value>
		int Columns { get; }

		/// <summary>
        /// Gets the number of rows in this <see cref="IMatrix{T}"/>.
		/// </summary>
		int Rows { get; }

		/// <summary>
        /// Gets a value indicating whether this <see cref="IMatrix{T}"/> is square.
		/// </summary>
        /// <value><c>true</c> if this <see cref="IMatrix{T}"/> is square; otherwise, <c>false</c>.</value>
		bool IsSquare { get; }
		
		/// <summary>
		/// Gets or sets the value at the specified index.
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="row"/> is less than 0.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="row"/> is greater than <see cref="Rows"/>.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="column"/> is less than 0.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="column"/> is greater than <see cref="Columns"/>.</exception>
        [SuppressMessage("Microsoft.Design", "CA1023:IndexersShouldNotBeMultidimensional")]
		T this[int row, int column] { get; set; }

		/// <summary>
        /// Gets the specified sub matrix of the current <see cref="IMatrix{T}"/>
		/// </summary>
		/// <param name="rowStart">The start row.</param>
		/// <param name="columnStart">The start column.</param>
		/// <param name="rowCount">The number of rows.</param>
		/// <param name="columnCount">The number of columns.</param>
        /// <returns>A sub-<see cref="IMatrix{T}"/> of the current <see cref="IMatrix{T}"/>.</returns>
		IMatrix<T> GetSubMatrix(int rowStart, int columnStart, int rowCount, int columnCount);

        /// <summary>
        /// Interchanges (swap) one row with another.
        /// </summary>
        /// <param name="firstRow">The index of the first row.</param>
		/// <param name="secondRow">The index of the second row.</param>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="firstRow"/> is less than 0.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="firstRow"/> is greater than <see cref="Rows"/>.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="secondRow"/> is less than 0.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="secondRow"/> is greater than <see cref="Rows"/>.</exception>
        void InterchangeRows(int firstRow, int secondRow);

        /// <summary>
        /// Interchanges (swap) one column with another.
        /// </summary>
        /// <param name="firstColumn">The index of the first column.</param>
		/// <param name="secondColumn">The index of the second column.</param>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="firstColumn"/> is less than 0.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="secondColumn"/> is less than 0.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="firstColumn"/> is greater than <see cref="Columns"/>.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="secondColumn"/> is greater than <see cref="Columns"/>.</exception>
        void InterchangeColumns(int firstColumn, int secondColumn);

        /// <summary>
        /// Gets the row at the specified index.
        /// </summary>
        /// <param name="rowIndex">Index of the row.</param>
		/// <returns>An array containing the values of the requested row.</returns>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="rowIndex"/> is less than 0.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="rowIndex"/> is greater than <see cref="Rows"/>.</exception>
        T[] GetRow(int rowIndex);

        /// <summary>
        /// Gets the column at the specified index.
        /// </summary>
        /// <param name="columnIndex">Index of the column.</param>
		/// <returns>An array containing the values of the requested column.</returns>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="columnIndex"/> is less than 0.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="columnIndex"/> is greater than <see cref="Columns"/>.</exception>
        T[] GetColumn(int columnIndex);


        /// <summary>
        /// Adds the specified number of rows to the matrix.
        /// </summary>
		/// <param name="rowCount">The number of rows to add.</param>     
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="rowCount"/> is less than or equal to 0.</exception>   
        void AddRows(int rowCount);
        
        /// <summary>
        /// Adds a single row to the <see cref="IMatrix{T}"/>.
        /// </summary>
        void AddRow();
        
        /// <summary>
        /// Adds a single row to the <see cref="IMatrix{T}"/>, and populates the values
        /// accordingly.
        /// </summary>
		/// <param name="values">The values to populate the row with.</param>
		/// <exception cref="ArgumentNullException"><paramref name="values"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
		/// <exception cref="ArgumentException">The length of <paramref name="values"/> is greater than <see cref="Columns"/>.</exception>
        void AddRow(params T[] values);


        /// <summary>
        /// Adds the specified number of columns to the <see cref="IMatrix{T}"/>.
        /// </summary>
		/// <param name="columnCount">The number of columns to add.</param>       
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="columnCount"/> is less than or equal to 0.</exception> 
        void AddColumns(int columnCount);

        /// <summary>
        /// Adds a single column to the <see cref="IMatrix{T}"/>.
        /// </summary>
        void AddColumn();

        /// <summary>
        /// Adds a single column to the <see cref="IMatrix{T}"/>, and populates the values
        /// accordingly.
        /// </summary>
		/// <param name="values">The values to populate the column with.</param>
		/// <exception cref="ArgumentNullException"><paramref name="values"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
		/// <exception cref="ArgumentException">The length of <paramref name="values"/> is greater than <see cref="Rows"/>.</exception>
        void AddColumn(params T[] values);

        /// <summary>
        /// Deletes the row from the Matrix.
        /// </summary>
        /// <param name="row">The index of the row to delete.</param>
        void DeleteRow(int row);    

        /// <summary>
        /// Deletes the column from the Matrix.
        /// </summary>
        /// <param name="column">The index of the column to delete.</param>
        void DeleteColumn(int column);

        /// <summary>
        /// Resizes the <see cref="IMatrix{T}"/> to the specified size.
        /// </summary>
        /// <param name="newNumberOfRows">The new number of rows.</param>
		/// <param name="newNumberOfColumns">The new number of columns.</param>
		/// <exception cref="ArgumentException"><paramref name="newNumberOfColumns"/> is less than or equal to 0.</exception>
		/// <exception cref="ArgumentException"><paramref name="newNumberOfRows"/> is less than or equal to 0.</exception>
        void Resize(int newNumberOfRows, int newNumberOfColumns);
	}
}
