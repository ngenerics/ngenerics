using System;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SortedListTests
{
    [TestFixture]
    public class Accept
    {

        [Test]
        public void Simple()
        {
            var visitor = new TrackingVisitor<int>();
            var sortedList = SortedListTest.GetTestList();
            sortedList.AcceptVisitor(visitor);

            Assert.AreEqual(visitor.TrackingList.Count, sortedList.Count);

            for (var i = 0; i <= 50; i++)
            {
                Assert.IsTrue(visitor.TrackingList.Contains(i * 2));
            }
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVisitor()
        {
            var sortedList = SortedListTest.GetTestList();
            sortedList.AcceptVisitor(null);
        }

    }
}