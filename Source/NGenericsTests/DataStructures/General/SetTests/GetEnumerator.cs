using System.Collections;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SetTests
{
    [TestFixture]
    public class GetEnumerator
    {

        [Test]
        public void Simple()
        {
            var pascalSet = new PascalSet(0, 50, new[] { 20, 25, 30, 35, 40 });

            var enumerator = pascalSet.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual(enumerator.Current, 20);

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual(enumerator.Current, 25);

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual(enumerator.Current, 30);

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual(enumerator.Current, 35);

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual(enumerator.Current, 40);

            Assert.IsFalse(enumerator.MoveNext());
        }

        [Test]
        public void Interface()
        {
            var pascalSet = new PascalSet(0, 50, new[] { 20, 25, 30, 35, 40 });

            var enumerator = ((IEnumerable)pascalSet).GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual((int)enumerator.Current, 20);

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual((int)enumerator.Current, 25);

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual((int)enumerator.Current, 30);

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual((int)enumerator.Current, 35);

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual((int)enumerator.Current, 40);

            Assert.IsFalse(enumerator.MoveNext());
        }

    }
}