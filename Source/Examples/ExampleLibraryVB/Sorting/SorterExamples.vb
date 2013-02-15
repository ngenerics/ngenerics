'  
' Copyright 2007-2013 The NGenerics Team
' (https://github.com/ngenerics/ngenerics/wiki/Team)
'
' This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
' have received a copy of the license along with the source code.  If not, an online copy
' of the license can be found at http://www.gnu.org/copyleft/lesser.html.
'

Imports System
Imports System.Collections.Generic
Imports NGenerics.Sorting
Imports NUnit.Framework

<TestFixture()> _
Public Class SorterExamples
#Region "SortListComparer"
  <Test()> _
  Public Sub SortListComparerExample()
    Dim sorter As IComparisonSorter(Of Integer) = New QuickSorter(Of Integer)

    Dim list As New List(Of Integer)
    list.Add(13)
    list.Add(5)
    list.Add(77)
    list.Add(9)
    list.Add(12)

    sorter.Sort(list, Comparer(Of Integer).Default)

    Assert.AreEqual(5, list.Item(0))
    Assert.AreEqual(9, list.Item(1))
    Assert.AreEqual(12, list.Item(2))
    Assert.AreEqual(13, list.Item(3))
    Assert.AreEqual(77, list.Item(4))
  End Sub
#End Region

#Region "SortListDelegate"
  <Test()> _
  Public Sub SortListDelegateExample()
    Dim sorter As IComparisonSorter(Of Integer) = New QuickSorter(Of Integer)

    Dim list As New List(Of Integer)
    list.Add(13)
    list.Add(5)
    list.Add(77)
    list.Add(9)
    list.Add(12)

    sorter.Sort(list, New Comparison(Of Integer)(AddressOf SorterExamples.IntComparison))

    Assert.AreEqual(5, list.Item(0))
    Assert.AreEqual(9, list.Item(1))
    Assert.AreEqual(12, list.Item(2))
    Assert.AreEqual(13, list.Item(3))
    Assert.AreEqual(77, list.Item(4))
  End Sub

  Private Shared Function IntComparison(ByVal i As Integer, ByVal j As Integer) As Integer
    If (i < j) Then
      Return -1
    End If
    If (i > j) Then
      Return 1
    End If
    Return 0
  End Function
#End Region

#Region "SortList"
  <Test()> _
  Public Sub SortListExample()
    Dim sorter As Sorter(Of Integer) = New QuickSorter(Of Integer)

    Dim list As New List(Of Integer)
    list.Add(13)
    list.Add(5)
    list.Add(77)
    list.Add(9)
    list.Add(12)

    sorter.Sort(list)

    Assert.AreEqual(5, list.Item(0))
    Assert.AreEqual(9, list.Item(1))
    Assert.AreEqual(12, list.Item(2))
    Assert.AreEqual(13, list.Item(3))
    Assert.AreEqual(77, list.Item(4))
  End Sub
#End Region

#Region "SortListOrder"
  <Test()> _
  Public Sub SortListOrderExample()
    Dim sorter As Sorter(Of Integer) = New QuickSorter(Of Integer)

    Dim list As New List(Of Integer)
    list.Add(13)
    list.Add(5)
    list.Add(77)
    list.Add(9)
    list.Add(12)

    sorter.Sort(list, SortOrder.Ascending)

    Assert.AreEqual(77, list.Item(4))
    Assert.AreEqual(13, list.Item(3))
    Assert.AreEqual(12, list.Item(2))
    Assert.AreEqual(9, list.Item(1))
    Assert.AreEqual(5, list.Item(0))
  End Sub
#End Region
End Class
