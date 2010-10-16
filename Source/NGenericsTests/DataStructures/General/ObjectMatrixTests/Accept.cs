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