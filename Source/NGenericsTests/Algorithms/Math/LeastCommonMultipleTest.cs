using NUnit.Framework;
using NGenerics.Algorithms;

namespace NGenerics.Tests.Algorithms.Math
{
    [TestFixture]
    public class LeastCommonMultipleTest
    {
        [Test]
        public void Lease_Common_Multiple_Between_Zero_And_Zero_Should_Be_Zero()
        {
            Assert.AreEqual(MathAlgorithms.LeastCommonMultiple(0, 0), 0);
        }

        [Test]
        public void Should_Return_Correct_Values_For_Non_Zero_Inputs()
        {
            Assert.AreEqual(MathAlgorithms.LeastCommonMultiple(34, 12), 204);
            Assert.AreEqual(MathAlgorithms.LeastCommonMultiple(45, 67), 3015);
            Assert.AreEqual(MathAlgorithms.LeastCommonMultiple(34, 4192), 71264);
            Assert.AreEqual(MathAlgorithms.LeastCommonMultiple(12, 65), 780);
            Assert.AreEqual(MathAlgorithms.LeastCommonMultiple(12, 64), 192);
        }
    }
}