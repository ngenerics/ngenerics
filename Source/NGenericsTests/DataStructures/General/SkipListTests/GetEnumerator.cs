using System.Collections;
using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SkipListTests
{
    [TestFixture]
    public class GetEnumerator
    {

        [Test]
        public void Simple()
        {
            var skipList = new SkipList<int, string>();

            var originalList = new List<KeyValuePair<int, string>>();

            for (var i = 0; i < 100; i++)
            {
                originalList.Add(new KeyValuePair<int, string>(i, i.ToString()));
                skipList.Add(originalList[i]);
            }

            var list = new List<KeyValuePair<int, string>>();

            using (var enumerator = skipList.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    list.Add(enumerator.Current);
                }
            }

            Assert.AreEqual(list.Count, 100);

            for (var i = 0; i < 100; i++)
            {
                Assert.IsTrue(list.Contains(originalList[i]));
            }
        }

        [Test]
        public void Interface()
        {
            var skipList = new SkipList<int, string>();

            var originalList = new List<KeyValuePair<int, string>>();

            for (var i = 0; i < 100; i++)
            {
                originalList.Add(new KeyValuePair<int, string>(i, i.ToString()));
                skipList.Add(originalList[i]);
            }

            var list = new List<KeyValuePair<int, string>>();

            var enumerator = ((IEnumerable)skipList).GetEnumerator();
            {
                while (enumerator.MoveNext())
                {
                    list.Add((KeyValuePair<int, string>)enumerator.Current);
                }
            }

            Assert.AreEqual(list.Count, 100);

            for (var i = 0; i < 100; i++)
            {
                Assert.IsTrue(list.Contains(originalList[i]));
            }
        }

    }
}