using System;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ObjectMatrixTests
{
    [TestFixture]
    public class Indexer:ObjectMatrixTest
    {
        [Test]
        public void ExcetionInvalid()
        {
            var matrix = new ObjectMatrix<int>(10, 15);

            matrix[0, 0] = 5;
            Assert.AreEqual(matrix[0, 0], 5);

            matrix[3, 2] = 99;
            Assert.AreEqual(matrix[3, 2], 99);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Exception1()
        {
            var matrix = new ObjectMatrix<int>(10, 15);
            matrix[10, 0] = 5;
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Exception2()
        {
            var matrix = new ObjectMatrix<int>(10, 15);
            matrix[9, 15] = 5;
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Exception3()
        {
            var matrix = new ObjectMatrix<int>(10, 15);
            var i = matrix[10, 0];
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Exception4()
        {
            var matrix = new ObjectMatrix<int>(10, 15);
            var i = matrix[9, 15];
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Exception5()
        {
            var matrix = new ObjectMatrix<int>(10, 15);
            var i = matrix[-1, 0];
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Exception6()
        {
            var matrix = new ObjectMatrix<int>(10, 15);
            var i = matrix[9, -1];
        }
    }
}