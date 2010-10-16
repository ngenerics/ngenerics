using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.DictionaryBaseTests
{
    [TestFixture]
    public class Construction
    {
        [Test]
        public void Simple()
        {
            new MockStringDictionary();
        }

        [Test]
        public void Capacity()
        {
            new MockStringDictionary(1);
        }

        [Test]
        public void CapacityComparer()
        {
            var target = new MockStringDictionary(1, StringComparer.InvariantCultureIgnoreCase);
            Assert.AreEqual(StringComparer.InvariantCultureIgnoreCase, target.Comparer);
        }

        [Test]
        public void DictionaryCompare()
        {
            var dictionary = new Dictionary<string, string> { { "a", "a" } };
            var target =
                new MockStringDictionary(dictionary, StringComparer.InvariantCultureIgnoreCase);
            Assert.AreEqual(StringComparer.InvariantCultureIgnoreCase, target.Comparer);
            Assert.AreEqual(1, target.Count);
        }

        [Test]
        public void Dictionary()
        {
            var dictionary = new Dictionary<string, string> { { "a", "a" } };
            var target = new MockStringDictionary(dictionary);
            Assert.AreEqual(1, target.Count);
        }
    }
}