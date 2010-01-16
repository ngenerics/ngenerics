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
Imports NGenerics.Patterns.Visitor

<TestFixture()> _
Partial Public Class VectorNExamples


#Region "AbsoluteMaximum"
  <Test()> _
  Public Sub AbsoluteMaximumExample()
    Dim vector1 As New VectorN(4)
    vector1.Item(0) = 1
    vector1.Item(1) = -4
    vector1.Item(2) = 3
    vector1.Item(3) = 2
    Assert.AreEqual(4, vector1.AbsoluteMaximum)
  End Sub

#End Region

#Region "AbsoluteMaximumIndex"
  <Test()> _
  Public Sub AbsoluteMaximumIndexExample()
    Dim vector1 As New VectorN(4)
    vector1.Item(0) = 1
    vector1.Item(1) = -4
    vector1.Item(2) = 3
    vector1.Item(3) = 2
    Assert.AreEqual(1, vector1.AbsoluteMaximumIndex)
  End Sub

#End Region

#Region "AbsoluteMinimum"
  <Test()> _
  Public Sub AbsoluteMinimumExample()

    Dim vector1 As New VectorN(4)
    vector1.Item(0) = 1
    vector1.Item(1) = -4
    vector1.Item(2) = 3
    vector1.Item(3) = 2
    Assert.AreEqual(1, vector1.AbsoluteMinimum)

  End Sub

#End Region

#Region "AbsoluteMinimumIndex"
  <Test()> _
  Public Sub AbsoluteMinimumIndexExample()

    Dim vector1 As New VectorN(5)
    vector1.Item(0) = 7
    vector1.Item(1) = -4
    vector1.Item(2) = 3
    vector1.Item(3) = 5
    vector1.Item(4) = 1
    Assert.AreEqual(4, vector1.AbsoluteMinimumIndex)

  End Sub

#End Region

#Region "Accept"
  <Test()> _
  Public Sub AcceptExample()

    Dim visitor As New CountingVisitor(Of Double)
    Dim vector1 As New VectorN(2)
        vector1.AcceptVisitor(visitor)
    Assert.AreEqual(2, visitor.Count)

  End Sub

#End Region

#Region "AddDouble"
  <Test()> _
  Public Sub AddDoubleExample()

    Dim vector1 As New VectorN(2)
    vector1.SetValues(4, 7)
    vector1.Add(1)
    Assert.AreEqual(5, vector1.Item(0))
    Assert.AreEqual(8, vector1.Item(1))

  End Sub

#End Region

#Region "AddVector"
  <Test()> _
  Public Sub AddVectorExample()

    Dim vector1 As New VectorN(2)
    vector1.SetValues(4, 7)
    Dim vector2 As New VectorN(2)
    vector2.SetValues(3, 4)
    vector1.Add(vector2)
    Assert.AreEqual(7, vector1.Item(0))
    Assert.AreEqual(11, vector1.Item(1))

  End Sub

#End Region

#Region "Clear"
  <Test()> _
  Public Sub ClearExample()

    Dim vector As New VectorN(2)
    vector.SetValues(3, 7)
    vector.Clear()
    Assert.AreEqual(0, vector.Item(0))
    Assert.AreEqual(0, vector.Item(1))

  End Sub

#End Region

#Region "Clone"
  <Test()> _
  Public Sub CloneExample()

    Dim vector As New VectorN(3)
    vector.SetValues(3, 7, 9)
    Dim clone As VectorN = DirectCast(vector.Clone, VectorN)
    Assert.AreEqual(3, vector.Item(0))
    Assert.AreEqual(7, vector.Item(1))
    Assert.AreEqual(9, vector.Item(2))
    Assert.AreEqual(3, clone.Item(0))
    Assert.AreEqual(7, clone.Item(1))
    Assert.AreEqual(9, clone.Item(2))
    Assert.AreNotSame(clone, vector)

  End Sub

#End Region

#Region "Constructor"
  <Test()> _
  Public Sub ConstructorExample()

    Dim vector As New VectorN(2)
    Assert.AreEqual(2, vector.DimensionCount)
    Assert.AreEqual(0, vector.Item(0))
    Assert.AreEqual(0, vector.Item(1))

  End Sub

#End Region

#Region "Decrement"
  <Test()> _
  Public Sub DecrementExample()

    Dim vector1 As New VectorN(2)
    vector1.SetValues(4, 7)
    vector1.Decrement()
    Assert.AreEqual(3, vector1.Item(0))
    Assert.AreEqual(6, vector1.Item(1))

  End Sub

#End Region

#Region "DimensionCount"
  <Test()> _
  Public Sub DimensionCountExample()

    Dim vector As New VectorN(2)
    Assert.AreEqual(2, vector.DimensionCount)

  End Sub

#End Region

#Region "DivideDouble"
  <Test()> _
  Public Sub DivideDoubleExample()

    Dim vector1 As New VectorN(2)
    vector1.SetValues(9, 3)
    vector1.Divide(3)
    Assert.AreEqual(3, vector1.Item(0))
    Assert.AreEqual(1, vector1.Item(1))

  End Sub

#End Region

#Region "DivideVector"
  <Test()> _
  Public Sub DivideVectorExample()

    Dim vector1 As New VectorN(2)
    vector1.SetValues(6, 16)
    Dim vector2 As New VectorN(2)
    vector2.SetValues(2, 4)
    vector1.Divide(vector2)
    Assert.AreEqual(3, vector1.Item(0))
    Assert.AreEqual(4, vector1.Item(1))

  End Sub

#End Region

#Region "DotProductVector"
  <Test()> _
  Public Sub DotProductVectorExample()

    Dim vector1 As New VectorN(2)
    vector1.SetValues(4, 7)
    Dim vector2 As New VectorN(2)
    vector2.SetValues(3, 4)
    Dim dotProduct As Double = vector1.DotProduct(vector2)
    Assert.AreEqual(40, dotProduct)

  End Sub

#End Region

#Region "GetHashCode"
  <Test()> _
  Public Sub GetHashCodeExample()

    Dim vector1 As New VectorN(2)
    vector1.Item(0) = 1
    vector1.Item(1) = 2
    Assert.AreNotEqual(0, vector1.GetHashCode)

  End Sub

#End Region

#Region "GetUnitVector"
  <Test()> _
  Public Sub GetUnitVectorExample()

    Dim vector As VectorN = VectorN.GetUnitVector(3)
    Assert.AreEqual(3, vector.DimensionCount)
    Assert.AreEqual(1, vector.Item(0))
    Assert.AreEqual(1, vector.Item(1))
    Assert.AreEqual(1, vector.Item(2))

  End Sub

#End Region

#Region "GetZeroVector"
  <Test()> _
  Public Sub GetZeroVectorExample()

    Dim vector As VectorN = VectorN.GetZeroVector(3)
    Assert.AreEqual(3, vector.DimensionCount)
    Assert.AreEqual(0, vector.Item(0))
    Assert.AreEqual(0, vector.Item(1))
    Assert.AreEqual(0, vector.Item(2))

  End Sub

#End Region

#Region "Increment"
  <Test()> _
  Public Sub IncrementExample()

    Dim vector1 As New VectorN(2)
    vector1.SetValues(4, 7)
    vector1.Increment()
    Assert.AreEqual(5, vector1.Item(0))
    Assert.AreEqual(8, vector1.Item(1))

  End Sub

#End Region

#Region "Index"
  <Test()> _
  Public Sub IndexExample()

    Dim vector As New VectorN(2)
    Assert.AreEqual(0, vector.Item(0))
    Assert.AreEqual(0, vector.Item(1))
    vector.Item(0) = 4
    vector.Item(1) = 5
    Assert.AreEqual(4, vector.Item(0))
    Assert.AreEqual(5, vector.Item(1))

  End Sub

#End Region

#Region "Magnitude"
  <Test()> _
  Public Sub MagnitudeExample()

    Dim vector As New VectorN(3)
    vector.SetValues(4, 3, 12)
    Assert.AreEqual(13, vector.Magnitude)

  End Sub

#End Region

#Region "Maximum"
  <Test()> _
  Public Sub MaximumExample()

    Dim vector1 As New VectorN(4)
    vector1.Item(0) = 1
    vector1.Item(1) = -4
    vector1.Item(2) = 3
    vector1.Item(3) = 2
    Assert.AreEqual(3, vector1.Maximum)

  End Sub

#End Region

#Region "MaximumIndex"
  <Test()> _
  Public Sub MaximumIndexExample()

    Dim vector1 As New VectorN(4)
    vector1.Item(0) = 1
    vector1.Item(1) = -4
    vector1.Item(2) = 3
    vector1.Item(3) = 2
    Assert.AreEqual(2, vector1.MaximumIndex)

  End Sub

#End Region

#Region "Minimum"
  <Test()> _
  Public Sub MinimumExample()

    Dim vector1 As New VectorN(4)
    vector1.Item(0) = 1
    vector1.Item(1) = -4
    vector1.Item(2) = 3
    vector1.Item(3) = 2
    Assert.AreEqual(-4, vector1.Minimum)

  End Sub

#End Region

#Region "MinimumIndex"
  <Test()> _
  Public Sub MinimumIndexExample()

    Dim vector1 As New VectorN(4)
    vector1.Item(0) = 1
    vector1.Item(1) = -4
    vector1.Item(2) = 3
    vector1.Item(3) = 2
    Assert.AreEqual(1, vector1.MinimumIndex)

  End Sub

#End Region

#Region "MultiplyDouble"
  <Test()> _
  Public Sub MultiplyDoubleExample()

    Dim vector1 As New VectorN(2)
    vector1.Item(0) = 1
    vector1.Item(1) = 2
    vector1.Multiply(2)
    Assert.AreEqual(2, vector1.Item(0))
    Assert.AreEqual(4, vector1.Item(1))

  End Sub

#End Region

#Region "MultiplyVector"
  <Test()> _
  Public Sub MultiplyVectorExample()

    Dim vector1 As New VectorN(2)
    vector1.Item(0) = 1
    vector1.Item(1) = 2
    Dim vector2 As New VectorN(2)
    vector2.Item(0) = 3
    vector2.Item(1) = 4
    Dim matrix As IMatrix(Of Double) = vector1.Multiply(vector2)
    Assert.AreEqual(2, matrix.Columns)
    Assert.AreEqual(2, matrix.Rows)
    Assert.AreEqual(3, matrix.Item(0, 0))
    Assert.AreEqual(4, matrix.Item(0, 1))
    Assert.AreEqual(6, matrix.Item(1, 0))
    Assert.AreEqual(8, matrix.Item(1, 1))

  End Sub

#End Region

#Region "Negate"
  <Test()> _
  Public Sub NegateExample()

    Dim vector1 As New VectorN(2)
    vector1.Item(0) = 1
    vector1.Item(1) = 2
    vector1.Negate()
    Assert.AreEqual(-1, vector1.Item(0))
    Assert.AreEqual(-2, vector1.Item(1))

  End Sub

#End Region

#Region "Normalize"
  <Test()> _
  Public Sub NormalizeExample()

    Dim vector As New VectorN(3)
    vector.Item(0) = 23
    vector.Item(1) = -21
    vector.Item(2) = 4
    vector.Normalize()
    Assert.AreEqual(1, vector.Magnitude)

  End Sub

#End Region


#Region "Product"
  <Test()> _
  Public Sub ProductExample()

    Dim vector As New VectorN(2)
    vector.SetValues(2, 3)
    Assert.AreEqual(6, vector.Product)

  End Sub

#End Region

#Region "SetValues"
  <Test()> _
  Public Sub SetValuesExample()

    Dim vector1 As New VectorN(2)
    vector1.SetValues(4, 6)
    Assert.AreEqual(4, vector1.Item(0))
    Assert.AreEqual(6, vector1.Item(1))

  End Sub

#End Region

#Region "SubtractDouble"
  <Test()> _
  Public Sub SubtractDoubleExample()

    Dim vector1 As New VectorN(2)
    vector1.Item(0) = 1
    vector1.Item(1) = 2
    vector1.Subtract(2)
    Assert.AreEqual(-1, vector1.Item(0))
    Assert.AreEqual(0, vector1.Item(1))

  End Sub

#End Region

#Region "SubtractVector"
  <Test()> _
  Public Sub SubtractVectorExample()

    Dim vector1 As New VectorN(2)
    vector1.Item(0) = 1
    vector1.Item(1) = 2
    Dim vector2 As New VectorN(2)
    vector2.Item(0) = 8
    vector2.Item(1) = 4
    vector1.Subtract(vector2)
    Assert.AreEqual(-7, vector1.Item(0))
    Assert.AreEqual(-2, vector1.Item(1))

  End Sub

#End Region

#Region "Sum"
  <Test()> _
  Public Sub SumExample()

    Dim vector As New VectorN(2)
    vector.SetValues(2, 3)
    Assert.AreEqual(5, vector.Sum)

  End Sub

#End Region

#Region "Swap"
  <Test()> _
  Public Sub SwapExample()

    Dim vector1 As New VectorN(2)
    vector1.Item(0) = 1
    vector1.Item(1) = 2
    Dim vector2 As New VectorN(2)
    vector2.Item(0) = 3
    vector2.Item(1) = 4
    vector1.Swap(vector2)
    Assert.AreEqual(3, vector1.Item(0))
    Assert.AreEqual(4, vector1.Item(1))
    Assert.AreEqual(1, vector2.Item(0))
    Assert.AreEqual(2, vector2.Item(1))

  End Sub

#End Region

#Region "ToArray"
  <Test()> _
  Public Sub ToArrayExample()

    Dim vector As New VectorN(2)
    vector.SetValues(8, 3)
    Dim actual As Double() = vector.ToArray
    Assert.AreEqual(2, actual.Length)
    Assert.AreEqual(8, actual(0))
    Assert.AreEqual(3, actual(1))

  End Sub

#End Region

#Region "ToMatrix"
  <Test()> _
  Public Sub ToMatrixExample()

    Dim vector As New VectorN(2)
    vector.SetValues(8, 3)
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

    Dim vector1 As New VectorN(2)
    Dim actual As String = vector1.ToString
    Assert.AreEqual("{0,0}", actual)
    vector1.Item(0) = 1
    vector1.Item(1) = 2
    actual = vector1.ToString
    Assert.AreEqual("{1,2}", actual)

  End Sub

#End Region

End Class