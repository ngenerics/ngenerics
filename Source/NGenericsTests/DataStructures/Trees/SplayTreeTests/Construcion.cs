using System;
using System.Collections.Generic;
using NGenerics.Comparers;
using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.SplayTreeTests
{
    [TestFixture]
    public class Construcion : SplayTreeTest
    {

        [Test]
        public void Simple()
        {
            var splayTree = new SplayTree<int, string>();

            Assert.AreEqual(splayTree.Count, 0);
            Assert.IsTrue(splayTree.Comparer is KeyValuePairComparer<int, string>);

            splayTree = new SplayTree<int, string>(new ReverseComparer<int>(Comparer<int>.Default));

            Assert.AreEqual(splayTree.Count, 0);
            Assert.IsTrue(splayTree.Comparer.GetType().IsAssignableFrom(typeof(KeyValuePairComparer<int, string>)));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullComparer()
        {
            new SplayTree<int, string>((IComparer<int>)null);
        }

    }
}