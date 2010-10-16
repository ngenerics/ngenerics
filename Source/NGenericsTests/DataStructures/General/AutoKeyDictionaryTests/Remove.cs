using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.AutoKeyDictionaryTests
{
    [TestFixture]
    public class Remove
    {
        [Test]
        public void Simple()
        {
            var target = new AutoKeyDictionary<string, int>(x => x.ToString()) { 3 };
            ICollection<int> collection = target;
            Assert.IsTrue(collection.Remove(3));
            Assert.IsFalse(target.ContainsKey("3"));
            Assert.IsFalse(collection.Remove(3));
        }

        [Test]
        public void NonExisting()
        {
            var target = new AutoKeyDictionary<string, int>(x => x.ToString()) { 1 };
            ICollection<int> collection = target;
            Assert.IsFalse(collection.Remove(2));
        }
    }
}