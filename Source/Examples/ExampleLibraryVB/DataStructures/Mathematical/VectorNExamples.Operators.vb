'  
' Copyright 2007-2013 The NGenerics Team
' (https://github.com/ngenerics/ngenerics/wiki/Team)
'
' This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
' have received a copy of the license along with the source code.  If not, an online copy
' of the license can be found at http://www.gnu.org/copyleft/lesser.html.
'

Imports NGenerics.DataStructures.General
Imports NGenerics.DataStructures.Mathematical
Imports NUnit.Framework

Partial Public Class VectorNExamples

#Region "OperatorDecrement"
    <Test()> _
    Public Sub OperatorDecrementExample()

        Dim vector1 As VectorBase(Of Double) = New VectorN(2)
        vector1.SetValues(4, 7)
        vector1 = VectorBase(Of Double).op_Decrement(vector1)
        Assert.AreEqual(3, vector1.Item(0))
        Assert.AreEqual(6, vector1.Item(1))

    End Sub

#End Region

#Region "OperatorDivideDouble"
    <Test()> _
    Public Sub OperatorDivideDoubleExample()

        Dim vector1 As New VectorN(2)
        vector1.SetValues(4, 12)
        Dim vector As IVector(Of Double) = DirectCast((vector1 / 2), IVector(Of Double))
        Assert.AreEqual(2, vector.Item(0))
        Assert.AreEqual(6, vector.Item(1))

    End Sub

#End Region

#Region "OperatorDivideVector"
    <Test()> _
    Public Sub OperatorDivideVectorExample()

        Dim vector1 As New VectorN(2)
        vector1.SetValues(4, 8)
        Dim vector2 As New VectorN(2)
        vector2.SetValues(2, 2)
        Dim vector As IVector(Of Double) = (vector1 / vector2)
        Assert.AreEqual(2, vector.Item(0))
        Assert.AreEqual(4, vector.Item(1))
    End Sub

#End Region

#Region "OperatorEquals"
    <Test()> _
    Public Sub OperatorEqualsExample()

        Dim vector1 As New VectorN(2)
        vector1.Item(0) = 1
        vector1.Item(1) = 2
        Dim vector2 As New VectorN(2)
        vector2.Item(0) = 1
        vector2.Item(1) = 2
        Assert.IsTrue(vector1 = vector2)

    End Sub

#End Region

#Region "OperatorFromMatrix"
    <Test()> _
    Public Sub OperatorFromMatrixExample()

        Dim matrix As New Matrix(3, 1)
        matrix.Item(0, 0) = 7
        matrix.Item(1, 0) = 4
        matrix.Item(2, 0) = 8
        Dim actual As VectorN = CType(matrix, VectorN)
        Assert.AreEqual(7, actual(0))
        Assert.AreEqual(4, actual(1))
        Assert.AreEqual(8, actual(2))

    End Sub

#End Region

#Region "OperatorGreaterThan"
    <Test()> _
    Public Sub OperatorGreaterThanExample()

        Dim vector1 As New VectorN(2)
        vector1.SetValues(2, 2)
        Dim vector2 As New VectorN(2)
        vector2.SetValues(1, 1)
        Dim vector3 As New VectorN(2)
        vector3.SetValues(2, 2)
        Dim vector4 As New VectorN(2)
        vector4.SetValues(3, 3)
        Assert.IsTrue((vector1 > vector2))
        Assert.IsFalse((vector1 > vector3))
        Assert.IsFalse((vector1 > vector4))

    End Sub

#End Region

#Region "OperatorGreaterThanOrEqualTo"
    <Test()> _
    Public Sub OperatorGreaterThanOrEqualToExample()

        Dim vector1 As New VectorN(2)
        vector1.SetValues(2, 2)
        Dim vector2 As New VectorN(2)
        vector2.SetValues(1, 1)
        Dim vector3 As New VectorN(2)
        vector3.SetValues(2, 2)
        Dim vector4 As New VectorN(2)
        vector4.SetValues(3, 3)
        Assert.IsTrue((vector1 >= vector2))
        Assert.IsTrue((vector1 >= vector3))
        Assert.IsFalse((vector1 >= vector4))

    End Sub

#End Region

#Region "OperatorIncrement"
    <Test()> _
    Public Sub OperatorIncrementExample()

        Dim vector1 As VectorBase(Of Double) = New VectorN(2)
        vector1.SetValues(4, 7)
        vector1 = VectorBase(Of Double).op_Increment(vector1)
        Assert.AreEqual(5, vector1.Item(0))
        Assert.AreEqual(8, vector1.Item(1))

    End Sub

#End Region

#Region "OperatorLessThan"
    <Test()> _
    Public Sub OperatorLessThanExample()

        Dim vector1 As New VectorN(2)
        vector1.SetValues(2, 2)
        Dim vector2 As New VectorN(2)
        vector2.SetValues(1, 1)
        Dim vector3 As New VectorN(2)
        vector3.SetValues(2, 2)
        Dim vector4 As New VectorN(2)
        vector4.SetValues(3, 3)
        Assert.IsFalse((vector1 < vector2))
        Assert.IsFalse((vector1 < vector3))
        Assert.IsTrue((vector1 < vector4))

    End Sub

#End Region

#Region "OperatorLessThanOrEqualTo"
    <Test()> _
    Public Sub OperatorLessThanOrEqualToExample()

        Dim vector1 As New VectorN(2)
        vector1.SetValues(2, 2)
        Dim vector2 As New VectorN(2)
        vector2.SetValues(1, 1)
        Dim vector3 As New VectorN(2)
        vector3.SetValues(2, 2)
        Dim vector4 As New VectorN(2)
        vector4.SetValues(3, 3)
        Assert.IsFalse((vector1 <= vector2))
        Assert.IsTrue((vector1 <= vector3))
        Assert.IsTrue((vector1 <= vector4))

    End Sub

#End Region

#Region "OperatorMultiplyDouble"
    <Test()> _
    Public Sub OperatorMultiplyDoubleExample()

        Dim vector1 As New VectorN(2)
        vector1.SetValues(4, 7)
        Dim vector As VectorBase(Of Double) = DirectCast((vector1 * 2), VectorBase(Of Double))
        Assert.AreEqual(8, vector.Item(0))
        Assert.AreEqual(14, vector.Item(1))

    End Sub

#End Region

#Region "OperatorMultiplyVector"
    <Test()> _
    Public Sub OperatorMultiplyVectorExample()

        Dim vector1 As New VectorN(2)
        vector1.SetValues(4, 7)
        Dim vector2 As New VectorN(2)
        vector2.SetValues(3, 4)

        Dim matrix As IMatrix(Of Double) = (vector1 * vector2)

        Assert.AreEqual(2, matrix.Columns)
        Assert.AreEqual(2, matrix.Rows)

        Assert.AreEqual(12, matrix.Item(0, 0))
        Assert.AreEqual(16, matrix.Item(0, 1))
        Assert.AreEqual(21, matrix.Item(1, 0))
        Assert.AreEqual(28, matrix.Item(1, 1))

    End Sub

#End Region

#Region "OperatorNegate"
    <Test()> _
    Public Sub OperatorNegateExample()

        Dim vector1 As New VectorN(2)
        vector1.Item(0) = 1
        vector1.Item(1) = 2
        Dim vector As IVector(Of Double) = VectorBase(Of Double).op_UnaryNegation(vector1)
        Assert.AreEqual(-1, vector.Item(0))
        Assert.AreEqual(-2, vector.Item(1))

    End Sub

#End Region

#Region "OperatorNotEquals"
    <Test()> _
    Public Sub OperatorNotEqualsExample()

        Dim vector1 As New VectorN(2)
        vector1.Item(0) = 1
        vector1.Item(1) = 2
        Dim vector2 As New VectorN(2)
        vector2.Item(0) = 1
        vector2.Item(1) = 2
        Assert.IsFalse(Not vector1 = vector2)

    End Sub

#End Region

#Region "OperatorPlusDouble"
    <Test()> _
    Public Sub OperatorPlusDoubleExample()

        Dim vector1 As New VectorN(2)
        vector1.SetValues(4, 7)
        Dim vector As IVector(Of Double) = DirectCast((vector1 + 2), IVector(Of Double))
        Assert.AreEqual(6, vector.Item(0))
        Assert.AreEqual(9, vector.Item(1))

    End Sub

#End Region

#Region "OperatorPlusVector"
    <Test()> _
    Public Sub OperatorPlusVectorExample()

        Dim vector1 As New VectorN(2)
        vector1.SetValues(4, 7)
        Dim vector2 As New VectorN(2)
        vector2.SetValues(3, 4)
        Dim vector As IVector(Of Double) = (vector1 + vector2)
        Assert.AreEqual(7, vector.Item(0))
        Assert.AreEqual(11, vector.Item(1))

    End Sub

#End Region

#Region "OperatorSubtractDouble"
    <Test()> _
    Public Sub OperatorSubtractDoubleExample()

        Dim vector1 As New VectorN(2)
        vector1.SetValues(4, 7)
        Dim vector As IVector(Of Double) = DirectCast((vector1 - 2), IVector(Of Double))
        Assert.AreEqual(2, vector.Item(0))
        Assert.AreEqual(5, vector.Item(1))

    End Sub

#End Region

#Region "OperatorSubtractVector"
    <Test()> _
    Public Sub OperatorSubtractVectorExample()

        Dim vector1 As New VectorN(2)
        vector1.SetValues(4, 7)
        Dim vector2 As New VectorN(2)
        vector2.SetValues(3, 4)
        Dim vector As IVector(Of Double) = (vector1 - vector2)
        Assert.AreEqual(1, vector.Item(0))
        Assert.AreEqual(3, vector.Item(1))

    End Sub

#End Region

#Region "OperatorToMatrix"
    <Test()> _
    Public Sub OperatorToMatrixExample()

        Dim vector As New VectorN(2)
        vector.SetValues(8, 3)
        Dim actual As Matrix = CType(vector, Matrix)
        Assert.AreEqual(2, actual.Rows)
        Assert.AreEqual(1, actual.Columns)
        Assert.AreEqual(8, actual.Item(0, 0))
        Assert.AreEqual(3, actual.Item(1, 0))

    End Sub

#End Region

End Class