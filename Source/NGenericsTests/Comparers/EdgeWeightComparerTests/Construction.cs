using NGenerics.Comparers;
using NUnit.Framework;

namespace NGenerics.Tests.Comparers.EdgeWeightComparerTests
{
    [TestFixture]
    public class Construction
    {
        [Test]
        public void Simple()
        {
            new EdgeWeightComparer<int>();
        }
    }
}