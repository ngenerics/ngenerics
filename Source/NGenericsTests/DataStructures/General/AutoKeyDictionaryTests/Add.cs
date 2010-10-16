using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.AutoKeyDictionaryTests
{
    [TestFixture]
    public class Add
    {
        [Test]
        public void Interface()
        {
            var target = new AutoKeyDictionary<string, int>(x => x.ToString());
            ICollection<int> collection = target;
            collection.Add(1);
            Assert.IsTrue(target.Contains(1));
        }
    }
}