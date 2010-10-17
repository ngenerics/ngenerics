using System;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.BagTests
{
    [TestFixture]
    public class Add : BagTest
    {

        [Test]
        public void Simple()
        {
            var bag = new Bag<string>
                          {
                              "aa"
                          };

            Assert.AreEqual(bag.Count, 1);
            Assert.IsTrue(bag.Contains("aa"));
            Assert.AreEqual(bag["aa"], 1);

            bag.Add("bb");
            Assert.AreEqual(bag.Count, 2);
            Assert.IsTrue(bag.Contains("bb"));
            Assert.AreEqual(bag["bb"], 1);

            bag.Add("aa");
            Assert.AreEqual(bag.Count, 3);
            Assert.IsTrue(bag.Contains("aa"));
            Assert.AreEqual(bag["aa"], 2);

            bag.Add("cc", 3);
            Assert.AreEqual(bag.Count, 6);
            Assert.IsTrue(bag.Contains("cc"));
            Assert.AreEqual(bag["cc"], 3);

            bag.Add("cc", 2);

            Assert.AreEqual(bag.Count, 8);
            Assert.IsTrue(bag.Contains("cc"));
            Assert.AreEqual(bag["cc"], 5);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionZeroAmount()
        {
            new Bag<string>
                {
                    {"aa", 0}
                };
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionNegativeAmount()
        {
            new Bag<string>
                {
                    {
                        "aa", -1
                        }
                };
        }

    }
}