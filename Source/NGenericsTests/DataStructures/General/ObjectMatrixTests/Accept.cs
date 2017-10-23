/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ObjectMatrixTests
{
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
}