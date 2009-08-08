/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using System.Collections.Generic;
using NGenerics.Tests.Util;
using NUnit.Framework;
using NGenerics.DataStructures.Mathematical;

namespace NGenerics.Tests.DataStructures.Mathematical
{
    public class ComplexNumberTest
    {
        [TestFixture]
        public class AdditiveIdentity
        {

            [Test]
            public void Simple()
            {
                var complexNumber = ComplexNumber.AdditiveIdentity;
                Assert.AreEqual(0, complexNumber.Real);
                Assert.AreEqual(0, complexNumber.Imaginary);
            }

        }

        [TestFixture]
        public class AdditiveInverse
        {

            [Test]
            public void Simple()
            {
                var complexNumber1 = new ComplexNumber(4, -2);
                var complexNumber2 = new ComplexNumber(-2, 6);

                var resultComplexNumber = complexNumber1.AdditiveInverse;

                Assert.AreEqual(-4, resultComplexNumber.Real);
                Assert.AreEqual(2, resultComplexNumber.Imaginary);

                resultComplexNumber = complexNumber2.AdditiveInverse;

                Assert.AreEqual(2, resultComplexNumber.Real);
                Assert.AreEqual(-6, resultComplexNumber.Imaginary);
            }

        }

        [TestFixture]
        public class AbsoluteValue
        {

            [Test]
            public void Simple()
            {
                var complexNumber1 = new ComplexNumber(-3, -4);
                var complexNumber2 = new ComplexNumber(-3, 4);
                var complexNumber3 = new ComplexNumber(3, -4);
                var complexNumber4 = new ComplexNumber(3, 4);

                Assert.AreEqual(5, complexNumber1.AbsoluteValue);
                Assert.AreEqual(5, complexNumber2.AbsoluteValue);
                Assert.AreEqual(5, complexNumber3.AbsoluteValue);
                Assert.AreEqual(5, complexNumber4.AbsoluteValue);
            }

        }

        [TestFixture]
        public class Clone
        {

            [Test]
            public void Simple()
            {
                var complexNumber = new ComplexNumber(5, 6);
                var copy = (ComplexNumber) complexNumber.Clone();

                Assert.AreEqual(copy.Real, complexNumber.Real);
                Assert.AreEqual(copy.Imaginary, complexNumber.Imaginary);

                complexNumber = new ComplexNumber(-2, 3);
                copy = (ComplexNumber) complexNumber.Clone();

                Assert.AreEqual(copy.Real, complexNumber.Real);
                Assert.AreEqual(copy.Imaginary, complexNumber.Imaginary);

                complexNumber = new ComplexNumber(5, -3);
                copy = (ComplexNumber) complexNumber.Clone();

                Assert.AreEqual(copy.Real, complexNumber.Real);
                Assert.AreEqual(copy.Imaginary, complexNumber.Imaginary);

                complexNumber = new ComplexNumber(-9, -4);
                copy = (ComplexNumber) complexNumber.Clone();

                Assert.AreEqual(copy.Real, complexNumber.Real);
                Assert.AreEqual(copy.Imaginary, complexNumber.Imaginary);
            }

        }

        [TestFixture]
        public class Conjugate
        {

            [Test]
            public void Simple()
            {
                var complexNumber1 = new ComplexNumber(1, 2);
                var conjugateComplexNumber = complexNumber1.Conjugate;

                Assert.AreEqual(1, conjugateComplexNumber.Real);
                Assert.AreEqual(-2, conjugateComplexNumber.Imaginary);

                complexNumber1.Imaginary = -1;
                conjugateComplexNumber = complexNumber1.Conjugate;
                Assert.AreEqual(1, conjugateComplexNumber.Real);
                Assert.AreEqual(1, conjugateComplexNumber.Imaginary);

            }

        }

        [TestFixture]
        public class Construction
        {

            [Test]
            public void Simple()
            {
                var complexNumber = new ComplexNumber(5, 10);

                Assert.AreEqual(5, complexNumber.Real);
                Assert.AreEqual(10, complexNumber.Imaginary);

                complexNumber = new ComplexNumber(double.MaxValue, double.Epsilon);

                Assert.AreEqual(double.MaxValue, complexNumber.Real);
                Assert.AreEqual(double.Epsilon, complexNumber.Imaginary);

                complexNumber = new ComplexNumber();
                Assert.AreEqual(0, complexNumber.Real);
                Assert.AreEqual(0, complexNumber.Imaginary);
            }

            [Test]
            public void Set()
            {
                var complexNumber = new ComplexNumber(5, 10);

                Assert.AreEqual(5, complexNumber.Real);
                Assert.AreEqual(10, complexNumber.Imaginary);

                complexNumber.Real = 6;
                complexNumber.Imaginary = 11;

                Assert.AreEqual(6, complexNumber.Real);
                Assert.AreEqual(11, complexNumber.Imaginary);
            }

        }

        [TestFixture]
        public class Divide
        {

            [Test]
            public void Operator()
            {
                var complexNumber1 = new ComplexNumber(-8, 4);
                var complexNumber2 = new ComplexNumber(3, 1);

                var divComplexNumber = complexNumber1 / complexNumber2;

                Assert.AreEqual(-2, divComplexNumber.Real);
                Assert.AreEqual(2, divComplexNumber.Imaginary);

                divComplexNumber = complexNumber1 / 4;
                Assert.AreEqual(-2, divComplexNumber.Real);
                Assert.AreEqual(1, divComplexNumber.Imaginary);

                complexNumber1 = new ComplexNumber(2, 6);
                complexNumber2 = new ComplexNumber(4, 1);

                divComplexNumber = complexNumber1 / complexNumber2;

                Assert.AreEqual(14 / (double) 17, divComplexNumber.Real);
                Assert.AreEqual(22 / (double) 17, divComplexNumber.Imaginary);
            }

            [Test]
            public void Simple()
            {
                var complexNumber1 = new ComplexNumber(-8, 4);
                var complexNumber2 = new ComplexNumber(3, 1);

                var divComplexNumber = complexNumber1.Divide(complexNumber2);

                Assert.AreEqual(-2, divComplexNumber.Real);
                Assert.AreEqual(2, divComplexNumber.Imaginary);

                divComplexNumber = complexNumber1.Divide(4);
                Assert.AreEqual(-2, divComplexNumber.Real);
                Assert.AreEqual(1, divComplexNumber.Imaginary);

                complexNumber1 = new ComplexNumber(2, 6);
                complexNumber2 = new ComplexNumber(4, 1);

                divComplexNumber = complexNumber1.Divide(complexNumber2);

                Assert.AreEqual(14 / (double) 17, divComplexNumber.Real);
                Assert.AreEqual(22 / (double) 17, divComplexNumber.Imaginary);
            }

        }

        [TestFixture]
        public class EqualsObj
        {

            [Test]
            public void Simple2()
            {
                var complexNumber1 = new ComplexNumber(1, 2);
                var complexNumber2 = new ComplexNumber(1, 2);
                var complexNumber3 = new ComplexNumber(1, 6);
                var complexNumber4 = new ComplexNumber(2, 2);
                var complexNumber5 = new ComplexNumber(3, 3);

                Assert.IsTrue(complexNumber1.Equals(complexNumber1));
                Assert.IsTrue(complexNumber1.Equals(complexNumber2));
                Assert.IsFalse(complexNumber1.Equals(complexNumber3));
                Assert.IsFalse(complexNumber1.Equals(complexNumber4));
                Assert.IsFalse(complexNumber1.Equals(complexNumber5));

                // Disable warning C1718 : Testing equality of same variable
#pragma warning disable 1718

                Assert.IsTrue(complexNumber1 == complexNumber1);

#pragma warning restore 1718

                Assert.IsTrue(complexNumber1 == complexNumber2);
                Assert.IsFalse(complexNumber1 == complexNumber3);
                Assert.IsFalse(complexNumber1 == complexNumber4);
                Assert.IsFalse(complexNumber1 == complexNumber5);

#pragma warning disable 1718

                Assert.IsFalse(complexNumber1 != complexNumber1);

#pragma warning restore 1718

                Assert.IsFalse(complexNumber1 != complexNumber2);
                Assert.IsTrue(complexNumber1 != complexNumber3);
                Assert.IsTrue(complexNumber1 != complexNumber4);
                Assert.IsTrue(complexNumber1 != complexNumber5);
            }

            [Test]
            public void Simple1()
            {
                object complexNumber1 = new ComplexNumber(1, 2);
                object complexNumber2 = new ComplexNumber(1, 2);
                object complexNumber3 = new ComplexNumber(1, 6);
                object complexNumber4 = new ComplexNumber(2, 2);
                object complexNumber5 = new ComplexNumber(3, 3);

                Assert.IsTrue(complexNumber1.Equals(complexNumber1));
                Assert.IsTrue(complexNumber1.Equals(complexNumber2));
                Assert.IsFalse(complexNumber1.Equals(complexNumber3));
                Assert.IsFalse(complexNumber1.Equals(complexNumber4));
                Assert.IsFalse(complexNumber1.Equals(complexNumber5));
            }

            [Test]
            public void Simple3()
            {
                object complexNumber1 = new ComplexNumber(1, 2);
                var complexNumber2 = new object();

                Assert.IsFalse(complexNumber1.Equals(complexNumber2));
                Assert.IsFalse(complexNumber1.Equals(null));
            }

        }

        [TestFixture]
        public class GetHashCodeObj
        {

            [Test]
            public void Simple()
            {
                var dictionary = new Dictionary<ComplexNumber, string>();

                for (var i = -100; i < 100; i++)
                {
                    for (var j = -100; j < 100; j++)
                    {
                        // Test uniqueness of hash code
                        var complexNumber = new ComplexNumber(i, j);
                        Assert.IsFalse(dictionary.ContainsKey(complexNumber));

                        dictionary.Add(complexNumber, null);
                    }
                }
            }

        }

        [TestFixture]
        public class Minus
        {

            [Test]
            public void Simple2()
            {
                var complexNumber1 = new ComplexNumber(4, 3);
                var complexNumber2 = new ComplexNumber(6, 2);
                var complexNumber3 = new ComplexNumber(-2, -4);
                var complexNumber4 = new ComplexNumber(3, -8);
                var complexNumber5 = new ComplexNumber(8, 3);

                var resultComplexNumber = complexNumber1 - complexNumber2;

                Assert.AreEqual(1, resultComplexNumber.Imaginary);
                Assert.AreEqual(-2, resultComplexNumber.Real);

                resultComplexNumber = complexNumber1 - complexNumber3;

                Assert.AreEqual(7, resultComplexNumber.Imaginary);
                Assert.AreEqual(6, resultComplexNumber.Real);

                resultComplexNumber = complexNumber1 - complexNumber4;

                Assert.AreEqual(11, resultComplexNumber.Imaginary);
                Assert.AreEqual(1, resultComplexNumber.Real);

                resultComplexNumber = complexNumber1 - complexNumber5;

                Assert.AreEqual(0, resultComplexNumber.Imaginary);
                Assert.AreEqual(-4, resultComplexNumber.Real);
            }

            [Test]
			public void Simple1()
            {
                var complexNumber1 = new ComplexNumber(4, 3);
                var complexNumber2 = new ComplexNumber(6, 2);
                var complexNumber3 = new ComplexNumber(-2, -4);
                var complexNumber4 = new ComplexNumber(3, -8);
                var complexNumber5 = new ComplexNumber(8, 3);

                var resultComplexNumber = complexNumber1.Subtract(complexNumber2);

                Assert.AreEqual(1, resultComplexNumber.Imaginary);
                Assert.AreEqual(-2, resultComplexNumber.Real);

                resultComplexNumber = complexNumber1.Subtract(complexNumber3);

                Assert.AreEqual(7, resultComplexNumber.Imaginary);
                Assert.AreEqual(6, resultComplexNumber.Real);

                resultComplexNumber = complexNumber1.Subtract(complexNumber4);

                Assert.AreEqual(11, resultComplexNumber.Imaginary);
                Assert.AreEqual(1, resultComplexNumber.Real);

                resultComplexNumber = complexNumber1.Subtract(complexNumber5);

                Assert.AreEqual(0, resultComplexNumber.Imaginary);
                Assert.AreEqual(-4, resultComplexNumber.Real);
            }

        }

        [TestFixture]
        public class Modulus
        {

            [Test]
            public void Simple()
            {
                var complex = new ComplexNumber(0, 10);
                var modulus = complex.Modulus;

                Assert.AreEqual(modulus, 10);

                complex = new ComplexNumber(10, 0);
                modulus = complex.Modulus;

                Assert.AreEqual(modulus, 10);

                complex = new ComplexNumber(1.576, -53.47);
                modulus = complex.Modulus;

                var answer = Math.Sqrt(1.576 * 1.576 + (-53.47 * -53.47));
                Assert.AreEqual(modulus, answer);
            }

        }

        [TestFixture]
        public class MultiplicativeIdentity
        {

            [Test]
            public void Simple()
            {
                var complexNumber = ComplexNumber.MultiplicativeIdentity;
                Assert.AreEqual(0, complexNumber.Imaginary);
                Assert.AreEqual(1, complexNumber.Real);
            }

        }
        
        [TestFixture]
        public class OperatorDouble
        {

            [Test]
            public void Simple()
            {
                ComplexNumber complexNumber = 7;
                Assert.AreEqual(7, complexNumber.Real);
                Assert.AreEqual(0, complexNumber.Imaginary);

            }

        }

        [TestFixture]
        public class Plus
        {
            [Test]
            public void Simple2()
            {
                var complexNumber1 = new ComplexNumber(4, 3);
                var complexNumber2 = new ComplexNumber(6, 2);
                var complexNumber3 = new ComplexNumber(-2, -4);
                var complexNumber4 = new ComplexNumber(3, -8);
                var complexNumber5 = new ComplexNumber(8, 3);

                var resultComplexNumber = complexNumber1 + complexNumber2;

                Assert.AreEqual(10, resultComplexNumber.Real);
                Assert.AreEqual(5, resultComplexNumber.Imaginary);

                resultComplexNumber = complexNumber1 + complexNumber3;

                Assert.AreEqual(2, resultComplexNumber.Real);
                Assert.AreEqual(-1, resultComplexNumber.Imaginary);

                resultComplexNumber = complexNumber1 + complexNumber4;

                Assert.AreEqual(7, resultComplexNumber.Real);
                Assert.AreEqual(-5, resultComplexNumber.Imaginary);


                resultComplexNumber = complexNumber1 + complexNumber5;

                Assert.AreEqual(12, resultComplexNumber.Real);
                Assert.AreEqual(6, resultComplexNumber.Imaginary);
            }

            [Test]
            public void Simple1()
            {
                var complexNumber1 = new ComplexNumber(4, 3);
                var complexNumber2 = new ComplexNumber(6, 2);
                var complexNumber3 = new ComplexNumber(-2, -4);
                var complexNumber4 = new ComplexNumber(3, -8);
                var complexNumber5 = new ComplexNumber(8, 3);

                var resultComplexNumber = complexNumber1.Add(complexNumber2);

                Assert.AreEqual(10, resultComplexNumber.Real);
                Assert.AreEqual(5, resultComplexNumber.Imaginary);

                resultComplexNumber = complexNumber1.Add(complexNumber3);

                Assert.AreEqual(2, resultComplexNumber.Real);
                Assert.AreEqual(-1, resultComplexNumber.Imaginary);

                resultComplexNumber = complexNumber1.Add(complexNumber4);

                Assert.AreEqual(7, resultComplexNumber.Real);
                Assert.AreEqual(-5, resultComplexNumber.Imaginary);


                resultComplexNumber = complexNumber1.Add(complexNumber5);

                Assert.AreEqual(12, resultComplexNumber.Real);
                Assert.AreEqual(6, resultComplexNumber.Imaginary);
            }

        }

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

        [TestFixture]
        public class Times
        {

            [Test]
            public void Simple()
            {
                var complexNumber1 = new ComplexNumber(1, 2);
                var complexNumber2 = new ComplexNumber(3, 4);
                var multiplyComplexNumber = complexNumber1.Multiply(complexNumber2);

                Assert.AreEqual(1 * 3 - 2 * 4, multiplyComplexNumber.Real);
                Assert.AreEqual(2 * 3 + 1 * 4, multiplyComplexNumber.Imaginary);

                multiplyComplexNumber = complexNumber1.Multiply(5);
                Assert.AreEqual(5 * 1, multiplyComplexNumber.Real);
                Assert.AreEqual(5 * 2, multiplyComplexNumber.Imaginary);

                multiplyComplexNumber = 6 * complexNumber1;
                Assert.AreEqual(6 * 1, multiplyComplexNumber.Real);
                Assert.AreEqual(6 * 2, multiplyComplexNumber.Imaginary);

                multiplyComplexNumber = complexNumber1 * 7;
                Assert.AreEqual(7 * 1, multiplyComplexNumber.Real);
                Assert.AreEqual(7 * 2, multiplyComplexNumber.Imaginary);

                complexNumber1 *= 1;
                Assert.AreEqual(1, complexNumber1.Real);
                Assert.AreEqual(2, complexNumber1.Imaginary);

                complexNumber1 *= 5;
                Assert.AreEqual(5, complexNumber1.Real);
                Assert.AreEqual(10, complexNumber1.Imaginary);

                complexNumber1 *= complexNumber2;
                Assert.AreEqual(5 * 3 - 10 * 4, complexNumber1.Real);
                Assert.AreEqual(10 * 3 + 5 * 4, complexNumber1.Imaginary);
            }

        }

        [TestFixture]
        public class ToMatrix
        {

            [Test]
			public void Simple()
            {
                var complexNumber = new ComplexNumber(3, 4);

                /* For (a, b) :
                * [ a, -b ]
                * [ b, a ]
                */

                var matrix = complexNumber.ToMatrix();

                Assert.AreEqual(matrix[0, 0], complexNumber.Real);
                Assert.AreEqual(matrix[0, 1], -1 * complexNumber.Imaginary);
                Assert.AreEqual(matrix[1, 0], complexNumber.Imaginary);
                Assert.AreEqual(matrix[1, 1], complexNumber.Real);

                complexNumber = new ComplexNumber(-2, 6);

                matrix = complexNumber.ToMatrix();

                Assert.AreEqual(matrix[0, 0], complexNumber.Real);
                Assert.AreEqual(matrix[0, 1], -1 * complexNumber.Imaginary);
                Assert.AreEqual(matrix[1, 0], complexNumber.Imaginary);
                Assert.AreEqual(matrix[1, 1], complexNumber.Real);

                complexNumber = new ComplexNumber(5, -1);

                matrix = complexNumber.ToMatrix();

                Assert.AreEqual(matrix[0, 0], complexNumber.Real);
                Assert.AreEqual(matrix[0, 1], -1 * complexNumber.Imaginary);
                Assert.AreEqual(matrix[1, 0], complexNumber.Imaginary);
                Assert.AreEqual(matrix[1, 1], complexNumber.Real);

                complexNumber = new ComplexNumber(-3, -2);

                matrix = complexNumber.ToMatrix();

                Assert.AreEqual(matrix[0, 0], complexNumber.Real);
                Assert.AreEqual(matrix[0, 1], -1 * complexNumber.Imaginary);
                Assert.AreEqual(matrix[1, 0], complexNumber.Imaginary);
                Assert.AreEqual(matrix[1, 1], complexNumber.Real);
            }

        }

        [TestFixture]
        public class ToStringObj
        {

            [Test]
            public void Simple()
            {
                var complexNumber = ComplexNumber.MultiplicativeIdentity;
                var s = complexNumber.ToString();

                Assert.IsNotNull(s);
                Assert.IsNotEmpty(s);
                Assert.IsTrue(s.Contains("i"));
                Assert.IsTrue(s.Contains("+"));
            }

            [Test]
            public void StringConversionTest()
            {
                var complexNumber = ComplexNumber.MultiplicativeIdentity;
                var s = (string) complexNumber;

                Assert.IsNotNull(s);
                Assert.IsNotEmpty(s);
                Assert.IsTrue(s.Contains("i"));
                Assert.IsTrue(s.Contains("+"));
            }

        }

        [TestFixture]
        public class Serializable
        {

            [Test]
            public void Simple()
            {
                var originalComplexNumber = new ComplexNumber(2, 3);
                var newComplexNumber = SerializeUtil.BinarySerializeDeserialize(originalComplexNumber);

                Assert.AreEqual(originalComplexNumber, newComplexNumber);

                originalComplexNumber = new ComplexNumber(5, -1);
                newComplexNumber = SerializeUtil.BinarySerializeDeserialize(originalComplexNumber);

                Assert.AreEqual(originalComplexNumber, newComplexNumber);

                originalComplexNumber = new ComplexNumber(-4, 5);
                newComplexNumber = SerializeUtil.BinarySerializeDeserialize(originalComplexNumber);

                Assert.AreEqual(originalComplexNumber, newComplexNumber);

                originalComplexNumber = new ComplexNumber(0, 0);
                newComplexNumber = SerializeUtil.BinarySerializeDeserialize(originalComplexNumber);

                Assert.AreEqual(originalComplexNumber, newComplexNumber);

                originalComplexNumber = new ComplexNumber(0, 5);
                newComplexNumber = SerializeUtil.BinarySerializeDeserialize(originalComplexNumber);

                Assert.AreEqual(originalComplexNumber, newComplexNumber);

                originalComplexNumber = new ComplexNumber(5, 0);
                newComplexNumber = SerializeUtil.BinarySerializeDeserialize(originalComplexNumber);

                Assert.AreEqual(originalComplexNumber, newComplexNumber);

                originalComplexNumber = new ComplexNumber(-3, -2);
                newComplexNumber = SerializeUtil.BinarySerializeDeserialize(originalComplexNumber);

                Assert.AreEqual(originalComplexNumber, newComplexNumber);
            }

        }
    }
}

