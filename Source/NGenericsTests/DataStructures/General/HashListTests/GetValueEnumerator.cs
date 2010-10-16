using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.HashListTests
{
    [TestFixture]
    public class GetValueEnumerator
    {
        [Test]
        public void Simple()
        {
            var hashList = new HashList<int, string> {{2, "a"}};

            Assert.AreEqual(hashList.ValueCount, 1);
            Assert.AreEqual(hashList.KeyCount, 1);

            hashList.Add(4, new List<string>(new[] { "2", "3", "4", "5" }));

            Assert.AreEqual(hashList.ValueCount, 5);
            Assert.AreEqual(hashList.KeyCount, 2);

            var enumerator = hashList.GetValueEnumerator();

            var list = new List<string>();

            while (enumerator.MoveNext())
            {
                list.Add(enumerator.Current);
            }

            Assert.AreEqual(list.Count, 5);
            Assert.IsTrue(list.Contains("a"));
            Assert.IsTrue(list.Contains("2"));
            Assert.IsTrue(list.Contains("3"));
            Assert.IsTrue(list.Contains("4"));
            Assert.IsTrue(list.Contains("5"));
        }
    }
}