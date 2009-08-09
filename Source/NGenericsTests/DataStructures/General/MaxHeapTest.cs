/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html. 
*/

using System;
using System.Collections;
using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NGenerics.Patterns.Visitor;
using NGenerics.Tests.TestObjects;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General
{
	[TestFixture]
	public class MaxHeapTest
    {
        #region Tests

        [TestFixture]
        public class Accept
        {
            [Test]
			public void Simple()
            {
                var visitor = new TrackingVisitor<int>();
                var heap = GetTestHeap();

                heap.AcceptVisitor(visitor);

                Assert.AreEqual(visitor.TrackingList.Count, heap.Count);
                Assert.IsTrue(visitor.TrackingList.Contains(5));
                Assert.IsTrue(visitor.TrackingList.Contains(4));
                Assert.IsTrue(visitor.TrackingList.Contains(99));
                Assert.IsTrue(visitor.TrackingList.Contains(12));
                Assert.IsTrue(visitor.TrackingList.Contains(5));
            }

            [Test]
            public void Stopping()
            {
                var visitor = new CompletedTrackingVisitor<int>();
                var heap = GetTestHeap();
                heap.AcceptVisitor(visitor);
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullVisitor()
            {
                var heap = GetTestHeap();
                heap.AcceptVisitor(null);
            }
        }

        [TestFixture]
        public class Add
        {
            [Test]
			public void Simple()
            {
                var heap = new Heap<int>(HeapType.Maximum);
                heap.Add(5);

                Assert.AreEqual(heap.Count, 1);
                Assert.IsFalse(heap.IsEmpty);
                Assert.AreEqual(heap.Root, 5);

                heap.Add(2);
                Assert.AreEqual(heap.Count, 2);
                Assert.IsFalse(heap.IsEmpty);
                Assert.AreEqual(heap.Root, 5);

                heap.Add(3);
                Assert.AreEqual(heap.Count, 3);
                Assert.IsFalse(heap.IsEmpty);
                Assert.AreEqual(heap.Root, 5);

                Assert.AreEqual(heap.RemoveRoot(), 5);

                heap.Add(1);
                Assert.AreEqual(heap.Count, 3);
                Assert.IsFalse(heap.IsEmpty);
                Assert.AreEqual(heap.Root, 3);
            }
        }

        [TestFixture]
        public class Clear
        {
            [Test]
			public void Simple()
            {
                var heap = new Heap<int>(HeapType.Maximum);

                for (var i = 1; i <= 20; i++)
                {
                    heap.Add(i);
                    Assert.AreEqual(heap.Root, i);
                }

                Assert.IsFalse(heap.IsEmpty);
                Assert.AreEqual(heap.Count, 20);

                heap.Clear();

                Assert.AreEqual(heap.Count, 0);
                Assert.IsTrue(heap.IsEmpty);
            }
        }

        [TestFixture]
        public class Contains
        {
            [Test]
			public void Simple()
            {
                var heap = GetTestHeap();

                Assert.IsTrue(heap.Contains(5));
                Assert.IsTrue(heap.Contains(4));
                Assert.IsTrue(heap.Contains(99));
                Assert.IsTrue(heap.Contains(12));
                Assert.IsTrue(heap.Contains(5));
                Assert.IsFalse(heap.Contains(3));
            }
        }

        [TestFixture]
        public class Construction
        {
            [Test]
			public void Simple()
            {
                var heap = new Heap<int>(HeapType.Maximum);

                Assert.AreEqual(heap.Type, HeapType.Maximum);
                Assert.AreEqual(heap.Count, 0);
                Assert.IsTrue(heap.IsEmpty);

                heap = new Heap<int>(HeapType.Maximum, Comparer<int>.Default);

                Assert.AreEqual(heap.Type, HeapType.Maximum);
                Assert.AreEqual(heap.Count, 0);
                Assert.IsTrue(heap.IsEmpty);

                heap = new Heap<int>(HeapType.Maximum, 50);

                Assert.AreEqual(heap.Type, HeapType.Maximum);
                Assert.AreEqual(heap.Count, 0);
                Assert.IsTrue(heap.IsEmpty);

                heap = new Heap<int>(HeapType.Maximum, 50, Comparer<int>.Default);

                Assert.AreEqual(heap.Type, HeapType.Maximum);
                Assert.AreEqual(heap.Count, 0);
                Assert.IsTrue(heap.IsEmpty);
            }

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

        [TestFixture]
        public class CopyTo
        {
            [Test]
			public void Simple()
            {
                var heap = GetTestHeap();
                var array = new int[heap.Count];

                heap.CopyTo(array, 0);

                var list = new List<int>(array);
                Assert.AreEqual(list.Count, heap.Count);
                Assert.IsTrue(list.Contains(5));
                Assert.IsTrue(list.Contains(4));
                Assert.IsTrue(list.Contains(99));
                Assert.IsTrue(list.Contains(12));
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullArray()
            {
                var heap = GetTestHeap();
                heap.CopyTo(null, 0);
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void ExceoptionInvalid1()
            {
                var heap = GetTestHeap();
                var array = new int[heap.Count - 1];
                heap.CopyTo(array, 0);
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void ExceptionInvalid2()
            {
                var heap = GetTestHeap();
                var array = new int[heap.Count];
                heap.CopyTo(array, 1);
            }
        }

        [TestFixture]
        public class GetEnumerator
        {
            [Test]
            public void Interface()
            {
                var heap = new Heap<int>(HeapType.Maximum);

                const int maximum = 100;

                for (var i = 0; i < maximum; i++)
                {
                    heap.Add(i);
                }

                var isPresent = new bool[maximum];

                for (var i = 0; i < isPresent.Length; i++)
                {
                    isPresent[i] = false;
                }

                var enumerator = ((IEnumerable) heap).GetEnumerator();

                Assert.IsTrue(enumerator.MoveNext());

                do
                {
                    isPresent[(int) enumerator.Current] = true;
                }
                while (enumerator.MoveNext());

                for (var i = 0; i < maximum; i++)
                {
                    Assert.IsTrue(isPresent[i]);
                }
            }

            [Test]
			public void Simple()
            {
                var heap = new Heap<int>(HeapType.Maximum);

                const int maximum = 100;

                for (var i = 0; i < maximum; i++)
                {
                    heap.Add(i);
                }

                var isPresent = new bool[maximum];

                for (var i = 0; i < isPresent.Length; i++)
                {
                    isPresent[i] = false;
                }

                var enumerator = heap.GetEnumerator();

                Assert.IsTrue(enumerator.MoveNext());

                do
                {
                    isPresent[enumerator.Current] = true;
                }
                while (enumerator.MoveNext());

                for (var i = 0; i < maximum; i++)
                {
                    Assert.IsTrue(isPresent[i]);
                }
            }
        }


        [TestFixture]
        public class IsReadOnly
        {
            [Test]
			public void Simple()
            {
                var heap = new Heap<int>(HeapType.Maximum);
                Assert.IsFalse(heap.IsReadOnly);

                heap = GetTestHeap();
                Assert.IsFalse(heap.IsReadOnly);
            }
        }

        [TestFixture]
        public class Remove
        {
            [Test]
            [ExpectedException(typeof(NotSupportedException))]
            public void ExceptionInterface()
            {
                ICollection<int> heap = GetTestHeap();
                heap.Remove(4);
            }
        }

        [TestFixture]
        public class RemoveRoot
        {
            [Test]
			public void Simple()
            {
                var heap = new Heap<int>(HeapType.Maximum) {5};
                Assert.AreEqual(heap.Root, 5);
                Assert.AreEqual(heap.Count, 1);
                Assert.IsFalse(heap.IsEmpty);

                Assert.AreEqual(heap.RemoveRoot(), 5);
                Assert.AreEqual(heap.Count, 0);
                Assert.IsTrue(heap.IsEmpty);
            }

            [Test]
            public void Stress()
            {
                var heap = new Heap<int>(HeapType.Maximum);

                const int maximum = 5000;

                for (var i = 1; i <= maximum; i++)
                {
                    heap.Add(i);

                    Assert.AreEqual(heap.Root, i);
                }

                for (var i = maximum; i > 0; i--)
                {
                    Assert.AreEqual(heap.RemoveRoot(), i);
                }
            }

            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionEmpty()
            {
                var heap = new Heap<int>(HeapType.Maximum);

                Assert.AreEqual(heap.Count, 0);

                heap.RemoveRoot();
            }
        }

        [TestFixture]
        public class Root
        {
            [Test]
			public void Simple()
            {
                var heap = new Heap<int>(HeapType.Maximum) {5};
                Assert.AreEqual(heap.Root, 5);
                Assert.AreEqual(heap.Count, 1);
            }

            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionInvalid()
            {
                var heap = new Heap<int>(HeapType.Maximum);
                var i = heap.Root;
            }
        }

        [TestFixture]
        public class Serializable
        {
            [Test]
			public void Simple()
            {
                var heap = GetTestHeap();
                var newHeap = SerializeUtil.BinarySerializeDeserialize(heap);

                Assert.AreNotSame(heap, newHeap);
                Assert.AreEqual(heap.Count, newHeap.Count);

                while (heap.Count > 0)
                {
                    Assert.AreEqual(heap.RemoveRoot(), newHeap.RemoveRoot());
                }
            }

            [Test]
            public void NonIComparable()
            {
                var heap = new Heap<NonComparableTClass>(HeapType.Maximum)
                                                  {
                                                      new NonComparableTClass(5),
                                                      new NonComparableTClass(4),
                                                      new NonComparableTClass(99),
                                                      new NonComparableTClass(12),
                                                      new NonComparableTClass(5)
                                                  };

                var newHeap = SerializeUtil.BinarySerializeDeserialize(heap);

                Assert.AreNotSame(heap, newHeap);
                Assert.AreEqual(heap.Count, newHeap.Count);

                while (heap.Count > 0)
                {
                    Assert.AreEqual(heap.RemoveRoot().Number, newHeap.RemoveRoot().Number);
                }
            }
        }
        
        #endregion

        #region Private Members

        private static Heap<int> GetTestHeap()
		{
			var heap = new Heap<int>(HeapType.Maximum) {5, 4, 99, 12, 5};

            return heap;
        }

        #endregion
    }
}
