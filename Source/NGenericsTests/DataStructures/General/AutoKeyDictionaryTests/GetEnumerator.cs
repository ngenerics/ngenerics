using System.Collections;
using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.AutoKeyDictionaryTests
{
    [TestFixture]
    public class GetEnumerator
    {
        [Test]
        public void Simple()
        {
            var target = new AutoKeyDictionary<string, int>(x => x.ToString()) { 2, 4, 9 };
            IEnumerable<int> enumerable = target;
            var enumerator = enumerable.GetEnumerator();

            enumerator.MoveNext();
            var current = enumerator.Current;
            Assert.AreEqual(2, current);

            enumerator.MoveNext();
            current = enumerator.Current;
            Assert.AreEqual(4, current);

            enumerator.MoveNext();
            current = enumerator.Current;
            Assert.AreEqual(9, current);
        }

        [Test]
        public void Interface()
        {
            var target = new AutoKeyDictionary<string, int>(x => x.ToString()) { 2, 4, 9 };
            IEnumerable enumerable = target;
            var enumerator = enumerable.GetEnumerator();

            enumerator.MoveNext();
            var current = (int)enumerator.Current;
            Assert.AreEqual(2, current);

            enumerator.MoveNext();
            current = (int)enumerator.Current;
            Assert.AreEqual(4, current);

            enumerator.MoveNext();
            current = (int)enumerator.Current;
            Assert.AreEqual(9, current);
        }
    }

    class GetEnumeratorImpl : GetEnumerator
    {
    }
}