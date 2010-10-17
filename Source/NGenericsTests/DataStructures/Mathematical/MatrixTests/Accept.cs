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