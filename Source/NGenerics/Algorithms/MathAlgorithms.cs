/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/


using System;
using System.Diagnostics.CodeAnalysis;

namespace NGenerics.Algorithms
{
    /// <summary>
    /// General math functions.
    /// </summary>
    public static class MathAlgorithms
    {
        #region Fibonacci Sequence

        [SuppressMessage("Microsoft.Usage", "CA2211:NonConstantFieldsShouldNotBeVisible")]
        internal static readonly long[] FibonacciSequence = new[]{0,
                                                                       1,
                                                                       1,
                                                                       2,
                                                                       3,
                                                                       5,
                                                                       8,
                                                                       13,
                                                                       21,
                                                                       34,
                                                                       55,
                                                                       89,
                                                                       144,
                                                                       233,
                                                                       377,
                                                                       610,
                                                                       987,
                                                                       1597,
                                                                       2584,
                                                                       4181,
                                                                       6765,
                                                                       10946,
                                                                       17711,
                                                                       28657,
                                                                       46368,
                                                                       75025,
                                                                       121393,
                                                                       196418,
                                                                       317811,
                                                                       514229,
                                                                       832040,
                                                                       1346269,
                                                                       2178309,
                                                                       3524578,
                                                                       5702887,
                                                                       9227465,
                                                                       14930352,
                                                                       24157817,
                                                                       39088169,
                                                                       63245986,
                                                                       102334155,
                                                                       165580141,
                                                                       267914296,
                                                                       433494437,
                                                                       701408733,
                                                                       1134903170,
                                                                       1836311903,
                                                                       2971215073,
                                                                       4807526976,
                                                                       7778742049,
                                                                       12586269025,
                                                                       20365011074,
                                                                       32951280099,
                                                                       53316291173,
                                                                       86267571272,
                                                                       139583862445,
                                                                       225851433717,
                                                                       365435296162,
                                                                       591286729879,
                                                                       956722026041,
                                                                       1548008755920,
                                                                       2504730781961,
                                                                       4052739537881,
                                                                       6557470319842,
                                                                       10610209857723,
                                                                       17167680177565,
                                                                       27777890035288,
                                                                       44945570212853,
                                                                       72723460248141,
                                                                       117669030460994,
                                                                       190392490709135,
                                                                       308061521170129,
                                                                       498454011879264,
                                                                       806515533049393,
                                                                       1304969544928657,
                                                                       2111485077978050,
                                                                       3416454622906707,
                                                                       5527939700884757,
                                                                       8944394323791464,
                                                                       14472334024676221,
                                                                       23416728348467685,
                                                                       37889062373143906,
                                                                       61305790721611591,
                                                                       99194853094755497,
                                                                       160500643816367088,
                                                                       259695496911122585,
                                                                       420196140727489673,
                                                                       679891637638612258,
                                                                       1100087778366101931,
                                                                       1779979416004714189,
                                                                       2880067194370816120,
                                                                       4660046610375530309,
                                                                       7540113804746346429};

        #endregion

        #region Public Methods

        /// <summary>
        /// Finds the greatest common divisor.
        /// </summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <returns>The greatest common divisor between the two integers supplied.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\Algorithms\MathExample.cs" region="GreatestCommonDivisor" lang="cs" title="The following example shows how to use the FindGreatestCommonDivisor method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\Algorithms\MathExample.vb"  region="GreatestCommonDivisor" lang="vbnet" title="The following example shows how to use the FindGreatestCommonDivisor method."/>
        /// </example>
        public static int GreatestCommonDivisor(int firstNumber, int secondNumber)
        {
            while (secondNumber != 0)
            {
                var temp = firstNumber % secondNumber;
                firstNumber = secondNumber;
                secondNumber = temp;
            }

            return Math.Abs(firstNumber);

        }

        /// <summary>
        /// Finds the least common multiple of the two numbers.
        /// </summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <returns>The least common multiple of the two numbers.</returns>
        public static long LeastCommonMultiple(int firstNumber, int secondNumber)
        {
            var temp = GreatestCommonDivisor(firstNumber, secondNumber);

            if (temp != 0)
            {
                //Dont use Math.BigMul as it does not exist in silverlight
// ReSharper disable RedundantCast
                var product = (long) firstNumber*(long) secondNumber;  
// ReSharper restore RedundantCast
                return Math.Abs(product) / temp;
            }

            return 0;
        }

        /// <summary>
        /// Generates the Nth Fibonacci number.
        /// </summary>
        /// <param name="nthElement">The value of N.</param>
        /// <returns>The Nth number in the Fibonacci sequence.</returns>    
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\Algorithms\MathExample.cs" region="Fibonacci" lang="cs" title="The following example shows how to use the GenerateNthFibonacci method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\Algorithms\MathExample.vb"  region="Fibonacci" lang="vbnet" title="The following example shows how to use the GenerateNthFibonacci method."/>
        /// </example>      
        public static long Fibonacci(int nthElement)
        {
            if ((nthElement < 0) || (nthElement >= FibonacciSequence.Length))
            {
                throw new ArgumentOutOfRangeException("nthElement");
            }

            long previous = 1, next = 0;

            for (var i = nthElement; i > 0; --i)
            {
                next += previous;
                previous = next - previous;
            }
            return next;
        }

        /// <summary>
        /// Generates the Fibonacci number series until the Nth element.
        /// </summary>
        /// <param name="nthElement">The upper bound N.</param>
        /// <returns>A series of Fibonacci numbers until the <paramref name="nthElement"/>.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\Algorithms\MathExample.cs" region="GenerateFibonacciSequence" lang="cs" title="The following example shows how to use the GenerateFibonacciSequence method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\Algorithms\MathExample.vb"  region="GenerateFibonacciSequence" lang="vbnet" title="The following example shows how to use the GenerateFibonacciSequence method."/>
        /// </example>      
        public static long[] GenerateFibonacciSequence(int nthElement)
        {
            if ((nthElement < 0) || (nthElement >= FibonacciSequence.Length))
            {
                throw new ArgumentOutOfRangeException("nthElement");
            }

            var numbers = new long[nthElement + 1];
            Array.Copy(FibonacciSequence, 0, numbers, 0, nthElement + 1);

            return numbers;
        }

        /// <summary>
        /// Calculates the Hypotenuse of a triangle.
        /// </summary>
        /// <param name="a">One of the shorter sides of the triangle.</param>
        /// <param name="b">One of the shorter sides of the triangle.</param>
        /// <returns>The Hypotenuse of a triangle.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\Algorithms\MathExample.cs" region="Hypotenuse" lang="cs" title="The following example shows how to use the Hypotenuse method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\Algorithms\MathExample.vb"  region="Hypotenuse" lang="vbnet" title="The following example shows how to use the Hypotenuse method."/>
        /// </example>      
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "a")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "b")]
        public static double Hypotenuse(double a, double b)
        {
            var absA = Math.Abs(a);
            var absB = Math.Abs(b);

            return Math.Sqrt((absB * absB) + (absA * absA));
        }

        #endregion
    }
}
