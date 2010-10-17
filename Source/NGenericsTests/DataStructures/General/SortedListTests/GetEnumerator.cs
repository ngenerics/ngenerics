using System.Collections;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SortedListTests
{
    [TestFixture]
    public class GetEnumerator
    {

        [Test]
        public void Simple()
        {
            var sortedList = new SortedList<int>();

            for (var i = 0; i < 20; i++)
            {
                sortedList.Add(i);
            }

            var counter = 0;
            var enumerator = sortedList.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Assert.AreEqual(enumerator.Current, counter);
                counter++;
            }

            Assert.AreEqual(counter, 20);
        }

        [Test]
        public void Interface()
        {
            var sortedList = new SortedList<int>();

            for (var i = 0; i < 20; i++)
            {
                sortedList.Add(i);
            }

            var counter = 0;

            var enumerator = ((IEnumerable)sortedList).GetEnumerator();

            while (enumerator.MoveNext())
            {
                Assert.AreEqual((int)enumerator.Current, counter);
                counter++;
            }

            Assert.AreEqual(counter, 20);
        }

    }
}