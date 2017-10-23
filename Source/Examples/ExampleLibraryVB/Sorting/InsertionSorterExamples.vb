'  
' Copyright 2007-2017 The NGenerics Team
' (https://github.com/ngenerics/ngenerics/wiki/Team)
'
' This program is licensed under the MIT License.  You should 
' have received a copy of the license along with the source code.  If not, an online copy
' of the license can be found at https://opensource.org/licenses/MIT.
'

Imports System.Collections.Generic
Imports NGenerics.Sorting
Imports NUnit.Framework

<TestFixture()> _
Public Class InsertionSorterExamples
#Region "Sort"
    <Test()> _
    Public Sub SortExample()
        Dim sorter As New InsertionSorter(Of Integer)

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

End Class






