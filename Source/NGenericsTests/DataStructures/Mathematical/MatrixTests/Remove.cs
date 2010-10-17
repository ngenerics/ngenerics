using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.MatrixTests
{
    [TestFixture]
    public class Remove
    {

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void InterfaceRemove()
        {
            ICollection<double> matrix = MatrixTest.GetTestMatrix();
            matrix.Remove(5);
        }

    }
}