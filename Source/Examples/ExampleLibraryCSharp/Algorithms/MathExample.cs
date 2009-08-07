/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/


using System;
using System.Collections.Generic;
using NGenerics.Algorithms;
using NUnit.Framework;

namespace ExampleLibraryCSharp.Algorithms
{
    [TestFixture]
    public class MathExample
    {
        #region GreatestCommonDivisor
        [Test]
        public void GreatestCommonDivisorOf180And640()
        {
            var commonDivisor = MathAlgorithms.GreatestCommonDivisor(180, 640);

            // commonDivisor should be equal to 20.
            Assert.AreEqual(commonDivisor, 20);
        }
        #endregion

		#region Fibonacci
		[Test]
		public void GenerateNthFibonacci()
		{
            var tenthFibonacci = MathAlgorithms.Fibonacci(10);

			Assert.AreEqual(55, tenthFibonacci);
		}
		#endregion

		#region GenerateFibonacciSequence
		[Test]
		public void GenerateFibonacciSequence()
		{
			var fib = new List<long>();

			fib.AddRange(MathAlgorithms.GenerateFibonacciSequence(10));

			Assert.AreEqual(fib.Count, 11);

			Assert.AreEqual(fib[0], 0);
			Assert.AreEqual(fib[1], 1);
			Assert.AreEqual(fib[2], 1);
			Assert.AreEqual(fib[3], 2);
			Assert.AreEqual(fib[4], 3);
			Assert.AreEqual(fib[5], 5);
			Assert.AreEqual(fib[6], 8);
			Assert.AreEqual(fib[7], 13);
			Assert.AreEqual(fib[8], 21);
			Assert.AreEqual(fib[9], 34);
			Assert.AreEqual(fib[10], 55);
		}
		#endregion

		#region Hypotenuse
		[Test]
		public void Hypotenuse()
		{
			var a = 4;
			var b = 8;

			var hyp = MathAlgorithms.Hypotenuse(a, b);

			Assert.AreEqual(hyp, Math.Sqrt(80));

			a = 8;
			b = 4;
			hyp = MathAlgorithms.Hypotenuse(a, b);

			Assert.AreEqual(hyp, Math.Sqrt(80));

			a = 0;
			b = 0;
			hyp = MathAlgorithms.Hypotenuse(a, b);
			Assert.AreEqual(hyp, 0);
		}
		#endregion
    }
}