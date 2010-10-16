using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.AutoKeyDictionaryTests
{
    [TestFixture]
    public class Keys
    {
        [Test]
        public void Simple()
        {
            var target = new AutoKeyDictionary<string, int>(x => x.ToString()) { 2, 4, 9 };
            var keys = target.Keys;

            IEnumerable<string> enumerable = keys;
            var enumerator = enumerable.GetEnumerator();

            enumerator.MoveNext();
            var current = enumerator.Current;
            Assert.AreEqual("2", current);

            enumerator.MoveNext();
            current = enumerator.Current;
            Assert.AreEqual("4", current);

            enumerator.MoveNext();
            current = enumerator.Current;
            Assert.AreEqual("9", current);

        }
    }
}