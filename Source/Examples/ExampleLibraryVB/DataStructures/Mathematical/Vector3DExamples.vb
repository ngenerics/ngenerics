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
Imports NGenerics.Patterns.Visitor

<TestFixture()> _
Partial Public Class Vector3DExamples


#Region "AbsoluteMaximum"
  <Test()> _
  Public Sub AbsoluteMaximumExample()

    Dim vector As New Vector3D(1, -4, 3)
    Assert.AreEqual(4, vector.AbsoluteMaximum)

  End Sub

#End Region

#Region "AbsoluteMaximumIndex"
  <Test()> _
  Public Sub AbsoluteMaximumIndexExample()

    Dim vector1 As New Vector3D(1, -4, 3)
    Assert.AreEqual(1, vector1.AbsoluteMaximumIndex)

    Dim vector2 As New Vector3D(1, -4, 5)
    Assert.AreEqual(2, vector2.AbsoluteMaximumIndex)

    Dim vector3 As New Vector3D(7, -4, 3)
    Assert.AreEqual(0, vector3.AbsoluteMaximumIndex)

    Dim vector4 As New Vector3D(7, -4, 8)
    Assert.AreEqual(2, vector4.AbsoluteMaximumIndex)

  End Sub

#End Region

#Region "AbsoluteMinimum"
  <Test()> _
  Public Sub AbsoluteMinimumExample()

    Dim vector As New Vector3D(1, -4, 3)
    Assert.AreEqual(1, vector.AbsoluteMinimum)

  End Sub

#End Region

#Region "AbsoluteMinimumIndex"
  <Test()> _
  Public Sub AbsoluteMinimumIndexExample()
    Dim vector1 As New Vector3D(1, -4, 3)
    Assert.AreEqual(0, vector1.AbsoluteMinimumIndex)

    Dim vector2 As New Vector3D(7, -4, 3)
    Assert.AreEqual(2, vector2.AbsoluteMinimumIndex)

    Dim vector3 As New Vector3D(7, -4, 8)
    Assert.AreEqual(1, vector3.AbsoluteMinimumIndex)

    Dim vector4 As New Vector3D(-8, 9, -7)
    Assert.AreEqual(2, vector4.AbsoluteMinimumIndex)

  End Sub

#End Region


#Region "AddDouble"
  <Test()> _
  Public Sub AddDoubleExample()

    Dim vector As New Vector3D(4, 7, 3)
    vector.Add(1)
    Assert.AreEqual(5, vector.X)
    Assert.AreEqual(8, vector.Y)
    Assert.AreEqual(4, vector.Z)

  End Sub

#End Region

#Region "AddVector"
  <Test()> _
  Public Sub AddVectorExample()

    Dim vector1 As New Vector3D(4, 7, -1)
    Dim vector2 As New Vector3D(3, 4, 2)
    vector1.Add(vector2)
    Assert.AreEqual(7, vector1.X)
    Assert.AreEqual(11, vector1.Y)
    Assert.AreEqual(1, vector1.Z)

  End Sub

#End Region

#Region "Clear"
  <Test()> _
  Public Sub ClearExample()

    Dim vector As New Vector3D(3, 7, 8)
    vector.Clear()
    Assert.AreEqual(0, vector.X)
    Assert.AreEqual(0, vector.Y)
    Assert.AreEqual(0, vector.Z)

  End Sub

#End Region

#Region "Clone"
  <Test()> _
  Public Sub CloneExample()

    Dim vector As New Vector3D(3, 7, 9)
    Dim clone As Vector3D = DirectCast(vector.Clone, Vector3D)
    Assert.AreEqual(3, clone.X)
    Assert.AreEqual(7, clone.Y)
    Assert.AreEqual(9, clone.Z)

  End Sub

#End Region

#Region "Constructor"
  <Test()> _
  Public Sub ConstructorExample()

    Dim vector As New Vector3D
    Assert.AreEqual(0, vector.X)
    Assert.AreEqual(0, vector.Y)
    Assert.AreEqual(0, vector.Z)

  End Sub

#End Region

#Region "ConstructorInitValues"
  <Test()> _
  Public Sub ConstructorInitValuesExample()

    Dim vector As New Vector3D(2, 7, 4)
    Assert.AreEqual(2, vector.X)
    Assert.AreEqual(7, vector.Y)
    Assert.AreEqual(4, vector.Z)

  End Sub

#End Region

#Region "CrossProduct2D"
  <Test()> _
  Public Sub CrossProduct2DExample()

    Dim vector3D As New Vector3D(1, 2, 3)
    Dim vector2D As New Vector2D(4, 5)
    Dim vector As Vector3D = vector3D.CrossProduct(vector2D)
    Assert.AreEqual(-15, vector.X)
    Assert.AreEqual(12, vector.Y)
    Assert.AreEqual(-3, vector.Z)

  End Sub

#End Region

#Region "CrossProduct3D"
  <Test()> _
  Public Sub CrossProduct3DExample()

    Dim vector1 As New Vector3D(1, 2, 3)
    Dim vector2 As New Vector3D(4, 5, 6)
    Dim vector As Vector3D = vector1.CrossProduct(vector2)
    Assert.AreEqual(-3, vector.X)
    Assert.AreEqual(6, vector.Y)
    Assert.AreEqual(-3, vector.Z)

  End Sub

#End Region

#Region "Decrement"
  <Test()> _
  Public Sub DecrementExample()

    Dim vector As New Vector3D(4, 7, 9)
    vector.Decrement()
    Assert.AreEqual(3, vector.X)
    Assert.AreEqual(6, vector.Y)
    Assert.AreEqual(8, vector.Z)

  End Sub

#End Region

#Region "DimensionCount"
  <Test()> _
  Public Sub DimensionCountExample()

    Dim vector3D As New Vector3D
    Assert.AreEqual(3, vector3D.DimensionCount)

  End Sub

#End Region

#Region "DivideDouble"
  <Test()> _
  Public Sub DivideDoubleExample()

    Dim vector As New Vector3D(9, 3, 18)
    vector.Divide(3)
    Assert.AreEqual(3, vector.X)
    Assert.AreEqual(1, vector.Y)
    Assert.AreEqual(6, vector.Z)

  End Sub

#End Region

#Region "DivideVector"
  <Test()> _
  Public Sub DivideVectorExample()

    Dim vector1 As New Vector3D(24, 48, 72)
    Dim vector2 As New Vector3D(2, 3, 4)
    vector1.Divide(vector2)
    Assert.AreEqual(1, vector1.X)
    Assert.AreEqual(2, vector1.Y)
    Assert.AreEqual(3, vector1.Z)

  End Sub

#End Region

#Region "DotProduct"
  <Test()> _
  Public Sub DotProductExample()

    Dim vector1 As New Vector3D(4, 7, 4)
    Dim vector2 As New Vector3D(3, 4, 8)
    Dim dotProduct As Double = vector1.DotProduct(vector2)
    Assert.AreEqual(72, dotProduct)

  End Sub

#End Region

#Region "GetHashCode"
  <Test()> _
  Public Sub GetHashCodeExample()

    Dim vector As New Vector3D(1, 2, 3)
    Assert.AreNotEqual(0, vector.GetHashCode)

  End Sub

#End Region

#Region "GetUnitVector"
  <Test()> _
  Public Sub GetUnitVectorExample()

    Dim vector As Vector3D = Vector3D.UnitVector
    Assert.AreEqual(1, vector.X)
    Assert.AreEqual(1, vector.Y)
    Assert.AreEqual(1, vector.Z)

  End Sub

#End Region

#Region "GetZeroVector"
  <Test()> _
  Public Sub GetZeroVectorExample()

    Dim vector As Vector3D = Vector3D.ZeroVector
    Assert.AreEqual(0, vector.X)
    Assert.AreEqual(0, vector.Y)
    Assert.AreEqual(0, vector.Z)

  End Sub

#End Region

#Region "Increment"
  <Test()> _
  Public Sub IncrementExample()

    Dim vector As New Vector3D(4, 7, 9)
    vector.Increment()
    Assert.AreEqual(5, vector.X)
    Assert.AreEqual(8, vector.Y)
    Assert.AreEqual(10, vector.Z)

  End Sub

#End Region

#Region "Index"
  <Test()> _
  Public Sub IndexExample()

    Dim vector As New Vector3D
    vector.Item(0) = 4
    vector.Item(1) = 5
    vector.Item(2) = -2
    Assert.AreEqual(4, vector.X)
    Assert.AreEqual(5, vector.Y)
    Assert.AreEqual(-2, vector.Z)
    Assert.AreEqual(4, vector.Item(0))
    Assert.AreEqual(5, vector.Item(1))
    Assert.AreEqual(-2, vector.Item(2))

  End Sub

#End Region

#Region "Magnitude"
  <Test()> _
  Public Sub MagnitudeExample()

    Dim vector3D As New Vector3D(4, 3, 12)
    Assert.AreEqual(13, vector3D.Magnitude)

  End Sub

#End Region

#Region "Maximum"
  <Test()> _
  Public Sub MaximumExample()

    Dim vector As New Vector3D(1, -4, 3)
    Assert.AreEqual(3, vector.Maximum)
    Assert.AreEqual(1, vector.X)
    Assert.AreEqual(-4, vector.Y)
    Assert.AreEqual(3, vector.Z)

  End Sub

#End Region

#Region "MaximumIndex"
  <Test()> _
  Public Sub MaximumIndexExample()

    Dim vector1 As New Vector3D(1, -4, 3)
    Assert.AreEqual(2, vector1.MaximumIndex)

    Dim vector2 As New Vector3D(4, -4, 3)
    Assert.AreEqual(0, vector2.MaximumIndex)

    Dim vector3 As New Vector3D(1, 4, 3)
    Assert.AreEqual(1, vector3.MaximumIndex)

    Dim vector4 As New Vector3D(3, 4, 9)
    Assert.AreEqual(2, vector4.MaximumIndex)

  End Sub

#End Region

#Region "Minimum"
  <Test()> _
  Public Sub MinimumExample()

    Dim vector As New Vector3D(1, -4, 3)
    Assert.AreEqual(-4, vector.Minimum)

  End Sub

#End Region

#Region "MinimumIndex"
  <Test()> _
  Public Sub MinimumIndexExample()

    Dim vector1 As New Vector3D(1, -4, 3)
    Assert.AreEqual(1, vector1.MinimumIndex)

    Dim vector2 As New Vector3D(1, 4, 3)
    Assert.AreEqual(0, vector2.MinimumIndex)

    Dim vector3 As New Vector3D(1, 4, -3)
    Assert.AreEqual(2, vector3.MinimumIndex)

    Dim vector4 As New Vector3D(6, 4, -3)
    Assert.AreEqual(2, vector4.MinimumIndex)

  End Sub

#End Region

#Region "MultiplyDouble"
  <Test()> _
  Public Sub MultiplyDoubleExample()

    Dim vector As New Vector3D(1, 2, 9)
    vector.Multiply(2)
    Assert.AreEqual(2, vector.X)
    Assert.AreEqual(4, vector.Y)
    Assert.AreEqual(18, vector.Z)

  End Sub

#End Region

#Region "MultiplyVector"
  <Test()> _
  Public Sub MultiplyVectorExample()

    Dim vector1 As New Vector3D(1, 2, 8)
    Dim vector2 As New Vector3D(3, 4, 2)
    Dim matrix As Matrix = vector1.Multiply(vector2)
    Assert.AreEqual(3, matrix.Columns)
    Assert.AreEqual(3, matrix.Rows)
    Assert.AreEqual(3, matrix.Item(0, 0))
    Assert.AreEqual(4, matrix.Item(0, 1))
    Assert.AreEqual(2, matrix.Item(0, 2))
    Assert.AreEqual(6, matrix.Item(1, 0))
    Assert.AreEqual(8, matrix.Item(1, 1))
    Assert.AreEqual(4, matrix.Item(1, 2))
    Assert.AreEqual(24, matrix.Item(2, 0))
    Assert.AreEqual(32, matrix.Item(2, 1))
    Assert.AreEqual(16, matrix.Item(2, 2))
  End Sub

#End Region

#Region "NamedDimensions"
  <Test()> _
  Public Sub NamedDimensionsExample()

    Dim vector As New Vector3D
    vector.X = 1
    vector.Y = 2
    vector.Z = 3
    Assert.AreEqual(1, vector.X)
    Assert.AreEqual(2, vector.Y)
    Assert.AreEqual(3, vector.Z)

  End Sub

#End Region

#Region "Negate"
  <Test()> _
  Public Sub NegateExample()

    Dim vector As New Vector3D(1, 2, -5)
    vector.Negate()
    Assert.AreEqual(-1, vector.X)
    Assert.AreEqual(-2, vector.Y)
    Assert.AreEqual(5, vector.Z)

  End Sub

#End Region

#Region "Normalize"
  <Test()> _
  Public Sub NormalizeExample()

    Dim vector As New Vector3D(23, -21, 4)
    vector.Normalize()
    Assert.AreEqual(1, vector.Magnitude)

  End Sub

#End Region


#Region "Product"
  <Test()> _
  Public Sub ProductExample()

    Dim vector3D As New Vector3D(2, 3, 5)
    Assert.AreEqual(30, vector3D.Product)

  End Sub

#End Region

#Region "SetValues"
  <Test()> _
  Public Sub SetValuesExample()

    Dim vector As New Vector3D
    vector.SetValues(4, 6, 8)
    Assert.AreEqual(4, vector.X)
    Assert.AreEqual(6, vector.Y)
    Assert.AreEqual(8, vector.Z)

  End Sub

#End Region

#Region "SubtractDouble"
  <Test()> _
  Public Sub SubtractDoubleExample()

    Dim vector As New Vector3D(1, 2, -2)
    vector.Subtract(2)
    Assert.AreEqual(-1, vector.X)
    Assert.AreEqual(0, vector.Y)
    Assert.AreEqual(-4, vector.Z)

  End Sub

#End Region

#Region "SubtractVector"
  <Test()> _
  Public Sub SubtractVectorExample()

    Dim vector1 As New Vector3D(1, 2, 9)
    Dim vector2 As New Vector3D(8, 4, 2)
    vector1.Subtract(vector2)
    Assert.AreEqual(-7, vector1.X)
    Assert.AreEqual(-2, vector1.Y)
    Assert.AreEqual(7, vector1.Z)

  End Sub

#End Region

#Region "Sum"
  <Test()> _
  Public Sub SumExample()

    Dim vector As New Vector3D(2, 3, 5)
    Assert.AreEqual(10, vector.Sum)

  End Sub

#End Region

#Region "Swap"
  <Test()> _
  Public Sub SwapExample()

    Dim vector1 As New Vector3D(1, 2, 3)
    Dim vector2 As New Vector3D(3, 4, 6)
    vector1.Swap(vector2)
    Assert.AreEqual(3, vector1.X)
    Assert.AreEqual(4, vector1.Y)
    Assert.AreEqual(6, vector1.Z)
    Assert.AreEqual(1, vector2.X)
    Assert.AreEqual(2, vector2.Y)
    Assert.AreEqual(3, vector2.Z)

  End Sub

#End Region

#Region "ToArray"
  <Test()> _
  Public Sub ToArrayExample()

    Dim actual As Double() = New Vector3D(8, 3, 6).ToArray
    Assert.AreEqual(3, actual.Length)
    Assert.AreEqual(8, actual(0))
    Assert.AreEqual(3, actual(1))
    Assert.AreEqual(6, actual(2))

  End Sub

#End Region

#Region "ToMatrix"
  <Test()> _
  Public Sub ToMatrixExample()

    Dim actual As IMatrix(Of Double) = New Vector3D(8, 3, 7).ToMatrix
    Assert.AreEqual(3, actual.Rows)
    Assert.AreEqual(1, actual.Columns)
    Assert.AreEqual(8, actual.Item(0, 0))
    Assert.AreEqual(3, actual.Item(1, 0))
    Assert.AreEqual(7, actual.Item(2, 0))

  End Sub

#End Region

#Region "ToString"
  <Test()> _
  Public Sub ToStringExample()

    Dim vector As New Vector3D
    Dim actual As String = vector.ToString
    Assert.AreEqual("{0,0,0}", actual)
    vector.X = 1
    vector.Y = 2
    vector.Z = 7
    actual = vector.ToString
    Assert.AreEqual("{1,2,7}", actual)

  End Sub

#End Region

End Class

