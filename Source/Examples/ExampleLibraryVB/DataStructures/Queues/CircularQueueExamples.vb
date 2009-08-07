'  
' Copyright 2009 The NGenerics Team
' (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)
'
' This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
' have received a copy of the license along with the source code.  If not, an online copy
' of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
'

Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports NGenerics.DataStructures.Queues
Imports NUnit.Framework
Imports NGenerics.Patterns.Visitor

<TestFixture()> _
Public Class CircularQueueExamples

#Region "Accept"
  <Test()> _
  Public Sub AcceptExample()
    Dim circularQueue As New CircularQueue(Of String)(10)
    circularQueue.Enqueue("cat")
    circularQueue.Enqueue("dog")
    circularQueue.Enqueue("canary")
    ' There should be 3 items in the circularQueue.
    Assert.AreEqual(circularQueue.Count, 3)

    ' Create a visitor that will simply count the items in the circularQueue.
    Dim visitor As New CountingVisitor(Of String)

    ' Make circularQueue call IVisitor<T>.Visit on all items contained.
    circularQueue.AcceptVisitor(visitor)

    ' The counting visitor would have visited 3 items.
    Assert.AreEqual(visitor.Count, 3)
  End Sub
#End Region


#Region "Capacity"
  <Test()> _
  Public Sub CapacityExample()
    Dim circularQueue As New CircularQueue(Of String)(3)

    ' Capacity is 3
    Assert.AreEqual(3, circularQueue.Capacity)

    ' Since Capacity is 3 the maximum items existing in the CircularQueue will be 3
    circularQueue.Enqueue("cat")
    circularQueue.Enqueue("dog")
    circularQueue.Enqueue("canary")
    circularQueue.Enqueue("frog")
    circularQueue.Enqueue("snake")
    Assert.AreEqual(3, circularQueue.Count)
  End Sub

#End Region


#Region "Clear"
  <Test()> _
  Public Sub ClearExample()
    Dim circularQueue As New CircularQueue(Of String)(10)
    circularQueue.Enqueue("cat")
    circularQueue.Enqueue("dog")
    circularQueue.Enqueue("canary")

    ' There should be 3 items in the circularQueue.
    Assert.AreEqual(circularQueue.Count, 3)

    ' Clear the circularQueue
    circularQueue.Clear()

    ' The circularQueue should be empty.
    Assert.AreEqual(circularQueue.Count, 0)

    ' No cat here..
    Assert.IsFalse(circularQueue.Contains("cat"))
  End Sub

#End Region


#Region "Constructor"
  <Test()> _
  Public Sub ConstructorExample()
    Dim circularQueue As New CircularQueue(Of String)(10)
    circularQueue.Enqueue("cat")
    circularQueue.Enqueue("dog")
    circularQueue.Enqueue("canary")
  End Sub

#End Region


#Region "Contains"
  <Test()> _
  Public Sub ContainsExample()
    Dim circularQueue As New CircularQueue(Of String)(10)
    circularQueue.Enqueue("cat")
    circularQueue.Enqueue("dog")
    circularQueue.Enqueue("canary")

    ' circularQueue does contain cat, dog and canary
    Assert.IsTrue(circularQueue.Contains("cat"))
    Assert.IsTrue(circularQueue.Contains("dog"))
    Assert.IsTrue(circularQueue.Contains("canary"))
    ' but not frog
    Assert.IsFalse(circularQueue.Contains("frog"))
  End Sub

#End Region


#Region "CopyTo"
  <Test()> _
  Public Sub CopyToExample()
    Dim circularQueue As New CircularQueue(Of String)(10)
    circularQueue.Enqueue("cat")
    circularQueue.Enqueue("dog")
    circularQueue.Enqueue("canary")
    circularQueue.Enqueue("canary")

    ' create new string array 
    ' note that the count is 4 because "canary" will exists twice.
    Dim stringArray As String() = New String(3) {}
    circularQueue.CopyTo(stringArray, 0)
  End Sub

#End Region


#Region "Count"
  <Test()> _
  Public Sub CountExample()
    Dim circularQueue As New CircularQueue(Of String)(10)
    circularQueue.Enqueue("cat")
    circularQueue.Enqueue("dog")
    circularQueue.Enqueue("canary")
    circularQueue.Enqueue("canary")

    ' Count is 4
    Assert.AreEqual(4, circularQueue.Count)
  End Sub

#End Region


#Region "Enqueue"
  <Test()> _
  Public Sub EnqueueExample()
    Dim circularQueue As New CircularQueue(Of String)(10)
    circularQueue.Enqueue("cat")
    circularQueue.Enqueue("dog")
    circularQueue.Enqueue("canary")

    ' There should be 3 items in the circularQueue.
    Assert.AreEqual(circularQueue.Count, 3)
  End Sub

#End Region

#Region "Dequeue"
  <Test()> _
  Public Sub DequeueExample()
    Dim circularQueue As New CircularQueue(Of String)(10)
    circularQueue.Enqueue("dog")
    circularQueue.Enqueue("canary")
    circularQueue.Enqueue("cat")

    ' Dequeue gives us "dog"
    Assert.AreEqual("dog", circularQueue.Dequeue())

    ' Dequeue gives us "canary"
    Assert.AreEqual("canary", circularQueue.Dequeue)

    ' Dequeue gives us "cat"
    Assert.AreEqual("cat", circularQueue.Dequeue)
  End Sub




#End Region

#Region "GetEnumerator"
  <Test()> _
  Public Sub GetEnumeratorExample()
    Dim circularQueue As New CircularQueue(Of String)(10)
    circularQueue.Enqueue("cat")
    circularQueue.Enqueue("dog")
    circularQueue.Enqueue("dog")
    circularQueue.Enqueue("canary")

    ' Get the enumerator and iterate through it.
    Dim enumerator As IEnumerator(Of String) = circularQueue.GetEnumerator
    Do While enumerator.MoveNext
      Debug.WriteLine(enumerator.Current)
    Loop
  End Sub

#End Region


#Region "IsEmpty"
  <Test()> _
  Public Sub IsEmptyExample()
    Dim circularQueue As New CircularQueue(Of String)(10)

    ' CircularQueue will be empty initially
    Assert.IsTrue(circularQueue.IsEmpty)
    circularQueue.Enqueue("cat")

    ' CircularQueue will be not be empty when an item is added
    Assert.IsFalse(circularQueue.IsEmpty)
    circularQueue.Clear()

    ' CircularQueue will be empty when items are cleared
    Assert.IsTrue(circularQueue.IsEmpty)
  End Sub

#End Region


#Region "IsFull"
    <Test()> _
    Public Sub IsFullExample()
        Dim circularQueue As New CircularQueue(Of String)(3)


        ' IsFull is false
        Assert.IsFalse(circularQueue.IsFull)

        ' Enqueue 3 items
        circularQueue.Enqueue("cat")
        circularQueue.Enqueue("dog")
        circularQueue.Enqueue("canary")
        Assert.IsTrue(circularQueue.IsFull)
    End Sub

#End Region


#Region "IsReadOnly"
    <Test()> _
    Public Sub IsReadOnlyExample()
        Dim circularQueue As New CircularQueue(Of String)(10)
        ' IsReadOnly is always false for a CircularQueue
        Assert.IsFalse(circularQueue.IsReadOnly)
        circularQueue.Enqueue("cat")
        circularQueue.Enqueue("dog")
        circularQueue.Enqueue("canary")
        Assert.IsFalse(circularQueue.IsReadOnly)
    End Sub

#End Region


#Region "Peek"
    <Test()> _
    Public Sub PeekExample()
        Dim circularQueue As New CircularQueue(Of String)(10)
        circularQueue.Enqueue("cat")
        ' Peek is "cat"
        Assert.AreEqual("cat", circularQueue.Peek)
        circularQueue.Enqueue("dog")
        ' Peek gives us "cat" because it is still the first item
        Assert.AreEqual("cat", circularQueue.Peek)
        circularQueue.Enqueue("canary")
        ' Peek gives us "cat" because it is still the first item
        Assert.AreEqual("cat", circularQueue.Peek)
    End Sub

#End Region


#Region "Remove"
    <Test()> _
  Public Sub RemoveExample()
        Dim circularQueue As New CircularQueue(Of String)(10)
        circularQueue.Enqueue("dog")
        circularQueue.Enqueue("canary")
        circularQueue.Enqueue("cat")

        ' Does not contain "canary"
        Assert.IsTrue(circularQueue.Contains("canary"))

        ' Remove "canary". Not that this remove the first item it finds 
        circularQueue.Remove("canary")

        ' Does contain "canary"
        Assert.IsFalse(circularQueue.Contains("canary"))
    End Sub
#End Region

End Class