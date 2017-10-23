'  
' Copyright 2007-2017 The NGenerics Team
' (https://github.com/ngenerics/ngenerics/wiki/Team)
'
' This program is licensed under the MIT License.  You should 
' have received a copy of the license along with the source code.  If not, an online copy
' of the license can be found at https://opensource.org/licenses/MIT.
'

Imports System
Imports System.Collections.Generic
Imports NGenerics.DataStructures.General
Imports NUnit.Framework
Imports NGenerics.Patterns.Visitor

<TestFixture()> _
Public Class PascalSetExamples
#Region "Accept"
  <Test()> _
  Public Sub AcceptExample()
    ' Create a sample PascalSet instance
    Dim pascalSet As New PascalSet(100)
    For i As Integer = 0 To 99 Step 10

      ' Set a couple of values in the PascalSet
      pascalSet.Add(i)
    Next

    ' Create a counting visitor that will count the number of 
    ' items visited.
    Dim visitor As New CountingVisitor(Of Integer)()

    ' Open up the door for the visitor
    pascalSet.AcceptVisitor(visitor)

    ' The visitor will have visited 10 items
    Assert.AreEqual(visitor.Count, 10)
  End Sub
#End Region

#Region "Add"
  <Test()> _
  Public Sub AddExample()
    ' Create a sample PascalSet instance
    Dim pascalSet As New PascalSet(100)

    ' Add the 10th item to the set
    pascalSet.Add(10)

    ' Add the 57th item to the set
    pascalSet.Add(57)

    ' There will be two items in the set
    Assert.AreEqual(pascalSet.Count, 2)

    ' And the set will contain the 10th and 57th item
    Assert.IsTrue(pascalSet.Contains(10))
    Assert.IsTrue(pascalSet.Contains(57))
  End Sub
#End Region


#Region "Capacity"
  <Test()> _
  Public Sub CapacityExample()
    ' Create a sample PascalSet instance
    Dim pascalSet As New PascalSet(90, 100)
    Assert.AreEqual(pascalSet.Capacity, 11)
  End Sub
#End Region

#Region "Clear"
  <Test()> _
  Public Sub ClearExample()
    ' Create a sample PascalSet instance
    Dim pascalSet As New PascalSet(100)

    ' Add the 10th item to the set
    pascalSet.Add(10)

    ' Add the 57th item to the set
    pascalSet.Add(57)

    ' There will be two items in the set
    Assert.AreEqual(pascalSet.Count, 2)

    ' Remove all items from the set
    pascalSet.Clear()

    ' There will be no items left in the set
    Assert.AreEqual(pascalSet.Count, 0)
  End Sub
#End Region

#Region "Contains"
  <Test()> _
  Public Sub ContainsExample()
    ' Create a sample PascalSet instance
    Dim pascalSet As New PascalSet(100)

    ' Add the 10th item to the set
    pascalSet.Add(10)

    ' Add the 57th item to the set
    pascalSet.Add(57)

    ' There will be two items in the set
    Assert.AreEqual(pascalSet.Count, 2)

    ' And the set will contain the 10th and 57th item
    Assert.IsTrue(pascalSet.Contains(10))
    Assert.IsTrue(pascalSet.Contains(57))

    ' But not the item 84
    Assert.IsFalse(pascalSet.Contains(84))
  End Sub
#End Region

#Region "Count"
  <Test()> _
  Public Sub CountExample()
    ' Create a sample PascalSet instance
    Dim pascalSet As New PascalSet(100)

    ' Add the 10th item to the set
    pascalSet.Add(10)

    ' There will be one item in the set
    Assert.AreEqual(pascalSet.Count, 1)

    ' Add the 57th item to the set
    pascalSet.Add(57)

    ' There will be two items in the set
    Assert.AreEqual(pascalSet.Count, 2)

    ' Clear the set, thereby removing all items
    pascalSet.Clear()

    ' There will be no items left in the set
    Assert.AreEqual(pascalSet.Count, 0)
  End Sub
#End Region

#Region "CopyTo"
  <Test()> _
  Public Sub CopyToExample()
    ' Create a sample PascalSet instance
    Dim pascalSet As New PascalSet(100)
    For i As Integer = 0 To 99 Step 10

      ' Set a couple of values in the PascalSet
      pascalSet.Add(i)
    Next

    ' Create an array to store the items in
    Dim values As Integer() = New Integer(9) {}

    ' Copy the items in the set to the array, at index 0
    pascalSet.CopyTo(values, 0)
  End Sub
#End Region

#Region "GetEnumerator"
  <Test()> _
  Public Sub GetEnumeratorExample()
    Dim pascalSet As New PascalSet(100)
    For i As Integer = 0 To 99 Step 10

      ' Set a couple of values in the PascalSet
      pascalSet.Add(i)
    Next

    ' Enumerate over the items in the PascalSet,
    ' printing them to the standard console
    Using enumerator As IEnumerator(Of Integer) = pascalSet.GetEnumerator()
      While enumerator.MoveNext()
        Console.WriteLine(enumerator.Current)
      End While
    End Using
  End Sub
#End Region

#Region "Intersection"
  <Test()> _
  Public Sub IntersectionExample()
    ' Create a sample PascalSet
    Dim set1 As New PascalSet(100)
    For i As Integer = 0 To 99 Step 10

      ' Set a couple of values in the PascalSet
      set1.Add(i)
    Next

    ' Create another sample PascalSet
    Dim set2 As New PascalSet(100)

    ' Set a couple of random values in the second set
    set2.Add(4)
    set2.Add(6)
    set2.Add(7)
    set2.Add(10)
    set2.Add(30)

    ' Get the intersection of the two sets
    Dim intersection As PascalSet = set1.Intersection(set2)

    ' The intersection will contain values that was
    ' contained in both sets.
    Assert.IsTrue(intersection(10))
    Assert.IsTrue(intersection(30))
    Assert.AreEqual(intersection.Count, 2)
  End Sub
#End Region

#Region "Inverse"
  <Test()> _
  Public Sub InverseExample()
    ' Create a sample PascalSet
    Dim pascalSet As New PascalSet(100)
    For i As Integer = 0 To 99 Step 10

      ' Set a couple of values in the PascalSet
      pascalSet.Add(i)
    Next

    ' Get the inverse of the set
    Dim inverse As PascalSet = pascalSet.Inverse()
    For i As Integer = 0 To 99

      ' All the items that were not included in the original
      ' set will be in the inverse.
      If (i Mod 10) > 0 Then
        Assert.IsTrue(inverse(i))
      End If
    Next

    ' We'll have 91 items in the set (101 - 10)
    Assert.AreEqual(inverse.Count, 91)
  End Sub
#End Region

#Region "IsEmpty"
  <Test()> _
  Public Sub IsEmptyExample()
    ' Create a sample PascalSet
    Dim pascalSet As New PascalSet(100)

    ' The PascalSet will initially be empty
    Assert.IsTrue(pascalSet.IsEmpty)
    For i As Integer = 0 To 99 Step 10

      ' Add a couple of values in the PascalSet
      pascalSet.Add(i)
    Next

    ' Not empty anymore...
    Assert.IsFalse(pascalSet.IsEmpty)

    ' Clear the PascalSet, making it empty once more.
    pascalSet.Clear()
    Assert.IsTrue(pascalSet.IsEmpty)
  End Sub
#End Region

#Region "IsFull"
  <Test()> _
  Public Sub IsFullExample()
    ' Create a sample PascalSet with a capacity of
    ' 100 items (1 - 100)
    Dim pascalSet As New PascalSet(1, 100)

    ' The set is initially empty
    Assert.IsFalse(pascalSet.IsFull)
    For i As Integer = 1 To 100

      ' The IsFull Property only returns true when every
      ' possible item in the set's universe has been added
      ' to the set.  We add some items to illustrate.
      pascalSet.Add(i)
    Next

    ' The set contains 100 items - thus, it's full
    Assert.AreEqual(pascalSet.Count, 100)
    Assert.IsTrue(pascalSet.IsFull)
  End Sub
#End Region

#Region "IsProperSubsetOf"
  <Test()> _
  Public Sub IsProperSubsetOfExample()
    ' Create 3 pascal sets with various items
    Dim s1 As New PascalSet(0, 50, New Integer() {15, 20, 30, 40, 34})
    Dim s2 As New PascalSet(0, 50, New Integer() {15, 20, 30})
    Dim s3 As New PascalSet(0, 50, New Integer() {15, 20, 30, 40, 34})

    ' s1 is not a proper subset of s2
    Assert.IsFalse(s1.IsProperSubsetOf(s2))

    ' s2 is a proper subset of s1
    Assert.IsTrue(s2.IsProperSubsetOf(s1))

    ' s3 is not a proper subset of s1
    Assert.IsFalse(s3.IsProperSubsetOf(s1))

    ' s1 is a proper subset of s3
    Assert.IsFalse(s1.IsProperSubsetOf(s3))
  End Sub
#End Region

#Region "IsProperSupersetOf"
  <Test()> _
  Public Sub IsProperSupersetOfExample()
    ' Create 3 pascal sets with various items
    Dim s1 As New PascalSet(0, 50, New Integer() {15, 20, 30, 40, 34})
    Dim s2 As New PascalSet(0, 50, New Integer() {15, 20, 30})
    Dim s3 As New PascalSet(0, 50, New Integer() {15, 20, 30, 40, 34})

    ' s1 is a proper superset of s2
    Assert.IsTrue(s1.IsProperSupersetOf(s2))

    ' s2 is not a proper superset of s1
    Assert.IsFalse(s2.IsProperSupersetOf(s1))

    ' s3 is not a proper subset of s1
    Assert.IsFalse(s3.IsProperSupersetOf(s1))

    ' s1 is also not a proper subset of s3
    Assert.IsFalse(s1.IsProperSupersetOf(s3))
  End Sub
#End Region

#Region "IsReadOnly"
  <Test()> _
  Public Sub IsReadOnlyExample()
    ' Create a sample PascalSet
    Dim pascalSet As New PascalSet(100)

    ' The IsReadOnly property of the PascalSet
    ' always returns false.
    Assert.IsFalse(pascalSet.IsReadOnly)
  End Sub
#End Region

#Region "IsSubsetOf"
  <Test()> _
  Public Sub IsSubsetOfExample()
    ' Create 3 pascal sets with various items
    Dim s1 As New PascalSet(0, 50, New Integer() {15, 20, 30, 40, 34})
    Dim s2 As New PascalSet(0, 50, New Integer() {15, 20, 30})
    Dim s3 As New PascalSet(0, 50, New Integer() {15, 20, 30, 40, 34})

    ' s1 is not a subset of s2
    Assert.IsFalse(s1.IsSubsetOf(s2))

    ' s2 is a subset of s1
    Assert.IsTrue(s2.IsSubsetOf(s1))

    ' s3 is a subset of s1
    Assert.IsTrue(s3.IsSubsetOf(s1))

    ' s1 is a subset of s3
    Assert.IsTrue(s1.IsSubsetOf(s3))
  End Sub
#End Region

#Region "IsSupersetOf"
  <Test()> _
  Public Sub IsSupersetOfExample()
    ' Create 3 pascal sets with various items
    Dim s1 As New PascalSet(0, 50, New Integer() {15, 20, 30, 40, 34})
    Dim s2 As New PascalSet(0, 50, New Integer() {15, 20, 30})
    Dim s3 As New PascalSet(0, 50, New Integer() {15, 20, 30, 40, 34})

    ' s1 is a superset of s2
    Assert.IsTrue(s1.IsSupersetOf(s2))

    ' s2 is not a superset of s1
    Assert.IsFalse(s2.IsSupersetOf(s1))

    ' s3 is a superset of s1
    Assert.IsTrue(s3.IsSupersetOf(s1))

    ' s1 is a superset of s3
    Assert.IsTrue(s1.IsSupersetOf(s3))
  End Sub
#End Region

#Region "LowerBound"
  <Test()> _
  Public Sub LowerBoundExample()
    ' Create a sample PascalSet, with a lower bound
    ' of 50, and an upper bound of 100
    Dim pascalSet As New PascalSet(50, 100)

    ' The lower bound will be 50
    Assert.AreEqual(pascalSet.LowerBound, 50)
  End Sub
#End Region

#Region "UpperBound"
  <Test()> _
  Public Sub UpperBoundExample()
    ' Create a sample PascalSet, with a lower bound
    ' of 50, and an upper bound of 100
    Dim pascalSet As New PascalSet(50, 100)

    ' The upper bound will be 100
    Assert.AreEqual(pascalSet.UpperBound, 100)
  End Sub
#End Region

#Region "Remove"
  <Test()> _
  Public Sub RemoveExample()
    ' Create a sample PascalSet, with a lower bound
    ' of 1, and an upper bound of 100
    Dim pascalSet As New PascalSet(0, 100)
    For i As Integer = 0 To 99 Step 10

      ' Add a couple items to the set
      pascalSet.Add(i)
    Next

    ' There should be 10 items in the set
    Assert.AreEqual(pascalSet.Count, 10)

    ' Remove 30 from the set
    Dim success As Boolean = pascalSet.Remove(30)

    ' The item would have been removed
    Assert.IsTrue(success)

    ' There should be 9 items in the set now
    Assert.AreEqual(pascalSet.Count, 9)

    ' Try and remove an item not in the set
    success = pascalSet.Remove(15)

    ' Which, of course, wouldn't be successful
    Assert.IsFalse(success)
  End Sub
#End Region

#Region "Subtract"
  <Test()> _
  Public Sub SubtractExample()
    ' Create 2 pascal sets with various items
    Dim s1 As New PascalSet(0, 50, New Integer() {15, 20, 30, 40, 34})
    Dim s2 As New PascalSet(0, 50, New Integer() {15, 20, 30})

    ' Subtract s2 from s1, obtaining another PascalSet
    Dim result As PascalSet = s1.Subtract(s2)

    ' There will only be two items in the result
    Assert.AreEqual(result.Count, 2)

    ' And those items will be 40, and 34
    Assert.IsTrue(result(40))
    Assert.IsTrue(result(34))
  End Sub
#End Region

#Region "Union"
  <Test()> _
  Public Sub UnionExample()
    ' Create 2 pascal sets with various items
    Dim s1 As New PascalSet(0, 50, New Integer() {15, 20, 30, 40, 34})
    Dim s2 As New PascalSet(0, 50, New Integer() {3, 4, 20})

    ' Compute the union of set s1 and s2
    Dim union As PascalSet = s1.Union(s2)

    ' The union will consist of the following items :
    ' { 3, 4, 15, 20, 30, 50, 34 }
    Assert.AreEqual(union.Count, 7)
    Assert.IsTrue(union(3))
    Assert.IsTrue(union(4))
    Assert.IsTrue(union(15))
    Assert.IsTrue(union(20))
    Assert.IsTrue(union(30))
    Assert.IsTrue(union(40))
    Assert.IsTrue(union(34))
  End Sub
#End Region
End Class
