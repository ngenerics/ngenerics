'  
' Copyright 2007-2009 The NGenerics Team
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
Public Class BagExamples


#Region "Accept"
  <Test()> _
  Public Sub AcceptExample()
    Dim bag As New Bag(Of String)
    bag.Add("cat")
    bag.Add("dog")
    bag.Add("canary")

    ' There should be 3 items in the bag.
    Assert.AreEqual(bag.Count, 3)

    ' Create a visitor that will simply count the items in the bag.
    Dim visitor As New CountingVisitor(Of String)

    ' Make bag call IVisitor<T>.Visit on all items contained.
    'TODO: Fix
        VisitorExtensions.AcceptVisitor(Of String)(bag, visitor)


    ' The counting visitor would have visited 3 items.
    Assert.AreEqual(visitor.Count, 3)
  End Sub

#End Region


#Region "AddAmount"
  <Test()> _
  Public Sub AddAmountExample()
    Dim bag As New Bag(Of String)
    bag.Add("cat")
    bag.Add("dog", 2)
    bag.Add("canary")

    ' There are 4 items in the bag.
    Assert.AreEqual(4, bag.Count)

    ' There are 2 "dog"s in the bag.
    Assert.AreEqual(2, bag.Item("dog"))
  End Sub

#End Region


#Region "Add"
  <Test()> _
  Public Sub AddExample()
    Dim bag As New Bag(Of String)
    bag.Add("cat")
    bag.Add("dog")
    bag.Add("canary")

    ' There should be 3 items in the bag.
    Assert.AreEqual(bag.Count, 3)
  End Sub

#End Region


#Region "ConstructorCapacity"
  <Test()> _
  Public Sub ConstructorCapacity() 'Example()
    Dim bag As New Bag(Of String)(3)
    bag.Add("cat")
    bag.Add("dog")
    bag.Add("canary")
  End Sub

#End Region


#Region "Clear"
  <Test()> _
  Public Sub ClearExample()
    Dim bag As New Bag(Of String)
    bag.Add("cat")
    bag.Add("dog")
    bag.Add("canary")

    ' There should be 3 items in the bag.
    Assert.AreEqual(bag.Count, 3)

    ' Clear the bag
    bag.Clear()

    ' The bag should be empty.
    Assert.AreEqual(bag.Count, 0)

    ' No cat here..
    Assert.IsFalse(bag.Contains("cat"))
  End Sub

#End Region


#Region "ConstructorComparer"
  <Test()> _
  Public Sub ConstructorComparerExample()
    Dim bagIgnoreCase As New Bag(Of String)(StringComparer.OrdinalIgnoreCase)
    bagIgnoreCase.Add("cat")
    bagIgnoreCase.Add("dog")
    bagIgnoreCase.Add("CAT")

    ' "CAT" will have a count of 2 because case is ignored
    Assert.AreEqual(2, bagIgnoreCase.Item("CAT"))


    Dim bagUseCase As New Bag(Of String)
    bagUseCase.Add("cat")
    bagUseCase.Add("dog")
    bagUseCase.Add("CAT")

    ' "CAT" will have a count of 1 because case is not ignored
    Assert.AreEqual(2, bagIgnoreCase.Item("CAT"))
  End Sub

#End Region


#Region "Constructor"
  <Test()> _
  Public Sub ConstructorExample()
    Dim bag As New Bag(Of String)
    bag.Add("cat")
    bag.Add("dog")
    bag.Add("canary")
  End Sub

#End Region


#Region "Contains"
  <Test()> _
  Public Sub ContainsExample()
    Dim bag As New Bag(Of String)
    bag.Add("cat")
    bag.Add("dog")
    bag.Add("canary")

    ' bag does contain cat, dog and canary
    Assert.IsTrue(bag.Contains("cat"))
    Assert.IsTrue(bag.Contains("dog"))
    Assert.IsTrue(bag.Contains("canary"))

    ' but not frog
    Assert.IsFalse(bag.Contains("frog"))
  End Sub

#End Region


#Region "CopyTo"
  <Test()> _
  Public Sub CopyToExample()
    Dim bag As New Bag(Of String)
    bag.Add("cat")
    bag.Add("dog")
    bag.Add("canary")
    bag.Add("canary")

    ' create new string array 
    ' note that the count is 4 because "canary" will exists twice.
    Dim stringArray As String() = New String(4 - 1) {}
    bag.CopyTo(stringArray, 0)
  End Sub

#End Region


#Region "Count"
  <Test()> _
  Public Sub CountExample()
    Dim bag As New Bag(Of String)
    bag.Add("cat")
    bag.Add("dog")
    bag.Add("canary")
    bag.Add("canary")

    ' Count is 4
    Assert.AreEqual(4, bag.Count)
  End Sub

#End Region


#Region "Equals"
  <Test()> _
  Public Sub EqualsExample()

    Dim bag1 As New Bag(Of String)
    bag1.Add("cat")
    bag1.Add("dog")
    bag1.Add("canary")

    Dim bag2 As New Bag(Of String)
    bag2.Add("cat")
    bag2.Add("dog")
    bag2.Add("canary")

    ' bag1 is "Equal" to bag2
    Assert.IsTrue(bag1.Equals(bag2))
  End Sub

#End Region


#Region "GetEnumerator"
  <Test()> _
  Public Sub GetEnumeratorExample()
    Dim bag As New Bag(Of String)
    bag.Add("cat")
    bag.Add("dog")
    bag.Add("dog")
    bag.Add("canary")

    ' Get the enumerator and iterate through it.
    Dim enumerator As IEnumerator(Of String) = bag.GetEnumerator
    Do While enumerator.MoveNext
      Debug.WriteLine(enumerator.Current)
    Loop
  End Sub

#End Region


#Region "Intersection"
  <Test()> _
  Public Sub IntersectionExample()
    Dim bag1 As New Bag(Of String)
    bag1.Add("cat")
    bag1.Add("dog")
    bag1.Add("dog")
    bag1.Add("canary")
    Dim bag2 As New Bag(Of String)
    bag2.Add("cat")
    bag2.Add("cat")
    bag2.Add("dog")
    bag2.Add("dog")
    bag2.Add("canary")

    Dim intersectionBag As Bag(Of String) = bag1.Intersection(bag2)

    ' Bag contains 2 "dog"s, 1 "cat"s and 1 "canary".
    Assert.AreEqual(2, intersectionBag.Item("dog"))
    Assert.AreEqual(1, intersectionBag.Item("cat"))
    Assert.AreEqual(1, intersectionBag.Item("canary"))
  End Sub

#End Region


#Region "IsEmpty"
  <Test()> _
  Public Sub IsEmptyExample()

    Dim bag As New Bag(Of String)

    ' Bag will be empty initially
    Assert.IsTrue(bag.IsEmpty)
    bag.Add("cat")

    ' Bag will be not be empty when an item is added
    Assert.IsFalse(bag.IsEmpty)
    bag.Clear()

    ' Bag will be empty when items are cleared
    Assert.IsTrue(bag.IsEmpty)
  End Sub

#End Region


#Region "IsReadOnly"
    <Test()> _
    Public Sub IsReadOnlyExample()
        Dim bag As New Bag(Of String)

        ' IsReadOnly is always false for a Bag
        Assert.IsFalse(bag.IsReadOnly)
        bag.Add("cat")
        bag.Add("dog")
        bag.Add("canary")
        Assert.IsFalse(bag.IsReadOnly)
    End Sub

#End Region


#Region "Item"
  <Test()> _
  Public Sub ItemExample()
    Dim bag As New Bag(Of String)
    bag.Add("cat")
    bag.Add("dog")
    bag.Add("dog")
    bag.Add("canary")

    ' bag contains 1 "cat", 2 "dog"s and 1 "canary.
    Assert.AreEqual(1, bag.Item("cat"))
    Assert.AreEqual(2, bag.Item("dog"))
    Assert.AreEqual(1, bag.Item("canary"))
  End Sub

#End Region


#Region "OperatorAdd"
  <Test()> _
  Public Sub OperatorAddExample()

    Dim bag1 As New Bag(Of String)
    bag1.Add("cat")
    bag1.Add("dog")
    bag1.Add("dog")
    bag1.Add("canary")

    Dim bag2 As New Bag(Of String)
    bag2.Add("cat")
    bag2.Add("cat")
    bag2.Add("dog")
    bag2.Add("dog")
    bag2.Add("canary")

    Dim unionBag As Bag(Of String) = (bag1 + bag2)

    ' Bag contains 4 "dog"s, 3 "cat"s and 2 "canary"s.
    Assert.AreEqual(4, unionBag.Item("dog"))
    Assert.AreEqual(3, unionBag.Item("cat"))
    Assert.AreEqual(2, unionBag.Item("canary"))
  End Sub

#End Region


#Region "OperatorMultiply"
  <Test()> _
  Public Sub OperatorMultiplyExample()

    Dim bag1 As New Bag(Of String)
    bag1.Add("cat")
    bag1.Add("dog")
    bag1.Add("dog")
    bag1.Add("canary")

    Dim bag2 As New Bag(Of String)
    bag2.Add("cat")
    bag2.Add("cat")
    bag2.Add("dog")
    bag2.Add("dog")
    bag2.Add("canary")

    Dim multipliedBag As Bag(Of String) = (bag1 * bag2)

    ' Bag contains 2 "dog"s, 1 "cat"s and 1 "canary".
    Assert.AreEqual(2, multipliedBag.Item("dog"))
    Assert.AreEqual(1, multipliedBag.Item("cat"))
    Assert.AreEqual(1, multipliedBag.Item("canary"))
  End Sub

#End Region


#Region "OperatorSubtract"
  <Test()> _
  Public Sub OperatorSubtractExample()

    Dim bag1 As New Bag(Of String)
    bag1.Add("cat")
    bag1.Add("dog")
    bag1.Add("dog")
    bag1.Add("canary")

    Dim bag2 As New Bag(Of String)
    bag2.Add("cat")
    bag2.Add("dog")

    Dim subtractBag As Bag(Of String) = (bag1 - bag2)

    ' Bag contains 1 "dog", 0 "cat"s and 1 "canary".
    Assert.AreEqual(1, subtractBag.Item("dog"))
    Assert.AreEqual(0, subtractBag.Item("cat"))
    Assert.AreEqual(1, subtractBag.Item("canary"))
  End Sub

#End Region


#Region "RemoveAll"
  <Test()> _
  Public Sub RemoveAllExample()

    Dim bag As New Bag(Of String)
    bag.Add("cat")
    bag.Add("dog")
    bag.Add("dog")
    bag.Add("canary")

    ' Bag contains 2 "dog"s
    Assert.AreEqual(2, bag.Item("dog"))

    ' Remove "dog"
    bag.RemoveAll("dog")

    ' Bag contains 0 "dog"
    Assert.AreEqual(0, bag.Item("dog"))
  End Sub

#End Region


#Region "Remove"
  <Test()> _
  Public Sub RemoveExample()

    Dim bag As New Bag(Of String)
    bag.Add("cat")
    bag.Add("dog")
    bag.Add("dog")
    bag.Add("canary")

    ' Bag contains 2 "dog"
    Assert.AreEqual(2, bag.Item("dog"))

    ' Remove a "dog"
    bag.Remove("dog")

    ' Bag contains 1 "dog"
    Assert.AreEqual(1, bag.Item("dog"))

    ' Remove a "dog"
    bag.Remove("dog")

    ' Bag contains 0 "dog"
    Assert.AreEqual(0, bag.Item("dog"))
  End Sub

#End Region


#Region "RemoveMaximum"
  <Test()> _
  Public Sub RemoveMaximumExample()

    Dim bag As New Bag(Of String)
    bag.Add("cat")
    bag.Add("dog")
    bag.Add("dog")
    bag.Add("dog")
    bag.Add("canary")

    ' Bag contains 3 "dog"s
    Assert.AreEqual(3, bag.Item("dog"))

    ' Remove 2 "dog"s
    bag.Remove("dog", 2)

    ' Bag contains 1 "dog"
    Assert.AreEqual(1, bag.Item("dog"))
  End Sub

#End Region


#Region "Subtract"
  <Test()> _
  Public Sub SubtractExample()

    Dim bag1 As New Bag(Of String)
    bag1.Add("cat")
    bag1.Add("dog")
    bag1.Add("dog")
    bag1.Add("canary")

    Dim bag2 As New Bag(Of String)
    bag2.Add("cat")
    bag2.Add("dog")

    Dim subtractBag As Bag(Of String) = bag1.Subtract(bag2)

    ' Bag contains 1 "dog", 0 "cat"s and 1 "canary".
    Assert.AreEqual(1, subtractBag.Item("dog"))
    Assert.AreEqual(0, subtractBag.Item("cat"))
    Assert.AreEqual(1, subtractBag.Item("canary"))
  End Sub

#End Region


#Region "Union"
  <Test()> _
  Public Sub UnionExample()

    Dim bag1 As New Bag(Of String)
    bag1.Add("cat")
    bag1.Add("dog")
    bag1.Add("dog")
    bag1.Add("canary")

    Dim bag2 As New Bag(Of String)
    bag2.Add("cat")
    bag2.Add("cat")
    bag2.Add("dog")
    bag2.Add("dog")
    bag2.Add("canary")

    Dim unionBag As Bag(Of String) = bag1.Union(bag2)

    ' Bag contains 4 "dog"s, 3 "cat"s and 2 "canary"s.
    Assert.AreEqual(4, unionBag.Item("dog"))
    Assert.AreEqual(3, unionBag.Item("cat"))
    Assert.AreEqual(2, unionBag.Item("canary"))
  End Sub

#End Region

End Class


