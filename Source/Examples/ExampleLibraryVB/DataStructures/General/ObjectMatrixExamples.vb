'  
' Copyright 2007-2010 The NGenerics Team
' (http://code.google.com/p/ngenerics/wiki/Team)
'
' This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
' have received a copy of the license along with the source code.  If not, an online copy
' of the license can be found at http://www.gnu.org/copyleft/lesser.html.
'

Imports System
Imports System.Collections.Generic
Imports NGenerics.DataStructures.General
Imports NUnit.Framework
Imports NGenerics.Patterns.Visitor

<TestFixture()> _
Public Class ObjectMatrixExamples

#Region "Accept"
  <Test()> _
  Public Sub AcceptExample()
    Dim matrix As New ObjectMatrix(Of Double)(2, 2)
    matrix.Item(0, 0) = -2
    matrix.Item(0, 1) = 3
    matrix.Item(1, 0) = 4
    matrix.Item(1, 1) = 6
    Dim visitor As New CountingVisitor(Of Double)
    matrix.AcceptVisitor(visitor)
    Assert.AreEqual(4, visitor.Count)
  End Sub
#End Region


#Region "AddColumn"
  <Test()> _
  Public Sub AddColumnExample()
    Dim matrix As New ObjectMatrix(Of Double)(2, 2)
    matrix.Item(0, 0) = 1
    matrix.Item(0, 1) = 2
    matrix.Item(1, 0) = 3
    matrix.Item(1, 1) = 4
    Assert.AreEqual(2, matrix.Columns)
    Assert.AreEqual(2, matrix.Rows)
    matrix.AddColumn()
    Assert.AreEqual(3, matrix.Columns)
    Assert.AreEqual(2, matrix.Rows)
  End Sub
#End Region


#Region "AddColumns"
  <Test()> _
  Public Sub AddColumnsExample()
    Dim matrix As New ObjectMatrix(Of Double)(2, 2)
    matrix.Item(0, 0) = 1
    matrix.Item(0, 1) = 2
    matrix.Item(1, 0) = 3
    matrix.Item(1, 1) = 4
    Assert.AreEqual(2, matrix.Columns)
    Assert.AreEqual(2, matrix.Rows)
    matrix.AddColumns(2)
    Assert.AreEqual(4, matrix.Columns)
    Assert.AreEqual(2, matrix.Rows)
  End Sub
#End Region


#Region "AddColumnValues"
  <Test()> _
  Public Sub AddColumnValuesExample()
    Dim matrix As New ObjectMatrix(Of Double)(2, 2)
    matrix.Item(0, 0) = 1
    matrix.Item(0, 1) = 2
    matrix.Item(1, 0) = 3
    matrix.Item(1, 1) = 4
    Assert.AreEqual(2, matrix.Columns)
    Assert.AreEqual(2, matrix.Rows)
    matrix.AddColumn(New Double() {5, 6})
    Assert.AreEqual(3, matrix.Columns)
    Assert.AreEqual(2, matrix.Rows)
    Assert.AreEqual(5, matrix.Item(0, 2))
    Assert.AreEqual(6, matrix.Item(1, 2))
  End Sub
#End Region


#Region "AddRow"
  <Test()> _
  Public Sub AddRowExample()
    Dim matrix As New ObjectMatrix(Of Double)(2, 2)
    matrix.Item(0, 0) = 1
    matrix.Item(0, 1) = 2
    matrix.Item(1, 0) = 3
    matrix.Item(1, 1) = 4
    Assert.AreEqual(2, matrix.Columns)
    Assert.AreEqual(2, matrix.Rows)
    matrix.AddRow()
    Assert.AreEqual(2, matrix.Columns)
    Assert.AreEqual(3, matrix.Rows)
  End Sub
#End Region


#Region "AddRows"
  <Test()> _
  Public Sub AddRowsExample()
    Dim matrix As New ObjectMatrix(Of Double)(2, 2)
    matrix.Item(0, 0) = 1
    matrix.Item(0, 1) = 2
    matrix.Item(1, 0) = 3
    matrix.Item(1, 1) = 4
    Assert.AreEqual(2, matrix.Columns)
    Assert.AreEqual(2, matrix.Rows)
    matrix.AddRows(2)
    Assert.AreEqual(2, matrix.Columns)
    Assert.AreEqual(4, matrix.Rows)
  End Sub
#End Region


#Region "AddRowValues"
  <Test()> _
  Public Sub AddRowValuesExample()
    Dim matrix As New ObjectMatrix(Of Double)(2, 2)
    matrix.Item(0, 0) = 1
    matrix.Item(0, 1) = 2
    matrix.Item(1, 0) = 3
    matrix.Item(1, 1) = 4
    Assert.AreEqual(2, matrix.Columns)
    Assert.AreEqual(2, matrix.Rows)
    matrix.AddRow(New Double() {5, 6})
    Assert.AreEqual(2, matrix.Columns)
    Assert.AreEqual(3, matrix.Rows)
    Assert.AreEqual(5, matrix.Item(2, 0))
    Assert.AreEqual(6, matrix.Item(2, 1))
  End Sub
#End Region


#Region "Clear"
  <Test()> _
  Public Sub ClearExample()
    Dim matrix As New ObjectMatrix(Of Double)(4, 5)
    matrix.Item(2, 3) = 5
    Assert.AreEqual(5, matrix.Item(2, 3))
    matrix.Clear()
    Assert.AreEqual(0, matrix.Item(2, 3))
  End Sub
#End Region


#Region "Constructor"
  <Test()> _
  Public Sub ConstructorExample()
    Dim matrix As New ObjectMatrix(Of Double)(2, 3)
    Assert.AreEqual(2, matrix.Rows)
    Assert.AreEqual(3, matrix.Columns)
  End Sub
#End Region


#Region "Columns"
  <Test()> _
  Public Sub ColumnsExample()
    Dim matrix As New ObjectMatrix(Of Double)(2, 3)
    Assert.AreEqual(3, matrix.Columns)
  End Sub
#End Region


#Region "Rows"
  <Test()> _
  Public Sub RowsExample()
    Dim matrix As New ObjectMatrix(Of Double)(2, 3)
    Assert.AreEqual(2, matrix.Rows)
  End Sub
#End Region


#Region "Contains"
  <Test()> _
  Public Sub ContainsExample()
    Dim matrix As New ObjectMatrix(Of Double)(2, 2)
    matrix.Item(0, 0) = -2
    matrix.Item(0, 1) = 3
    matrix.Item(1, 0) = 4
    matrix.Item(1, 1) = 6
    Assert.IsTrue(matrix.Contains(-2))
    Assert.IsTrue(matrix.Contains(3))
    Assert.IsFalse(matrix.Contains(-5))
  End Sub
#End Region


#Region "Count"
    <Test()> _
   Public Sub CountExample()
        Dim matrix As New ObjectMatrix(Of Double)(2, 2)
        Dim collection As ICollection(Of Double) = matrix
        matrix.Item(0, 0) = 1
        matrix.Item(0, 1) = 2
        matrix.Item(1, 1) = 3
        matrix.Item(1, 0) = 4
        Assert.AreEqual(4, collection.Count)
    End Sub

#End Region


#Region "CopyTo"
  <Test()> _
  Public Sub CopyToExample()
    Dim matrix As New ObjectMatrix(Of Double)(2, 2)
    matrix.Item(0, 0) = 1
    matrix.Item(0, 1) = 2
    matrix.Item(1, 0) = 3
    matrix.Item(1, 1) = 4
    Dim array As Double() = New Double((matrix.Rows * matrix.Columns) - 1) {}
    matrix.CopyTo(array, 0)
    Assert.AreEqual(1, array(0))
    Assert.AreEqual(4, array(3))
  End Sub
#End Region


  '#Region "Equals"
  '    <Test()> _
  '    Public Sub EqualsExample()
  '        Dim matrix1 As New ObjectMatrix(Of Double)(2, 2)
  '        matrix1.Item(0, 0) = 1
  '        matrix1.Item(0, 1) = 2
  '        matrix1.Item(1, 1) = 3
  '        matrix1.Item(1, 0) = 4
  '        Dim matrix2 As New ObjectMatrix(Of Double)(2, 2)
  '        matrix2.Item(0, 0) = 1
  '        matrix2.Item(0, 1) = 2
  '        matrix2.Item(1, 1) = 3
  '        matrix2.Item(1, 0) = 4
  '        Assert.IsTrue(matrix1.Equals(matrix2))
  '        Dim matrix3 As New ObjectMatrix(Of Double)(2, 2)
  '        matrix3.Item(0, 0) = 1
  '        matrix3.Item(0, 1) = 2
  '        matrix3.Item(1, 1) = 3
  '        matrix3.Item(1, 0) = 5
  '        Assert.IsFalse(matrix1.Equals(matrix3))
  '    End Sub
  '#End Region


#Region "GetColumn"
  <Test()> _
  Public Sub GetColumnExample()
    Dim matrix As New ObjectMatrix(Of Double)(2, 2)
    matrix.Item(0, 0) = 1
    matrix.Item(0, 1) = 2
    matrix.Item(1, 0) = 3
    matrix.Item(1, 1) = 4
    Dim column1 As Double() = matrix.GetColumn(0)
    Assert.AreEqual(1, column1(0))
    Assert.AreEqual(3, column1(1))
    Dim column2 As Double() = matrix.GetColumn(1)
    Assert.AreEqual(2, column2(0))
    Assert.AreEqual(4, column2(1))
  End Sub
#End Region


#Region "GetEnumerator"
  <Test()> _
  Public Sub GetEnumeratorExample()
    Dim matrix As New ObjectMatrix(Of Double)(2, 2)
    matrix.Item(0, 0) = 1
    matrix.Item(0, 1) = 2
    matrix.Item(1, 1) = 3
    matrix.Item(1, 0) = 4
    Dim enumerator As IEnumerator(Of Double) = matrix.GetEnumerator
    Do While enumerator.MoveNext
      Console.WriteLine(enumerator.Current)
    Loop
  End Sub
#End Region


#Region "GetRow"
  <Test()> _
  Public Sub GetRowExample()
    Dim matrix As New ObjectMatrix(Of Double)(2, 2)
    matrix.Item(0, 0) = 1
    matrix.Item(0, 1) = 2
    matrix.Item(1, 0) = 3
    matrix.Item(1, 1) = 4
    Dim row1 As Double() = matrix.GetRow(0)
    Assert.AreEqual(1, row1(0))
    Assert.AreEqual(2, row1(1))
    Dim row2 As Double() = matrix.GetRow(1)
    Assert.AreEqual(3, row2(0))
    Assert.AreEqual(4, row2(1))
  End Sub
#End Region


#Region "GetSubMatrix"
  <Test()> _
  Public Sub GetSubMatrixExample()
    Dim matrix As New ObjectMatrix(Of Double)(3, 3)
    matrix.Item(0, 0) = 1
    matrix.Item(0, 1) = 2
    matrix.Item(0, 2) = 3
    matrix.Item(1, 0) = 4
    matrix.Item(1, 1) = 5
    matrix.Item(1, 2) = 6
    matrix.Item(2, 0) = 7
    matrix.Item(2, 1) = 8
    matrix.Item(2, 2) = 9
    Dim result1 As ObjectMatrix(Of Double) = matrix.GetSubMatrix(0, 0, 1, 1)
    Assert.AreEqual(1, result1.Rows)
    Assert.AreEqual(1, result1.Columns)
    Dim result2 As ObjectMatrix(Of Double) = matrix.GetSubMatrix(1, 2, 2, 1)
    Assert.AreEqual(2, result2.Rows)
    Assert.AreEqual(1, result2.Columns)
  End Sub
#End Region


#Region "Index"
  <Test()> _
  Public Sub IndexExample()
    Dim matrix As New ObjectMatrix(Of Double)(4, 5)
    matrix.Item(2, 3) = 5
    Assert.AreEqual(5, matrix.Item(2, 3))
  End Sub
#End Region


#Region "InterchangeColumns"
  <Test()> _
  Public Sub InterchangeColumnsExample()
    Dim matrix As New ObjectMatrix(Of Double)(2, 2)
    matrix.Item(0, 0) = 1
    matrix.Item(0, 1) = 2
    matrix.Item(1, 0) = 3
    matrix.Item(1, 1) = 4
    matrix.InterchangeColumns(0, 1)
    Assert.AreEqual(2, matrix.Item(0, 0))
    Assert.AreEqual(1, matrix.Item(0, 1))
    Assert.AreEqual(4, matrix.Item(1, 0))
    Assert.AreEqual(3, matrix.Item(1, 1))
  End Sub
#End Region


#Region "InterchangeRows"
  <Test()> _
  Public Sub InterchangeRowsExample()
    Dim matrix As New ObjectMatrix(Of Double)(2, 2)
    matrix.Item(0, 0) = 1
    matrix.Item(0, 1) = 2
    matrix.Item(1, 0) = 3
    matrix.Item(1, 1) = 4
    matrix.InterchangeRows(0, 1)
    Assert.AreEqual(3, matrix.Item(0, 0))
    Assert.AreEqual(4, matrix.Item(0, 1))
    Assert.AreEqual(1, matrix.Item(1, 0))
    Assert.AreEqual(2, matrix.Item(1, 1))
  End Sub
#End Region


#Region "IsReadOnly"
  <Test()> _
  Public Sub IsReadOnlyExample()
    Dim matrix As New ObjectMatrix(Of Double)(4, 5)
    Assert.IsFalse(matrix.IsReadOnly)
    matrix.Item(2, 3) = 5
    Assert.IsFalse(matrix.IsReadOnly)
  End Sub
#End Region


#Region "IsSquare"
  <Test()> _
  Public Sub IsSquareExample()
    Dim matrix As New ObjectMatrix(Of Double)(10, 10)
    Assert.IsTrue(matrix.IsSquare)
    matrix = New ObjectMatrix(Of Double)(3, 4)
    Assert.IsFalse(matrix.IsSquare)
    matrix = New ObjectMatrix(Of Double)(35, 35)
    Assert.IsTrue(matrix.IsSquare)
    matrix = New ObjectMatrix(Of Double)(45, 44)
    Assert.IsFalse(matrix.IsSquare)
  End Sub
#End Region


#Region "Resize"
  <Test()> _
  Public Sub ResizeExample()
    Dim matrix As New ObjectMatrix(Of Double)(3, 3)
    matrix.Item(0, 0) = 1
    matrix.Item(0, 1) = 2
    matrix.Item(0, 2) = 3
    matrix.Item(1, 0) = 4
    matrix.Item(1, 1) = 5
    matrix.Item(1, 2) = 6
    matrix.Item(2, 0) = 7
    matrix.Item(2, 1) = 8
    matrix.Item(2, 2) = 9
    matrix.Resize(2, 2)
    Assert.AreEqual(matrix.Columns, 2)
    Assert.AreEqual(matrix.Rows, 2)
    Assert.AreEqual(1, matrix.Item(0, 0))
    Assert.AreEqual(2, matrix.Item(0, 1))
    Assert.AreEqual(4, matrix.Item(1, 0))
    Assert.AreEqual(5, matrix.Item(1, 1))
  End Sub
#End Region

#Region "DeleteColumn"
  <Test()> _
  Public Sub DeleteColumnExample()
    Dim matrix As New ObjectMatrix(Of Double)(4, 5)

    ' Delete the second row from the matrix
    matrix.DeleteRow(2)

    ' Only 3 rows left...
    Assert.AreEqual(matrix.Rows, 3)
  End Sub

#End Region

#Region "DeleteRow"
  <Test()> _
Public Sub DeleteRowExample()
    Dim matrix As New ObjectMatrix(Of Double)(4, 5)


    ' Delete the second column from the matrix
    matrix.DeleteColumn(2)

    ' Only 4 columns left...
    Assert.AreEqual(matrix.Columns, 4)
  End Sub
#End Region

End Class
