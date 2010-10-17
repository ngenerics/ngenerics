using System.Collections.Generic;
using NGenerics.Extensions;
using NUnit.Framework;

namespace NGenerics.Tests.Extensions.ListExtensionsTests
{
    [TestFixture]
    public class AddRange
    {
        [Test]
        public void Simple()
        {
            IList<int> iList1 = new List<int> { 1, 2, 3, 4 };
            IList<int> iList2 = new List<int> { 5, 6 };

            iList1.AddRange(iList2);

            Assert.AreEqual(6, iList1.Count);
        }
    }
}