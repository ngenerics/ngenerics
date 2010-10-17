using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SkipListTests
{
    [TestFixture]
    public class CurrentListLevel
    {

        [Test]
        public void Simple()
        {
            var skipList = new SkipList<int, string>();
            Assert.AreEqual(skipList.CurrentListLevel, 0);

            for (var i = 0; i < 100; i++)
            {
                skipList.Add(new KeyValuePair<int, string>(i, i.ToString()));
            }

            Assert.Greater(skipList.CurrentListLevel, 0);
        }

    }
}