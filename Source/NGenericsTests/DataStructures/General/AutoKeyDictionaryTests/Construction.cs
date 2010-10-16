using System;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.AutoKeyDictionaryTests
{
    [TestFixture]
    public class Construction
    {
        [Test]
        public void Simple()
        {
            new AutoKeyDictionary<string, int>(x => x.ToString());
        }

        [Test]
        public void Comparer()
        {
            new AutoKeyDictionary<string, int>(x => x.ToString(), StringComparer.InvariantCultureIgnoreCase);
        }

        [Test]
        public void CapacityComparer()
        {
            var target = new AutoKeyDictionary<string, int>(x => x.ToString(), StringComparer.InvariantCultureIgnoreCase, 1);
            Assert.AreEqual(StringComparer.InvariantCultureIgnoreCase, target.Comparer);
        }
    }
}