'  
' Copyright 2007-2009 The NGenerics Team
' (http://code.google.com/p/ngenerics/wiki/Team)
'
' This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
' have received a copy of the license along with the source code.  If not, an online copy
' of the license can be found at http://www.gnu.org/copyleft/lesser.html.
'

Imports NGenerics.DataStructures.Mathematical
Imports NUnit.Framework

Partial Public Class Vector3DExamples


#Region "OperatorDecrement"
    <Test()> _
    Public Sub OperatorDecrementExample()

        Dim vector3D As New Vector3D(4, 7, 8)
    vector3D = NGenerics.DataStructures.Mathematical.Vector3D.op_Decrement(vector3D)
        Assert.AreEqual(3, vector3D.X)
        Assert.AreEqual(6, vector3D.Y)
        Assert.AreEqual(7, vector3D.Z)

    End Sub

#End Region

#Region "OperatorDivideDouble"
    <Test()> _
    Public Sub OperatorDivideDoubleExample()

        Dim vector3D1 As New Vector3D(4, 12, 8)
        Dim vector As Vector3D = vector3D1 / 2
        Assert.AreEqual(2, vector.X)
        Assert.AreEqual(6, vector.Y)
        Assert.AreEqual(4, vector.Z)

    End Sub

#End Region

#Region "OperatorDivideVector"
    <Test()> _
    Public Sub OperatorDivideVectorExample()

        Dim vector3D1 As New Vector3D(24, 48, 72)
        Dim vector3D2 As New Vector3D(2, 3, 4)
        Dim vector As Vector3D = (vector3D1 / vector3D2)
        Assert.AreEqual(1, vector.X)
        Assert.AreEqual(2, vector.Y)
        Assert.AreEqual(3, vector.Z)

    End Sub

#End Region

#Region "OperatorEquals"
    <Test()> _
    Public Sub OperatorEqualsExample()

        Dim vector3D1 As New Vector3D(1, 2, 6)
        Dim vector3D2 As New Vector3D(1, 2, 6)
        Assert.IsTrue(vector3D1 = vector3D2)

    End Sub

#End Region

#Region "OperatorFromMatrix"
    <Test()> _
    Public Sub OperatorFromMatrixExample()

        Dim matrix As New Matrix(3, 1)
        matrix.Item(0, 0) = 7
        matrix.Item(1, 0) = 4
        matrix.Item(2, 0) = 8
        Dim actual As Vector3D = CType(matrix, Vector3D)
        Assert.AreEqual(7, actual.X)
        Assert.AreEqual(4, actual.Y)
        Assert.AreEqual(8, actual.Z)

    End Sub

#End Region

#Region "OperatorGreaterThan"
    <Test()> _
    Public Sub OperatorGreaterThanExample()

        Dim vector1 As New Vector3D(2, 2, 2)
        Dim vector2 As New Vector3D(1, 1, 1)
        Dim vector3 As New Vector3D(2, 2, 2)
        Dim vector4 As New Vector3D(3, 3, 3)
        Assert.IsTrue((vector1 > vector2))
        Assert.IsFalse((vector1 > vector3))
        Assert.IsFalse((vector1 > vector4))

    End Sub

#End Region

#Region "OperatorGreaterThanOrEqualTo"
    <Test()> _
    Public Sub OperatorGreaterThanOrEqualToExample()

        Dim vector1 As New Vector3D(2, 2, 2)
        Dim vector2 As New Vector3D(1, 1, 1)
        Dim vector3 As New Vector3D(2, 2, 2)
        Dim vector4 As New Vector3D(3, 3, 3)
        Assert.IsTrue((vector1 >= vector2))
        Assert.IsTrue((vector1 >= vector3))
        Assert.IsFalse((vector1 >= vector4))

    End Sub

#End Region

#Region "OperatorIncrement"
    <Test()> _
    Public Sub OperatorIncrementExample()
        Dim vector3D As New Vector3D(4, 7, 8)
    vector3D = NGenerics.DataStructures.Mathematical.Vector3D.op_Increment(vector3D)
        Assert.AreEqual(5, vector3D.X)
        Assert.AreEqual(8, vector3D.Y)
        Assert.AreEqual(9, vector3D.Z)
    End Sub

#End Region

#Region "OperatorLessThan"
    <Test()> _
    Public Sub OperatorLessThanExample()

        Dim vector1 As New Vector3D(2, 2, 2)
        Dim vector2 As New Vector3D(1, 1, 1)
        Dim vector3 As New Vector3D(2, 2, 2)
        Dim vector4 As New Vector3D(3, 3, 3)
        Assert.IsFalse((vector1 < vector2))
        Assert.IsFalse((vector1 < vector3))
        Assert.IsTrue((vector1 < vector4))

    End Sub

#End Region

#Region "OperatorLessThanOrEqualTo"
    <Test()> _
    Public Sub OperatorLessThanOrEqualToExample()
        Dim vector1 As New Vector3D(2, 2, 2)
        Dim vector2 As New Vector3D(1, 1, 1)
        Dim vector3 As New Vector3D(2, 2, 2)
        Dim vector4 As New Vector3D(3, 3, 3)
        Assert.IsFalse((vector1 <= vector2))
        Assert.IsTrue((vector1 <= vector3))
        Assert.IsTrue((vector1 <= vector4))
    End Sub

#End Region

#Region "OperatorMultiplyDouble"
    <Test()> _
    Public Sub OperatorMultiplyDoubleExample()

        Dim vector3D1 As New Vector3D(4, 7, 8)
        Dim vector As Vector3D = vector3D1 * 2
        Assert.AreEqual(8, vector.X)
        Assert.AreEqual(14, vector.Y)
        Assert.AreEqual(16, vector.Z)

    End Sub

#End Region

#Region "OperatorMultiplyVector"
    <Test()> _
    Public Sub OperatorMultiplyVectorExample()

        Dim vector3D1 As New Vector3D(4, 7, 2)
        Dim vector3D2 As New Vector3D(3, 4, 9)
        Dim matrix As Matrix = vector3D1 * vector3D2
        Assert.AreEqual(3, matrix.Columns)
        Assert.AreEqual(3, matrix.Rows)
        Assert.AreEqual(12, matrix.Item(0, 0))
        Assert.AreEqual(16, matrix.Item(0, 1))
        Assert.AreEqual(36, matrix.Item(0, 2))

        Assert.AreEqual(21, matrix.Item(1, 0))
        Assert.AreEqual(28, matrix.Item(1, 1))
        Assert.AreEqual(63, matrix.Item(1, 2))

        Assert.AreEqual(6, matrix.Item(2, 0))
        Assert.AreEqual(8, matrix.Item(2, 1))
        Assert.AreEqual(18, matrix.Item(2, 2))

    End Sub

#End Region

#Region "OperatorNegate"
    <Test()> _
    Public Sub OperatorNegateExample()

        Dim vector3D1 As New Vector3D
        vector3D1.X = 1
        vector3D1.Y = 2
        vector3D1.Z = 3
        Dim vector As Vector3D = Vector3D.op_UnaryNegation(vector3D1)
        Assert.AreEqual(-1, vector.X)
        Assert.AreEqual(-2, vector.Y)
        Assert.AreEqual(-3, vector.Z)

    End Sub

#End Region

#Region "OperatorNotEquals"
    <Test()> _
    Public Sub OperatorNotEqualsExample()

        Dim vector3D1 As New Vector3D(1, 2, 5)
        Dim vector3D2 As New Vector3D(1, 2, 5)
        Assert.IsFalse(Not vector3D1 = vector3D2)

    End Sub

#End Region

#Region "OperatorPlusDouble"
    <Test()> _
    Public Sub OperatorPlusDoubleExample()

        Dim vector3D1 As New Vector3D(4, 7, 8)
        Dim vector As Vector3D = (vector3D1 + 2)
        Assert.AreEqual(6, vector.X)
        Assert.AreEqual(9, vector.Y)
        Assert.AreEqual(10, vector.Z)

    End Sub

#End Region

#Region "OperatorPlusVector"
    <Test()> _
    Public Sub OperatorPlusVectorExample()

        Dim vector3D1 As New Vector3D(4, 7, 9)
        Dim vector3D2 As New Vector3D(3, 4, 1)
        Dim vector As Vector3D = (vector3D1 + vector3D2)
        Assert.AreEqual(7, vector.X)
        Assert.AreEqual(11, vector.Y)
        Assert.AreEqual(10, vector.Z)

    End Sub

#End Region

#Region "OperatorSubtractDouble"
    <Test()> _
    Public Sub OperatorSubtractDoubleExample()

        Dim vector3D As New Vector3D(4, 7, 6)
        Dim vector As Vector3D = vector3D - 2
        Assert.AreEqual(2, vector.X)
        Assert.AreEqual(5, vector.Y)
        Assert.AreEqual(4, vector.Z)

    End Sub

#End Region

#Region "OperatorSubtractVector"
    <Test()> _
    Public Sub OperatorSubtractVectorExample()
        Dim vector3D1 As New Vector3D(4, 7, 8)
        Dim vector3D2 As New Vector3D(3, 4, 2)
        Dim vector As Vector3D = (vector3D1 - vector3D2)
        Assert.AreEqual(1, vector.X)
        Assert.AreEqual(3, vector.Y)
        Assert.AreEqual(6, vector.Z)
        Assert.AreNotSame(vector3D1, vector)
        Assert.AreNotSame(vector3D2, vector)
        Assert.AreEqual(4, vector3D1.X)
        Assert.AreEqual(7, vector3D1.Y)
        Assert.AreEqual(8, vector3D1.Z)
        Assert.AreEqual(3, vector3D2.X)
        Assert.AreEqual(4, vector3D2.Y)
        Assert.AreEqual(2, vector3D2.Z)
    End Sub

#End Region

#Region "OperatorToMatrix"
    <Test()> _
    Public Sub OperatorToMatrixExample()

        Dim vector As New Vector3D(8, 3, 7)
        Dim actual As Matrix = CType(vector, Matrix)
        Assert.AreEqual(3, actual.Rows)
        Assert.AreEqual(1, actual.Columns)
        Assert.AreEqual(8, actual.Item(0, 0))
        Assert.AreEqual(3, actual.Item(1, 0))
        Assert.AreEqual(7, actual.Item(2, 0))

    End Sub

#End Region

End Class

