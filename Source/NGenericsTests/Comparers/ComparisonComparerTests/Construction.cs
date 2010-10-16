using System;
using NGenerics.Comparers;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.Comparers.ComparisonComparerTests
{
    [TestFixture]
    public class Construction : ComparisonComparerTest
    {
        [Test]
        public void Simple()
        {
            var comparer = GetTestComparer();

            Assert.IsNotNull(comparer.Comparison);

            comparer.Comparison = ((x, y) => x.TestProperty.CompareTo(y.TestProperty));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullComparison()
        {
            new ComparisonComparer<SimpleClass>(null);
        }
    }
}