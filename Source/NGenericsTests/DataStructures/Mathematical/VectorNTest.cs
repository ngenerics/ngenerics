/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorNTest
{
    [TestFixture]
    public class AbsoluteMaximum
    {
        [Test]
        public void Simple()
        {
            var vector1 = new VectorN(4);
            vector1[0] = 1;
            vector1[1] = -4;
            vector1[2] = 3;
            vector1[3] = 2;
            Assert.AreEqual(4, vector1.AbsoluteMaximum());
        }
    }

    [TestFixture]
    public class AbsoluteMaximumIndex
    {
        [Test]
        public void Simple()
        {
            var vector1 = new VectorN(4);
            vector1[0] = 1;
            vector1[1] = -4;
            vector1[2] = 3;
            vector1[3] = 2;
            Assert.AreEqual(1, vector1.AbsoluteMaximumIndex());
        }
    }

    [TestFixture]
    public class AbsoluteMinimum
    {

        [Test]
        public void Simple()
        {
            var vector1 = new VectorN(4);
            vector1[0] = 1;
            vector1[1] = -4;
            vector1[2] = 3;
            vector1[3] = 2;
            Assert.AreEqual(1, vector1.AbsoluteMinimum());
        }

    }

    [TestFixture]
    public class AbsoluteMinimumIndex
    {

        [Test]
        public void Simple()
        {
            var vector1 = new VectorN(5);
            vector1[0] = 7;
            vector1[1] = -4;
            vector1[2] = 3;
            vector1[3] = 5;
            vector1[4] = 1;

            Assert.AreEqual(4, vector1.AbsoluteMinimumIndex());
        }

    }

    [TestFixture]
    public class Add
    {

        [Test]
        public void Double()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(4, 7);
            vector1.Add(1);
            Assert.AreEqual(5, vector1[0]);
            Assert.AreEqual(8, vector1[1]);
        }

        [Test]
        public void Vector()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(4, 7);
            var vector2 = new VectorN(2);
            vector2.SetValues(3, 4);
            vector1.Add(vector2);
            Assert.AreEqual(7, vector1[0]);
            Assert.AreEqual(11, vector1[1]);
        }

    }

    [TestFixture]
    public class Clone
    {

        [Test]
        public void Simple()
        {
            var vector = new VectorN(3);
            vector.SetValues(3, 7, 9);

            var clone = (VectorN)vector.Clone();

            Assert.AreEqual(3, vector[0]);
            Assert.AreEqual(7, vector[1]);
            Assert.AreEqual(9, vector[2]);

            Assert.AreEqual(3, clone[0]);
            Assert.AreEqual(7, clone[1]);
            Assert.AreEqual(9, clone[2]);

            Assert.AreNotSame(clone, vector);
        }

    }

    [TestFixture]
    public class Contruction
    {

        [Test]
        public void Simple()
        {
            var vector = new VectorN(2);
            Assert.AreEqual(2, vector.DimensionCount);
            Assert.AreEqual(0, vector[0]);
            Assert.AreEqual(0, vector[1]);
        }

    }

    [TestFixture]
    public class CrossProduct
    {

        [Test]
        public void Simple3x3()
        {
            var vector1 = new VectorN(3);
            vector1.SetValues(1, 2, 3);
            var vector2 = new VectorN(3);
            vector2.SetValues(4, 5, 6);

            var vector = vector1.CrossProduct(vector2);

            Assert.AreEqual(-3, vector[0]);
            Assert.AreEqual(6, vector[1]);
            Assert.AreEqual(-3, vector[2]);
        }

        [Test]
        public void Simple2x2()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(2, 3);
            var vector2 = new VectorN(2);
            vector2.SetValues(4, 5);

            var vector = vector1.CrossProduct(vector2);

            Assert.AreEqual(0, vector[0]);
            Assert.AreEqual(0, vector[1]);
            Assert.AreEqual(-2, vector[2]);
        }

        [Test]
        public void Simple2x3()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(2, 3);
            var vector2 = new VectorN(3);
            vector2.SetValues(4, 5, 6);

            var vector = vector1.CrossProduct(vector2);

            Assert.AreEqual(18, vector[0]);
            Assert.AreEqual(-12, vector[1]);
            Assert.AreEqual(-2, vector[2]);
        }

        [Test]
        public void Simple3x2()
        {
            var vector1 = new VectorN(3);
            vector1.SetValues(1, 2, 3);
            var vector2 = new VectorN(2);
            vector2.SetValues(4, 5);

            var vector = vector1.CrossProduct(vector2);

            Assert.AreEqual(-15, vector[0]);
            Assert.AreEqual(12, vector[1]);
            Assert.AreEqual(-3, vector[2]);
        }

    }

    [TestFixture]
    public class Decrement
    {

        [Test]
        public void Simple()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(4, 7);
            vector1.Decrement();
            Assert.AreEqual(3, vector1[0]);
            Assert.AreEqual(6, vector1[1]);
        }

    }

    [TestFixture]
    public class Divide
    {

        [Test]
        public void Double()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(9, 3);
            vector1.Divide(3);
            Assert.AreEqual(3, vector1[0]);
            Assert.AreEqual(1, vector1[1]);
        }

        [Test]
        public void Vector()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(6, 16);
            var vector2 = new VectorN(2);
            vector2.SetValues(2, 4);
            vector1.Divide(vector2);
            Assert.AreEqual(3, vector1[0]);
            Assert.AreEqual(4, vector1[1]);
        }

    }

    [TestFixture]
    public class DotProduct
    {

        [Test]
        public void Simple()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(4, 7);

            var vector2 = new VectorN(2);
            vector2.SetValues(3, 4);

            var dotProduct = vector1.DotProduct(vector2);
            Assert.AreEqual(40, dotProduct);


            Assert.AreEqual(4, vector1[0]);
            Assert.AreEqual(7, vector1[1]);

            Assert.AreEqual(3, vector2[0]);
            Assert.AreEqual(4, vector2[1]);
        }

    }

    [TestFixture]
    public class DimensionCount
    {

        [Test]
        public void Simple()
        {
            var vector = new VectorN(2);
            Assert.AreEqual(2, vector.DimensionCount);
        }

    }

    [TestFixture]
    public class GetZeroVector
    {

        [Test]
        public void Simple()
        {
            var vector = VectorN.GetZeroVector(3);
            Assert.AreEqual(3, vector.DimensionCount);
            Assert.AreEqual(0, vector[0]);
            Assert.AreEqual(0, vector[1]);
            Assert.AreEqual(0, vector[2]);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionZero()
        {
            VectorN.GetZeroVector(0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionNegative()
        {
            VectorN.GetZeroVector(-1);
        }

    }

    [TestFixture]
    public class GetUnitVector
    {

        [Test]
        public void Simple()
        {
            var vector = VectorN.GetUnitVector(3);

            Assert.AreEqual(3, vector.DimensionCount);
            Assert.AreEqual(1, vector[0]);
            Assert.AreEqual(1, vector[1]);
            Assert.AreEqual(1, vector[2]);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionDimensionCountZero()
        {
            VectorN.GetUnitVector(0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionDimensionCountNegative()
        {
            VectorN.GetUnitVector(-1);
        }

    }

    [TestFixture]
    public class Increment
    {

        [Test]
        public void Simple()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(4, 7);
            vector1.Increment();
            Assert.AreEqual(5, vector1[0]);
            Assert.AreEqual(8, vector1[1]);
        }

    }

    [TestFixture]
    public class Index
    {

        [Test]
        public void Simple()
        {
            var vector = new VectorN(2);
            Assert.AreEqual(2, vector.DimensionCount);

            Assert.AreEqual(0, vector[0]);
            Assert.AreEqual(0, vector[1]);

            vector[0] = 4;
            vector[1] = 5;

            Assert.AreEqual(4, vector[0]);
            Assert.AreEqual(5, vector[1]);
        }

        [Test]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ExceptionTooLarge()
        {
            var vector = new VectorN(2);
            var d = vector[2];
        }

        [Test]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ExceptionTooSmall()
        {
            var vector = new VectorN(2);
            var d = vector[-1];
        }

    }

    [TestFixture]
    public class Magnitude
    {

        [Test]
        public void Simple()
        {
            var vector = new VectorN(3);
            vector.SetValues(4, 3, 12);
            Assert.AreEqual(13, vector.Magnitude());

            Assert.AreEqual(4, vector[0]);
            Assert.AreEqual(3, vector[1]);
            Assert.AreEqual(12, vector[2]);
        }

    }

    [TestFixture]
    public class MaximumIndex
    {

        [Test]
        public void Simple()
        {
            var vector1 = new VectorN(4);
            vector1[0] = 1;
            vector1[1] = -4;
            vector1[2] = 3;
            vector1[3] = 2;
            Assert.AreEqual(2, vector1.MaximumIndex());
        }

    }

    [TestFixture]
    public class MinimumIndex
    {

        [Test]
        public void Simple()
        {
            var vector1 = new VectorN(4);
            vector1[0] = 1;
            vector1[1] = -4;
            vector1[2] = 3;
            vector1[3] = 2;
            Assert.AreEqual(1, vector1.MinimumIndex());
        }

    }

    [TestFixture]
    public class Multiply
    {

        [Test]
        public void Double()
        {
            var vector1 = new VectorN(2);
            vector1[0] = 1;
            vector1[1] = 2;
            vector1.Multiply(2);
            Assert.AreEqual(2, vector1[0]);
            Assert.AreEqual(4, vector1[1]);
        }

        [Test]
        public void Vector()
        {
            var vector1 = new VectorN(2);
            vector1[0] = 1;
            vector1[1] = 2;
            var vector2 = new VectorN(2);
            vector2[0] = 3;
            vector2[1] = 4;
            var matrix = vector1.Multiply(vector2);
            Assert.AreEqual(2, matrix.Columns);
            Assert.AreEqual(2, matrix.Rows);
            Assert.AreEqual(3, matrix[0, 0]);
            Assert.AreEqual(4, matrix[0, 1]);
            Assert.AreEqual(6, matrix[1, 0]);
            Assert.AreEqual(8, matrix[1, 1]);
        }

    }

    [TestFixture]
    public class Negate
    {

        [Test]
        public void Simple()
        {
            var vector1 = new VectorN(2);
            vector1[0] = 1;
            vector1[1] = 2;
            vector1.Negate();
            Assert.AreEqual(-1, vector1[0]);
            Assert.AreEqual(-2, vector1[1]);
        }

    }

    [TestFixture]
    public class Normalize
    {

        [Test]
        public void Simple()
        {
            var vector = new VectorN(3);
            vector[0] = 23;
            vector[1] = -21;
            vector[2] = 4;
            vector.Normalize();
            Assert.AreEqual(1, vector.Magnitude());
        }

    }

    [TestFixture]
    public class Product
    {

        [Test]
        public void Simple()
        {
            var vector = new VectorN(2);
            vector.SetValues(2, 3);
            Assert.AreEqual(6, vector.Product());
        }

    }

    [TestFixture]
    public class Sum
    {

        [Test]
        public void Simple()
        {
            var vector = new VectorN(2);
            vector.SetValues(2, 3);
            Assert.AreEqual(5, vector.Sum());
        }

    }

    [TestFixture]
    public class Subtract
    {

        [Test]
        public void Double()
        {
            var vector1 = new VectorN(2);
            vector1[0] = 1;
            vector1[1] = 2;

            vector1.Subtract(2);

            Assert.AreEqual(-1, vector1[0]);
            Assert.AreEqual(0, vector1[1]);
        }

        [Test]
        public void Vector()
        {
            var vector1 = new VectorN(2);
            vector1[0] = 1;
            vector1[1] = 2;

            var vector2 = new VectorN(2);
            vector2[0] = 8;
            vector2[1] = 4;

            vector1.Subtract(vector2);

            Assert.AreEqual(-7, vector1[0]);
            Assert.AreEqual(-2, vector1[1]);
        }

    }

    [TestFixture]
    public class Swap
    {

        [Test]
        public void Simple()
        {
            var vector1 = new VectorN(2);
            vector1[0] = 1;
            vector1[1] = 2;

            var vector2 = new VectorN(2);
            vector2[0] = 3;
            vector2[1] = 4;

            vector1.Swap(vector2);

            Assert.AreEqual(3, vector1[0]);
            Assert.AreEqual(4, vector1[1]);
            Assert.AreEqual(1, vector2[0]);
            Assert.AreEqual(2, vector2[1]);
        }

    }

    [TestFixture]
    public class ToArray
    {

        [Test]
        public void Simple()
        {
            var vector = new VectorN(2);
            vector.SetValues(8, 3);

            var actual = vector.ToArray();

            Assert.AreEqual(2, actual.Length);
            Assert.AreEqual(8, actual[0]);
            Assert.AreEqual(3, actual[1]);
        }

    }

    [TestFixture]
    public class ToMatrix
    {

        [Test]
        public void Simple()
        {
            var vector = new VectorN(2);
            vector.SetValues(8, 3);

            var actual = vector.ToMatrix();

            Assert.AreEqual(2, actual.Rows);
            Assert.AreEqual(1, actual.Columns);

            Assert.AreEqual(8, actual[0, 0]);
            Assert.AreEqual(3, actual[1, 0]);
        }

    }
}
