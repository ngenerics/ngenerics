using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.MatrixTests
{
    [TestFixture]
    public class LinearSolve
    {
		
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullLeft()
        {
            Matrix.LinearSolve(null, new Matrix(3, 3));
        }

    }
}