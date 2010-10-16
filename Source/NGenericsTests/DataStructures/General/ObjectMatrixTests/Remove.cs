using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ObjectMatrixTests
{
    [TestFixture]
    public class Remove:ObjectMatrixTest
    {
        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void ExceptionInterfaceNotSupported()
        {
            var matrix = GetTestMatrix();
            ((ICollection<int>) matrix).Remove(5);
        }
    }
}