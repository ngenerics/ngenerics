using System;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ListTests
{
    [TestFixture]
    public class ConvertAll
    {
        [Test]
        public void Simple()
        {
            var intListBase = new ListBase<int> {4};

            var longListBase = intListBase.ConvertAll(new Converter<int, long>(IntToLong));

            Assert.IsTrue(longListBase.Contains(4));
        }

        public static long IntToLong(int x)
        {
            return x;
        }
    }
}