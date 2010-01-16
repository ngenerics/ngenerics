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
Imports System.Diagnostics
Imports NGenerics.DataStructures.General
Imports NUnit.Framework
Imports NGenerics.Patterns.Visitor

<TestFixture()> _
Public Class HeapExamples

#Region "Accept"
  <Test()> _
  Public Sub AcceptExample()
    Dim heap As New Heap(Of String)(HeapType.Minimum)
    heap.Add("cat")
    heap.Add("dog")
    heap.Add("canary")

    ' There should be 3 items in the heap.
    Assert.AreEqual(heap.Count, 3)

    ' Create a visitor that will simply count the items in the heap.
    Dim visitor As New CountingVisitor(Of String)

    ' Make heap call IVisitor<T>.Visit on all items contained.
        heap.AcceptVisitor(visitor)

    ' The counting visitor would have visited 3 items.
    Assert.AreEqual(visitor.Count, 3)
  End Sub

#End Region


#Region "Add"
  <Test()> _
  Public Sub AddExample()
    Dim heap As New Heap(Of String)(HeapType.Minimum)
    heap.Add("cat")
    heap.Add("dog")
    heap.Add("canary")

    ' There should be 3 items in the heap.
    Assert.AreEqual(heap.Count, 3)
  End Sub

#End Region


#Region "Clear"
  <Test()> _
  Public Sub ClearExample()
    Dim heap As New Heap(Of String)(HeapType.Minimum)
    heap.Add("cat")
    heap.Add("dog")
    heap.Add("canary")

    ' There should be 3 items in the heap.
    Assert.AreEqual(heap.Count, 3)

    ' Clear the heap
    heap.Clear()

    ' The heap should be empty.
    Assert.AreEqual(heap.Count, 0)

    ' No cat here..
    Assert.IsFalse(heap.Contains("cat"))
  End Sub

#End Region


#Region "ConstructorCapacity"
  <Test()> _
  Public Sub ConstructorCapacityExample()

    ' If you know how many items will initially be in the list it is 
    ' more efficient to set the initial capacity
    Dim heap As New Heap(Of String)(HeapType.Minimum, 3)
    heap.Add("cat")
    heap.Add("dog")
    heap.Add("canary")
  End Sub

#End Region


#Region "ConstructorComparer"
  <Test()> _
  Public Sub ConstructorComparerExample()
    Dim heapIgnoreCase As New Heap(Of String)(HeapType.Minimum, StringComparer.OrdinalIgnoreCase)
    heapIgnoreCase.Add("frog")
    heapIgnoreCase.Add("cat")
    heapIgnoreCase.Add("CAT")
    heapIgnoreCase.Add("dog")

    ' "cat" will be the root because case is ignored
    Assert.AreEqual("cat", heapIgnoreCase.Root)

    Dim heapUseCase As New Heap(Of String)(HeapType.Minimum, StringComparer.Ordinal)
    heapUseCase.Add("frog")
    heapUseCase.Add("cat")
    heapUseCase.Add("CAT")
    heapUseCase.Add("dog")

    ' "CAT" will be the root because case is not ignored
    Assert.AreEqual("CAT", heapUseCase.Root)
  End Sub

#End Region


#Region "Constructor"
  <Test()> _
  Public Sub ConstructorExample()
    Dim heap As New Heap(Of String)(HeapType.Minimum)
    heap.Add("cat")
    heap.Add("dog")
    heap.Add("canary")
  End Sub

#End Region


#Region "Contains"
  <Test()> _
  Public Sub ContainsExample()
    Dim heap As New Heap(Of String)(HeapType.Minimum)
    heap.Add("cat")
    heap.Add("dog")
    heap.Add("canary")

    ' heap does contain cat, dog and canary
    Assert.IsTrue(heap.Contains("cat"))
    Assert.IsTrue(heap.Contains("dog"))
    Assert.IsTrue(heap.Contains("canary"))

    ' but not frog
    Assert.IsFalse(heap.Contains("frog"))
  End Sub

#End Region


#Region "CopyTo"
  <Test()> _
  Public Sub CopyToExample()
    Dim heap As New Heap(Of String)(HeapType.Minimum)
    heap.Add("cat")
    heap.Add("dog")
    heap.Add("canary")
    heap.Add("canary")

    ' create new string array 
    ' note that the count is 4 because "canary" will exists twice.
    Dim stringArray As String() = New String(4 - 1) {}
    heap.CopyTo(stringArray, 0)
  End Sub

#End Region


#Region "Count"
  <Test()> _
  Public Sub CountExample()
    Dim heap As New Heap(Of String)(HeapType.Minimum)
    heap.Add("cat")
    heap.Add("dog")
    heap.Add("canary")
    heap.Add("canary")

    ' Count is 4
    Assert.AreEqual(4, heap.Count)
  End Sub

#End Region


#Region "GetEnumerator"
  <Test()> _
  Public Sub GetEnumeratorExample()
    Dim heap As New Heap(Of String)(HeapType.Minimum)
    heap.Add("cat")
    heap.Add("dog")
    heap.Add("dog")
    heap.Add("canary")

    ' Get the enumerator and iterate through it.
    Dim enumerator As IEnumerator(Of String) = heap.GetEnumerator
    Do While enumerator.MoveNext
      Debug.WriteLine(enumerator.Current)
    Loop
  End Sub

#End Region


#Region "IsEmpty"
  <Test()> _
  Public Sub IsEmptyExample()
    Dim heap As New Heap(Of String)(HeapType.Minimum)

    ' Heap will be empty initially
    Assert.IsTrue(heap.IsEmpty)
    heap.Add("cat")

    ' Heap will be not be empty when an item is added
    Assert.IsFalse(heap.IsEmpty)
    heap.Clear()

    ' Heap will be empty when items are cleared
    Assert.IsTrue(heap.IsEmpty)
  End Sub

#End Region


#Region "IsReadOnly"
  <Test()> _
  Public Sub IsReadOnlyExample()
    Dim heap As New Heap(Of String)(HeapType.Minimum)

    ' IsReadOnly is always false for a Heap
    Assert.IsFalse(heap.IsReadOnly)
    heap.Add("cat")
    heap.Add("dog")
    heap.Add("canary")
    Assert.IsFalse(heap.IsReadOnly)
  End Sub

#End Region


#Region "RemoveRoot"
  <Test()> _
  Public Sub RemoveRootExample()
    Dim heap As New Heap(Of String)(HeapType.Minimum)
    heap.Add("cat")
    heap.Add("dog")
    heap.Add("canary")

    'because a heap is sorted the order will be "canary", "cat" and "dog"

    ' Root is "canary"
    Assert.AreEqual("canary", heap.Root)

    ' Remove Root
    heap.RemoveRoot()

    ' Root is "cat"
    Assert.AreEqual("cat", heap.Root)

    ' Remove Root
    heap.RemoveRoot()

    ' Root is "dog"
    Assert.AreEqual("dog", heap.Root)

    ' Remove Root
    heap.RemoveRoot()

    Assert.IsTrue(heap.IsEmpty)
  End Sub

#End Region


#Region "Root"
  <Test()> _
  Public Sub RootExample()
    Dim heap As New Heap(Of String)(HeapType.Minimum)
    heap.Add("cat")
    heap.Add("dog")
    heap.Add("canary")

    'because a heap is sorted the order will be "canary", "cat" and "dog"

    ' Root is "canary"
    Assert.AreEqual("canary", heap.Root)

    ' Remove Root
    heap.RemoveRoot()

    ' Root is "cat"
    Assert.AreEqual("cat", heap.Root)

    ' Remove Root
    heap.RemoveRoot()

    ' Root is "dog"
    Assert.AreEqual("dog", heap.Root)

    ' Remove Root
    heap.RemoveRoot()
    Assert.IsTrue(heap.IsEmpty)
  End Sub

#End Region


#Region "Type"
  <Test()> _
  Public Sub TypeExample()
    Dim heap As New Heap(Of String)(HeapType.Minimum)
    heap.Add("cat")
    heap.Add("dog")
    heap.Add("canary")
    Assert.AreEqual(HeapType.Minimum, heap.Type)
  End Sub

#End Region
End Class