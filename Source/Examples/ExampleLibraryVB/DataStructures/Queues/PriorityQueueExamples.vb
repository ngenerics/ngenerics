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
Imports NGenerics.DataStructures.Queues
Imports NGenerics.DataStructures.General
Imports NUnit.Framework
Imports NGenerics.Patterns.Visitor

<TestFixture()> _
Public Class PriorityQueueExamples

#Region "Accept"
  <Test()> _
  Public Sub AcceptExample()
    Dim priorityQueue As New PriorityQueue(Of String, Integer)(PriorityQueueType.Minimum)
    priorityQueue.Enqueue("cat")
    priorityQueue.Enqueue("dog")
    priorityQueue.Enqueue("canary")

    ' There should be 3 items in the priorityQueue.
    Assert.AreEqual(priorityQueue.Count, 3)

    ' Create a visitor that will simply count the items in the priorityQueue.
    Dim visitor As New CountingVisitor(Of String)

    ' Make priorityQueue call IVisitor<T>.Visit on all items contained.
    priorityQueue.AcceptVisitor(visitor)

    ' The counting visitor would have visited 3 items.
    Assert.AreEqual(visitor.Count, 3)
  End Sub

#End Region

#Region "Add"
  <Test()> _
  Public Sub AddExample()
    Dim priorityQueue As New PriorityQueue(Of String, Integer)(PriorityQueueType.Minimum)
    priorityQueue.Add("cat")
    priorityQueue.Add("dog")
    priorityQueue.Add("canary")

    ' There will be 3 items in the priorityQueue.
    Assert.AreEqual(priorityQueue.Count, 3)
  End Sub

#End Region

#Region "AddPriority"
  <Test()> _
  Public Sub AddPriorityExample()
    Dim priorityQueue As New PriorityQueue(Of String, Integer)(PriorityQueueType.Minimum)
    priorityQueue.Add("cat", 2)
    priorityQueue.Add("canary", 1)
    priorityQueue.Add("dog", 3)

    ' There will be 3 items in the priorityQueue.
    Assert.AreEqual(priorityQueue.Count, 3)

    ' "canary" will be at the top as it has the highest priority
    Assert.AreEqual("canary", priorityQueue.Peek)
  End Sub

#End Region

#Region "Clear"
  <Test()> _
  Public Sub ClearExample()
    Dim priorityQueue As New PriorityQueue(Of String, Integer)(PriorityQueueType.Minimum)
    priorityQueue.Enqueue("cat")
    priorityQueue.Enqueue("dog")
    priorityQueue.Enqueue("canary")

    ' There should be 3 items in the priorityQueue.
    Assert.AreEqual(priorityQueue.Count, 3)

    ' Clear the priorityQueue
    priorityQueue.Clear()

    ' The priorityQueue should be empty.
    Assert.AreEqual(priorityQueue.Count, 0)

    ' No cat here..
    Assert.IsFalse(priorityQueue.Contains("cat"))
  End Sub

#End Region

#Region "Constructor"
  <Test()> _
  Public Sub ConstructorExample()
    Dim priorityQueue As New PriorityQueue(Of String, Integer)(PriorityQueueType.Minimum)
    priorityQueue.Enqueue("cat")
    priorityQueue.Enqueue("dog")
    priorityQueue.Enqueue("canary")
  End Sub

#End Region

#Region "Contains"
  <Test()> _
  Public Sub ContainsExample()
    Dim priorityQueue As New PriorityQueue(Of String, Integer)(PriorityQueueType.Minimum)
    priorityQueue.Enqueue("cat")
    priorityQueue.Enqueue("dog")
    priorityQueue.Enqueue("canary")

    ' priorityQueue does contain cat, dog and canary
    Assert.IsTrue(priorityQueue.Contains("cat"))
    Assert.IsTrue(priorityQueue.Contains("dog"))
    Assert.IsTrue(priorityQueue.Contains("canary"))
    ' but not frog
    Assert.IsFalse(priorityQueue.Contains("frog"))
  End Sub

#End Region

#Region "CopyTo"
  <Test()> _
  Public Sub CopyToExample()
    Dim priorityQueue As New PriorityQueue(Of String, Integer)(PriorityQueueType.Minimum)
    priorityQueue.Enqueue("cat")
    priorityQueue.Enqueue("dog")
    priorityQueue.Enqueue("canary")
    priorityQueue.Enqueue("canary")

    ' create new string array 
    ' note that the count is 4 because "canary" will exists twice.
    Dim stringArray As String() = New String(4 - 1) {}
    priorityQueue.CopyTo(stringArray, 0)
  End Sub

#End Region

#Region "Count"
  <Test()> _
  Public Sub CountExample()
    Dim priorityQueue As New PriorityQueue(Of String, Integer)(PriorityQueueType.Minimum)
    priorityQueue.Enqueue("cat")
    priorityQueue.Enqueue("dog")
    priorityQueue.Enqueue("canary")
    priorityQueue.Enqueue("canary")

    ' Count is 4
    Assert.AreEqual(4, priorityQueue.Count)
  End Sub

#End Region

#Region "Enqueue"
  <Test()> _
  Public Sub EnqueueExample()
    Dim priorityQueue As New PriorityQueue(Of String, Integer)(PriorityQueueType.Minimum)
    priorityQueue.Enqueue("cat")
    priorityQueue.Enqueue("dog")
    priorityQueue.Enqueue("canary")

    ' There should be 3 items in the priorityQueue.
    Assert.AreEqual(priorityQueue.Count, 3)
  End Sub

#End Region

#Region "Dequeue"
  <Test()> _
  Public Sub DequeueExample()

    Dim circularQueue As New PriorityQueue(Of String, Integer)(PriorityQueueType.Minimum)
    circularQueue.Enqueue("dog", 2)
    circularQueue.Enqueue("canary", 1)
    circularQueue.Enqueue("cat", 3)

    ' Dequeue gives us "canary"
    Assert.AreEqual("canary", circularQueue.Dequeue)

    ' Dequeue gives us "dog"
    Assert.AreEqual("dog", circularQueue.Dequeue())

    ' Dequeue gives us "cat"
    Assert.AreEqual("cat", circularQueue.Dequeue)
  End Sub

#End Region

#Region "EnqueuePriority"
  <Test()> _
  Public Sub EnqueuePriorityExample()
    Dim priorityQueue As New PriorityQueue(Of String, Integer)(PriorityQueueType.Minimum)
    priorityQueue.Enqueue("cat", 2)
    priorityQueue.Enqueue("canary", 1)
    priorityQueue.Enqueue("dog", 3)

    ' There will be 3 items in the priorityQueue.
    Assert.AreEqual(priorityQueue.Count, 3)

    ' "canary" will be at the top as it has the highest priority
    Assert.AreEqual("canary", priorityQueue.Peek)
  End Sub

#End Region

#Region "DequeueWithPriority"

  <Test()> _
  Public Sub DequeueWithPriorityExample()
    Dim priorityQueue As New PriorityQueue(Of String, Integer)(PriorityQueueType.Minimum)
    priorityQueue.Enqueue("dog", 2)
    priorityQueue.Enqueue("canary", 1)
    priorityQueue.Enqueue("cat", 3)

    Dim priority As Integer

    ' Peek gives us "canary"
    Assert.AreEqual("canary", priorityQueue.Dequeue(priority))

    ' With priority 1
    Assert.AreEqual(priority, 1)

    ' Peek gives us "dog"
    Assert.AreEqual("dog", priorityQueue.Dequeue(priority))

    ' With priority 2
    Assert.AreEqual(priority, 2)

    ' Peek gives us "cat"
    Assert.AreEqual("cat", priorityQueue.Dequeue(priority))

    ' With priority 3
    Assert.AreEqual(priority, 3)
  End Sub

#End Region

#Region "GetEnumerator"
  <Test()> _
  Public Sub GetEnumeratorExample()
    Dim priorityQueue As New PriorityQueue(Of String, Integer)(PriorityQueueType.Minimum)
    priorityQueue.Enqueue("cat")
    priorityQueue.Enqueue("dog")
    priorityQueue.Enqueue("dog")
    priorityQueue.Enqueue("canary")

    ' Get the enumerator and iterate through it.
    Dim enumerator As IEnumerator(Of String) = priorityQueue.GetEnumerator
    Do While enumerator.MoveNext
      Debug.WriteLine(enumerator.Current)
    Loop
  End Sub

#End Region

#Region "GetKeyEnumerator"
  <Test()> _
  Public Sub GetKeyEnumeratorExample()
    Dim priorityQueue As New PriorityQueue(Of String, Integer)(PriorityQueueType.Minimum)
    priorityQueue.Enqueue("cat")
    priorityQueue.Enqueue("dog")
    priorityQueue.Enqueue("dog")
    priorityQueue.Enqueue("canary")
    ' Get the enumerator and iterate through it.
    Dim enumerator As IEnumerator(Of KeyValuePair(Of Integer, String)) = priorityQueue.GetKeyEnumerator
    Do While enumerator.MoveNext
      Debug.WriteLine(enumerator.Current.Key)
      Debug.WriteLine(enumerator.Current.Value)
    Loop
  End Sub

#End Region

#Region "IsReadOnly"
  <Test()> _
  Public Sub IsReadOnlyExample()
    Dim priorityQueue As New PriorityQueue(Of String, Integer)(PriorityQueueType.Minimum)

    ' IsReadOnly is always false for a PriorityQueue
    Assert.IsFalse(priorityQueue.IsReadOnly)
    priorityQueue.Enqueue("cat")
    priorityQueue.Enqueue("dog")
    priorityQueue.Enqueue("canary")
    Assert.IsFalse(priorityQueue.IsReadOnly)
  End Sub

#End Region

#Region "Peek"
  <Test()> _
  Public Sub PeekExample()
    Dim priorityQueue As New PriorityQueue(Of String, Integer)(PriorityQueueType.Minimum)
    priorityQueue.Enqueue("cat")
    ' Peek is "cat"
    Assert.AreEqual("cat", priorityQueue.Peek)
    priorityQueue.Enqueue("dog")
    ' Peek gives us "cat" because it is still the first item
    Assert.AreEqual("cat", priorityQueue.Peek)
    priorityQueue.Enqueue("canary")
    ' Peek gives us "cat" because it is still the first item
    Assert.AreEqual("cat", priorityQueue.Peek)
  End Sub

#End Region

#Region "PeekPriority"

  <Test()> _
  Public Sub PeekPriorityExample()
    Dim priorityQueue As PriorityQueue(Of String, Integer) = New PriorityQueue(Of String, Integer)(PriorityQueueType.Minimum)

    Dim priority As Integer

    priorityQueue.Enqueue("cat", 3)

    ' Peek is "cat", priority is 3
    Dim nextItem As String = priorityQueue.Peek(priority)
    Assert.AreEqual("cat", nextItem)
    Assert.AreEqual(priority, 3)

    priorityQueue.Enqueue("dog", 4)

    ' Peek gives us "cat" because it is still the first item
    nextItem = priorityQueue.Peek(priority)
    Assert.AreEqual("cat", nextItem)
    Assert.AreEqual(priority, 3)

    priorityQueue.Enqueue("canary", 2)

    ' Peek gives us "canary" since the priority is less than that of cat
    nextItem = priorityQueue.Peek(priority)
    Assert.AreEqual("canary", nextItem)
    Assert.AreEqual(priority, 2)
  End Sub

#End Region

#Region "Remove"
  <Test()> _
  Public Sub RemoveExample()
    Dim priorityQueue As New PriorityQueue(Of String, Integer)(PriorityQueueType.Minimum)

    ' Does not contain "canary"
    Assert.IsFalse(priorityQueue.Contains("canary"))
    priorityQueue.Enqueue("canary")

    ' Does contain "canary"
    Assert.IsTrue(priorityQueue.Contains("canary"))
  End Sub

#End Region
End Class

