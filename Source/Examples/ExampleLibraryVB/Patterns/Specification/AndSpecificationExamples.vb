'  
' Copyright 2007-2017 The NGenerics Team
' (https://github.com/ngenerics/ngenerics/wiki/Team)
'
' This program is licensed under the MIT License.  You should 
' have received a copy of the license along with the source code.  If not, an online copy
' of the license can be found at https://opensource.org/licenses/MIT.
'

Imports NGenerics.Patterns.Specification
Imports NUnit.Framework


<TestFixture()> _
Public Class AndSpecificationExamples

#Region "IsSatisfiedBy"

  Public Class Person
    Private _name As String
    Private _surname As String


    Public Property Name() As String
      Get
        Return _name
      End Get
      Set(ByVal value As String)
        _name = value
      End Set
    End Property
    Public Property Surname() As String
      Get
        Return _surname
      End Get
      Set(ByVal value As String)
        _surname = value
      End Set
    End Property
  End Class

  <Test()> _
  Public Sub IsSatisfiedByExample()
    ' Our model to test on
    Dim p As New Person()
    p.Name = "Hilton"
    p.Surname = "Goosen"

    ' Build up two specifications to AND together
    Dim nameSpecification As New PredicateSpecification(Of Person)(Function(x As Person) x.Name = "Hilton")
    Dim surnameSpecification As New PredicateSpecification(Of Person)(Function(x As Person) x.Surname = "Goosen")

    ' Create a new And Specification
    Dim specification As New AndSpecification(Of Person)(nameSpecification, surnameSpecification)

    Assert.IsTrue(specification.IsSatisfiedBy(p))

    ' Set the surname to something else
    surnameSpecification = New PredicateSpecification(Of Person)(Function(x As Person) x.Surname = "Hanekom")
    specification = New AndSpecification(Of Person)(nameSpecification, surnameSpecification)

    ' Surname specification is not satisfied by this person
    Assert.IsFalse(specification.IsSatisfiedBy(p))
  End Sub

#End Region

End Class

