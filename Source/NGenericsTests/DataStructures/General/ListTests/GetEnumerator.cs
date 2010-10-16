using System.Collections;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ListTests
{
    [TestFixture]
    public class GetEnumerator
    {

        [Test]
        public void Simple()
        {
            var listBase = new ListBase<string> { "a", "b", "c" };
            var enumerator = listBase.GetEnumerator();

            var counter = 0;

            while (enumerator.MoveNext())
            {
                counter++;

            }

            Assert.AreEqual(counter, 3);
        }

        [Test]
        public void GenericInterface()
        {
            var bag = new ListBase<string> { "a", "b", "c" };
            var enumerator = bag.GetEnumerator();

            var counter = 0;

            while (enumerator.MoveNext())
            {
                counter++;

            }

            Assert.AreEqual(counter, 3);
        }

        [Test]
        public void Interface()
        {
            var listBase = (IEnumerable)new ListBase<string> { "a", "b", "c" };
            var enumerator = listBase.GetEnumerator();

            var counter = 0;

            while (enumerator.MoveNext())
            {
                counter++;
            }

            Assert.AreEqual(counter, 3);
        }

    }
}