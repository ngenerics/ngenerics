using System.Collections.Generic;
using NGenerics.Extensions;
using NUnit.Framework;

namespace NGenerics.Tests.Extensions
{
    [TestFixture]
    public class CollectionExtensionsTests
    {
        [Test]
        public void IsEmpty_Returns_False_When_Collection_Has_Items()
        {
            Assert.IsFalse(new List<int>() { 1 }.IsEmpty());
        }

        [Test]
        public void IsEmpty_Returns_True_When_Collection_Has_No_Items()
        {
            Assert.IsTrue(new List<int>().IsEmpty());
        }
    }
}
