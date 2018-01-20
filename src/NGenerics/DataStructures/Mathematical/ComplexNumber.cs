/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/


/* 
 * Most of this class can be contributed to David Larson.
   (see his posts on the NGenerics site).
*/

using System;
using System.Globalization;

namespace NGenerics.DataStructures.Mathematical
{
    /// <summary>
    /// A Complex Number data structure.  
	/// </summary>
    [Serializable]
	public struct ComplexNumber : IEquatable<ComplexNumber>
#if (!SILVERLIGHT && !WINDOWSPHONE)
        , ICloneable
#endif
    {
        #region Globals

        private double real;
        private double imaginary;

        #endregion

        #region Construction

  
        /// <param name="real">The real part of the number.</param>
        /// <param name="imaginary">The imaginary part of the number.</param>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\ComplexNumberExamples.cs" region="Constructor" lang="cs" title="The following example shows how to use the default constructor."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\ComplexNumberExamples.vb" region="Constructor" lang="vbnet" title="The following example shows how to use the default constructor."/>
        /// </example>
        public ComplexNumber(double real, double imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }

        #endregion

        #region IEquatable<ComplexNumber> Members

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// <c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.
        /// </returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\ComplexNumberExamples.cs" region="Equals" lang="cs" title="The following example shows how to use the Equals method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\ComplexNumberExamples.vb" region="Equals" lang="vbnet" title="The following example shows how to use the Equals method."/>
        /// </example>
        public bool Equals(ComplexNumber other)
        {
            return this == other;
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Returns the complex conjugate.
        /// </summary>
        /// <returns>The same number with imaginary part negated.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\ComplexNumberExamples.cs" region="Conjugate" lang="cs" title="The following example shows how to use the Conjugate property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\ComplexNumberExamples.vb" region="Conjugate" lang="vbnet" title="The following example shows how to use the Conjugate property."/>
        /// </example>
        public ComplexNumber Conjugate
        {
            get
            {
                return new ComplexNumber(real, -1 * imaginary);
            }
        }


        /// <summary>
        /// Times the number according *.
        /// </summary>
        /// <param name="complex">The matrix to multiply this matrix with.</param>
        /// <returns>The result of the times operation.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\ComplexNumberExamples.cs" region="MultiplyComplexNumber" lang="cs" title="The following example shows how to use the Multiply method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\ComplexNumberExamples.vb" region="MultiplyComplexNumber" lang="vbnet" title="The following example shows how to use the Multiply method."/>
        /// </example>
        public ComplexNumber Multiply(ComplexNumber complex)
        {
            return MultiplyInternal(this, complex);
        }


        /// <summary>
        /// Times the numbers according to the operator *.
        /// </summary>
        /// <param name="number">The number to multiply this number with.</param>
        /// <returns>The result of the times operation.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\ComplexNumberExamples.cs" region="MultiplyDouble" lang="cs" title="The following example shows how to use the Multiply method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\ComplexNumberExamples.vb" region="MultiplyDouble" lang="vbnet" title="The following example shows how to use the Multiply method."/>
        /// </example>
        public ComplexNumber Multiply(double number)
        {
            return MultiplyInternal(this, number);
        }


        /// <summary>
        /// Divides the numbers according to the operator /.
        /// </summary>
        /// <param name="number">The number to divide this number with.</param>
        /// <returns>The result of the divide operation.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\ComplexNumberExamples.cs" region="DivideComplexNumber" lang="cs" title="The following example shows how to use the Divide method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\ComplexNumberExamples.vb" region="DivideComplexNumber" lang="vbnet" title="The following example shows how to use the Divide method."/>
        /// </example>
        public ComplexNumber Divide(ComplexNumber number)
        {
            return DivideInternal(this, number);
        }


        /// <summary>
        /// Divides the numbers according to the operator /.
        /// </summary>
        /// <param name="number">The number to divide this number with.</param>
        /// <returns>The result of the divide operation.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\ComplexNumberExamples.cs" region="DivideDouble" lang="cs" title="The following example shows how to use the Divide method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\ComplexNumberExamples.vb" region="DivideDouble" lang="vbnet" title="The following example shows how to use the Divide method."/>
        /// </example>
        public ComplexNumber Divide(double number)
        {
            return DivideInternal(this, number);
        }


        /// <summary>
        /// Adds two numbers according operator +.
        /// </summary>
        /// <param name="number">The number to add to this number.</param>
        /// <returns>The result of the addition operation.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\ComplexNumberExamples.cs" region="Add" lang="cs" title="The following example shows how to use the Add method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\ComplexNumberExamples.vb" region="Add" lang="vbnet" title="The following example shows how to use the Add method."/>
        /// </example>
        public ComplexNumber Add(ComplexNumber number)
        {
            return AddInternal(this, number);
        }


        /// <summary>
        /// Subtracts the number according -.
        /// </summary>
        /// <param name="complex">The matrix to subtract from this matrix.</param>
        /// <returns>The result of the subtraction.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\ComplexNumberExamples.cs" region="Subtract" lang="cs" title="The following example shows how to use the Subtract method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\ComplexNumberExamples.vb" region="Subtract" lang="vbnet" title="The following example shows how to use the Subtract method."/>
        /// </example>
        public ComplexNumber Subtract(ComplexNumber complex)
        {
            return SubtractInternal(this, complex);
        }


        /// <summary>
        /// Converts the current complex number to it's matrix representation.
        /// </summary>
        /// <returns>The <see cref="IMathematicalMatrix"/> representation of the <see cref="ComplexNumber"/>.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\ComplexNumberExamples.cs" region="ToMatrix" lang="cs" title="The following example shows how to use the ToMatrix method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\ComplexNumberExamples.vb" region="ToMatrix" lang="vbnet" title="The following example shows how to use the ToMatrix method."/>
        /// </example>
        public IMathematicalMatrix ToMatrix()
        {
            /* For (a, b) :
             *   [ a, -b ]
             *   [ b,  a ]             
             */

            var matrix = new Matrix(2, 2);
            matrix[0, 0] = real;
            matrix[0, 1] = -1 * imaginary;

            matrix[1, 0] = imaginary;
            matrix[1, 1] = real;

            return matrix;
        }


        /// <summary>
        /// Absolute value of a complex number
        /// </summary>
        /// <value>The modulus.</value>
        /// <returns>The result of the Abs operation.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\ComplexNumberExamples.cs" region="Modulus" lang="cs" title="The following example shows how to use the Modulus property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\ComplexNumberExamples.vb" region="Modulus" lang="vbnet" title="The following example shows how to use the Modulus property."/>
        /// </example>
        public double Modulus
        {
            get
            {
                return Math.Sqrt(
                    (real * real) + (imaginary * imaginary)
                );
            }
        }


        /// <summary>
        /// Gets or sets the real part of the complex number.
        /// </summary>
        /// <value>The real part.</value>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\ComplexNumberExamples.cs" region="Real" lang="cs" title="The following example shows how to use the Real property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\ComplexNumberExamples.vb" region="Real" lang="vbnet" title="The following example shows how to use the Real property."/>
        /// </example>
        public double Real
        {
            get
            {
                return real;
            }
            set
            {
                real = value;
            }
        }


        /// <summary>
        /// Gets or sets the imaginary part of the complex number.
        /// </summary>
        /// <value>The imaginary part.</value>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\ComplexNumberExamples.cs" region="Imaginary" lang="cs" title="The following example shows how to use the Imaginary property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\ComplexNumberExamples.vb" region="Imaginary" lang="vbnet" title="The following example shows how to use the Imaginary property."/>
        /// </example>
        public double Imaginary
        {
            get
            {
                return imaginary;
            }
            set
            {
                imaginary = value;
            }
        }

        /// <summary>
        /// Computes the additive inverse of the current complex number.
        /// </summary>
        /// <returns>The additive inverse of the current complex number.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\ComplexNumberExamples.cs" region="AdditiveInverse" lang="cs" title="The following example shows how to use the AdditiveInverse property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\ComplexNumberExamples.vb" region="AdditiveInverse" lang="vbnet" title="The following example shows how to use the AdditiveInverse property."/>
        /// </example>
        public ComplexNumber AdditiveInverse
        {
            get
            {
                return new ComplexNumber(real * -1, imaginary * -1);
            }
        }

        /// <summary>
        /// Computes the absolute value of the current complex number.
        /// </summary>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\ComplexNumberExamples.cs" region="AbsoluteValue" lang="cs" title="The following example shows how to use the AbsoluteValue property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\ComplexNumberExamples.vb" region="AbsoluteValue" lang="vbnet" title="The following example shows how to use the AbsoluteValue property."/>
        /// </example>
        public double AbsoluteValue
        {
            get
            {
                return Math.Sqrt((real * real) + (imaginary * imaginary));
            }
        }


        /// <summary>
        /// Gets the reciprocal.
        /// </summary>
        /// <value>The reciprocal.</value>
        /// <exception cref="InvalidOperationException"><see cref="Real"/> and <see cref="Imaginary"/> are 0.</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\ComplexNumberExamples.cs" region="Reciprocal" lang="cs" title="The following example shows how to use the Reciprocal property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\ComplexNumberExamples.vb" region="Reciprocal" lang="vbnet" title="The following example shows how to use the Reciprocal property."/>
        /// </example>
        public ComplexNumber Reciprocal
        {
            get
            {
                #region Validation

                if ((real == 0) && (imaginary == 0))
                {
                    throw new InvalidOperationException("Finding the Reciprocal of the complex number is only defined for non-zero (real, imaginary) numbers.");
                }

                #endregion

                var div = (real * real) + (imaginary * imaginary);

                return new ComplexNumber(real / div, (imaginary * -1) / div);
            }
        }


        /// <summary>
        /// Gets the additive identity.
        /// </summary>
        /// <value>The additive identity.</value>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\ComplexNumberExamples.cs" region="AdditiveIdentity" lang="cs" title="The following example shows how to use the AdditiveIdentity property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\ComplexNumberExamples.vb" region="AdditiveIdentity" lang="vbnet" title="The following example shows how to use the AdditiveIdentity property."/>
        /// </example>
        public static ComplexNumber AdditiveIdentity
        {
            get
            {
                return new ComplexNumber(0, 0);
            }
        }


        /// <summary>
        /// Gets the multiplicative identity.
        /// </summary>
        /// <value>The multiplicative identity.</value>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\ComplexNumberExamples.cs" region="MultiplicativeIdentity" lang="cs" title="The following example shows how to use the MultiplicativeIdentity property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\ComplexNumberExamples.vb" region="MultiplicativeIdentity" lang="vbnet" title="The following example shows how to use the MultiplicativeIdentity property."/>
        /// </example>
        public static ComplexNumber MultiplicativeIdentity
        {
            get
            {
                return new ComplexNumber(1, 0);
            }
        }


        #endregion

        #region Operator Overloads

        /// <summary>
        /// Overload of the operator + 
        /// </summary>
        /// <param name="left">The left hand number.</param>
        /// <param name="right">The right hand number.</param>
        /// <returns>The result of the addition.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\ComplexNumberExamples.cs" region="OperatorPlus" lang="cs" title="The following example shows how to use the plus operator."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\ComplexNumberExamples.vb" region="OperatorPlus" lang="vbnet" title="The following example shows how to use the plus operator."/>
        /// </example>
        public static ComplexNumber operator +(ComplexNumber left, ComplexNumber right)
        {
            return AddInternal(left, right);
        }


        /// <summary>
        /// Overload of the operator - 
        /// </summary>
        /// <param name="left">The left hand number.</param>
        /// <param name="right">The right hand number.</param>
        /// <returns>The result of the subtraction.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\ComplexNumberExamples.cs" region="OperatorMinus" lang="cs" title="The following example shows how to use the minus operator."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\ComplexNumberExamples.vb" region="OperatorMinus" lang="vbnet" title="The following example shows how to use the minus operator."/>
        /// </example>
        public static ComplexNumber operator -(ComplexNumber left, ComplexNumber right)
        {
            return SubtractInternal(left, right);
        }


        /// <summary>
        /// Overload of the operator * 
        /// </summary>
        /// <param name="left">The left hand number.</param>
        /// <param name="right">The right hand number.</param>
        /// <returns>The result of the multiplication.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\ComplexNumberExamples.cs" region="OperatorMultiplyComplexNumberComplexNumber" lang="cs" title="The following example shows how to use the multiply operator."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\ComplexNumberExamples.vb" region="OperatorMultiplyComplexNumberComplexNumber" lang="vbnet" title="The following example shows how to use the multiply operator."/>
        /// </example>
        public static ComplexNumber operator *(ComplexNumber left, ComplexNumber right)
        {
            // (a + bi)(c + di) = (ac - bd) + (ad + bc)i
            return MultiplyInternal(left, right);
        }


        /// <summary>
        /// Overload of the operator / 
        /// </summary>
        /// <param name="left">The left hand number.</param>
        /// <param name="right">The right hand number.</param>
        /// <returns>The result of the division.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\ComplexNumberExamples.cs" region="OperatorDivideComplexNumberComplexNumber" lang="cs" title="The following example shows how to use the divide operator."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\ComplexNumberExamples.vb" region="OperatorDivideComplexNumberComplexNumber" lang="vbnet" title="The following example shows how to use the divide operator."/>
        /// </example>
        public static ComplexNumber operator /(ComplexNumber left, ComplexNumber right)
        {
            return DivideInternal(left, right);
        }
        
        /// <summary>
        /// Overload of the operator /
        /// </summary>
        /// <param name="complexNumber">The left hand number.</param>
        /// <param name="number">The right hand number.</param>
        /// <returns>The result of the division.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\ComplexNumberExamples.cs" region="OperatorDivideComplexNumberDouble" lang="cs" title="The following example shows how to use the divide operator overload."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\ComplexNumberExamples.vb" region="OperatorDivideComplexNumberDouble" lang="vbnet" title="The following example shows how to use the divide operator overload."/>
        /// </example>
        public static ComplexNumber operator /(ComplexNumber complexNumber, double number)
        {
            return DivideInternal(complexNumber, number);
        }


        /// <summary>
        /// Overload of the operator * 
        /// </summary>
        /// <param name="complexNumber">The number to be multiplied with.</param>
        /// <param name="number">The number.</param>
        /// <returns>The result of the multiplication.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\ComplexNumberExamples.cs" region="OperatorMultiplyComplexNumberDouble" lang="cs" title="The following example shows how to use the multiply operator overload."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\ComplexNumberExamples.vb" region="OperatorMultiplyComplexNumberDouble" lang="vbnet" title="The following example shows how to use the multiply operator overload."/>
        /// </example>
        public static ComplexNumber operator *(ComplexNumber complexNumber, double number)
        {
            return MultiplyInternal(complexNumber, number);
        }


        /// <summary>
        /// Overload of the operator * 
        /// </summary>
        /// <param name="complexNumber">The number to be multiplied with.</param>
        /// <param name="number">The number.</param>
        /// <returns>The result of the multiplication.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\ComplexNumberExamples.cs" region="OperatorMultiplyDoubleComplexNumber" lang="cs" title="The following example shows how to use the multiply operator overload."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\ComplexNumberExamples.vb" region="OperatorMultiplyDoubleComplexNumber" lang="vbnet" title="The following example shows how to use the multiply operator overload."/>
        /// </example>
        public static ComplexNumber operator *(double number, ComplexNumber complexNumber)
        {
            return new ComplexNumber(complexNumber.real * number, complexNumber.imaginary * number);
        }


        /// <summary>
        /// Equals operator.
        /// </summary>
        /// <param name="left">The left hand side.</param>
        /// <param name="right">The right hand side.</param>
        /// <returns><c>true</c> is <paramref name="left"/> is equal to <paramref name="right"/>; otherwise <c>false</c>.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\ComplexNumberExamples.cs" region="OperatorEquals" lang="cs" title="The following example shows how to use the equals operator overload."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\ComplexNumberExamples.vb" region="OperatorEquals" lang="vbnet" title="The following example shows how to use the equals operator overload."/>
        /// </example>
        public static bool operator ==(ComplexNumber left, ComplexNumber right)
        {
            return (left.real == right.real) && (left.imaginary == right.imaginary);
        }


        /// <summary>
        /// Not Equals operator.
        /// </summary>
        /// <param name="left">The left hand side.</param>
        /// <param name="right">The right hand side.</param>
        /// <returns><c>true</c> is <paramref name="left"/> is not equal to <paramref name="right"/>; otherwise <c>false</c>.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\ComplexNumberExamples.cs" region="OperatorNotEquals" lang="cs" title="The following example shows how to use the not equals operator overload."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\ComplexNumberExamples.vb" region="OperatorNotEquals" lang="vbnet" title="The following example shows how to use the not equals operator overload."/>
        /// </example>
        public static bool operator !=(ComplexNumber left, ComplexNumber right)
        {
            return !(left == right);
        }


        /// <summary>
        /// Performs an explicit conversion from <see cref="ComplexNumber"/> to <see cref="String"/>.
        /// </summary>
        /// <param name="complexNumber">The complex number.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator string(ComplexNumber complexNumber)
        {
            return complexNumber.ToString();
        }

        /// <summary>
        /// Performs an implicit conversion from a <see cref="double"/> to <see cref="ComplexNumber"/>.
        /// </summary>
        /// <param name="real">The double number that will form the real part of the complex number.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator ComplexNumber(double real)
        {
            return new ComplexNumber(real, 0);
        }

        //public static implicit operator ComplexNumber(string representation)
        //{
        //    //"5 + 7i"
        //    //"7i"
        //    //"5"
        //    representation = representation.Trim();
        //    double real;
        //    double imaginary;
        //    if (representation.Contains("+"))
        //    {
        //        string[] strings = representation.Split('+');
        //        real = Convert.ToDouble(strings[0].Trim());
        //        string imaginaryString = strings[1].Trim();
        //        if (imaginaryString.EndsWith("i"))
        //        {
        //            imaginary = Convert.ToDouble(imaginaryString.Substring(0, imaginaryString.Length-1));
        //        }
        //        else
        //        {
        //            throw new ArgumentException("invalid format for ComplexNumber", representation);
        //        }
        //    }
        //    else
        //    {
        //        if (representation.EndsWith("i"))
        //        {
        //            real = 0;
        //            imaginary = Convert.ToDouble(representation.Substring(0, representation.Length - 1));
        //        }
        //        else
        //        {
        //            imaginary = 0;
        //            real = Convert.ToDouble(representation);
        //        }
        //    }
        //    ComplexNumber complexNumber = new ComplexNumber(real, imaginary);
        //    return complexNumber;
        //}

        #endregion

        #region IEquatable<ComplexNumber> Members

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// <c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.
        /// </returns>
        bool IEquatable<ComplexNumber>.Equals(ComplexNumber other)
        {
            return (real == other.real) && (imaginary == other.imaginary);
        }

        #endregion

        #region ICloneable Members

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public object Clone()
        {
            return new ComplexNumber(real, imaginary);
        }

        #endregion

        #region Object Members

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\ComplexNumberExamples.cs" region="ToString" lang="cs" title="The following example shows how to use the ToString method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\ComplexNumberExamples.vb" region="ToString" lang="vbnet" title="The following example shows how to use the ToString method."/>
        /// </example>
        public override string ToString()
        {
            return String.Format(CultureInfo.InvariantCulture, "{0} + {1}i", real, imaginary);
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\ComplexNumberExamples.cs" region="EqualsObject" lang="cs" title="The following example shows how to use the object.Equals overload."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\ComplexNumberExamples.vb" region="EqualsObject" lang="vbnet" title="The following example shows how to use the object.Equals overload."/>
        /// </example>
        public override bool Equals(object obj)
		{
		    if ((obj == null) || (obj.GetType() != GetType()))
            {
                return false;
            }
		    
            return this == (ComplexNumber)obj;
		}


        /// <inheritdoc />
        public override int GetHashCode()
        {
            return real.GetHashCode() ^ imaginary.GetHashCode() & real.GetHashCode();
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Internal multiplication function for multiplication between complex numbers.
        /// </summary>
        /// <param name="left">The left hand side.</param>
        /// <param name="right">The right hand side.</param>
        private static ComplexNumber MultiplyInternal(ComplexNumber left, ComplexNumber right)
        {
            // (a + bi)(c + di) = (ac - bd) + (ad + bc)i
            return new ComplexNumber(
                (left.Real * right.Real) - (left.Imaginary * right.Imaginary),
                (left.Real * right.Imaginary) + (left.Imaginary * right.Real)
            );
        }



        /// <summary>
        /// Internal multiplication function for multiplication between a complex number and a number.
        /// </summary>
        /// <param name="left">The left hand side.</param>
        /// <param name="right">The right side.</param>
        private static ComplexNumber MultiplyInternal(ComplexNumber left, double right)
        {
            return new ComplexNumber(left.Real * right, left.Imaginary * right);
        }


        /// <summary>
        /// Internal division function for dividing a complex number with a number.
        /// </summary>
        /// <param name="left">The left hand side.</param>
        /// <param name="right">The right side.</param>
        private static ComplexNumber DivideInternal(ComplexNumber left, double right)
        {
            return new ComplexNumber(left.Real / right, left.Imaginary / right);
        }


        /// <summary>
        /// Internal division function for division between complex numbers.
        /// </summary>
        /// <param name="left">The left hand side.</param>
        /// <param name="right">The right hand side.</param>
        private static ComplexNumber DivideInternal(ComplexNumber left, ComplexNumber right)
        {
            var conjugate = right.Conjugate;

            var t1 = left.Multiply(conjugate);
            var t2 = right.Multiply(conjugate);

            return new ComplexNumber(
                t1.Real / t2.Real,
                t1.Imaginary / t2.Real
            );
        }


        /// <summary>
        /// Internal addition function for the addition of complex numbers.
        /// </summary>
        /// <param name="left">The left hand side.</param>
        /// <param name="right">The right hand side.</param>
        private static ComplexNumber AddInternal(ComplexNumber left, ComplexNumber right)
        {
            return new ComplexNumber(left.Real + right.Real, left.Imaginary + right.Imaginary);
        }


        /// <summary>
        /// Internal subtraction function for the subtraction of complex numbers.
        /// </summary>
        /// <param name="left">The left hand side.</param>
        /// <param name="right">The right hand side.</param>
        private static ComplexNumber SubtractInternal(ComplexNumber left, ComplexNumber right)
        {
            return new ComplexNumber(left.Real - right.Real, left.Imaginary - right.Imaginary);
        }

        #endregion
    }
}