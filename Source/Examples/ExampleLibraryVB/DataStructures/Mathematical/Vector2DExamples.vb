'  
' Copyright 2007-2010 The NGenerics Team
' (http://code.google.com/p/ngenerics/wiki/Team)
'
' This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
' have received a copy of the license along with the source code.  If not, an online copy
' of the license can be found at http://www.gnu.org/copyleft/lesser.html.
'

Imports NGenerics.DataStructures.General
Imports NGenerics.DataStructures.Mathematical
Imports NUnit.Framework

<TestFixture()> _
Partial Public Class Vector2DExamples

#Region "AbsoluteMaximum"
    <Test()> _
    Public Sub AbsoluteMaximumExample()

        Dim vector1 As New Vector2D(1, -4)
        Assert.AreEqual(4, vector1.AbsoluteMaximum)

        Dim vector2 As New Vector2D(5, -4)
        Assert.AreEqual(5, vector2.AbsoluteMaximum)

    End Sub
#End Region
#Region "AbsoluteMaximumIndex"
    <Test()> _
    Public Sub AbsoluteMaximumIndexExample()

        Dim vector1 As New Vector2D(1, -4)
        Assert.AreEqual(1, vector1.AbsoluteMaximumIndex)

        Dim vector2 As New Vector2D(5, -4)
        Assert.AreEqual(0, vector2.AbsoluteMaximumIndex)

    End Sub

#End Region
#Region "AbsoluteMinimum"
    <Test()> _
    Public Sub AbsoluteMinimumExample()

        Dim vector As New Vector2D(1, -4)
        Assert.AreEqual(1, vector.AbsoluteMinimum)

    End Sub

#End Region

#Region "AbsoluteMinimumIndex"
    <Test()> _
    Public Sub AbsoluteMinimumIndexExample()

        Dim vector1 As New Vector2D(1, -4)
        Assert.AreEqual(0, vector1.AbsoluteMinimumIndex)

        Dim vector2 As New Vector2D(-4, 1)
        Assert.AreEqual(1, vector2.AbsoluteMinimumIndex)

    End Sub

#End Region

#Region "AddDouble"
    <Test()> _
    Public Sub AddDoubleExample()

        Dim vector As New Vector2D(4, 7)
        vector.Add(1)
        Assert.AreEqual(5, vector.X)
        Assert.AreEqual(8, vector.Y)

    End Sub

#End Region

#Region "AddVector"
    <Test()> _
    Public Sub AddVectorExample()

        Dim vector1 As New Vector2D(4, 7)
        Dim vector2 As New Vector2D(3, 4)
        vector1.Add(vector2)

        Assert.AreEqual(7, vector1.X)
        Assert.AreEqual(11, vector1.Y)

    End Sub

#End Region

#Region "Clear"
    <Test()> _
    Public Sub ClearExample()

        Dim vector As New Vector2D(3, 7)
        vector.Clear()

        Assert.AreEqual(0, vector.X)
        Assert.AreEqual(0, vector.Y)

    End Sub

#End Region

#Region "Constructor"
    <Test()> _
    Public Sub ConstructorExample()

        Dim vector As New Vector2D
        Assert.AreEqual(2, vector.DimensionCount)
        Assert.AreEqual(0, vector.X)
        Assert.AreEqual(0, vector.Y)

    End Sub

#End Region

#Region "ConstructorInitValues"
    <Test()> _
    Public Sub ConstructorInitValuesExample()

        Dim vector As New Vector2D(2, 5)
        Assert.AreEqual(2, vector.DimensionCount)
        Assert.AreEqual(2, vector.X)
        Assert.AreEqual(5, vector.Y)

    End Sub

#End Region

#Region "CrossProduct2D"
    <Test()> _
    Public Sub CrossProduct2DExample()

        Dim vector1 As New Vector2D(2, 3)
        Dim vector2 As New Vector2D(4, 5)

        Dim vector As IVector(Of Double) = vector1.CrossProduct(vector2)

        Assert.AreEqual(0, vector.Item(0))
        Assert.AreEqual(0, vector.Item(1))
        Assert.AreEqual(-5, vector.Item(2))

    End Sub

#End Region

#Region "CrossProduct3D"
    <Test()> _
    Public Sub CrossProduct3DExample()

        Dim vector2D As New Vector2D(4, 5)
        Dim vector3D As New Vector3D(1, 2, 3)

        Dim vector As IVector(Of Double) = vector2D.CrossProduct(vector3D)

        Assert.AreEqual(15, vector.Item(0))
        Assert.AreEqual(-12, vector.Item(1))
        Assert.AreEqual(3, vector.Item(2))

    End Sub

#End Region

#Region "Decrement"
    <Test()> _
    Public Sub DecrementExample()

        Dim vector As New Vector2D(4, 7)
        vector.Decrement()
        Assert.AreEqual(3, vector.X)
        Assert.AreEqual(6, vector.Y)

    End Sub

#End Region

#Region "DimensionCount"
    <Test()> _
    Public Sub DimensionCountExample()

        Dim vector As New Vector2D
        Assert.AreEqual(2, vector.DimensionCount)

    End Sub

#End Region

#Region "DivideDouble"
    <Test()> _
    Public Sub DivideDoubleExample()

        Dim vector As New Vector2D(9, 3)
        vector.Divide(3)
        Assert.AreEqual(3, vector.X)
        Assert.AreEqual(1, vector.Y)

    End Sub

#End Region

#Region "DivideVector2D"
    <Test()> _
    Public Sub DivideVector2DExample()

        Dim vector1 As New Vector2D(24, 32)
        Dim vector2 As New Vector2D(2, 4)
        vector1.Divide(vector2)
        Assert.AreEqual(3, vector1.X)
        Assert.AreEqual(4, vector1.Y)

    End Sub

#End Region

#Region "DotProduct"
    <Test()> _
    Public Sub DotProductExample()

        Dim vector1 As New Vector2D(4, 7)
        Dim vector2 As New Vector2D(3, 4)
        Dim dotProduct As Double = vector1.DotProduct(vector2)
        Assert.AreEqual(40, dotProduct)

    End Sub

#End Region

#Region "GetUnitVector"
    <Test()> _
    Public Sub GetUnitVectorExample()

    Dim vector As Vector2D = Vector2D.UnitVector
        Assert.AreEqual(1, vector.X)
        Assert.AreEqual(1, vector.Y)

    End Sub

#End Region

#Region "GetZeroVector"
    <Test()> _
    Public Sub GetZeroVectorExample()

    Dim vector As Vector2D = Vector2D.ZeroVector
        Assert.AreEqual(0, vector.X)
        Assert.AreEqual(0, vector.Y)

    End Sub

#End Region

#Region "Increment"
    <Test()> _
    Public Sub IncrementExample()

        Dim vector As New Vector2D(4, 7)
        vector.Increment()
        Assert.AreEqual(5, vector.X)
        Assert.AreEqual(8, vector.Y)

    End Sub

#End Region

#Region "Index"
    <Test()> _
    Public Sub IndexExample()

        Dim vector As New Vector2D
        vector.Item(0) = 4
        vector.Item(1) = 5
        Assert.AreEqual(4, vector.Item(0))
        Assert.AreEqual(5, vector.Item(1))

    End Sub

#End Region

#Region "Magnitude"
    <Test()> _
    Public Sub MagnitudeExample()

        Dim vector As New Vector2D(2, 3)
        Assert.AreEqual(3.6055512754639891, vector.Magnitude)

    End Sub


#End Region

#Region "Maximum"
    <Test()> _
    Public Sub MaximumExample()

        Dim vector As New Vector2D(1, -4)
        Assert.AreEqual(1, vector.Maximum)

    End Sub

#End Region

#Region "MaximumIndex"
    <Test()> _
    Public Sub MaximumIndexExample()

        Dim vector1 As New Vector2D(1, -4)
        Assert.AreEqual(0, vector1.MaximumIndex)

        Dim vector2 As New Vector2D(1, 4)
        Assert.AreEqual(1, vector2.MaximumIndex)

    End Sub

#End Region

#Region "Minimum"
    <Test()> _
    Public Sub MinimumExample()

        Dim vector As New Vector2D(1, -4)
        Assert.AreEqual(-4, vector.Minimum)

    End Sub

#End Region

#Region "MinimumIndex"
    <Test()> _
    Public Sub MinimumIndexExample()

        Dim vector1 As New Vector2D(1, -4)
        Assert.AreEqual(1, vector1.MinimumIndex)

        Dim vector2 As New Vector2D(1, 4)
        Assert.AreEqual(0, vector2.MinimumIndex)

    End Sub

#End Region

#Region "MultiplyDouble"
    <Test()> _
    Public Sub MultiplyDoubleExample()

        Dim vector As New Vector2D(1, 2)
        vector.Multiply(2)
        Assert.AreEqual(2, vector.X)
        Assert.AreEqual(4, vector.Y)

    End Sub

#End Region

#Region "MultiplyVector"
    <Test()> _
    Public Sub MultiplyVectorExample()

        Dim vector1 As New Vector2D(1, 2)
        Dim vector2 As New Vector2D(3, 4)
        Dim matrix As Matrix = vector1.Multiply(vector2)
        Assert.AreEqual(2, matrix.Columns)
        Assert.AreEqual(2, matrix.Rows)
        Assert.AreEqual(3, matrix.Item(0, 0))
        Assert.AreEqual(4, matrix.Item(0, 1))
        Assert.AreEqual(6, matrix.Item(1, 0))
        Assert.AreEqual(8, matrix.Item(1, 1))

    End Sub

#End Region

#Region "NamedDimensions"
    <Test()> _
    Public Sub NamedDimensionsExample()

        Dim vector As New Vector2D
        vector.X = 1
        vector.Y = 2
        Assert.AreEqual(1, vector.X)
        Assert.AreEqual(2, vector.Y)

    End Sub

#End Region

#Region "Negate"
    <Test()> _
    Public Sub NegateExample()

        Dim vector As New Vector2D(1, 2)
        vector.Negate()
        Assert.AreEqual(-1, vector.X)
        Assert.AreEqual(-2, vector.Y)

    End Sub

#End Region

#Region "Normalize"
    <Test()> _
    Public Sub NormalizeExample()

        Dim vector As New Vector2D(23, 21)
        vector.Normalize()
        Assert.AreEqual(1, vector.Magnitude)

    End Sub

#End Region

#Region "Product"
    <Test()> _
    Public Sub ProductExample()

        Dim vector As New Vector2D(2, 3)
        Assert.AreEqual(6, vector.Product)

    End Sub

#End Region

#Region "SetValues"
    <Test()> _
    Public Sub SetValuesExample()

        Dim vector As New Vector2D
        vector.SetValues(4, 6)
        Assert.AreEqual(4, vector.X)
        Assert.AreEqual(6, vector.Y)

    End Sub

#End Region

#Region "SubtractDouble"
    <Test()> _
    Public Sub SubtractDoubleExample()

        Dim vector As New Vector2D(1, 2)
        vector.Subtract(2)
        Assert.AreEqual(-1, vector.X)
        Assert.AreEqual(0, vector.Y)

    End Sub

#End Region

#Region "SubtractVector"
    <Test()> _
    Public Sub SubtractVectorExample()

        Dim vector1 As New Vector2D(1, 2)
        Dim vector2 As New Vector2D(8, 4)
        vector1.Subtract(vector2)
        Assert.AreEqual(-7, vector1.X)
        Assert.AreEqual(-2, vector1.Y)

    End Sub

#End Region

#Region "Sum"
    <Test()> _
    Public Sub SumExample()

        Dim vector As New Vector2D(2, 3)
        Assert.AreEqual(5, vector.Sum)

    End Sub

#End Region

#Region "Swap"
    <Test()> _
    Public Sub SwapExample()

        Dim vector1 As New Vector2D(1, 2)
        Dim vector2 As New Vector2D(3, 4)
        vector1.Swap(vector2)
        Assert.AreEqual(3, vector1.X)
        Assert.AreEqual(4, vector1.Y)
        Assert.AreEqual(1, vector2.X)
        Assert.AreEqual(2, vector2.Y)

    End Sub

#End Region

#Region "ToArray"
    <Test()> _
    Public Sub ToArrayExample()

        Dim vector As New Vector2D(8, 3)
        Dim actual As Double() = vector.ToArray
        Assert.AreEqual(2, actual.Length)
        Assert.AreEqual(8, actual(0))
        Assert.AreEqual(3, actual(1))

    End Sub

#End Region

#Region "ToMatrix"
    <Test()> _
    Public Sub ToMatrixExample()

        Dim vector As New Vector2D(8, 3)
        Dim actual As IMatrix(Of Double) = vector.ToMatrix
        Assert.AreEqual(2, actual.Rows)
        Assert.AreEqual(1, actual.Columns)
        Assert.AreEqual(8, actual.Item(0, 0))
        Assert.AreEqual(3, actual.Item(1, 0))

    End Sub

#End Region

#Region "ToString"
    <Test()> _
    Public Sub ToStringExample()

        Dim vector As New Vector2D
        Dim actual As String = vector.ToString
        Assert.AreEqual("{0,0}", actual)
        vector.X = 1
        vector.Y = 2
        actual = vector.ToString
        Assert.AreEqual("{1,2}", actual)

    End Sub

#End Region

End Class

