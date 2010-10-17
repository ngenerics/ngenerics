/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.MatrixTests
{
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
}