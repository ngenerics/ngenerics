using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SkipListTests
{
    [TestFixture]
    public class Keys
    {

        [Test]
        public void Simple()
        {
            var skipList = new SkipList<int, string>();

            for (var i = 0; i < 100; i++)
            {
                skipList.Add(i, i.ToString());
            }

            var list = new List<int>();
            list.AddRange(skipList.Keys);

            Assert.AreEqual(list.Count, 100);

            for (var i = 0; i < 100; i++)
            {
                Assert.IsTrue(list.Contains(i));
            }
        }

    }
}