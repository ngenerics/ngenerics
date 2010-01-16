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
Imports NGenerics.Patterns.Conversion
Imports NUnit.Framework


Namespace Patterns.Conversion
  <TestFixture()> _
  Public Class ConverterExamples

#Region "Convert"

    <Test()> _
    Public Sub ConvertExample()
      Dim converter As OrderConverter = New OrderConverter()
      Dim order As Order = New Order()
      order.OrderDate = DateTime.Now

      Dim lineItems As New List(Of OrderLineItem)

      Dim lineItem1 As New OrderLineItem
      lineItem1.Amount = CDec(20.2)
      lineItem1.Description = "Item 1"

      Dim lineItem2 As New OrderLineItem
      lineItem2.Amount = CDec(14.43)
      lineItem2.Description = "Item 2"

      lineItems.Add(lineItem1)
      lineItems.Add(lineItem2)
      order.LineItems = lineItems

      Dim dto As OrderDto = converter.Convert(order)

      Assert.AreEqual(dto.OrderDate, order.OrderDate)
      Assert.AreEqual(dto.Total, 34.63D)
    End Sub

    Public Class OrderConverter
      Implements IConverter(Of Order, OrderDto)

      Public Function Convert(ByVal input As Order) As OrderDto Implements IConverter(Of Order, OrderDto).Convert
        Dim order As New OrderDto()

        order.OrderDate = input.OrderDate
        order.Total = input.Total

        Return order
      End Function
      
    End Class

    Public Class Order

      Private _OrderDate As DateTime
      Public Property OrderDate() As DateTime
        Get
          Return _OrderDate
        End Get
        Set(ByVal value As DateTime)
          _OrderDate = value
        End Set
      End Property
      Private _LineItems As IList(Of OrderLineItem)
      Public Property LineItems() As IList(Of OrderLineItem)
        Get
          Return _LineItems
        End Get
        Set(ByVal value As IList(Of OrderLineItem))
          _LineItems = value
        End Set
      End Property

      Public ReadOnly Property Total() As Decimal
        Get
          Dim _total As Decimal = 0

          If LineItems Is Nothing Then
            Return _total
          End If

          For Each _lineItem As OrderLineItem In LineItems
            Total += _lineItem.Amount
          Next

          Return total
        End Get
      End Property
    End Class

    Public Class OrderLineItem
      Private _Description As String
      Public Property Description() As String
        Get
          Return _Description
        End Get
        Set(ByVal value As String)
          _Description = value
        End Set
      End Property
      Private _Amount As Decimal
      Public Property Amount() As Decimal
        Get
          Return _Amount
        End Get
        Set(ByVal value As Decimal)
          _Amount = value
        End Set
      End Property
    End Class

    Public Class OrderDto
      Private _OrderDate As DateTime
      Public Property OrderDate() As DateTime
        Get
          Return _OrderDate
        End Get
        Set(ByVal value As DateTime)
          _OrderDate = value
        End Set
      End Property
      Private _Total As Decimal
      Public Property Total() As Decimal
        Get
          Return _Total
        End Get
        Set(ByVal value As Decimal)
          _Total = value
        End Set
      End Property
    End Class

#End Region
  End Class
End Namespace