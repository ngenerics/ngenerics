using System;
using System.Collections.Generic;
using NGenerics.Comparers;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.Comparers.ReverseComparerTests
{
    [TestFixture]
    public class Construction
    {
        [Test]
        public void Simple()
        {
            var comparer = new ReverseComparer<int>();

            Assert.AreEqual(comparer.Comparer, Comparer<int>.Default);

            IComparer<int> newComparer = new IntComparer();

            comparer = new ReverseComparer<int>(newComparer);

            Assert.AreEqual(comparer.Comparer, newComparer);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullComparer()
        {
            new ReverseComparer<int>(null);
        }
    }
}