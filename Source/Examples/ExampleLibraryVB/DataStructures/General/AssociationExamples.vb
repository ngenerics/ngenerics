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

<TestFixture()> _
Public Class AssociationExamples

#Region "Constructor"
  <Test()> _
  Public Sub ConstructorExample()
    ' Create a new association
    Dim association As New _
      Association(Of Integer, String)(4, "four")

    ' Key will be equal to 4
    Assert.AreEqual(association.Key, 4)

    ' Value will be equal to "four"
    Assert.AreEqual(association.Value, "four")
  End Sub
#End Region

#Region "Key"
  <Test()> _
  Public Sub KeyExample()
    Dim association As _
      New Association(Of Integer, String)(1, "monkey")

    ' The key's value will be 1.
    Assert.AreEqual(association.Key, 1)

    ' Set the key's value to 3.
    association.Key = 3

    ' The key's value will be 3.
    Assert.AreEqual(association.Key, 3)
  End Sub
#End Region


#Region "Value"
  <Test()> _
  Public Sub ValueExample()
    Dim association As _
      New Association(Of Integer, String)(1, "dove")

    ' The value will be "dove".
    Assert.AreEqual(association.Value, "dove")

    ' Set the value to "monkey".
    association.Value = "monkey"

    ' The new value will be "monkey".
    Assert.AreEqual(association.Value, "monkey")
  End Sub

#End Region


#Region "ToKeyValuePair"
  <Test()> _
  Public Sub ToKeyValuePairExample()
    Dim association As _
      New Association(Of Integer, String)(1, "dove")

    Dim pair As KeyValuePair(Of Integer, String) = _
      association.ToKeyValuePair()

    Assert.AreEqual(pair.Key, association.Key)
    Assert.AreEqual(pair.Value, association.Value)
  End Sub

#End Region
End Class


