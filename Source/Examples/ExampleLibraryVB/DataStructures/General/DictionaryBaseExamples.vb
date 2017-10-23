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

<TestFixture()> _
Public Class DictionaryBaseExamples
    Public Class MyDictionary(Of TKey, TValue)
        Inherits DictionaryBase(Of String, Integer)


    End Class

#Region "Add"
    <Test()> _
    Public Sub AddExample()
        Dim dictionary As DictionaryBase(Of String, Integer) = New MyDictionary(Of String, Integer)
        dictionary.Add("cat", 1)
        dictionary.Add("dog", 2)
        dictionary.Add("canary", 3)

        ' There should be 3 items in the dictionary.
        Assert.AreEqual(dictionary.Count, 3)
    End Sub

#End Region


#Region "Clear"
    <Test()> _
    Public Sub ClearExample()
        Dim dictionary As DictionaryBase(Of String, Integer) = New MyDictionary(Of String, Integer)
        dictionary.Add("cat", 1)
        dictionary.Add("dog", 2)
        dictionary.Add("canary", 3)

        ' There should be 3 items in the dictionary.
        Assert.AreEqual(dictionary.Count, 3)

        ' Clear the dictionary
        dictionary.Clear()

        ' The dictionary should be empty.
        Assert.AreEqual(dictionary.Count, 0)

        ' No cat here..
        Assert.AreEqual(dictionary.ContainsKey("cat"), False)
    End Sub

#End Region


#Region "Comparer"
    <Test()> _
    Public Sub ComparerExample()
        Dim dictionary As DictionaryBase(Of String, Integer) = New MyDictionary(Of String, Integer)

        ' If no comparer is specified, the default comparer is used.
        Assert.AreSame(dictionary.Comparer, EqualityComparer(Of String).Default)
    End Sub

#End Region


#Region "ContainsKey"
    <Test()> _
    Public Sub ContainsKeyExample()
        Dim dictionary As DictionaryBase(Of String, Integer) = New MyDictionary(Of String, Integer)
        dictionary.Add("cat", 1)
        dictionary.Add("dog", 2)
        dictionary.Add("canary", 3)

        ' The dictionary should contain a cat and a dog...
        Assert.IsTrue(dictionary.ContainsKey("cat"))
        Assert.IsTrue(dictionary.ContainsKey("dog"))

        ' But definitely not an ostrich.
        Assert.IsFalse(dictionary.ContainsKey("ostrich"))
    End Sub

#End Region


#Region "Count"
    <Test()> _
    Public Sub CountExample()
        Dim dictionary As DictionaryBase(Of String, Integer) = New MyDictionary(Of String, Integer)

        ' Tree count is 0.
        Assert.AreEqual(dictionary.Count, 0)

        ' Add a cat.
        dictionary.Add("cat", 1)

        ' Tree count is 1.
        Assert.AreEqual(dictionary.Count, 1)

        ' Add a dog
        dictionary.Add("dog", 2)

        ' Tree count is 2.
        Assert.AreEqual(dictionary.Count, 2)

        ' Clear the dictionary - thereby removing all items contained.
        dictionary.Clear()

        ' Tree is empty again with 0 count.
        Assert.AreEqual(dictionary.Count, 0)
    End Sub

#End Region


#Region "GetEnumerator"
    <Test()> _
  Public Sub GetEnumeratorExample()
        Dim dictionary As DictionaryBase(Of String, Integer) = New MyDictionary(Of String, Integer)
        dictionary.Add("cat", 8)
        dictionary.Add("dog", 3)
        dictionary.Add("canary", 4)

        ' Enumerate through the items in the dictionary, and write the contents
        ' to the standard output.
        Dim enumerator As IEnumerator(Of KeyValuePair(Of String, Integer)) = dictionary.GetEnumerator
        Do While enumerator.MoveNext
            System.Console.Write("Key : ")
            System.Console.WriteLine(enumerator.Current.Key)
            System.Console.Write("Value : ")
            System.Console.WriteLine(enumerator.Current.Value)
        Loop
    End Sub

#End Region


#Region "Item"
    <Test()> _
Public Sub ItemExample()
        Dim dictionary As DictionaryBase(Of String, Integer) = New MyDictionary(Of String, Integer)
        dictionary.Add("cat", 1)
        dictionary.Add("dog", 2)
        dictionary.Add("canary", 3)

        Assert.AreEqual(1, dictionary.Item("cat"))
        Assert.AreEqual(2, dictionary.Item("dog"))
        Assert.AreEqual(3, dictionary.Item("canary"))
    End Sub
#End Region


#Region "Keys"
    <Test()> _
    Public Sub KeysExample()
        Dim dictionary As DictionaryBase(Of String, Integer) = New MyDictionary(Of String, Integer)
        dictionary.Add("cat", 1)
        dictionary.Add("dog", 2)
        dictionary.Add("canary", 3)

        ' Retrieve the keys from the dictionary.
        Dim keys As ICollection(Of String) = dictionary.Keys

        ' The keys collection contains three items : 
        ' "cat", "dog", and "canary".
        Assert.AreEqual(keys.Count, 3)
        Assert.AreEqual(keys.Contains("cat"), True)
        Assert.AreEqual(keys.Contains("dog"), True)
        Assert.AreEqual(keys.Contains("canary"), True)
    End Sub

#End Region


#Region "Remove"
    <Test()> _
    Public Sub RemoveExample()
        Dim dictionary As DictionaryBase(Of String, Integer) = New MyDictionary(Of String, Integer)
        dictionary.Add("cat", 1)
        dictionary.Add("dog", 2)
        dictionary.Add("canary", 3)

        ' There are three items in the dictionary
        Assert.AreEqual(dictionary.Count, 3)

        ' Let's remove the dog
        dictionary.Remove("dog")

        ' Now the dictionary contains only two items, and dog isn't 
        Assert.AreEqual(dictionary.Count, 2)
        Assert.AreEqual(dictionary.ContainsKey("dog"), False)
    End Sub

#End Region


#Region "TryGetValue"
    <Test()> _
    Public Sub TryGetValueExample()
        Dim value As Integer
        Dim dictionary As DictionaryBase(Of String, Integer) = New MyDictionary(Of String, Integer)
        dictionary.Add("cat", 1)
        dictionary.Add("dog", 2)
        dictionary.Add("canary", 3)

        ' We'll get the value for cat successfully.
        Assert.IsTrue(dictionary.TryGetValue("cat", value))

        ' And the value should be 1.
        Assert.AreEqual(value, 1)

        ' But we won't get a horse
        Assert.IsFalse(dictionary.TryGetValue("horse", value))
    End Sub

#End Region


#Region "Values"
    <Test()> _
    Public Sub ValuesExample()
        Dim dictionary As DictionaryBase(Of String, Integer) = New MyDictionary(Of String, Integer)
        dictionary.Add("cat", 1)
        dictionary.Add("dog", 2)
        dictionary.Add("canary", 3)

        ' Retrieve the values from the dictionary.
        Dim values As ICollection(Of Integer) = dictionary.Values

        ' The keys collection contains three items : 
        ' 1, 2, and 3.
        Assert.AreEqual(values.Count, 3)

        Assert.AreEqual(values.Contains(1), True)
        Assert.AreEqual(values.Contains(2), True)
        Assert.AreEqual(values.Contains(3), True)
    End Sub

#End Region
End Class