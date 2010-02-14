'  
' Copyright 2007-2010 The NGenerics Team
' (http://code.google.com/p/ngenerics/wiki/Team)
'
' This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
' have received a copy of the license along with the source code.  If not, an online copy
' of the license can be found at http://www.gnu.org/copyleft/lesser.html.
'
Imports NUnit.Framework
Imports NGenerics.Patterns.Specification

Namespace Patterns.Specification
    <TestFixture()> _
    Public Class XorSpecificationExamples

#Region "IsSatisfiedBy"

        <Test()> _
        Public Sub IsSatisfiedByExample()

            Dim divisibleByTwoSpecification As PredicateSpecification(Of Integer) = New PredicateSpecification(Of Integer)(Function(x) x Mod 2 = 0)
            Dim divisibleByThreeSpecification As PredicateSpecification(Of Integer) = New PredicateSpecification(Of Integer)(Function(x) x Mod 3 = 0)

            Dim xorSpecifciation As XorSpecification(Of Integer) = New XorSpecification(Of Integer)(divisibleByTwoSpecification, divisibleByThreeSpecification)

            ' Not divisible by either two or thre
            Assert.IsFalse(xorSpecifciation.IsSatisfiedBy(1))

            ' Divisible by two only
            Assert.IsTrue(xorSpecifciation.IsSatisfiedBy(2))

            ' Divisible by thee only
            Assert.IsTrue(xorSpecifciation.IsSatisfiedBy(3))

            ' Divisible by two and three
            Assert.IsFalse(xorSpecifciation.IsSatisfiedBy(6))
        End Sub
#End Region

    End Class
End Namespace