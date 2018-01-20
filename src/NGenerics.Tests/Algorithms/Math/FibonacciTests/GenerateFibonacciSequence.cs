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
    public class GenerateFibonacciSequence
    {
        [Test]
        public void Simple()
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

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionNegativeUpperBound()
        {
            MathAlgorithms.GenerateFibonacciSequence(-1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Huge()
        {
            var setupLength = MathAlgorithms.FibonacciSequence.Length;

            MathAlgorithms.GenerateFibonacciSequence(setupLength + 10);

        }
    }

}