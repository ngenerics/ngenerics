using System;
using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.GeneralTreeTests
{
    [TestFixture]
    public class RemoveAt : GeneralTreeTest
    {

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExcepionInvalidIndex1()
        {
            var generalTree = new GeneralTree<int>(3);
            generalTree.RemoveAt(1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionInvalidIndex2()
        {
            var generalTree = GetTestTree();
            generalTree.RemoveAt(5);
        }

    }
}