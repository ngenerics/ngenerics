/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using System.Collections.Generic;
using NGenerics.Algorithms;
using NUnit.Framework;

namespace NGenerics.Tests.Algorithms.Math.FibonacciTests
{
    [TestFixture]
    public class GenerateNthFibonacci
    {
        [Test]
        public void Simple()
        {
            var fib = new List<long>();

            for (var i = 0; i < 10; i++)
            {
                fib.Add(MathAlgorithms.Fibonacci(i));
            }

            Assert.AreEqual(0, fib[0]);
            Assert.AreEqual(1, fib[1]);
            Assert.AreEqual(1, fib[2]);
            Assert.AreEqual(2, fib[3]);
            Assert.AreEqual(3, fib[4]);
            Assert.AreEqual(5, fib[5]);
            Assert.AreEqual(8, fib[6]);
            Assert.AreEqual(13, fib[7]);
            Assert.AreEqual(21, fib[8]);
            Assert.AreEqual(34, fib[9]);
        }

        [Test]
        public void ExceptionNegativeUpperBound()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => MathAlgorithms.Fibonacci(-1));
        }
    }
}