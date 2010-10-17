using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.MatrixTests
{
    [TestFixture]
    public class Add
    {

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void ExceptionInterfaceAdd()
        {
            ICollection<double> matrix = MatrixTest.GetTestMatrix();
            matrix.Add(5);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullMatrix()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.Add(null);
        }

    }
}