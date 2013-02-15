'  
' Copyright 2007-2013 The NGenerics Team
' (https://github.com/ngenerics/ngenerics/wiki/Team)
'
' This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
' have received a copy of the license along with the source code.  If not, an online copy
' of the license can be found at http://www.gnu.org/copyleft/lesser.html.
'

Imports System
Imports NGenerics.DataStructures.General
Imports NUnit.Framework

#Region "Singleton"
<TestFixture()> _
Public Class SingletonExamples

  Public Sub New()

        'get the singleton and set its data to 5;
        Singleton(Of MyExampleSingleton).Instance.Data = 5
    End Sub

    <Test()> _
    Public Sub RunExample()

        ' get two instances of MyExampleSingleton
        Dim singleton1 As MyExampleSingleton = Singleton(Of MyExampleSingleton).Instance
        Dim singleton2 As MyExampleSingleton = Singleton(Of MyExampleSingleton).Instance

        ' Both will point to the same instance
        Assert.IsTrue(Object.ReferenceEquals(singleton1, singleton2))

        ' Both will have a data value of 5
        Assert.AreEqual(singleton1.Data, 5)
        Assert.AreEqual(singleton2.Data, 5)
    End Sub

End Class


Public Class MyExampleSingleton
  ' Properties
  Public Property Data() As Integer
    Get
      Return Me._data
    End Get
    Set(ByVal value As Integer)
      Me._data = value
    End Set
  End Property


  ' Fields
  Private _data As Integer
End Class

#End Region

#Region "ConstructWith"
<TestFixture()> _
Public Class ConstructWithSingletonExample
    Public Sub New()
        ' Add the construction method for the singleton.
        Singleton(Of SimpleClass).ConstructWith = Function() New SimpleFactory().ProvideValue()
    End Sub

    <Test()> _
    Public Sub RunExample()
        ' get two instances of SimpleClass
        Dim singleton1 As SimpleClass = Singleton(Of SimpleClass).Instance
        Dim singleton2 As SimpleClass = Singleton(Of SimpleClass).Instance

        ' Both will point to the same instance
        Assert.IsTrue(ReferenceEquals(singleton1, singleton2))

        ' Both will have a data value of 5
        Assert.AreEqual(2, singleton1.Data)
        Assert.AreEqual(2, singleton2.Data)
    End Sub
End Class

Public Class SimpleClass
    Private privateData As Integer
    Public Property Data() As Integer
        Get
            Return privateData
        End Get
        Set(ByVal value As Integer)
            privateData = value
        End Set
    End Property
End Class

Public Class SimpleFactory
    Public Function ProvideValue() As SimpleClass
        Return New SimpleClass With {.Data = 2}
    End Function
End Class
#End Region
