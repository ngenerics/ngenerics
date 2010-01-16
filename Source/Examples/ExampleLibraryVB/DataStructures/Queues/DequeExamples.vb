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
Imports NGenerics.DataStructures.Queues
Imports NUnit.Framework
Imports NGenerics.Patterns.Visitor

<TestFixture()> _
Public Class DequeExamples

#Region "Accept"
  <Test()> _
  Public Sub AcceptVisitorExample()
    Dim deque As New Deque(Of String)
    deque.EnqueueHead("cat")
    deque.EnqueueHead("dog")
    deque.EnqueueHead("canary")

    ' There should be 3 items in the deque.
    Assert.AreEqual(3, deque.Count)

    ' Create a visitor that will simply count the items in the deque.
    Dim visitor As New CountingVisitor(Of String)

    ' Make deque call IVisitor<T>.Visit on all items contained.
    deque.AcceptVisitor(visitor)

    ' The counting visitor would have visited 3 items.
    Assert.AreEqual(3, visitor.Count)
  End Sub
#End Region

#Region "Clear"
  <Test()> _
  Public Sub ClearExample()
    Dim deque As New Deque(Of String)
    deque.EnqueueHead("cat")
    deque.EnqueueHead("dog")
    deque.EnqueueHead("canary")

    ' There should be 3 items in the deque.
    Assert.AreEqual(3, deque.Count)

    ' Clear the deque
    deque.Clear()

    ' The deque should be empty.
    Assert.AreEqual(0, deque.Count)

    ' No cat here..
    Assert.IsFalse(deque.Contains("cat"))
  End Sub
#End Region

#Region "ConstructorCollection"
  <Test()> _
  Public Sub ConstructorCollectionExample()
    Dim array As String() = New String() {"cat", "dog", "canary"}
    Dim deque As New Deque(Of String)(array)
    Assert.AreEqual(3, deque.Count)
  End Sub
#End Region

#Region "Constructor"
  <Test()> _
  Public Sub ConstructorExample()
    Dim deque As New Deque(Of String)
    deque.EnqueueHead("cat")
    deque.EnqueueHead("dog")
    deque.EnqueueHead("canary")
    Assert.AreEqual(3, deque.Count)
  End Sub
#End Region

#Region "Contains"
  <Test()> _
  Public Sub ContainsExample()
    Dim deque As New Deque(Of String)
    deque.EnqueueHead("cat")
    deque.EnqueueHead("dog")
    deque.EnqueueHead("canary")

    ' deque does contain cat, dog and canary
    Assert.IsTrue(deque.Contains("cat"))
    Assert.IsTrue(deque.Contains("dog"))
    Assert.IsTrue(deque.Contains("canary"))
    ' but not frog
    Assert.IsFalse(deque.Contains("frog"))
  End Sub
#End Region

#Region "CopyTo"
  <Test()> _
  Public Sub CopyToExample()
    Dim deque As New Deque(Of String)
    deque.EnqueueHead("cat")
    deque.EnqueueHead("dog")
    deque.EnqueueHead("canary")
    deque.EnqueueHead("canary")

    ' create new string array 
    ' note that the count is 4 because "canary" will exists twice.
    Dim stringArray As String() = New String(4 - 1) {}
    deque.CopyTo(stringArray, 0)
  End Sub
#End Region

#Region "Count"
  <Test()> _
  Public Sub CountExample()
    Dim deque As New Deque(Of String)
    deque.EnqueueHead("cat")
    deque.EnqueueHead("dog")
    deque.EnqueueHead("canary")
    deque.EnqueueHead("canary")

    ' Count is 4
    Assert.AreEqual(4, deque.Count)
  End Sub
#End Region

#Region "DequeueHead"
  <Test()> _
  Public Sub DequeueHeadExample()
    Dim deque As New Deque(Of String)
    deque.EnqueueHead("dog")
    deque.EnqueueHead("canary")
    deque.EnqueueHead("cat")

    ' DequeueHead gives us "cat"
    Assert.AreEqual("cat", deque.DequeueHead)

    ' DequeueHead gives us "canary"
    Assert.AreEqual("canary", deque.DequeueHead)

    ' DequeueHead gives us "dog"
    Assert.AreEqual("dog", deque.DequeueHead)
  End Sub
#End Region

#Region "DequeueTail"
  <Test()> _
  Public Sub DequeueTailExample()
    Dim deque As New Deque(Of String)
    deque.EnqueueHead("dog")
    deque.EnqueueHead("canary")
    deque.EnqueueHead("cat")

    ' DequeueTail gives us "dog"
    Assert.AreEqual("dog", deque.DequeueTail)

    ' DequeueTail gives us "canary"
    Assert.AreEqual("canary", deque.DequeueTail)

    ' DequeueTail gives us "cat"
    Assert.AreEqual("cat", deque.DequeueTail)
  End Sub
#End Region

#Region "EnqueueHead"
  <Test()> _
  Public Sub EnqueueHeadExample()
    Dim deque As New Deque(Of String)

    deque.EnqueueHead("cat")
    Assert.AreEqual("cat", deque.Head)
    Assert.AreEqual("cat", deque.Tail)

    deque.EnqueueHead("dog")
    Assert.AreEqual("dog", deque.Head)
    Assert.AreEqual("cat", deque.Tail)

    deque.EnqueueHead("canary")
    Assert.AreEqual("canary", deque.Head)
    Assert.AreEqual("cat", deque.Tail)

    ' There should be 3 items in the deque.
    Assert.AreEqual(3, deque.Count)
  End Sub
#End Region

#Region "EnqueueTail"
  <Test()> _
  Public Sub EnqueueTailExample()
    Dim deque As New Deque(Of String)

    deque.EnqueueTail("cat")
    Assert.AreEqual("cat", deque.Head)
    Assert.AreEqual("cat", deque.Tail)

    deque.EnqueueTail("dog")
    Assert.AreEqual("cat", deque.Head)
    Assert.AreEqual("dog", deque.Tail)

    deque.EnqueueTail("canary")
    Assert.AreEqual("cat", deque.Head)
    Assert.AreEqual("canary", deque.Tail)

    ' There should be 3 items in the deque.
    Assert.AreEqual(3, deque.Count)
  End Sub
#End Region

#Region "GetEnumerator"
  <Test()> _
  Public Sub GetEnumeratorExample()
    Dim deque As New Deque(Of String)
    deque.EnqueueHead("cat")
    deque.EnqueueHead("dog")
    deque.EnqueueHead("dog")
    deque.EnqueueHead("canary")

    ' Get the enumerator and iterate through it.
    Dim enumerator As IEnumerator(Of String) = deque.GetEnumerator
    Do While enumerator.MoveNext
      Debug.WriteLine(enumerator.Current)
    Loop
  End Sub
#End Region

#Region "Head"
  <Test()> _
  Public Sub HeadExample()
    Dim deque As New Deque(Of String)
    deque.EnqueueHead("cat")
    ' Head is "cat"
    Assert.AreEqual("cat", deque.Head)

    deque.EnqueueHead("dog")
    ' Head gives us "dog" because it has been put on the Head
    Assert.AreEqual("dog", deque.Head)

    deque.EnqueueTail("canary")
    ' Head gives us "dog" because "canary" has been put on the Tail
    Assert.AreEqual("dog", deque.Head)
  End Sub
#End Region

#Region "IsEmpty"
  <Test()> _
  Public Sub IsEmptyExample()
    Dim deque As New Deque(Of String)

    ' Deque will be empty initially
    Assert.IsTrue(deque.IsEmpty)

    deque.EnqueueHead("cat")

    ' Deque will be not be empty when an item is added
    Assert.IsFalse(deque.IsEmpty)
    deque.Clear()

    ' Deque will be empty when items are cleared
    Assert.IsTrue(deque.IsEmpty)
  End Sub
#End Region

#Region "IsReadOnly"
  <Test()> _
  Public Sub IsReadOnlyExample()
    Dim deque As New Deque(Of String)
    ' IsReadOnly is always false for a Deque
    Assert.IsFalse(deque.IsReadOnly)
    deque.EnqueueHead("cat")
    deque.EnqueueHead("dog")
    deque.EnqueueHead("canary")
    Assert.IsFalse(deque.IsReadOnly)
  End Sub
#End Region

#Region "Tail"
  <Test()> _
  Public Sub TailExample()
    Dim deque As New Deque(Of String)

    deque.EnqueueHead("cat")
    ' Tail is "cat"
    Assert.AreEqual("cat", deque.Tail)

    deque.EnqueueHead("dog")
    ' Tail gives "cat" because it is still the Head
    Assert.AreEqual("cat", deque.Tail)

    deque.EnqueueTail("canary")
    ' Tail gives us "cat" because it has been Enqueued to to the Tail
    Assert.AreEqual("canary", deque.Tail)
  End Sub
#End Region

End Class



