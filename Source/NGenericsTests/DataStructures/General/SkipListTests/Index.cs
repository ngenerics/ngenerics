using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SkipListTests
{
    [TestFixture]
    public class Index
    {

        [Test]
        public void Set()
        {
            var skipList = new SkipList<int, string> { { 1, "1" } };

            skipList[1] = "2";

            Assert.AreEqual(skipList[1], "2");

            skipList.Add(2, "2");

            skipList[2] = "3";

            Assert.AreEqual(skipList[2], "3");
        }

        [Test]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void ExceptionInvalidItemGet1()
        {
            var skipList = new SkipList<int, string>();
            var v = skipList[10];
        }

        [Test]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void ExceptionInvalidItemGet2()
        {
            var skipList = new SkipList<int, string> { { 1, "aa" } };
            var v = skipList[2];
        }

        [Test]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void ExceptionInvalidItemset1()
        {
            var skipList = new SkipList<int, string>();
            skipList[10] = "2";
        }

        [Test]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void ExceptionInvalidItemset2()
        {
            var skipList = new SkipList<int, string> { { 1, "aa" } };
            skipList[10] = "2";
        }

    }
}