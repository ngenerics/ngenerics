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
Imports System.Diagnostics
Imports NGenerics.DataStructures.General
Imports NUnit.Framework
Imports NGenerics.Patterns.Visitor


<TestFixture()> _
Public Class SortedListExamples

#Region "Accept"
  <Test()> _
  Public Sub AcceptVisitorExample()
    Dim sortedList As New SortedList(Of String)
    sortedList.Add("cat")
    sortedList.Add("dog")
    sortedList.Add("canary")

    ' There should be 3 items in the sortedList.
    Assert.AreEqual(sortedList.Count, 3)

    ' Create a visitor that will simply count the items in the sortedList.
    Dim visitor As New CountingVisitor(Of String)

    ' Make sortedList tree call IVisitor<T>.Visit on all items contained.
        sortedList.AcceptVisitor(visitor)

    '  The counting visitor would have visited 3 items.
    Assert.AreEqual(visitor.Count, 3)
  End Sub
#End Region


#Region "Add"
  <Test()> _
  Public Sub AddExample()
    Dim sortedList As New SortedList(Of String)
    sortedList.Add("cat")
    sortedList.Add("dog")
    sortedList.Add("canary")

    ' There should be 3 items in the sortedList.
    Assert.AreEqual(sortedList.Count, 3)
  End Sub

#End Region


#Region "ConstructorCapacity"
  <Test()> _
  Public Sub ConstructorCapacity() 'Example()
    ' If you know how many items will initially be in the list it is 
    ' more efficient to set the initial capacity
    Dim sortedList As New SortedList(Of String)(3)
    sortedList.Add("cat")
    sortedList.Add("dog")
    sortedList.Add("canary")
  End Sub

#End Region


#Region "Clear"
  <Test()> _
  Public Sub ClearExampleExample()
    Dim sortedList As New SortedList(Of String)
    sortedList.Add("cat")
    sortedList.Add("dog")
    sortedList.Add("canary")

    ' There should be 3 items in the sortedList.
    Assert.AreEqual(sortedList.Count, 3)

    ' Clear the tree
    sortedList.Clear()

    ' The sortedList should be empty.
    Assert.AreEqual(sortedList.Count, 0)

    ' No cat here..
    Assert.IsFalse(sortedList.Contains("cat"))
  End Sub

#End Region


#Region "ConstructorCollection"
  <Test()> _
  Public Sub ConstructorCollectionExample()
    Dim array As String() = New String() {"cat", "dog", "canary"}

    Dim sortedList As New SortedList(Of String)(array)

    ' sortedList contains all the elements of the array
    Assert.IsTrue(sortedList.Contains("cat"))
    Assert.IsTrue(sortedList.Contains("canary"))
    Assert.IsTrue(sortedList.Contains("dog"))
  End Sub

#End Region


#Region "ConstructorComparer"
  <Test()> _
  Public Sub ConstructorComparerExample()
    Dim sortedListIgnoreCase As New SortedList(Of String)(StringComparer.OrdinalIgnoreCase)
    sortedListIgnoreCase.Add("cat")
    sortedListIgnoreCase.Add("dog")
    sortedListIgnoreCase.Add("CAT")

    ' "CAT" will be at the start because case is ignored
    Assert.AreEqual(0, sortedListIgnoreCase.IndexOf("CAT"))


    Dim sortedListUseCase As New SortedList(Of String)
    sortedListUseCase.Add("cat")
    sortedListUseCase.Add("dog")
    sortedListUseCase.Add("CAT")

    ' "CAT" will in the second position because case is not ignored
    Assert.AreEqual(1, sortedListUseCase.IndexOf("CAT"))
  End Sub

#End Region


#Region "Constructor"
  <Test()> _
  Public Sub ConstructorExample()
    Dim sortedList As New SortedList(Of String)
    sortedList.Add("cat")
    sortedList.Add("dog")
    sortedList.Add("canary")
  End Sub

#End Region


#Region "Contains"
  <Test()> _
  Public Sub ContainsExample()
    Dim sortedList As New SortedList(Of String)
    sortedList.Add("cat")
    sortedList.Add("dog")
    sortedList.Add("canary")

    ' sortedList does contain cat, dog and canary
    Assert.IsTrue(sortedList.Contains("cat"))
    Assert.IsTrue(sortedList.Contains("dog"))
    Assert.IsTrue(sortedList.Contains("canary"))

    ' but not frog
    Assert.IsFalse(sortedList.Contains("frog"))
  End Sub

#End Region


#Region "CopyTo"
  <Test()> _
  Public Sub CopyToExample()
    Dim sortedList As New SortedList(Of String)
    sortedList.Add("cat")
    sortedList.Add("dog")
    sortedList.Add("canary")

    ' create new string array with the same length
    Dim stringArray As String() = New String(sortedList.Count - 1) {}
    sortedList.CopyTo(stringArray, 0)

    ' stringArray contains cat, dog and canary (note canary is in the 0 position)
    Assert.AreEqual("canary", stringArray(0))
    Assert.AreEqual("cat", stringArray(1))
    Assert.AreEqual("dog", stringArray(2))
  End Sub

#End Region


#Region "Count"
  <Test()> _
  Public Sub CountExample()
    Dim sortedList As New SortedList(Of String)
    sortedList.Add("cat")
    sortedList.Add("dog")
    sortedList.Add("canary")

    ' Count is 3
    Assert.AreEqual(3, sortedList.Count)
  End Sub

#End Region


#Region "GetEnumerator"
  <Test()> _
  Public Sub GetEnumeratorExample()
    Dim sortedList As New SortedList(Of String)
    sortedList.Add("cat")
    sortedList.Add("dog")
    sortedList.Add("canary")

    ' Get the enumerator and iterate through it.
    Dim enumerator As IEnumerator(Of String) = sortedList.GetEnumerator
    Do While enumerator.MoveNext
      Debug.WriteLine(enumerator.Current)
    Loop
  End Sub

#End Region


#Region "IndexOf"
  <Test()> _
  Public Sub IndexOfExample()
    Dim sortedList As New SortedList(Of String)
    sortedList.Add("canary")
    sortedList.Add("cat")
    sortedList.Add("dog")

    ' "dog" is in position 2
    Assert.AreEqual(2, sortedList.IndexOf("dog"))
  End Sub

#End Region


#Region "IsEmpty"
  <Test()> _
  Public Sub IsEmptyExample()
    Dim sortedList As New SortedList(Of String)

    ' SortedList will be empty initially
    Assert.IsTrue(sortedList.IsEmpty)

    sortedList.Add("cat")

    ' SortedList will be not be empty when an item is added
    Assert.IsFalse(sortedList.IsEmpty)

    sortedList.Clear()

    ' SortedList will be empty when items are cleared
    Assert.IsTrue(sortedList.IsEmpty)
  End Sub

#End Region




#Region "IsReadOnly"
  <Test()> _
  Public Sub IsReadOnlyExample()
    Dim sortedList As New SortedList(Of String)
    ' IsReadOnly is always false for a SortedList
    Assert.IsFalse(sortedList.IsReadOnly)
    sortedList.Add("cat")
    sortedList.Add("dog")
    sortedList.Add("canary")
    Assert.IsFalse(sortedList.IsReadOnly)
  End Sub

#End Region


#Region "Remove"
  <Test()> _
  Public Sub RemoveExample()
    Dim sortedList As New SortedList(Of String)
    sortedList.Add("cat")
    sortedList.Add("dog")
    sortedList.Add("canary")

    ' SortedList Contains "dog"
    Assert.IsTrue(sortedList.Contains("dog"))

    ' Remove "dog"
    sortedList.Remove("dog")

    ' SortedList does not contains "dog"
    Assert.IsFalse(sortedList.Contains("dog"))
  End Sub

#End Region


#Region "RemoveAt"
  <Test()> _
  Public Sub RemoveAtExample()
    Dim sortedList As New SortedList(Of String)
    sortedList.Add("canary")
    sortedList.Add("cat")
    sortedList.Add("dog")

    ' SortedList Contains "dog"
    Assert.IsTrue(sortedList.Contains("dog"))

    ' "dog" is in position 2
    Assert.AreEqual(2, sortedList.IndexOf("dog"))

    ' Remove "dog"
    sortedList.RemoveAt(2)

    ' SortedList does not contains "dog"
    Assert.IsFalse(sortedList.Contains("dog"))
  End Sub
#End Region



End Class
