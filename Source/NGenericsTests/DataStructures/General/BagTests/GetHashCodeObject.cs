using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.BagTests
{
    [TestFixture]
    public class GetHashCodeObject : BagTest
    {

        [Test]
        public void Simple()
        {
            var dictionary = new Dictionary<Bag<string>, string>();

            for (var i = 0; i < dictionary.Count; i++)
            {
                var bag = GetTestBag();

                bag.GetHashCode();

                Assert.IsFalse(dictionary.ContainsKey(bag));

                dictionary.Add(bag, null);
            }
        }

    }
}