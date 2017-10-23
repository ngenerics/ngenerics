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

namespace NGenerics.Tests.DataStructures.Mathematical.ComplexNumberTests
{
    [TestFixture]
    public class Reciprocal
    {

        [Test]
        public void Simple()
        {
            var complexNumber1 = new ComplexNumber(4, 5);
            var complexNumber2 = new ComplexNumber(-2, 4);
            var complexNumber3 = new ComplexNumber(1, -3);
            var complexNumber4 = new ComplexNumber(-6, -12);

            var resultComplexNumber = complexNumber1.Reciprocal;

            Assert.AreEqual(4d / 41d, resultComplexNumber.Real);
            Assert.AreEqual(-5d / 41d, resultComplexNumber.Imaginary);

            resultComplexNumber = complexNumber2.Reciprocal;

            Assert.AreEqual(-2d / 20d, resultComplexNumber.Real);
            Assert.AreEqual(-4d / 20d, resultComplexNumber.Imaginary);

            resultComplexNumber = complexNumber3.Reciprocal;

            Assert.AreEqual(1d / 10d, resultComplexNumber.Real);
            Assert.AreEqual(3d / 10d, resultComplexNumber.Imaginary);

            resultComplexNumber = complexNumber4.Reciprocal;

            Assert.AreEqual(-6d / 180d, resultComplexNumber.Real);
            Assert.AreEqual(12d / 180d, resultComplexNumber.Imaginary);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionZeroComplexNumber()
        {
            var complexNumber = new ComplexNumber(0, 0);
            var resultComplexNumber = complexNumber.Reciprocal;
        }

    }
}