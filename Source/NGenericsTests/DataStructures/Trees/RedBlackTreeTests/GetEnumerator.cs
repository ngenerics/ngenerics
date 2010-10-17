using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.RedBlackTreeTests
{
    [TestFixture]
    public class GetEnumerator : RedBlackTreeTest
    {

        [Test]
        public void Simple1()
        {
            var list = new List<KeyValuePair<int, string>>();
            var redBlackTree = GetTestTree();

            using (var enumerator = redBlackTree.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    list.Add(enumerator.Current);
                }

            }
        }

        [Test]
        public void Simple2()
        {
            var redBlackTree = GetTestTree();
            var list = new List<KeyValuePair<int, string>>();

            using (var enumerator = redBlackTree.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    list.Add(enumerator.Current);
                }
            }

            Assert.AreEqual(list.Count, 100);

            for (var i = 0; i < 100; i++)
            {
                Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(i, i.ToString())));
            }
        }

        [Test]
        public void Interface()
        {
            var list = new List<KeyValuePair<int, string>>();
            var redBlackTree = GetTestTree();

            using (var enumerator = redBlackTree.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    list.Add(enumerator.Current);
                }

            }
        }

        [Test]
        public void Interface1()
        {
            IEnumerable<KeyValuePair<int, string>> redBlackTree = GetTestTree();
            var list = new List<KeyValuePair<int, string>>();

            using (var enumerator = redBlackTree.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    list.Add(enumerator.Current);
                }
            }

            Assert.AreEqual(list.Count, 100);

            for (var i = 0; i < 100; i++)
            {
                Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(i, i.ToString())));
            }
        }

        [Test]
        public void Interface2()
        {
            var redBlackTree = GetTestTree();
            var list = new List<KeyValuePair<int, string>>();

            var enumerator = ((IEnumerable)redBlackTree).GetEnumerator();
            {
                while (enumerator.MoveNext())
                {
                    list.Add((KeyValuePair<int, string>)enumerator.Current);
                }
            }

            Assert.AreEqual(list.Count, 100);

            for (var i = 0; i < 100; i++)
            {
                Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(i, i.ToString())));
            }
        }

    }
}