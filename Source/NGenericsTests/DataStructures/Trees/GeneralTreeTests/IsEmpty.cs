using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.GeneralTreeTests
{
    [TestFixture]
    public class IsEmpty : GeneralTreeTest
    {

        [Test]
        public void Simple()
        {
            var generalTree = GetTestTree();
            Assert.IsFalse(generalTree.IsEmpty);

            generalTree.Clear();
            Assert.IsTrue(generalTree.IsEmpty);
        }

    }
}