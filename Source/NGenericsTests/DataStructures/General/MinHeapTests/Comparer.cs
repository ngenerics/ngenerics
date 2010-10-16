using System;
using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.MinHeapTests
{
    [TestFixture]
    public class Comparer : MinHeapTest
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullComparer1()
        {
            new Heap<int>(HeapType.Maximum, (IComparer<int>) null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullComparer2()
        {
            new Heap<int>(HeapType.Maximum, 50, (IComparer<int>) null);
        }
    }
}