'  
' Copyright 2007-2009 The NGenerics Team
' (http://code.google.com/p/ngenerics/wiki/Team)
'
' This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
' have received a copy of the license along with the source code.  If not, an online copy
' of the license can be found at http://www.gnu.org/copyleft/lesser.html.
'

Imports System
Imports NGenerics.DataStructures.Mathematical
Imports NUnit.Framework

<TestFixture()> _
Public Class ComplexNumberExamples

#Region "Add"
    <Test()> _
    Public Sub AddExample()
        Dim complexNumber1 As New ComplexNumber(4, 3)
        Dim complexNumber2 As New ComplexNumber(6, 2)
        Dim result As ComplexNumber = complexNumber1.Add(complexNumber2)
        Assert.AreEqual(result.Real, 10)
        Assert.AreEqual(result.Imaginary, 5)
    End Sub
#End Region

        #Region "AbsoluteValue"
    <Test()> _
        Public Sub AbsoluteValueExample()
            Dim  complexNumber As New ComplexNumber(4, -3)

            Assert.AreEqual(complexNumber.AbsoluteValue, 5)
     End Sub
        #End Region

#Region "AdditiveIdentity"
    <Test()> _
    Public Sub AdditiveIdentityExample()
        Dim complexNumber As ComplexNumber = ComplexNumber.AdditiveIdentity
        Assert.AreEqual(complexNumber.Real, 0)
        Assert.AreEqual(complexNumber.Imaginary, 0)
    End Sub
#End Region


#Region "AdditiveInverse"
    <Test()> _
    Public Sub AdditiveInverseExample()
        Dim complexNumber1 As New ComplexNumber(4, -2)
        Dim result As ComplexNumber = complexNumber1.AdditiveInverse
        Assert.AreEqual(result.Real, -4)
        Assert.AreEqual(result.Imaginary, 2)
    End Sub
#End Region


#Region "Clone"
    <Test()> _
    Public Sub CloneExample()
        Dim complexNumber As New ComplexNumber(5, 6)
        Dim clonedComplexNumber As ComplexNumber = DirectCast(complexNumber.Clone, ComplexNumber)
        Assert.AreEqual(clonedComplexNumber.Real, 5)
        Assert.AreEqual(clonedComplexNumber.Imaginary, 6)
    End Sub
#End Region


#Region "Conjugate"
    <Test()> _
    Public Sub ConjugateExample()
        Dim complexNumber As New ComplexNumber(1, 2)
        Dim conjugateComplexNumber As ComplexNumber = complexNumber.Conjugate
        Assert.AreEqual(conjugateComplexNumber.Real, 1)
        Assert.AreEqual(conjugateComplexNumber.Imaginary, -2)
    End Sub
#End Region


#Region "Constructor"
    <Test()> _
    Public Sub ConstructorExample()
        Dim complex As New ComplexNumber(5, 10)
        Assert.AreEqual(5, complex.Real)
        Assert.AreEqual(10, complex.Imaginary)
        Dim defaultComplexNumber As New ComplexNumber
        Assert.AreEqual(0, defaultComplexNumber.Real)
        Assert.AreEqual(0, defaultComplexNumber.Imaginary)
    End Sub
#End Region


#Region "DivideComplexNumber"
    <Test()> _
    Public Sub DivideComplexNumberExample()
        Dim complexNumber1 As New ComplexNumber(-8, 4)
        Dim complexNumber2 As New ComplexNumber(3, 1)
        Dim div As ComplexNumber = complexNumber1.Divide(complexNumber2)
        Assert.AreEqual(div.Real, -2)
        Assert.AreEqual(div.Imaginary, 2)
    End Sub
#End Region


#Region "DivideDouble"
    <Test()> _
    Public Sub DivideDoubleExample()
        Dim div As ComplexNumber = New ComplexNumber(8, 4).Divide(CDbl(2))
        Assert.AreEqual(div.Real, 4)
        Assert.AreEqual(div.Imaginary, 2)
    End Sub
#End Region


#Region "Equals"
    <Test()> _
    Public Sub EqualsExample()
        Dim complexNumber1 As New ComplexNumber(1, 2)
        Dim complexNumber2 As New ComplexNumber(1, 2)
        Assert.IsTrue(complexNumber1.Equals(complexNumber1))
        Assert.IsTrue(complexNumber1.Equals(complexNumber2))
    End Sub
#End Region


#Region "EqualsObject"
    <Test()> _
    Public Sub EqualsObjectExample()
        Dim complexNumber1 As Object = New ComplexNumber(1, 2)
        Dim complexNumber2 As Object = New ComplexNumber(1, 2)
        Assert.IsTrue(complexNumber1.Equals(complexNumber1))
        Assert.IsTrue(complexNumber1.Equals(complexNumber2))
    End Sub
#End Region


#Region "Imaginary"
    <Test()> _
    Public Sub ImaginaryExample()
        Dim complex As New ComplexNumber(5, 10)
        Assert.AreEqual(complex.Imaginary, 10)
        complex.Imaginary = 15
        Assert.AreEqual(15, complex.Imaginary)
    End Sub
#End Region


#Region "Modulus"
    <Test()> _
    Public Sub ModulusExample()
        Dim complex As New ComplexNumber(0, 10)
        Assert.AreEqual(complex.Modulus, 10)
    End Sub
#End Region


#Region "MultiplicativeIdentity"
    <Test()> _
    Public Sub MultiplicativeIdentityExample()
        Dim complexNumber As ComplexNumber = _
            ComplexNumber.MultiplicativeIdentity
        Assert.AreEqual(complexNumber.Imaginary, 0)
        Assert.AreEqual(complexNumber.Real, 1)
    End Sub
#End Region


#Region "MultiplyComplexNumber"
    <Test()> _
    Public Sub MultiplyComplexNumberExample()
        Dim complexNumber1 As New ComplexNumber(1, 2)
        Dim complexNumber2 As New ComplexNumber(3, 4)
        Dim times As ComplexNumber = complexNumber1.Multiply(complexNumber2)
        Assert.AreEqual(times.Real, -5)
        Assert.AreEqual(times.Imaginary, 10)
    End Sub
#End Region


#Region "MultiplyDouble"
    <Test()> _
    Public Sub MultiplyDoubleExample()
        Dim times As ComplexNumber = New ComplexNumber(1, 2).Multiply(CDbl(2))
        Assert.AreEqual(times.Real, 2)
        Assert.AreEqual(times.Imaginary, 4)
    End Sub
#End Region


#Region "OperatorDivideComplexNumberDouble"
    <Test()> _
    Public Sub OperatorDivideComplexNumberDoubleExample()
        Dim complexNumber1 As New ComplexNumber(-8, 4)
        Dim div As ComplexNumber = DirectCast((complexNumber1 / 2), ComplexNumber)
    Assert.AreEqual(div.Real, -4)
        Assert.AreEqual(div.Imaginary, 2)
    End Sub
#End Region


#Region "OperatorDivideComplexNumberComplexNumber"
    <Test()> _
    Public Sub OperatorDivideComplexNumberExample()
        Dim complexNumber1 As New ComplexNumber(-8, 4)
        Dim complexNumber2 As New ComplexNumber(3, 1)
        Dim div As ComplexNumber = (complexNumber1 / complexNumber2)
        Assert.AreEqual(div.Real, -2)
        Assert.AreEqual(div.Imaginary, 2)
    End Sub
#End Region


#Region "OperatorEquals"
    <Test()> _
    Public Sub OperatorEqualsExample()
        Dim complexNumber1 As New ComplexNumber(-8, 4)
        Dim complexNumber2 As New ComplexNumber(-8, 4)
        Assert.IsTrue((complexNumber1 = complexNumber2))
    End Sub
#End Region


#Region "OperatorMinusComplexNumber"
    <Test()> _
    Public Sub OperatorMinusComplexNumberExample()
        Dim complexNumber1 As New ComplexNumber(4, 3)
        Dim complexNumber2 As New ComplexNumber(6, 2)
        Dim result As ComplexNumber = (complexNumber1 - complexNumber2)
        Assert.AreEqual(1, result.Imaginary)
        Assert.AreEqual(-2, result.Real)
    End Sub
#End Region


#Region "OperatorMultiplyComplexNumberComplexNumber"
  <Test()> _
  Public Sub OperatorMultiplyComplexNumberComplexNumberExample()
    Dim complexNumber1 As New ComplexNumber(-8, 4)
    Dim complexNumber2 As New ComplexNumber(3, 1)
    Dim div As ComplexNumber = (complexNumber1 * complexNumber2)
    Assert.AreEqual(div.Real, -28)
    Assert.AreEqual(div.Imaginary, 4)
  End Sub
#End Region


#Region "OperatorMultiplyComplexNumberDouble"
  <Test()> _
  Public Sub OperatorMultiplyComplexNumberDoubleExample()
    Dim complexNumber1 As New ComplexNumber(-8, 4)
    Dim div As ComplexNumber = DirectCast((complexNumber1 * 2), ComplexNumber)
    Assert.AreEqual(div.Real, -16)
    Assert.AreEqual(div.Imaginary, 8)
  End Sub
#End Region


#Region "OperatorMultiplyDoubleComplexNumber"
  <Test()> _
  Public Sub OperatorMultiplyDoubleComplexNumberExample()
    Dim complexNumber1 As New ComplexNumber(-8, 4)
    Dim div As ComplexNumber = DirectCast((2 * complexNumber1), ComplexNumber)
    Assert.AreEqual(div.Real, -16)
    Assert.AreEqual(div.Imaginary, 8)
  End Sub
#End Region


#Region "OperatorNotEquals"
  <Test()> _
  Public Sub OperatorNotEqualsExample()
    Dim complexNumber1 As New ComplexNumber(-8, 4)
    Dim complexNumber2 As New ComplexNumber(3, 7)
    Assert.IsTrue((complexNumber1 <> complexNumber2))
  End Sub
#End Region


#Region "OperatorPlus"
    <Test()> _
    Public Sub OperatorPlusExample()
        Dim complexNumber1 As New ComplexNumber(4, 3)
        Dim complexNumber2 As New ComplexNumber(6, 2)
        Dim result As ComplexNumber = (complexNumber1 + complexNumber2)
        Assert.AreEqual(result.Real, 10)
        Assert.AreEqual(result.Imaginary, 5)
    End Sub
#End Region


#Region "Real"
    <Test()> _
    Public Sub RealExample()
        Dim complexNumber As New ComplexNumber(5, 10)
        Assert.AreEqual(5, complexNumber.Real)
        complexNumber.Real = 10
        Assert.AreEqual(complexNumber.Real, 10)
    End Sub
#End Region


#Region "Reciprocal"
    <Test()> _
    Public Sub ReciprocalExample()
        Dim complexNumber As New ComplexNumber(4, 5)
        Dim result As ComplexNumber = complexNumber.Reciprocal
        Assert.AreEqual(result.Real, 0.0975609756097561)
        Assert.AreEqual(result.Imaginary, -0.12195121951219512)
    End Sub
#End Region


#Region "Subtract"
    <Test()> _
    Public Sub SubtractExample()
        Dim complexNumber1 As New ComplexNumber(4, 3)
        Dim complexNumber2 As New ComplexNumber(6, 2)
        Dim result As ComplexNumber = complexNumber1.Subtract(complexNumber2)
        Assert.AreEqual(result.Imaginary, 1)
        Assert.AreEqual(result.Real, -2)
    End Sub
#End Region


#Region "ToMatrix"
    <Test()> _
    Public Sub ToMatrixExample()
        Dim matrix As IMathematicalMatrix = New ComplexNumber(3, 4).ToMatrix
        Assert.AreEqual(matrix.Item(0, 0), 3)
        Assert.AreEqual(matrix.Item(0, 1), -4)
        Assert.AreEqual(matrix.Item(1, 0), 4)
        Assert.AreEqual(matrix.Item(1, 1), 3)
    End Sub
#End Region


#Region "ToString"
    <Test()> _
    Public Sub ToStringExample()
        Dim stringRepresentation As String = New ComplexNumber(4, -2).ToString
        Assert.AreEqual("4 + -2i", stringRepresentation)
    End Sub
#End Region


End Class


