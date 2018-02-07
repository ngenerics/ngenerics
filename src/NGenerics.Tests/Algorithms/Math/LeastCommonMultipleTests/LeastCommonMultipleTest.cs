/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.Algorithms;
using NUnit.Framework;

namespace NGenerics.Tests.Algorithms.Math.LeastCommonMultipleTests
{
    [TestFixture]
    public class LeastCommonMultipleTest
    {
        [Test]
        public void Lease_Common_Multiple_Between_Zero_And_Zero_Should_Be_Zero()
        {
            Assert.AreEqual(0, MathAlgorithms.LeastCommonMultiple(0, 0));
        }

        [Test]
        public void Should_Return_Correct_Values_For_Non_Zero_Inputs()
        {
            Assert.AreEqual(204, MathAlgorithms.LeastCommonMultiple(34, 12));
            Assert.AreEqual(3015, MathAlgorithms.LeastCommonMultiple(45, 67));
            Assert.AreEqual(71264, MathAlgorithms.LeastCommonMultiple(34, 4192));
            Assert.AreEqual(780, MathAlgorithms.LeastCommonMultiple(12, 65));
            Assert.AreEqual(192, MathAlgorithms.LeastCommonMultiple(12, 64));
        }
    }
}