using System;
using NUnit.Framework;

namespace NGenerics.Tests.Comparers.ComparisonComparerTests
{
    [TestFixture]
    public class Comparison : ComparisonComparerTest
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullComparer()
        {
            var comparer = GetTestComparer();
            comparer.Comparison = null;
        }
    }
}