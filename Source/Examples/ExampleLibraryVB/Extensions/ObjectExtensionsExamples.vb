'  
' Copyright 2007-2017 The NGenerics Team
' (https://github.com/ngenerics/ngenerics/wiki/Team)
'
' This program is licensed under the MIT License.  You should 
' have received a copy of the license along with the source code.  If not, an online copy
' of the license can be found at https://opensource.org/licenses/MIT.
'

Imports NGenerics.Extensions
Imports NUnit.Framework

Namespace Extensions
  <TestFixture()> _
  Public Class ObjectExtensionsExamples
#Region "ConvertTo"
    <Test()> _
    Public Sub ConvertToExample()
      ' Convert from the string representation to an actual number,
      Dim From As String = "23.55"
      Dim [to] As Decimal = From.ConvertTo(Of Decimal)()

      Assert.AreEqual([to], 23.55)
    End Sub
#End Region
  End Class
End Namespace