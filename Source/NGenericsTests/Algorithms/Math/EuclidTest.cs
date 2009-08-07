/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/

using NGenerics.Algorithms;
using NUnit.Framework;

namespace NGenerics.Tests.Algorithms.Math
{
    [TestFixture]
    public class EuclidTest
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
}