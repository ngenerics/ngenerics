/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.MatrixTests
{
	public class MatrixTest
    {
	    public static void TestDiagonalValues(Matrix matrix, int rows, int columns, int value)
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

	    public static Matrix GetTestMatrix()
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

	    public static bool IsOriginalTestMatrix(IMathematicalMatrix matrix)
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


	}
}