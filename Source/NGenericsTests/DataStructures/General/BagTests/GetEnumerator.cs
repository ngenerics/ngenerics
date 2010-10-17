using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.BagTests
{
    [TestFixture]
    public class GetEnumerator : BagTest
    {

        [Test]
        public void Simple()
        {
            var bag = GetTestBag();
            var enumerator = bag.GetEnumerator();

            var counter = 0;

            while (enumerator.MoveNext())
            {
                counter++;

            }

            Assert.AreEqual(counter, 20);
        }

        [Test]
        public void GenericInterface()
        {
            IEnumerable<string> bag = GetTestBag();
            var enumerator = bag.GetEnumerator();

            var counter = 0;

            while (enumerator.MoveNext())
            {
                counter++;

            }

            Assert.AreEqual(counter, 20);
        }

        [Test]
        public void Interface()
        {
            IEnumerable bag = GetTestBag();
            var enumerator = bag.GetEnumerator();

            var counter = 0;

            while (enumerator.MoveNext())
            {
                counter++;
            }

            Assert.AreEqual(counter, 20);
        }

    }
}