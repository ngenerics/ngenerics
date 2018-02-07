/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/


using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Examples.DataStructures.Mathematical
{
    [TestFixture]
    public class ComplexNumberExamples
    {

        #region Add
        [Test]
        public void AddExample()
        {
            var complexNumber1 = new ComplexNumber(4, 3);
            var complexNumber2 = new ComplexNumber(6, 2);

            var result = complexNumber1.Add(complexNumber2);

            Assert.AreEqual(10, result.Real);
            Assert.AreEqual(5, result.Imaginary);
        }

        #endregion

        #region AbsoluteValue
        [Test]
        public void AbsoluteValueExample()
        {
            var complexNumber = new ComplexNumber(4, -3);

            var result = complexNumber.AbsoluteValue;

            Assert.AreEqual(5, result);
        }
        #endregion

        #region AdditiveIdentity
        [Test]
        public void AdditiveIdentityExample()
        {
            var complexNumber = ComplexNumber.AdditiveIdentity;
            Assert.AreEqual(0, complexNumber.Real);
            Assert.AreEqual(0, complexNumber.Imaginary);
        }

        #endregion

        #region AdditiveInverse
        [Test]
        public void AdditiveInverseExample()
        {
            var complexNumber1 = new ComplexNumber(4, -2);

            var result = complexNumber1.AdditiveInverse;

            Assert.AreEqual(result.Real, -4);
            Assert.AreEqual(2, result.Imaginary);
        }
        #endregion

        #region Clone
        [Test]
        public void CloneExample()
        {
            var complexNumber = new ComplexNumber(5, 6);
            var clonedComplexNumber = (ComplexNumber)complexNumber.Clone();

            // The clone will have the same Real and Imaginary numbers
            Assert.AreEqual(5, clonedComplexNumber.Real);
            Assert.AreEqual(6, clonedComplexNumber.Imaginary);
        }

        #endregion

        #region Constructor
        [Test]
        public void ConstructorExample()
        {
            var complex = new ComplexNumber(5, 10);
            Assert.AreEqual(5, complex.Real);
            Assert.AreEqual(10, complex.Imaginary);

            // Real and Imaginary are initialised to 0
            var defaultComplexNumber = new ComplexNumber();
            Assert.AreEqual(0, defaultComplexNumber.Real);
            Assert.AreEqual(0, defaultComplexNumber.Imaginary);
        }
        #endregion

        #region Conjugate

        [Test]
        public void ConjugateExample()
        {
            var complexNumber = new ComplexNumber(1, 2);
            var conjugateComplexNumber = complexNumber.Conjugate;

            Assert.AreEqual(1, conjugateComplexNumber.Real);
            Assert.AreEqual(-2, conjugateComplexNumber.Imaginary);

        }

        #endregion


        #region DivideComplexNumber

        [Test]
        public void DivideComplexNumberExample()
        {
            var complexNumber1 = new ComplexNumber(-8, 4);
            var complexNumber2 = new ComplexNumber(3, 1);

            var div = complexNumber1.Divide(complexNumber2);

            Assert.AreEqual(-2, div.Real);
            Assert.AreEqual(2, div.Imaginary);
        }

        #endregion

        #region DivideDouble

        [Test]
        public void DivideDoubleExample()
        {
            var complexNumber1 = new ComplexNumber(8, 4);

            var div = complexNumber1.Divide(2);

            Assert.AreEqual(4, div.Real);
            Assert.AreEqual(2, div.Imaginary);
        }

        #endregion

        #region Equals
        [Test]
        public void EqualsExample()
        {
            var complexNumber1 = new ComplexNumber(1, 2);
            var complexNumber2 = new ComplexNumber(1, 2);

            Assert.IsTrue(complexNumber1.Equals(complexNumber1));
            Assert.IsTrue(complexNumber1.Equals(complexNumber2));
        }
        #endregion

        #region EqualsObject
        [Test]
        public void EqualsObjectExample()
        {
            object complexNumber1 = new ComplexNumber(1, 2);
            object complexNumber2 = new ComplexNumber(1, 2);

            Assert.IsTrue(complexNumber1.Equals(complexNumber2));
        }

        #endregion

        #region Imaginary
        [Test]
        public void ImaginaryExample()
        {
            var complex = new ComplexNumber(5, 10);

            // Imaginary is 10
            Assert.AreEqual(10, complex.Imaginary);

            // Set Imaginary to 15
            complex.Imaginary = 15;

            // Imaginary now equals 15
            Assert.AreEqual(15, complex.Imaginary);
        }
        #endregion

        #region Modulus
        [Test]
        public void ModulusExample()
        {
            var complex = new ComplexNumber(0, 10);
            var modulus = complex.Modulus;

            Assert.AreEqual(10, modulus);
        }
        #endregion

        #region MultiplicativeIdentity
        [Test]
        public void MultiplicativeIdentityExample()
        {
            var complexNumber = ComplexNumber.MultiplicativeIdentity;
            Assert.AreEqual(0, complexNumber.Imaginary);
            Assert.AreEqual(1, complexNumber.Real);
        }

        #endregion

        #region MultiplyComplexNumber

        [Test]
        public void MultiplyComplexNumberExample()
        {
            var complexNumber1 = new ComplexNumber(1, 2);
            var complexNumber2 = new ComplexNumber(3, 4);
            var times = complexNumber1.Multiply(complexNumber2);

            Assert.AreEqual(-5, times.Real);
            Assert.AreEqual(10, times.Imaginary);
        }
        #endregion

        #region MultiplyDouble

        [Test]
        public void MultiplyDoubleExample()
        {
            var complexNumber1 = new ComplexNumber(1, 2);
            var times = complexNumber1.Multiply(2);

            Assert.AreEqual(2, times.Real);
            Assert.AreEqual(4, times.Imaginary);
        }
        #endregion

        #region OperatorMinusComplexNumber
        [Test]
        public void OperatorMinusComplexNumberExample()
        {
            var complexNumber1 = new ComplexNumber(4, 3);
            var complexNumber2 = new ComplexNumber(6, 2);

            var result = complexNumber1 - complexNumber2;
            Assert.AreEqual(1, result.Imaginary);
            Assert.AreEqual(-2, result.Real);
        }

        #endregion

        #region OperatorPlus
        [Test]
        public void OperatorPlusExample()
        {
            var complexNumber1 = new ComplexNumber(4, 3);
            var complexNumber2 = new ComplexNumber(6, 2);

            var result = complexNumber1 + complexNumber2;

            Assert.AreEqual(10, result.Real);
            Assert.AreEqual(5, result.Imaginary);

        }
        #endregion

        #region OperatorEquals
        [Test]
        public void OperatorEquals()
        {
            var complexNumber1 = new ComplexNumber(-8, 4);
            var complexNumber2 = new ComplexNumber(-8, 4);
            Assert.IsTrue(complexNumber1 == complexNumber2);
        }
        #endregion

        #region OperatorNotEquals
        [Test]
        public void OperatorNotEqualsExample()
        {
            var complexNumber1 = new ComplexNumber(-8, 4);
            var complexNumber2 = new ComplexNumber(3, 7);
            Assert.IsTrue(complexNumber1 != complexNumber2);
        }
        #endregion

        #region OperatorDivideComplexNumberDouble
        [Test]
        public void OperatorDivideComplexNumberDoubleExample()
        {
            var complexNumber1 = new ComplexNumber(-8, 4);

            var div = complexNumber1 / 2;

            Assert.AreEqual(-4, div.Real);
            Assert.AreEqual(2, div.Imaginary);
        }
        #endregion

        #region OperatorDivideComplexNumberComplexNumber
        [Test]
        public void OperatorDivideComplexNumberComplexNumberExample()
        {
            var complexNumber1 = new ComplexNumber(-8, 4);
            var complexNumber2 = new ComplexNumber(3, 1);

            var div = complexNumber1 / complexNumber2;

            Assert.AreEqual(-2, div.Real);
            Assert.AreEqual(2, div.Imaginary);
        }
        #endregion

        #region OperatorMultiplyComplexNumberComplexNumber
        [Test]
        public void OperatorMultiplyComplexNumberComplexNumberExample()
        {
            var complexNumber1 = new ComplexNumber(-8, 4);
            var complexNumber2 = new ComplexNumber(3, 1);

            var div = complexNumber1 * complexNumber2;

            Assert.AreEqual(-28, div.Real);
            Assert.AreEqual(4, div.Imaginary);
        }
        #endregion

        #region OperatorMultiplyComplexNumberDouble

        [Test]
        public void OperatorMultiplyComplexNumberDoubleExample()
        {
            var complexNumber1 = new ComplexNumber(-8, 4);

            var div = complexNumber1 * 2;

            Assert.AreEqual(-16, div.Real);
            Assert.AreEqual(8, div.Imaginary);
        }
        #endregion

        #region OperatorMultiplyDoubleComplexNumber

        [Test]
        public void OperatorMultiplyDoubleComplexNumberExample()
        {
            var complexNumber1 = new ComplexNumber(-8, 4);

            var div = 2 * complexNumber1;

            Assert.AreEqual(-16, div.Real);
            Assert.AreEqual(8, div.Imaginary);
        }

        #endregion

        #region Real
        [Test]
        public void RealExample()
        {
            var complexNumber = new ComplexNumber(5, 10);

            // Real is 5
            Assert.AreEqual(5, complexNumber.Real);

            // Set Real to 10
            complexNumber.Real = 10;

            // Real now equals 10
            Assert.AreEqual(10, complexNumber.Real);
        }
        #endregion

        #region Reciprocal
        [Test]
        public void ReciprocalExample()
        {
            var complexNumber = new ComplexNumber(4, 5);

            var result = complexNumber.Reciprocal;

            Assert.AreEqual(4d / 41d, result.Real);
            Assert.AreEqual(-5d / 41d, result.Imaginary);
        }

        #endregion

        #region Subtract
        [Test]
        public void SubtractExample()
        {
            var complexNumber1 = new ComplexNumber(4, 3);
            var complexNumber2 = new ComplexNumber(6, 2);

            var result = complexNumber1.Subtract(complexNumber2);

            Assert.AreEqual(1, result.Imaginary);
            Assert.AreEqual(-2, result.Real);
        }

        #endregion

        #region ToMatrix
        [Test]
        public void ToMatrixExample()
        {
            var complexNumber = new ComplexNumber(3, 4);

            /* For (a, b) :
            * [ a, -b ]
            * [ b, a ]
            */

            var matrix = complexNumber.ToMatrix();

            Assert.AreEqual(3, matrix[0, 0]);
            Assert.AreEqual(-4, matrix[0, 1]);
            Assert.AreEqual(4, matrix[1, 0]);
            Assert.AreEqual(3, matrix[1, 1]);
        }

        #endregion

        #region ToString
        [Test]
        public void ToStringExample()
        {
            var complexNumber = new ComplexNumber(4, -2);
            var stringRepresentation = complexNumber.ToString();

            Assert.AreEqual("4 + -2i", stringRepresentation);
        }

        #endregion
    }
}