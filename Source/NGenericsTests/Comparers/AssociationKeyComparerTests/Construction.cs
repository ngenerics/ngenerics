using NGenerics.Comparers;
using NUnit.Framework;

namespace NGenerics.Tests.Comparers.AssociationKeyComparerTests
{
    [TestFixture]
    public class Construction
    {
        [Test]
        public void Simple()
        {
            new AssociationKeyComparer<int, string>();
        }
    }
}