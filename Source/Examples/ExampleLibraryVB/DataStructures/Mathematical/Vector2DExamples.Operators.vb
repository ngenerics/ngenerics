'  
' Copyright 2007-2017 The NGenerics Team
' (https://github.com/ngenerics/ngenerics/wiki/Team)
'
' This program is licensed under the MIT License.  You should 
' have received a copy of the license along with the source code.  If not, an online copy
' of the license can be found at https://opensource.org/licenses/MIT.
'

Imports NGenerics.DataStructures.Mathematical
Imports NUnit.Framework

Partial Public Class Vector2DExamples

#Region "OperatorDecrement"
    <Test()> _
    Public Sub OperatorDecrementExample()

        Dim vector2D As New Vector2D(4, 7)
    vector2D = NGenerics.DataStructures.Mathematical.Vector2D.op_Decrement(vector2D)
        Assert.AreEqual(3, vector2D.X)
        Assert.AreEqual(6, vector2D.Y)

    End Sub

#End Region

#Region "OperatorDivideDouble"
    <Test()> _
    Public Sub OperatorDivideDoubleExample()

        Dim vector2D As New Vector2D(4, 12)
        Dim vector As Vector2D = DirectCast((vector2D / 2), Vector2D)
        Assert.AreEqual(2, vector.X)
        Assert.AreEqual(6, vector.Y)

    End Sub

#End Region

#Region "OperatorDivideVector"
    <Test()> _
    Public Sub OperatorDivideVectorExample()

        Dim vector2D1 As New Vector2D(4, 8)
        Dim vector2D2 As New Vector2D(2, 2)
        Dim vector As Vector2D = (vector2D1 / vector2D2)
        Assert.AreEqual(1, vector.X)
        Assert.AreEqual(2, vector.Y)

    End Sub

#End Region

#Region "OperatorEquals"
    <Test()> _
    Public Sub OperatorEqualsExample()

        Dim vector2D1 As New Vector2D(1, 2)
        Dim vector2D2 As New Vector2D(1, 2)
        Assert.IsTrue(vector2D1 = vector2D2)

    End Sub

#End Region

#Region "OperatorFromMatrix"
    <Test()> _
    Public Sub OperatorFromMatrixExample()

        Dim matrix As New Matrix(2, 1)
        matrix.Item(0, 0) = 7
        matrix.Item(1, 0) = 4
        Dim actual As Vector2D = CType(matrix, Vector2D)
        Assert.AreEqual(7, actual.X)
        Assert.AreEqual(4, actual.Y)

    End Sub

#End Region

#Region "OperatorGreaterThan"
    <Test()> _
    Public Sub OperatorGreaterThanExample()

        Dim vector1 As New Vector2D(2, 2)
        Dim vector2 As New Vector2D(1, 1)
        Dim vector3 As New Vector2D(2, 2)
        Dim vector4 As New Vector2D(3, 3)
        Assert.IsTrue((vector1 > vector2))
        Assert.IsFalse((vector1 > vector3))
        Assert.IsFalse((vector1 > vector4))

    End Sub

#End Region

#Region "OperatorGreaterThanOrEqualTo"
    <Test()> _
    Public Sub OperatorGreaterThanOrEqualToExample()

        Dim vector1 As New Vector2D(2, 2)
        Dim vector2 As New Vector2D(1, 1)
        Dim vector3 As New Vector2D(2, 2)
        Dim vector4 As New Vector2D(3, 3)
        Assert.IsTrue((vector1 >= vector2))
        Assert.IsTrue((vector1 >= vector3))
        Assert.IsFalse((vector1 >= vector4))

    End Sub

#End Region

#Region "OperatorIncrement"
    <Test()> _
    Public Sub OperatorIncrementExample()

        Dim vector2D As New Vector2D(4, 7)
    vector2D = NGenerics.DataStructures.Mathematical.Vector2D.op_Increment(vector2D)
        Assert.AreEqual(5, vector2D.X)
        Assert.AreEqual(8, vector2D.Y)

    End Sub

#End Region

#Region "OperatorLessThan"
    <Test()> _
    Public Sub OperatorLessThanExample()

        Dim vector1 As New Vector2D(2, 2)
        Dim vector2 As New Vector2D(1, 1)
        Dim vector3 As New Vector2D(2, 2)
        Dim vector4 As New Vector2D(3, 3)
        Assert.IsFalse((vector1 < vector2))
        Assert.IsFalse((vector1 < vector3))
        Assert.IsTrue((vector1 < vector4))

    End Sub

#End Region

#Region "OperatorLessThanOrEqualTo"
    <Test()> _
    Public Sub OperatorLessThanOrEqualToExample()

        Dim vector1 As New Vector2D(2, 2)
        Dim vector2 As New Vector2D(1, 1)
        Dim vector3 As New Vector2D(2, 2)
        Dim vector4 As New Vector2D(3, 3)
        Assert.IsFalse((vector1 <= vector2))
        Assert.IsTrue((vector1 <= vector3))
        Assert.IsTrue((vector1 <= vector4))

    End Sub

#End Region

#Region "OperatorMultiplyDouble"
    <Test()> _
    Public Sub OperatorMultiplyDoubleExample()

        Dim vector2D As New Vector2D(4, 7)
        Dim vector As Vector2D = vector2D * 2
        Assert.AreEqual(8, vector.X)
        Assert.AreEqual(14, vector.Y)
        Assert.AreEqual(4, vector2D.X)
        Assert.AreEqual(7, vector2D.Y)
        Assert.AreNotSame(vector2D, vector)

    End Sub

#End Region

#Region "OperatorMultiplyVector"
    <Test()> _
    Public Sub OperatorMultiplyVectorExample()

        Dim vector2D1 As New Vector2D(4, 7)
        Dim vector2D2 As New Vector2D(3, 4)
        Dim matrix As Matrix = vector2D1 * vector2D2
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

        Dim vector2D As New Vector2D(1, 2)
        Dim vector As Vector2D = -vector2D
        Assert.AreEqual(-1, vector.X)
        Assert.AreEqual(-2, vector.Y)

    End Sub

#End Region

#Region "OperatorNotEquals"
    <Test()> _
    Public Sub OperatorNotEqualsExample()

        Dim vector2D1 As New Vector2D(1, 2)
        Dim vector2D2 As New Vector2D(1, 2)
        Assert.IsFalse((Not vector2D1 = vector2D2))

    End Sub

#End Region

#Region "OperatorPlusDouble"
    <Test()> _
    Public Sub OperatorPlusDoubleExample()

        Dim vector2D As New Vector2D(4, 7)
        Dim vector As Vector2D = (vector2D + 2)
        Assert.AreEqual(6, vector.X)
        Assert.AreEqual(9, vector.Y)

    End Sub

#End Region

#Region "OperatorPlusVector"
    <Test()> _
    Public Sub OperatorPlusVectorExample()

        Dim vector2D1 As New Vector2D(4, 7)
        Dim vector2D2 As New Vector2D(3, 4)
        Dim vector As Vector2D = (vector2D1 + vector2D2)
        Assert.AreEqual(7, vector.X)
        Assert.AreEqual(11, vector.Y)

    End Sub

#End Region

#Region "OperatorSubtractDouble"
    <Test()> _
    Public Sub OperatorSubtractDoubleExample()

        Dim vector2D As New Vector2D(4, 7)
        Dim vector As Vector2D = (vector2D - 2)
        Assert.AreEqual(2, vector.X)
        Assert.AreEqual(5, vector.Y)

    End Sub

#End Region

#Region "OperatorSubtractVector"
    <Test()> _
    Public Sub OperatorSubtractVectorExample()

        Dim vector2D1 As New Vector2D(4, 7)
        Dim vector2D2 As New Vector2D(3, 4)
        Dim vector As Vector2D = (vector2D1 - vector2D2)
        Assert.AreEqual(1, vector.X)
        Assert.AreEqual(3, vector.Y)

    End Sub

#End Region

#Region "OperatorToMatrix"
    <Test()> _
    Public Sub OperatorToMatrixExample()

        Dim vector As New Vector2D(8, 3)
        Dim actual As Matrix = CType(vector, Matrix)
        Assert.AreEqual(2, actual.Rows)
        Assert.AreEqual(1, actual.Columns)
        Assert.AreEqual(8, actual.Item(0, 0))
        Assert.AreEqual(3, actual.Item(1, 0))

    End Sub

#End Region

End Class

