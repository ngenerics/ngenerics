/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ObjectMatrixTests
{
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
}