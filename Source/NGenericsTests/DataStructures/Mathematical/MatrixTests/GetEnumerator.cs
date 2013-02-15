/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System.Collections;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.MatrixTests
{
    [TestFixture]
    public class GetEnumerator
    {

        [Test]
        public void InterfaceEnumerator()
        {
            var matrix = MatrixTest.GetTestMatrix();

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
            var matrix = MatrixTest.GetTestMatrix();

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
}