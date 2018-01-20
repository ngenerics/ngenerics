/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/


using NGenerics.Algorithms;
using NUnit.Framework;

namespace NGenerics.Tests.Algorithms.Math.EuclidTests
{
    [TestFixture]
    public class GreatestCommonDivisor
    {
        [Test]
        public void TestValid()
        {
            Assert.AreEqual(MathAlgorithms.GreatestCommonDivisor(8, 4), 4);
            Assert.AreEqual(MathAlgorithms.GreatestCommonDivisor(4, 8), 4);

            Assert.AreEqual(MathAlgorithms.GreatestCommonDivisor(5, 1), 1);

            Assert.AreEqual(MathAlgorithms.GreatestCommonDivisor(0, 0), 0);

            Assert.AreEqual(MathAlgorithms.GreatestCommonDivisor(0, 0), 0);

            Assert.AreEqual(MathAlgorithms.GreatestCommonDivisor(180, 640), 20);
        }
    }


}