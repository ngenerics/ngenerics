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
Imports NGenerics.DataStructures.General
Imports NUnit.Framework
Imports NGenerics.Patterns.Visitor

<TestFixture()> _
Public Class SkipListExamples

#Region "Accept"
  <Test()> _
  Public Sub AcceptExample()
    Dim skipList As New SkipList(Of String, Integer)
    skipList.Add("cat", 1)
    skipList.Add("dog", 2)
    skipList.Add("canary", 3)

    ' There should be 3 items in the SkipList.
    Assert.AreEqual(skipList.Count, 3)

    ' Create a visitor that will simply count the items in the skipList.
    Dim visitor As New CountingVisitor(Of KeyValuePair(Of String, Integer))

    ' Make the skipList call IVisitor<T>.Visit on all items contained.
    skipList.AcceptVisitor(visitor)

    ' The counting visitor would have visited 3 items.
    Assert.AreEqual(visitor.Count, 3)
  End Sub

#End Region


#Region "Add"
  <Test()> _
  Public Sub AddExample()
    Dim skipList As New SkipList(Of String, Integer)
    skipList.Add("cat", 1)
    skipList.Add("dog", 2)
    skipList.Add("canary", 3)

    ' There will be 3 items in the skipList.
    Assert.AreEqual(skipList.Count, 3)
  End Sub

#End Region


#Region "AddKeyValuePair"
  <Test()> _
  Public Sub AddKeyValuePairExample()
    Dim skipList As New SkipList(Of String, Integer)
    skipList.Add(New KeyValuePair(Of String, Integer)("cat", 1))
    skipList.Add(New KeyValuePair(Of String, Integer)("dog", 2))
    skipList.Add(New KeyValuePair(Of String, Integer)("canary", 3))

    ' There should be 3 items in the SkipList.
    Assert.AreEqual(skipList.Count, 3)

    ' The skipList should contain all three keys
    Assert.AreEqual(skipList.ContainsKey("cat"), True)
    Assert.AreEqual(skipList.ContainsKey("dog"), True)
    Assert.AreEqual(skipList.ContainsKey("canary"), True)

    ' The value of the item with key "dog" must be 2.
    Assert.AreEqual(skipList.Item("dog"), 2)
  End Sub

#End Region


#Region "Clear"
  <Test()> _
  Public Sub ClearExample()
    Dim skipList As New SkipList(Of String, Integer)
    skipList.Add("cat", 1)
    skipList.Add("dog", 2)
    skipList.Add("canary", 3)

    ' There should be 3 items in the SkipList.
    Assert.AreEqual(skipList.Count, 3)

    ' Clear the skipList
    skipList.Clear()

    ' The skipList should be empty.
    Assert.AreEqual(skipList.Count, 0)

    ' No cat here..
    Assert.AreEqual(skipList.ContainsKey("cat"), False)
  End Sub

#End Region


#Region "Comparer"
  <Test()> _
  Public Sub ComparerExample()
    Dim skipList As New SkipList(Of String, Integer)

    ' If no comparer is specified, the default comparer is used.
    Assert.AreSame(skipList.Comparer, Comparer(Of String).Default)
  End Sub

#End Region


#Region "ConstructorComparer"
  <Test()> _
  Public Sub ConstructorComparerExample()
    Dim ignoreCaseSkipList As New SkipList(Of String, Integer)(StringComparer.OrdinalIgnoreCase)
    ignoreCaseSkipList.Add("cat", 1)
    ignoreCaseSkipList.Add("dog", 2)
    ignoreCaseSkipList.Add("canary", 3)

    ' "CAT" will be in the SkipList because case is ignored
    Assert.IsTrue(ignoreCaseSkipList.ContainsKey("CAT"))

    Dim useCaseSkipList As New SkipList(Of String, Integer)(StringComparer.Ordinal)
    useCaseSkipList.Add("cat", 1)
    useCaseSkipList.Add("dog", 2)
    useCaseSkipList.Add("canary", 3)

    ' "CAT" will not be in the SkipList because case is not ignored
    Assert.IsFalse(useCaseSkipList.ContainsKey("CAT"))
  End Sub

#End Region


#Region "Constructor"
  <Test()> _
  Public Sub ConstructorExample()
    Dim skipList As New SkipList(Of String, Integer)
    skipList.Add("cat", 1)
    skipList.Add("dog", 2)
    skipList.Add("canary", 3)
  End Sub

#End Region


#Region "ContainsKeyValue"
  <Test()> _
  Public Sub ContainsKeyValueExample()
    Dim skipList As New SkipList(Of String, Integer)
    skipList.Add("cat", 1)
    skipList.Add("dog", 2)
    skipList.Add("canary", 3)

    ' The skipList should contain 1 cat and 2 dogs...
    Assert.IsTrue(skipList.Contains(New KeyValuePair(Of String, Integer)("cat", 1)))
    Assert.IsTrue(skipList.Contains(New KeyValuePair(Of String, Integer)("dog", 2)))

    ' But not 3 cats and 1 dog
    Assert.IsFalse(skipList.Contains(New KeyValuePair(Of String, Integer)("cat", 3)))
    Assert.IsFalse(skipList.Contains(New KeyValuePair(Of String, Integer)("dog", 1)))
  End Sub

#End Region


#Region "ContainsKey"
  <Test()> _
  Public Sub ContainsKeyExample()
    Dim skipList As New SkipList(Of String, Integer)
    skipList.Add("cat", 1)
    skipList.Add("dog", 2)
    skipList.Add("canary", 3)

    ' The skipList should contain a cat and a dog...
    Assert.AreEqual(skipList.ContainsKey("cat"), True)
    Assert.AreEqual(skipList.ContainsKey("dog"), True)

    ' But definitely not an ostrich.
    Assert.AreEqual(skipList.ContainsKey("ostrich"), False)
  End Sub

#End Region


#Region "CopyTo"
  <Test()> _
  Public Sub CopyToExample()
    Dim skipList As New SkipList(Of String, Integer)
    skipList.Add("cat", 1)
    skipList.Add("dog", 2)
    skipList.Add("canary", 3)

    ' Create a new array of length 3 to copy the elements into.
    Dim values As KeyValuePair(Of String, Integer)() = New KeyValuePair(Of String, Integer)(3 - 1) {}
    skipList.CopyTo(values, 0)
  End Sub

#End Region


#Region "Count"
  <Test()> _
  Public Sub CountExample()
    Dim skipList As New SkipList(Of String, Integer)

    ' SkipList count is 0.
    Assert.AreEqual(skipList.Count, 0)

    ' Add a cat.
    skipList.Add("cat", 1)

    ' SkipList count is 1.
    Assert.AreEqual(skipList.Count, 1)

    ' Add a dog
    skipList.Add("dog", 2)

    ' SkipList count is 2.
    Assert.AreEqual(skipList.Count, 2)

    ' Clear the skipList - thereby removing all items contained.
    skipList.Clear()

    ' SkipList is empty again with 0 count.
    Assert.AreEqual(skipList.Count, 0)
  End Sub

#End Region


#Region "CurrentListLevel"
  <Test()> _
  Public Sub CurrentListLevelExample()
    Dim skipList As New SkipList(Of Integer, String)

    ' CurrentListLevel will initial be 0
    Assert.AreEqual(skipList.CurrentListLevel, 0)
    Dim i As Integer
    For i = 0 To 100 - 1
      skipList.Add(New KeyValuePair(Of Integer, String)(i, i.ToString))
    Next i
    Assert.Greater(skipList.CurrentListLevel, 0)
  End Sub

#End Region


#Region "GetEnumerator"
  <Test()> _
Public Sub GetEnumeratorExample()
    Dim skipList As New SkipList(Of String, Integer)
    skipList.Add("cat", 1)
    skipList.Add("dog", 2)
    skipList.Add("canary", 3)
    Dim enumerator As IEnumerator(Of KeyValuePair(Of String, Integer)) = skipList.GetEnumerator
    Do While enumerator.MoveNext
      Console.Write("Key : ")
      Console.WriteLine(enumerator.Current.Key)
      Console.Write("Value : ")
      Console.WriteLine(enumerator.Current.Value)
    Loop
  End Sub
#End Region


#Region "IsEmpty"
  <Test()> _
  Public Sub IsEmptyExample()
    Dim skipList As New SkipList(Of String, Integer)

    ' SkipList is empty.
    Assert.AreEqual(skipList.IsEmpty, True)

    ' Add a cat.
    skipList.Add("cat", 1)

    ' SkipList is not empty.
    Assert.IsFalse(skipList.IsEmpty)

    ' Clear the SkipList - thereby removing all items contained.
    skipList.Clear()

    ' SkipList is empty again with count = 0.
    Assert.IsTrue(skipList.IsEmpty)
  End Sub

#End Region


#Region "IsReadOnly"
  <Test()> _
  Public Sub IsReadOnlyExample()

    ' The IsReadOnly property will always return false - the 
    ' search skipList is not a read-only data structure.
    Dim skipList As New SkipList(Of String, Integer)
    Assert.IsFalse(skipList.IsReadOnly)
  End Sub

#End Region


#Region "Item"
  <Test()> _
Public Sub ItemExample()
    Dim skipList As New SkipList(Of String, Integer)
    skipList.Add("cat", 1)
    skipList.Add("dog", 2)
    skipList.Add("canary", 3)
    Assert.AreEqual(1, skipList.Item("cat"))
    Assert.AreEqual(2, skipList.Item("dog"))
    Assert.AreEqual(3, skipList.Item("canary"))
  End Sub
#End Region


#Region "Keys"
  <Test()> _
  Public Sub KeysExample()
    Dim skipList As New SkipList(Of String, Integer)
    skipList.Add("cat", 1)
    skipList.Add("dog", 2)
    skipList.Add("canary", 3)

    ' Retrieve the keys from the SkipList.
    Dim keys As ICollection(Of String) = skipList.Keys

    ' The keys collection contains three items : 
    ' "cat", "dog", and "canary".
    Assert.AreEqual(keys.Count, 3)
    Assert.IsTrue(keys.Contains("cat"))
    Assert.IsTrue(keys.Contains("dog"))
    Assert.IsTrue(keys.Contains("canary"))
  End Sub

#End Region


#Region "MaximumListLevel"
  <Test()> _
  Public Sub MaximumListLevelExample()
    Dim skipList As New SkipList(Of String, Integer)(14, 0.7, StringComparer.OrdinalIgnoreCase)
    skipList.Add("cat", 1)
    skipList.Add("dog", 2)
    skipList.Add("canary", 3)
    Assert.AreEqual(skipList.Count, 3)
    Assert.AreEqual(skipList.Probability, 0.7)
    Assert.AreEqual(skipList.MaximumListLevel, 14)
  End Sub

#End Region


#Region "Probability"
  <Test()> _
  Public Sub ProbabilityExample()
    Dim skipList As New SkipList(Of String, Integer)(14, 0.7, StringComparer.OrdinalIgnoreCase)
    skipList.Add("cat", 1)
    skipList.Add("dog", 2)
    skipList.Add("canary", 3)
    Assert.AreEqual(skipList.Count, 3)
    Assert.AreEqual(skipList.Probability, 0.7)
    Assert.AreEqual(skipList.MaximumListLevel, 14)
  End Sub

#End Region


#Region "Remove"
  <Test()> _
  Public Sub RemoveExample()
    Dim skipList As New SkipList(Of String, Integer)
    skipList.Add("cat", 1)
    skipList.Add("dog", 2)
    skipList.Add("canary", 3)

    ' There are three items in the SkipList
    Assert.AreEqual(skipList.Count, 3)

    ' Let's remove the dog
    skipList.Remove("dog")

    ' Now the SkipList contains only two items, and dog isn't 
    ' in the SkipList.
    Assert.AreEqual(skipList.Count, 2)
    Assert.IsFalse(skipList.ContainsKey("dog"))
  End Sub

#End Region


#Region "TryGetValue"
  <Test()> _
  Public Sub TryGetValueExample()
    Dim value As Integer
    Dim skipList As New SkipList(Of String, Integer)
    skipList.Add("cat", 1)
    skipList.Add("dog", 2)
    skipList.Add("canary", 3)

    ' We'll get the value for cat successfully.
    Assert.AreEqual(skipList.TryGetValue("cat", value), True)

    ' And the value should be 1.
    Assert.AreEqual(value, 1)

    ' But we won't get a horse
    Assert.AreEqual(skipList.TryGetValue("horse", value), False)
  End Sub

#End Region


#Region "Values"
  <Test()> _
  Public Sub ValuesExample()
    Dim skipList As New SkipList(Of String, Integer)
    skipList.Add("cat", 1)
    skipList.Add("dog", 2)
    skipList.Add("canary", 3)

    ' Retrieve the values from the SkipList.
    Dim values As ICollection(Of Integer) = skipList.Values

    ' The keys collection contains three items : 
    ' 1, 2, and 3.
    Assert.AreEqual(values.Count, 3)
    Assert.AreEqual(values.Contains(1), True)
    Assert.AreEqual(values.Contains(2), True)
    Assert.AreEqual(values.Contains(3), True)
  End Sub

#End Region

End Class


