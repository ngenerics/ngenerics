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
Imports NGenerics.DataStructures.General
Imports NUnit.Framework

<TestFixture()> _
Public Class HashListExamples

#Region "Add"
  <Test()> _
  Public Sub AddExample()
    Dim whatAnimalEatHashList As New HashList(Of String, String)
    whatAnimalEatHashList.Add("cat", "milk")
    whatAnimalEatHashList.Add("cat", "fish")
    whatAnimalEatHashList.Add("dog", "dog food")
    whatAnimalEatHashList.Add("dog", "bones")
    whatAnimalEatHashList.Add("tiger", "people")
        ' There should be 3 items.
        Assert.AreEqual(whatAnimalEatHashList.Count, 3)
    End Sub

#End Region


#Region "AddParams"
    <Test()> _
    Public Sub AddParamsExample()
        Dim whatAnimalEatHashList As New HashList(Of String, String)
        whatAnimalEatHashList.Add("cat", New String() {"milk", "fish"})
        whatAnimalEatHashList.Add("dog", New String() {"dog food", "bones"})
        whatAnimalEatHashList.Add("tiger", "people")

        ' There are 3 keys.
        Assert.AreEqual(3, whatAnimalEatHashList.KeyCount)

        ' There are 5 values.
        Assert.AreEqual(5, whatAnimalEatHashList.ValueCount)
    End Sub

#End Region


#Region "Clear"
    <Test()> _
    Public Sub ClearExample()
        Dim whatAnimalEatHashList As New HashList(Of String, String)
        whatAnimalEatHashList.Add("cat", "milk")
        whatAnimalEatHashList.Add("cat", "fish")
        whatAnimalEatHashList.Add("dog", "dog food")
        whatAnimalEatHashList.Add("dog", "bones")
        whatAnimalEatHashList.Add("tiger", "people")
        Assert.AreEqual(whatAnimalEatHashList.Count, 3)
        whatAnimalEatHashList.Clear()
        Assert.AreEqual(whatAnimalEatHashList.Count, 0)
        Assert.IsFalse(whatAnimalEatHashList.ContainsKey("cat"))
    End Sub

#End Region


#Region "ConstructorCapacity"
    <Test()> _
    Public Sub ConstructorCapacityExample()
        ' If you know how many items will initially be in the HashList it is 
        ' more efficient to set the initial capacity
        Dim whatAnimalEatHashList As New HashList(Of String, String)(3)
        whatAnimalEatHashList.Add("cat", "milk")
        whatAnimalEatHashList.Add("cat", "fish")
        whatAnimalEatHashList.Add("dog", "dog food")
        whatAnimalEatHashList.Add("dog", "bones")
        whatAnimalEatHashList.Add("tiger", "people")
    End Sub

#End Region


#Region "ConstructorComparer"
    <Test()> _
    Public Sub ConstructorComparerExample()
        Dim whatAnimalEatHashListIgnoreCase As New HashList(Of String, String)(StringComparer.OrdinalIgnoreCase)
        whatAnimalEatHashListIgnoreCase.Add("cat", "milk")
        whatAnimalEatHashListIgnoreCase.Add("CAT", "fish")

        ' KeyCount is 1 because case is ignored
        Assert.AreEqual(1, whatAnimalEatHashListIgnoreCase.KeyCount)
        Dim whatAnimalEatHashListUseCase As New HashList(Of String, String)(StringComparer.Ordinal)
        whatAnimalEatHashListUseCase.Add("cat", "milk")
        whatAnimalEatHashListUseCase.Add("CAT", "fish")

        ' KeyCount is 2 because case is not ignored
        Assert.AreEqual(2, whatAnimalEatHashListUseCase.KeyCount)
    End Sub

#End Region


#Region "Constructor"
    <Test()> _
    Public Sub ConstructorExample()
        Dim whatAnimalEatHashList As New HashList(Of String, String)
        whatAnimalEatHashList.Add("cat", "milk")
        whatAnimalEatHashList.Add("cat", "fish")
        whatAnimalEatHashList.Add("dog", "dog food")
        whatAnimalEatHashList.Add("dog", "bones")
        whatAnimalEatHashList.Add("tiger", "people")
    End Sub

#End Region


#Region "GetValueEnumerator"
    <Test()> _
    Public Sub GetValueEnumeratorExample()
        Dim whatAnimalEatHashList As New HashList(Of String, String)
        whatAnimalEatHashList.Add("cat", "milk")
        whatAnimalEatHashList.Add("cat", "fish")
        whatAnimalEatHashList.Add("dog", "dog food")
        whatAnimalEatHashList.Add("dog", "bones")
        whatAnimalEatHashList.Add("tiger", "people")

        ' Get the enumerator and iterate through all 5 values.
        Dim enumerator As IEnumerator(Of String) = whatAnimalEatHashList.GetValueEnumerator
        Do While enumerator.MoveNext
            Debug.WriteLine(enumerator.Current)
        Loop
    End Sub

#End Region


#Region "KeyCount"
    <Test()> _
    Public Sub KeyCountExample()
        Dim whatAnimalEatHashList As New HashList(Of String, String)
        whatAnimalEatHashList.Add("cat", New String() {"milk", "fish"})
        whatAnimalEatHashList.Add("dog", New String() {"dog food", "bones"})
        whatAnimalEatHashList.Add("tiger", "people")

        ' There are 4 keys.
        Assert.AreEqual(3, whatAnimalEatHashList.KeyCount)
    End Sub

#End Region


#Region "RemoveAll"
    <Test()> _
    Public Sub RemoveAllExample()
        Dim whatAnimalEatHashList As New HashList(Of String, String)
        whatAnimalEatHashList.Add("dog", "dog food")
        whatAnimalEatHashList.Add("dog", "bones")
        whatAnimalEatHashList.Add("dog", "cats")
        whatAnimalEatHashList.Add("tiger", "people")
        whatAnimalEatHashList.Add("tiger", "cats")

        ' HashList contains 5 values
        Assert.AreEqual(5, whatAnimalEatHashList.ValueCount)

        ' Remove "cats" values
        whatAnimalEatHashList.RemoveAll("cats")

        ' HashList contains 3 values because all values matching "cats" have been removed
        Assert.AreEqual(3, whatAnimalEatHashList.ValueCount)
    End Sub

#End Region


#Region "Remove"
    <Test()> _
    Public Sub RemoveExample()
        Dim whatAnimalEatHashList As New HashList(Of String, String)
        whatAnimalEatHashList.Add("cat", "milk")
        whatAnimalEatHashList.Add("cat", "fish")
        whatAnimalEatHashList.Add("dog", "dog food")
        whatAnimalEatHashList.Add("dog", "bones")
        whatAnimalEatHashList.Add("tiger", "people")

        ' HashList contains "dog"
        Assert.IsTrue(whatAnimalEatHashList.ContainsKey("dog"))

        ' Remove "dog"
        whatAnimalEatHashList.Remove("dog")

        ' HashList does not contain "dog"
        Assert.IsFalse(whatAnimalEatHashList.ContainsKey("dog"))
    End Sub

#End Region


#Region "RemoveKeyValue"
    <Test()> _
  Public Sub RemoveKeyValueExample()
        Dim list As New HashList(Of String, String)
        list.Add("dog", "dog food")
        list.Add("dog", "bones")
        Assert.AreEqual(2, list.Item("dog").Count)
        list.Remove("dog", "bones")
        Assert.AreEqual(1, list.Item("dog").Count)
    End Sub


#End Region


#Region "RemoveValue"
    <Test()> _
    Public Sub RemoveValueExample()
        Dim whatAnimalEatHashList As New HashList(Of String, String)
        whatAnimalEatHashList.Add("dog", "dog food")
        whatAnimalEatHashList.Add("dog", "bones")
        whatAnimalEatHashList.Add("lion", "bones")

        ' There are 3 Values.
        Assert.AreEqual(3, whatAnimalEatHashList.ValueCount)

        ' Remove the first instance of "bones"
        whatAnimalEatHashList.RemoveValue("bones")

        ' There are now 2 Values.
        Assert.AreEqual(2, whatAnimalEatHashList.ValueCount)
    End Sub



#End Region


#Region "ValueCount"
    <Test()> _
    Public Sub ValueCountExample()
        Dim whatAnimalEatHashList As New HashList(Of String, String)
        whatAnimalEatHashList.Add("cat", New String() {"milk", "fish"})
        whatAnimalEatHashList.Add("dog", New String() {"dog food", "bones"})
        whatAnimalEatHashList.Add("tiger", "people")

        ' There are 4 values.
        Assert.AreEqual(5, whatAnimalEatHashList.ValueCount)
    End Sub

#End Region

End Class


