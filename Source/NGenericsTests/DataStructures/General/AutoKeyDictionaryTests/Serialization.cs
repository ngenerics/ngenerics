using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.AutoKeyDictionaryTests
{
    [TestFixture]
    public class Serialization
    {
        [Test]
        public void DataContractSerializer()
        {
            var target = new AutoKeyDictionary<string, int>(x => x.ToString()) { 2 };
            ICollection<int> collection = target;
            Assert.IsTrue(collection.Contains(2));
            Assert.IsFalse(collection.Contains(1));
            Assert.IsFalse(collection.Contains(3));
        }
    }
}