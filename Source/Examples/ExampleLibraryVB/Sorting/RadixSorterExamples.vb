'  
' Copyright 2009 The NGenerics Team
' (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)
'
' This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
' have received a copy of the license along with the source code.  If not, an online copy
' of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
'

Imports System.Collections.Generic
Imports NGenerics.Sorting
Imports NUnit.Framework

<TestFixture()> _
Public Class RadixSorterExamples
#Region "Sort"
  <Test()> _
  Public Sub SortExample()
    Dim sorter As New RadixSorter

    Dim list As New List(Of Integer)
    list.Add(13)
    list.Add(5)
    list.Add(77)
    list.Add(9)
    list.Add(12)

    sorter.Sort(list, SortOrder.Ascending)

    Assert.AreEqual(5, list.Item(0))
    Assert.AreEqual(9, list.Item(1))
    Assert.AreEqual(12, list.Item(2))
    Assert.AreEqual(13, list.Item(3))
    Assert.AreEqual(77, list.Item(4))
  End Sub
#End Region

End Class
