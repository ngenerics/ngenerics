'  
'  Copyright 2007-2013 The NGenerics Team
' (https://github.com/ngenerics/ngenerics/wiki/Team)
'
' This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
' have received a copy of the license along with the source code.  If not, an online copy
' of the license can be found at http://www.gnu.org/copyleft/lesser.html.
'


Imports NGenerics.Patterns.Specification
Imports NUnit.Framework

Namespace Patterns.Specification
  <TestFixture()> _
  Public Class NotSpecificationExamples
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
      Dim goldCustomer As Customer = New Customer()
      goldCustomer.Name = "Customer 1"
      goldCustomer.Type = CustomerType.Gold

      Dim silverCustomer As Customer = New Customer()
      silverCustomer.Name = "Customer 2"
      silverCustomer.Type = CustomerType.Silver

      Dim notGoldSpecification As AbstractSpecification(Of Customer) = New PredicateSpecification(Of Customer)(Function(x As Customer) x.Type = CustomerType.Gold).[Not]()

      ' Gold customer
      Assert.IsFalse(notGoldSpecification.IsSatisfiedBy(goldCustomer))

      ' Silver customer
      Assert.IsTrue(notGoldSpecification.IsSatisfiedBy(silverCustomer))
    End Sub

#End Region
  End Class
End Namespace