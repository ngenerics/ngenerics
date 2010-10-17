using System.Collections;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.GeneralTreeTests
{
    [TestFixture]
    public class GetEnumerator : GeneralTreeTest
    {

        [Test]
        public void Simple()
        {
            var generalTree = GetTestTree();
            var enumerator = generalTree.GetEnumerator();

            var itemCount = 7;

            while (enumerator.MoveNext())
            {
                itemCount--;
            }

            Assert.AreEqual(itemCount, 0);
        }

        [Test]
        public void Interface()
        {
            var generalTree = GetTestTree();
            var enumerator = ((IEnumerable)generalTree).GetEnumerator();

            var itemCount = 7;

            while (enumerator.MoveNext())
            {
                itemCount--;
            }

            Assert.AreEqual(itemCount, 0);
        }

    }
}