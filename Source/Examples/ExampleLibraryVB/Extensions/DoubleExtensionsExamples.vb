'  
' Copyright 2009 The NGenerics Team
' (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)
'
' This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
' have received a copy of the license along with the source code.  If not, an online copy
' of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
'

Imports NGenerics.Extensions
Imports NUnit.Framework

Namespace Extensions
  <TestFixture()> _
  Public Class DoubleExtensionsExamples
#Region "IsSimilarTo"

    <Test()> _
    Public Sub IsSimilarToExample()
      Dim d1 As Double = 5.000000000009R
      Dim d2 As Double = 5.0R

      ' Since the difference between the two values are less / equal than the default precision,
      ' the following statement returns true :
      Assert.IsTrue(d1.IsSimilarTo(d2))
    End Sub

#End Region

#Region "IsSimilarWithPrecision"

    <Test()> _
    Public Sub IsSimilarWithPrecisionExample()
      Dim d1 As Double = 5.1R
      Dim d2 As Double = 5.0R

      ' Since the difference between the two values are less / equal than the supplied precision,
      ' the following statement returns true :
      Assert.IsTrue(d1.IsSimilarTo(d2, 0.1))
    End Sub

#End Region
  End Class
End Namespace