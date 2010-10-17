﻿using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorNTests
{
    [TestFixture]
    public class DivideOperator
    {
        [Test]
        public void DivideDouble()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(4, 12);
            IVector<double> vector = vector1 / 2;
            Assert.AreEqual(2, vector[0]);
            Assert.AreEqual(6, vector[1]);
            Assert.AreEqual(4, vector1[0]);
            Assert.AreEqual(12, vector1[1]);
            Assert.AreNotSame(vector1, vector);
        }


        [Test]
        public void DivideVector()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(4, 8);
            var vector2 = new VectorN(2);
            vector2.SetValues(2, 2);
            IVector<double> vector = vector1 / vector2;
            Assert.AreEqual(2, vector[0]);
            Assert.AreEqual(4, vector[1]);
            Assert.AreEqual(4, vector1[0]);
            Assert.AreEqual(8, vector1[1]);
            Assert.AreEqual(2, vector2[0]);
            Assert.AreEqual(2, vector2[1]);
            Assert.AreNotSame(vector1, vector);
            Assert.AreNotSame(vector2, vector);
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionDifferentDimensions()
        {
            var vector1 = new VectorN(2);
            var vector2 = new VectorN(4);
            IVector<double> vector = vector1 / vector2;
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionLeftNull()
        {
            var vector1 = new VectorN(2);
            IVector<double> vector = null / vector1;
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionRightNull()
        {
            var vector1 = new VectorN(2);
            IVector<double> vector = vector1 / null;
        }
    }
}