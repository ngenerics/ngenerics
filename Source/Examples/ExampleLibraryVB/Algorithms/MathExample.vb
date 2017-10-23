'  
' Copyright 2007-2017 The NGenerics Team
' (https://github.com/ngenerics/ngenerics/wiki/Team)
'
' This program is licensed under the MIT License.  You should 
' have received a copy of the license along with the source code.  If not, an online copy
' of the license can be found at https://opensource.org/licenses/MIT.
'


Imports NGenerics.Algorithms
Imports NUnit.Framework

Namespace ExampleLibraryVB.Algorithms
    <TestFixture()> _
    Public Class MathExample

#Region "GreatestCommonDivisor"
    <Test()> _
    Public Sub FindGreatestCommonDivisorOf180And640()
      Dim commonDivisor As Integer = MathAlgorithms.GreatestCommonDivisor(180, 640)

      ' commonDivisor should be equal to 20.
      Assert.AreEqual(commonDivisor, 20)
    End Sub
#End Region

#Region "Fibonacci"
    <Test()> _
  Public Sub GenerateNthFibonacci()

      Dim tenthFibonacci As Long = MathAlgorithms.Fibonacci(10)

      Assert.AreEqual(55, tenthFibonacci)
    End Sub
#End Region

#Region "GenerateFibonacciSequence"
        <Test()> _
       Public Sub GenerateFibonacciSequence()

            Dim fib As New List(Of Long)()

            fib.AddRange(MathAlgorithms.GenerateFibonacciSequence(10))

            Assert.AreEqual(fib.Count, 11)

            Assert.AreEqual(fib(0), 0)
            Assert.AreEqual(fib(1), 1)
            Assert.AreEqual(fib(2), 1)
            Assert.AreEqual(fib(3), 2)
            Assert.AreEqual(fib(4), 3)
            Assert.AreEqual(fib(5), 5)
            Assert.AreEqual(fib(6), 8)
            Assert.AreEqual(fib(7), 13)
            Assert.AreEqual(fib(8), 21)
            Assert.AreEqual(fib(9), 34)
            Assert.AreEqual(fib(10), 55)
        End Sub
#End Region


#Region "Hypotenuse"
        <Test()> _
        Public Sub Hypotenuse()

            Dim a As Integer = 4
            Dim b As Integer = 8

            Dim hyp As Double = MathAlgorithms.Hypotenuse(a, b)

            Assert.AreEqual(hyp, System.Math.Sqrt(80))

            a = 8
            b = 4
            hyp = MathAlgorithms.Hypotenuse(a, b)

            Assert.AreEqual(hyp, System.Math.Sqrt(80))

            a = 0
            b = 0
            hyp = MathAlgorithms.Hypotenuse(a, b)
            Assert.AreEqual(hyp, 0)
        End Sub
#End Region
    End Class
End Namespace
