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

namespace NGenerics.Tests.DataStructures.Mathematical.MatrixTests
{
    [TestFixture]
    public class Accept
    {

        [Test]
        public void Simple()
        {
            var visitor = new TrackingVisitor<double>();
            var matrix = MatrixTest.GetTestMatrix();

            matrix.AcceptVisitor(visitor);

            Assert.AreEqual(visitor.TrackingList.Count, matrix.Rows * matrix.Columns);

            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    Assert.IsTrue(visitor.TrackingList.Contains(i + j));
                }
            }
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullVisitor()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.AcceptVisitor(null);
        }

    }
}