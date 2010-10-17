using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SkipListTests
{
    [TestFixture]
    public class Remove
    {

        [Test]
        public void Simple()
        {
            var skipList = new SkipList<int, string>();

            for (var i = 0; i < 100; i++)
            {
                skipList.Add(i, i.ToString());
            }

            for (var i = 0; i < 100; i++)
            {
                if ((i % 2) == 0)
                {
                    Assert.IsTrue(skipList.Remove(i));
                }
                else
                {
                    Assert.IsTrue(skipList.Remove(new KeyValuePair<int, string>(i, "a")));
                }

                Assert.AreEqual(skipList.Count, 99 - i);
                Assert.IsFalse(skipList.ContainsKey(i));
            }
        }
        [Test]
        public void ItemNotInList1()
        {
            var skipList = new SkipList<int, string>();
            Assert.IsFalse(skipList.Remove(4));
        }

        [Test]
        public void ItemNotInList2()
        {
            var skipList = new SkipList<int, string>();
            Assert.IsFalse(skipList.Remove(new KeyValuePair<int, string>(3, "3")));
        }

    }
}