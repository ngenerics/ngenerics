'  
' Copyright 2009 The NGenerics Team
' (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)
'
' This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
' have received a copy of the license along with the source code.  If not, an online copy
' of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
'

Imports NGenerics.DataStructures.Mathematical
Imports NUnit.Framework

<TestFixture()> _
Public Class MatrixExamples

#Region "Clone"
    <Test()> _
    Public Sub CloneExample()
        Dim matrix As New Matrix(2, 2)
        matrix.Item(0, 0) = 1
        matrix.Item(0, 1) = 2
        matrix.Item(1, 0) = 3
        matrix.Item(1, 1) = 4
        Dim clone As Matrix = matrix.Clone
        Assert.AreEqual(matrix.Rows, clone.Rows)
        Assert.AreEqual(matrix.Columns, clone.Columns)
        Assert.IsTrue(matrix.Equals(clone))
    End Sub
#End Region

#Region "Constructor"
    <Test()> _
    Public Sub ConstructorExample()
        Dim matrix As New Matrix(2, 3)
        Assert.AreEqual(2, matrix.Rows)
        Assert.AreEqual(3, matrix.Columns)
    End Sub
#End Region

#Region "Equals"
    <Test()> _
    Public Sub EqualsExample()
        Dim matrix1 As New Matrix(2, 2)
        matrix1.Item(0, 0) = 1
        matrix1.Item(0, 1) = 2
        matrix1.Item(1, 1) = 3
        matrix1.Item(1, 0) = 4
        Dim matrix2 As New Matrix(2, 2)
        matrix2.Item(0, 0) = 1
        matrix2.Item(0, 1) = 2
        matrix2.Item(1, 1) = 3
        matrix2.Item(1, 0) = 4
        Assert.IsTrue(matrix1.Equals(matrix2))
        Dim matrix3 As New Matrix(2, 2)
        matrix3.Item(0, 0) = 1
        matrix3.Item(0, 1) = 2
        matrix3.Item(1, 1) = 3
        matrix3.Item(1, 0) = 5
        Assert.IsFalse(matrix1.Equals(matrix3))
    End Sub
#End Region

#Region "GetSubMatrix"
    <Test()> _
    Public Sub GetSubMatrixExample()
        Dim matrix As New Matrix(3, 3)
        matrix.Item(0, 0) = 1
        matrix.Item(0, 1) = 2
        matrix.Item(0, 2) = 3
        matrix.Item(1, 0) = 4
        matrix.Item(1, 1) = 5
        matrix.Item(1, 2) = 6
        matrix.Item(2, 0) = 7
        matrix.Item(2, 1) = 8
        matrix.Item(2, 2) = 9
        Dim result1 As Matrix = matrix.GetSubMatrix(0, 0, 1, 1)
        Assert.AreEqual(1, result1.Rows)
        Assert.AreEqual(1, result1.Columns)
        Dim result2 As Matrix = matrix.GetSubMatrix(1, 2, 2, 1)
        Assert.AreEqual(2, result2.Rows)
        Assert.AreEqual(1, result2.Columns)
    End Sub
#End Region

#Region "IsSymmetric"
    <Test()> _
    Public Sub IsSymmetricExample()
        Dim matrix1 As New Matrix(2, 3)
        matrix1.Item(0, 0) = -2
        matrix1.Item(0, 1) = 3
        matrix1.Item(0, 2) = 2
        matrix1.Item(1, 0) = 4
        matrix1.Item(1, 1) = 6
        matrix1.Item(1, 2) = -2
        Assert.IsFalse(matrix1.IsSymmetric)
        Dim matrix2 As New Matrix(2, 2)
        matrix2.Item(0, 0) = -2
        matrix2.Item(0, 1) = 3
        matrix2.Item(1, 0) = 4
        matrix2.Item(1, 1) = 6
        Assert.IsFalse(matrix2.IsSymmetric)
        Dim matrix3 As New Matrix(2, 2)
        matrix3.Item(0, 0) = 1
        matrix3.Item(0, 1) = 1
        matrix3.Item(1, 0) = 1
        matrix3.Item(1, 1) = 1
        Assert.IsTrue(matrix3.IsSymmetric)
        Dim matrix4 As New Matrix(3, 3)
        matrix4.Item(0, 0) = 1
        matrix4.Item(0, 1) = 2
        matrix4.Item(0, 2) = 3
        matrix4.Item(1, 0) = 2
        matrix4.Item(1, 1) = -4
        matrix4.Item(1, 2) = 5
        matrix4.Item(2, 0) = 3
        matrix4.Item(2, 1) = 5
        matrix4.Item(2, 2) = 6
        Assert.IsTrue(matrix4.IsSymmetric)
    End Sub
#End Region

#Region "MultiplyMatrixDouble"
    <Test()> _
    Public Sub MultiplyMatrixDoubleExample()
        Dim matrix1 As New Matrix(2, 3)
        matrix1.Item(0, 0) = 1
        matrix1.Item(0, 1) = 4
        matrix1.Item(0, 2) = 5
        matrix1.Item(1, 0) = -3
        matrix1.Item(1, 1) = 2
        matrix1.Item(1, 2) = 7
        Dim expectedMatrix As New Matrix(2, 3)
        expectedMatrix.Item(0, 0) = 2
        expectedMatrix.Item(0, 1) = 8
        expectedMatrix.Item(0, 2) = 10
        expectedMatrix.Item(1, 0) = -6
        expectedMatrix.Item(1, 1) = 4
        expectedMatrix.Item(1, 2) = 14
        Assert.IsTrue(matrix1.Multiply(CDbl(2)).Equals(expectedMatrix))
    End Sub
#End Region

#Region "MultiplyMatrixMatrix"
    <Test()> _
    Public Sub MultiplyMatrixMatrixExample()
        Dim matrix1 As New Matrix(2, 3)
        matrix1.Item(0, 0) = -2
        matrix1.Item(0, 1) = 3
        matrix1.Item(0, 2) = 2
        matrix1.Item(1, 0) = 4
        matrix1.Item(1, 1) = 6
        matrix1.Item(1, 2) = -2
        Dim matrix2 As New Matrix(3, 4)
        matrix2.Item(0, 0) = 4
        matrix2.Item(0, 1) = -1
        matrix2.Item(0, 2) = 2
        matrix2.Item(0, 3) = 5
        matrix2.Item(1, 0) = 3
        matrix2.Item(1, 1) = 0
        matrix2.Item(1, 2) = 1
        matrix2.Item(1, 3) = 1
        matrix2.Item(2, 0) = -2
        matrix2.Item(2, 1) = 3
        matrix2.Item(2, 2) = 5
        matrix2.Item(2, 3) = -3
        Dim expectedMatrix As New Matrix(2, 4)
        expectedMatrix.Item(0, 0) = -3
        expectedMatrix.Item(0, 1) = 8
        expectedMatrix.Item(0, 2) = 9
        expectedMatrix.Item(0, 3) = -13
        expectedMatrix.Item(1, 0) = 38
        expectedMatrix.Item(1, 1) = -10
        expectedMatrix.Item(1, 2) = 4
        expectedMatrix.Item(1, 3) = 32
        Assert.IsTrue(matrix1.Multiply(matrix2).Equals(expectedMatrix))
    End Sub
#End Region

#Region "Negate"
    <Test()> _
    Public Sub NegateExample()
        Dim matrix1 As New Matrix(2, 3)
        matrix1.Item(0, 0) = 1
        matrix1.Item(0, 1) = 4
        matrix1.Item(0, 2) = 5
        matrix1.Item(1, 0) = -3
        matrix1.Item(1, 1) = 2
        matrix1.Item(1, 2) = 7
        Dim expectedMatrix As New Matrix(2, 3)
        expectedMatrix.Item(0, 0) = -1
        expectedMatrix.Item(0, 1) = -4
        expectedMatrix.Item(0, 2) = -5
        expectedMatrix.Item(1, 0) = 3
        expectedMatrix.Item(1, 1) = -2
        expectedMatrix.Item(1, 2) = -7
        Assert.IsTrue(matrix1.Negate.Equals(expectedMatrix))
    End Sub
#End Region

#Region "OperatorMinus"
    <Test()> _
    Public Sub OperatorMinusExample()
        Dim matrix1 As New Matrix(2, 3)
        matrix1.Item(0, 0) = 1
        matrix1.Item(0, 1) = 2
        matrix1.Item(0, 2) = -4
        matrix1.Item(1, 0) = 0
        matrix1.Item(1, 1) = 3
        matrix1.Item(1, 2) = -1
        Dim matrix2 As New Matrix(2, 3)
        matrix2.Item(0, 0) = -1
        matrix2.Item(0, 1) = 0
        matrix2.Item(0, 2) = 2
        matrix2.Item(1, 0) = 1
        matrix2.Item(1, 1) = -5
        matrix2.Item(1, 2) = 3
        Dim expectedMatrix As New Matrix(2, 3)
        expectedMatrix.Item(0, 0) = 2
        expectedMatrix.Item(0, 1) = 2
        expectedMatrix.Item(0, 2) = -6
        expectedMatrix.Item(1, 0) = -1
        expectedMatrix.Item(1, 1) = 8
        expectedMatrix.Item(1, 2) = -4
        Dim result As Matrix = (matrix1 - matrix2)
        Assert.IsTrue(result.Equals(expectedMatrix))
    End Sub
#End Region

#Region "Subtract"
    <Test()> _
    Public Sub SubtractExample()
        Dim matrix1 As New Matrix(2, 3)
        matrix1.Item(0, 0) = 1
        matrix1.Item(0, 1) = 2
        matrix1.Item(0, 2) = -4
        matrix1.Item(1, 0) = 0
        matrix1.Item(1, 1) = 3
        matrix1.Item(1, 2) = -1
        Dim matrix2 As New Matrix(2, 3)
        matrix2.Item(0, 0) = -1
        matrix2.Item(0, 1) = 0
        matrix2.Item(0, 2) = 2
        matrix2.Item(1, 0) = 1
        matrix2.Item(1, 1) = -5
        matrix2.Item(1, 2) = 3
        Dim expectedMatrix As New Matrix(2, 3)
        expectedMatrix.Item(0, 0) = 2
        expectedMatrix.Item(0, 1) = 2
        expectedMatrix.Item(0, 2) = -6
        expectedMatrix.Item(1, 0) = -1
        expectedMatrix.Item(1, 1) = 8
        expectedMatrix.Item(1, 2) = -4
        Dim result As Matrix = matrix1.Subtract(matrix2)
        Assert.IsTrue(result.Equals(expectedMatrix))
    End Sub
#End Region

#Region "OperatorMultiplyMatrixDouble"
    <Test()> _
    Public Sub OperatorMultiplyMatrixDoubleExample()
        Dim matrix1 As New Matrix(2, 3)
        matrix1.Item(0, 0) = 1
        matrix1.Item(0, 1) = 4
        matrix1.Item(0, 2) = 5
        matrix1.Item(1, 0) = -3
        matrix1.Item(1, 1) = 2
        matrix1.Item(1, 2) = 7
        Dim expectedMatrix As New Matrix(2, 3)
        expectedMatrix.Item(0, 0) = 2
        expectedMatrix.Item(0, 1) = 8
        expectedMatrix.Item(0, 2) = 10
        expectedMatrix.Item(1, 0) = -6
        expectedMatrix.Item(1, 1) = 4
        expectedMatrix.Item(1, 2) = 14
        Dim result As Matrix = DirectCast((matrix1 * 2), Matrix)
        Assert.IsTrue(result.Equals(expectedMatrix))
        result = DirectCast((2 * matrix1), Matrix)
        Assert.IsTrue(result.Equals(expectedMatrix))
    End Sub
#End Region

#Region "OperatorMultiplyMatrixMatrix"
    <Test()> _
    Public Sub OperatorMultiplyMatrixMatrixExample()
        Dim matrix1 As New Matrix(2, 3)
        matrix1.Item(0, 0) = -2
        matrix1.Item(0, 1) = 3
        matrix1.Item(0, 2) = 2
        matrix1.Item(1, 0) = 4
        matrix1.Item(1, 1) = 6
        matrix1.Item(1, 2) = -2
        Dim matrix2 As New Matrix(3, 4)
        matrix2.Item(0, 0) = 4
        matrix2.Item(0, 1) = -1
        matrix2.Item(0, 2) = 2
        matrix2.Item(0, 3) = 5
        matrix2.Item(1, 0) = 3
        matrix2.Item(1, 1) = 0
        matrix2.Item(1, 2) = 1
        matrix2.Item(1, 3) = 1
        matrix2.Item(2, 0) = -2
        matrix2.Item(2, 1) = 3
        matrix2.Item(2, 2) = 5
        matrix2.Item(2, 3) = -3
        Dim expectedMatrix As New Matrix(2, 4)
        expectedMatrix.Item(0, 0) = -3
        expectedMatrix.Item(0, 1) = 8
        expectedMatrix.Item(0, 2) = 9
        expectedMatrix.Item(0, 3) = -13
        expectedMatrix.Item(1, 0) = 38
        expectedMatrix.Item(1, 1) = -10
        expectedMatrix.Item(1, 2) = 4
        expectedMatrix.Item(1, 3) = 32
        Dim result As Matrix = (matrix1 * matrix2)
        Assert.IsTrue(result.Equals(expectedMatrix))
    End Sub
#End Region

#Region "OperatorPlus"
    <Test()> _
    Public Sub OperatorPlusExample()
        Dim matrix1 As New Matrix(2, 3)
        matrix1.Item(0, 0) = 1
        matrix1.Item(0, 1) = 2
        matrix1.Item(0, 2) = -4
        matrix1.Item(1, 0) = 0
        matrix1.Item(1, 1) = 3
        matrix1.Item(1, 2) = -1
        Dim matrix2 As New Matrix(2, 3)
        matrix2.Item(0, 0) = -1
        matrix2.Item(0, 1) = 0
        matrix2.Item(0, 2) = 2
        matrix2.Item(1, 0) = 1
        matrix2.Item(1, 1) = -5
        matrix2.Item(1, 2) = 3
        Dim expectedMatrix As New Matrix(2, 3)
        expectedMatrix.Item(0, 0) = 0
        expectedMatrix.Item(0, 1) = 2
        expectedMatrix.Item(0, 2) = -2
        expectedMatrix.Item(1, 0) = 1
        expectedMatrix.Item(1, 1) = -2
        expectedMatrix.Item(1, 2) = 2
        Dim result As Matrix = (matrix1 + matrix2)
        Assert.IsTrue(result.Equals(expectedMatrix))
    End Sub
#End Region

#Region "Add"
    <Test()> _
    Public Sub AddExample()
        Dim matrix1 As New Matrix(2, 3)
        matrix1.Item(0, 0) = 1
        matrix1.Item(0, 1) = 2
        matrix1.Item(0, 2) = -4
        matrix1.Item(1, 0) = 0
        matrix1.Item(1, 1) = 3
        matrix1.Item(1, 2) = -1

        Dim matrix2 As New Matrix(2, 3)
        matrix2.Item(0, 0) = -1
        matrix2.Item(0, 1) = 0
        matrix2.Item(0, 2) = 2
        matrix2.Item(1, 0) = 1
        matrix2.Item(1, 1) = -5
        matrix2.Item(1, 2) = 3

        Dim expectedMatrix As New Matrix(2, 3)
        expectedMatrix.Item(0, 0) = 0
        expectedMatrix.Item(0, 1) = 2
        expectedMatrix.Item(0, 2) = -2
        expectedMatrix.Item(1, 0) = 1
        expectedMatrix.Item(1, 1) = -2
        expectedMatrix.Item(1, 2) = 2

        Dim result As Matrix = matrix1.Add(matrix2)
        Assert.IsTrue(result.Equals(expectedMatrix))
    End Sub
#End Region

#Region "Transpose"
    <Test()> _
    Public Sub TransposeExample()
        Dim matrix1 As New Matrix(2, 3)
        matrix1.Item(0, 0) = 1
        matrix1.Item(0, 1) = 4
        matrix1.Item(0, 2) = 5
        matrix1.Item(1, 0) = -3
        matrix1.Item(1, 1) = 2
        matrix1.Item(1, 2) = 7

        '            T			[ 1, -3]
        ' [ 1, 4,  5]    =		[ 4,  2)
        ' [-3, 2,  7]			[ 5,  7]

        Dim expectedMatrix As New Matrix(3, 2)
        expectedMatrix.Item(0, 0) = 1
        expectedMatrix.Item(0, 1) = -3
        expectedMatrix.Item(1, 0) = 4
        expectedMatrix.Item(1, 1) = 2
        expectedMatrix.Item(2, 0) = 5
        expectedMatrix.Item(2, 1) = 7
        Assert.IsTrue(matrix1.Transpose.Equals(expectedMatrix))
    End Sub
#End Region

#Region "Minor"
    <Test()> _
    Public Sub MinorExample()
        Dim matrix As Matrix = New Matrix(4, 5)
        Dim minor As Matrix = matrix.Minor(2, 3)

        ' The resulting matrix will have one less column,
        ' and one less row.
        Assert.AreEqual(minor.Columns, 4)
        Assert.AreEqual(minor.Rows, 3)
    End Sub
#End Region


#Region "Adjoint"
    <Test()> _
Public Sub AdjointExample()

        'A = [ a, b ]
        '    [ c, d ]
        Dim matrix As Matrix = New Matrix(2, 2)
        matrix(0, 0) = 2
        matrix(0, 1) = 4
        matrix(1, 0) = 1
        matrix(1, 1) = 3

        Dim a As Matrix = matrix.Adjoint()

        ' Adj(A) = [ d, -b]
        '          [ -c, a]
        Assert.AreEqual(a(0, 0), 3)
        Assert.AreEqual(a(0, 1), -4)
        Assert.AreEqual(a(1, 0), -1)
        Assert.AreEqual(a(1, 1), 2)
    End Sub
#End Region

#Region "Inverse"
    <Test()> _
    Public Sub InverseExample()

        ' [  1, -1,  3 ] -1
        ' [  2,  1,  2 ]
        ' [ -2, -2,  1 ]

        ' Set up the matrix to look like the above sample.
        Dim matrix As Matrix = New Matrix(3, 3)
        matrix(0, 0) = 1
        matrix(0, 1) = -1
        matrix(0, 2) = 3

        matrix(1, 0) = 2
        matrix(1, 1) = 1
        matrix(1, 2) = 2

        matrix(2, 0) = -2
        matrix(2, 1) = -2
        matrix(2, 2) = 1

        ' Calculate the inverse of the matrix
        Dim a As Matrix = matrix.Inverse()

        ' The Inverse should be the following :
        ' [  1,        -1,   -1 ]
        ' [  -(6/5),  7/5,  4/5 ]
        ' [  -(2/5),  4/5,  3/5 ]

        Assert.AreEqual(1, a(0, 0))
        Dim delta As Double = 0.0000001
        Assert.AreEqual(-1, a(0, 1), delta)
        Assert.AreEqual(a(0, 2), -1)

        Assert.AreEqual((6.0F / 5.0F) * -1.0F, a(1, 0), delta)
        Assert.AreEqual(7.0F / 5.0F, a(1, 1), delta)
        Assert.AreEqual(4.0F / 5.0F, a(1, 2), delta)

        Assert.AreEqual((2.0F / 5.0F) * -1.0F, a(2, 0), delta)
        Assert.AreEqual(4.0F / 5.0F, a(2, 1), delta)
        Assert.AreEqual(3.0F / 5.0F, a(2, 2), delta)
    End Sub
#End Region

#Region "Concatenate"
    <Test()> _
Public Sub ConcatenateExample()

        Dim matrix1 As Matrix = New Matrix(2, 2)

        ' Set up the matrix to look like the following :
        ' (1, 2)
        ' [3, 4]
        matrix1(0, 0) = 1
        matrix1(0, 1) = 2
        matrix1(0, 1) = 3
        matrix1(0, 1) = 4

        ' Set up the second matrix to look like the following :
        ' [5, 6]
        ' [7, 8]
        Dim matrix2 As Matrix = New Matrix(2, 2)
        matrix2(0, 0) = 5
        matrix2(0, 1) = 6
        matrix2(0, 1) = 7
        matrix2(0, 1) = 8

        ' Concatenate the two matrices
        Dim concat As Matrix = matrix1.Concatenate(matrix2)

        ' The result looks like this :
        ' (1, 2, 5, 6]
        ' [3, 4, 7, 8]
        '
        ' And the columns have increased to 4, while the rows 
        ' stayed the same...
        Assert.AreEqual(concat.Columns, 4)
        Assert.AreEqual(concat.Rows, 2)
    End Sub
#End Region

#Region "MultiplyColumn"
    <Test()> _
   Public Sub MultiplyColumnExample()

        ' Set up a sample matrix to look like this :
        ' (1, 2)
        ' [3, 4]
        Dim matrix As Matrix = New Matrix(2, 2)

        matrix(0, 0) = 1
        matrix(0, 1) = 2
        matrix(1, 0) = 3
        matrix(1, 1) = 4

        ' Multiply the second column by 3
        matrix.MultiplyColumn(1, 3)

        ' Now the matrix looks like this :
        ' (1,  6]
        ' [3, 12)
        Assert.AreEqual(matrix(0, 0), 1)
        Assert.AreEqual(matrix(0, 1), 6)
        Assert.AreEqual(matrix(1, 0), 3)
        Assert.AreEqual(matrix(1, 1), 12)
    End Sub
#End Region


#Region "MultiplyRow"
    <Test()> _
Public Sub MultiplyRowExample()
        ' Set up a sample matrix to look like this :
        ' (1, 2)
        ' [3, 4]
        Dim matrix As Matrix = New Matrix(2, 2)

        matrix(0, 0) = 1
        matrix(0, 1) = 2
        matrix(1, 0) = 3
        matrix(1, 1) = 4

        ' Multiply the second row by 3
        matrix.MultiplyRow(1, 3)

        ' Now the matrix looks like this :
        ' (1,  2)
        ' [9, 12)
        Assert.AreEqual(matrix(0, 0), 1)
        Assert.AreEqual(matrix(0, 1), 2)
        Assert.AreEqual(matrix(1, 0), 9)
        Assert.AreEqual(matrix(1, 1), 12)
    End Sub
#End Region

#Region "Determinant"
    <Test()> _
    Public Sub DeterminantExample()

        ' Set up a sample matrix
        Dim matrix As Matrix = New Matrix(3, 3)

        ' [ 3,  1,  8 ]
        ' [ 2, -5,  4 ]
        ' [-1,  6, -2 ]
        ' Determinant = 14

        matrix(0, 0) = 3
        matrix(0, 1) = 1
        matrix(0, 2) = 8

        matrix(1, 0) = 2
        matrix(1, 1) = -5
        matrix(1, 2) = 4

        matrix(2, 0) = -1
        matrix(2, 1) = 6
        matrix(2, 2) = -2

        ' Calculate the determinant - the answer is 14.
        Assert.AreEqual(14, matrix.Determinant(), 0.000000001)
    End Sub
#End Region

#Region "IsSingular"
    <Test()> _
Public Sub IsSingularExample()

        ' Set up a sample matrix.
        Dim matrix As Matrix = New Matrix(3, 3)

        ' [ 4,  4,  4 ]
        ' [ 4,  4,  4 ]
        ' [ 4,  4,  4 ]
        ' Determinant = 0

        matrix(0, 0) = 4
        matrix(0, 1) = 4
        matrix(0, 2) = 4

        matrix(1, 0) = 4
        matrix(1, 1) = 4
        matrix(1, 2) = 4

        ' The determinant is equal to 0, so the matrix
        ' is singular.
        Assert.AreEqual(matrix.IsSingular, True)
    End Sub
#End Region

End Class