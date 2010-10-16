using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ObjectMatrixTests
{
    [TestFixture]
    public class Add:ObjectMatrixTest
    {
        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void ExceptionInterface()
        {
            var matrix = GetTestMatrix();
            ((ICollection<int>) matrix).Add(5);
        }
    }
}