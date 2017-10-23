/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.MatrixTests
{
    [TestFixture]
    public class Inverse
    {

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionZeroDeterminant()
        {
            var matrix = new Matrix(3, 3);

            // [ 4,  4,  4 ]
            // [ 4,  4,  4 ]
            // [ 4,  4,  4 ]
            // Determinant = 0

            matrix[0, 0] = 4;
            matrix[0, 1] = 4;
            matrix[0, 2] = 4;

            matrix[1, 0] = 4;
            matrix[1, 1] = 4;
            matrix[1, 2] = 4;

            matrix.Inverse();
        }

        [Test]
        public void Simple2()
        {
            // [  19.6, 24.974999999999998,  36.999999999999993 ] -1
            // [  24.974999999999998,  52.125000000000014,  67.5 ]
            // [  36.999999999999993, 67.5,  100.0 ]
            //
            // = 
            //
            // [  1,        -1,   -1 ]
            // [  -(6/5),  7/5,  4/5 ]
            // [  -(2/5),  4/5,  3/5 ]



            var matrix = new Matrix(3, 3);
            matrix[0, 0] = 19.6;
            matrix[0, 1] = 24.974999999999998;
            matrix[0, 2] = 36.999999999999993;

            matrix[1, 0] = 24.974999999999998;
            matrix[1, 1] = 52.125000000000014;
            matrix[1, 2] = 67.5;

            matrix[2, 0] = 36.999999999999993;
            matrix[2, 1] = 67.5;
            matrix[2, 2] = 100.0;

            var inv = matrix.Inverse();



            Assert.AreEqual(inv[0, 0], 0.169204737732656, 0.000000001);
            Assert.AreEqual(inv[0, 1], -1.44028932924345E-16, 0.000000001);
            Assert.AreEqual(inv[0, 2], -0.0626057529610827, 0.000000001);

            Assert.AreEqual(inv[1, 0], -7.20806576118106E-17, 0.00001);
            Assert.AreEqual(inv[1, 1], 0.152380952380952, 0.00001);
            Assert.AreEqual(inv[1, 2], -0.102857142857143, 0.00001);

            Assert.AreEqual(inv[2, 0], -0.0626057529610828, 0.00001);
            Assert.AreEqual(inv[2, 1], -0.102857142857142, 0.00001);
            Assert.AreEqual(inv[2, 2], 0.102592700024172, 0.00001);
        }

        [Test]
        public void Simple()
        {
            // [  1, -1,  3 ] -1
            // [  2,  1,  2 ]
            // [ -2, -2,  1 ]
            //
            // = 
            //
            // [  1,        -1,   -1 ]
            // [  -(6/5),  7/5,  4/5 ]
            // [  -(2/5),  4/5,  3/5 ]


            var matrix = new Matrix(3, 3);
            matrix[0, 0] = 1;
            matrix[0, 1] = -1;
            matrix[0, 2] = 3;

            matrix[1, 0] = 2;
            matrix[1, 1] = 1;
            matrix[1, 2] = 2;

            matrix[2, 0] = -2;
            matrix[2, 1] = -2;
            matrix[2, 2] = 1;

            var a = matrix.Inverse();

            Assert.AreEqual(a[0, 0], 1, 0.000000001);
            Assert.AreEqual(a[0, 1], -1, 0.000000001);
            Assert.AreEqual(a[0, 2], -1, 0.000000001);

            Assert.AreEqual(a[1, 0], (6F / 5F) * -1F, 0.00001);
            Assert.AreEqual(a[1, 1], 7F / 5F, 0.00001);
            Assert.AreEqual(a[1, 2], 4F / 5F, 0.00001);

            Assert.AreEqual(a[2, 0], (2F / 5F) * -1F, 0.00001);
            Assert.AreEqual(a[2, 1], 4F / 5F, 0.00001);
            Assert.AreEqual(a[2, 2], 3F / 5F, 0.00001);
        }

        [Test]
        public void InverseInterface()
        {
            // [  1, -1,  3 ] -1
            // [  2,  1,  2 ]
            // [ -2, -2,  1 ]
            //
            // = 
            //
            // [  1,        -1,   -1 ]
            // [  -(6/5),  7/5,  4/5 ]
            // [  -(2/5),  4/5,  3/5 ]


            IMathematicalMatrix matrix = new Matrix(3, 3);
            matrix[0, 0] = 1;
            matrix[0, 1] = -1;
            matrix[0, 2] = 3;

            matrix[1, 0] = 2;
            matrix[1, 1] = 1;
            matrix[1, 2] = 2;

            matrix[2, 0] = -2;
            matrix[2, 1] = -2;
            matrix[2, 2] = 1;

            var a = matrix.Inverse();

            Assert.AreEqual(a[0, 0], 1, 0.000000001);
            Assert.AreEqual(a[0, 1], -1, 0.000000001);
            Assert.AreEqual(a[0, 2], -1, 0.000000001);

            Assert.AreEqual(a[1, 0], (6F / 5F) * -1F, 0.00001);
            Assert.AreEqual(a[1, 1], 7F / 5F, 0.00001);
            Assert.AreEqual(a[1, 2], 4F / 5F, 0.00001);

            Assert.AreEqual(a[2, 0], (2F / 5F) * -1F, 0.00001);
            Assert.AreEqual(a[2, 1], 4F / 5F, 0.00001);
            Assert.AreEqual(a[2, 2], 3F / 5F, 0.00001);
        }

    }
}