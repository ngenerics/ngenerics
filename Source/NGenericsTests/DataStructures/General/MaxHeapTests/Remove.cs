using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.MaxHeapTests
{
    [TestFixture]
    public class Remove : MaxHeapTest
    {
        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void ExceptionInterface()
        {
            ICollection<int> heap = GetTestHeap();
            heap.Remove(4);
        }
    }
}