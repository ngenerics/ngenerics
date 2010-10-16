/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ObjectMatrixTests
{
   
    public class ObjectMatrixTest
    {  

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

    }
}
