using NGenerics.Comparers;
using NUnit.Framework;

namespace NGenerics.Tests.Comparers.KeyValuePairComparerTests
{
    [TestFixture]
    public class Construction
    {
        [Test]
        public void Simple()
        {
            new KeyValuePairComparer<int, string>();
        }
    }
}