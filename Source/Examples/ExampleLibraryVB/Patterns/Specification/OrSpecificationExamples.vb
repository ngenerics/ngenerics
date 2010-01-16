'  
'  Copyright 2007-2010 The NGenerics Team
' (http://code.google.com/p/ngenerics/wiki/Team)
'
' This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
' have received a copy of the license along with the source code.  If not, an online copy
' of the license can be found at http://www.gnu.org/copyleft/lesser.html.
'


Imports NGenerics.Patterns.Specification
Imports NUnit.Framework

Namespace Patterns.Specification
  <TestFixture()> _
  Public Class OrSpecificationExamples
#Region "IsSatisfiedBy"

    Public Enum CustomerType
      Bronze
      Silver
      Gold
    End Enum

    Public Class Customer
      Private _Name As String
      Public Property Name() As String
        Get
          Return _Name
        End Get
        Set(ByVal value As String)
          _Name = value
        End Set
      End Property
      Private _Type As CustomerType
      Public Property Type() As CustomerType
        Get
          Return _Type
        End Get
        Set(ByVal value As CustomerType)
          _Type = value
        End Set
      End Property
    End Class

    <Test()> _
    Public Sub IsSatisfiedByExample()
      Dim goldCustomer As Customer = New Customer() With {.Name = "Customer1", .Type = CustomerType.Gold}
      Dim silverCustomer As Customer = New Customer() With {.Name = "Customer2", .Type = CustomerType.Silver}
      Dim bronzeCustomer As Customer = New Customer() With {.Name = "Customer3", .Type = CustomerType.Bronze}

      Dim specification As OrSpecification(Of Customer) = New OrSpecification(Of Customer)( _
          New PredicateSpecification(Of Customer)(Function(x) x.Type = CustomerType.Gold), _
          New PredicateSpecification(Of Customer)(Function(x) x.Name = "Customer3"))

      ' Gold customer
      Assert.IsTrue(specification.IsSatisfiedBy(goldCustomer))

      ' Silver customer
      Assert.IsFalse(specification.IsSatisfiedBy(silverCustomer))

      ' Customer 3
      Assert.IsTrue(specification.IsSatisfiedBy(bronzeCustomer))
    End Sub

#End Region
  End Class
End Namespace